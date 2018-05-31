using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json.Linq;
using Tools;

namespace ServerApp
{
    class HttpServer
    {
        private int _port;

        private Thread _serverThread;

        private HttpListener _listener;

        private static AutoResetEvent _listenForNextRequest = new AutoResetEvent(false);

        private Logger _logger;

        public HttpServer()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 0);
            tcpListener.Start();
            _port = ((IPEndPoint)tcpListener.LocalEndpoint).Port;
            tcpListener.Stop();
            if (!Directory.Exists("logs"))
                Directory.CreateDirectory("logs");
            _logger = new Logger("logs", "Server");
            this.Initialize();
        }

        private void Initialize()
        {
            _serverThread = new Thread(this.Listen);
            _serverThread.Start();
            _logger.Log($"{Environment.NewLine}*****{Environment.NewLine}Server started at port {_port}");
        }

        private void Listen()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://*:" + _port.ToString() + "/");
            _listener.Start();
            while (true)
            {
                try
                {
                    _listener.BeginGetContext(this.Process, _listener);
                    _listenForNextRequest.WaitOne();
                }
                catch (Exception)
                {

                }
            }
        }

        private void Process(IAsyncResult ar)
        {
            HttpListenerContext context = null;
            try
            {
                var hl = ar.AsyncState as HttpListener;
                context = hl.EndGetContext(ar);

                Stream output = this.HandleContext(context);

                context.Response.ContentLength64 = output.Length;

                byte[] buffer = new byte[1024 * 16];
                int nbytes;
                while ((nbytes = output.Read(buffer, 0, buffer.Length)) > 0)
                    context.Response.OutputStream.Write(buffer, 0, nbytes);
                output.Close();

                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.OutputStream.Flush();
                _logger.Log("Request was successfully processed");
            }
            catch (Exception ex)
            {
                _logger.Log($"Exception: {ex.Message}");
                int code = ex is ExceptionWithCode ?
                   (ex as ExceptionWithCode).Code :
                   (int)HttpStatusCode.InternalServerError;
                if(context != null)
                {
                    context.Response.StatusCode = code;
                }
            }
            finally
            {
                if(context != null)
                {
                    context.Response.OutputStream.Close();
                }
                _listenForNextRequest.Set();
            }
        }

        private Stream HandleContext(HttpListenerContext hl)
        {
            hl.Response.ContentType = "text/html";
            string routeNameOrigin = hl.Request.Url.AbsolutePath.Substring(1);
            _logger.Log($"HandleContext: {routeNameOrigin}");
            string routeNameLower = routeNameOrigin.ToLowerInvariant();
            string errorMessage = string.Empty;
            string apiKey = hl.Request.QueryString["apiKey"];
            if (hl.Request.HttpMethod == "POST")
            {
                if (!string.IsNullOrEmpty(apiKey))
                {
                    switch (routeNameLower)
                    {
                        // Этот роут создает папку с apiKey и файлом config.xml. Если они есть - перезаписывает.
                        case KnownRoutes.Config:
                            JObject requestBody = JObject.Parse(new StreamReader(hl.Request.InputStream).ReadToEnd());
                            if (requestBody["content"] != null)
                            {
                                string content = requestBody["content"].ToString();
                                if (!Directory.Exists(apiKey))
                                {
                                    Directory.CreateDirectory(apiKey);
                                }
                                File.WriteAllText($"/{apiKey}/config.xml", content);
                                return new MemoryStream(Encoding.UTF8.GetBytes("OK"));
                            }
                            else
                            {
                                errorMessage = GenerateErrorMessage("Content");
                            }
                            break;
                        // Этот роут закачивает файлы в нужную папку apiKey. Если файл существует, он будет перезаписан.
                        case KnownRoutes.Upload:
                            string fileName = hl.Request.QueryString["fileName"];
                            if (!string.IsNullOrEmpty(fileName))
                            {
                                if (!Directory.Exists(apiKey))
                                {
                                    errorMessage = GenerateErrorMessage("ApiKey", "DefinedApiKeys", apiKey);
                                }
                                else
                                {
                                    using (FileStream fs = File.Create($"{apiKey}/{fileName}"))
                                    {
                                        hl.Request.InputStream.CopyTo(fs);
                                    }
                                    return new MemoryStream(Encoding.UTF8.GetBytes("OK"));
                                }
                            }
                            else
                            {
                                errorMessage = GenerateErrorMessage("FileName");
                            }
                            break;
                        default:
                            errorMessage = GenerateErrorMessage("RouteName", "KnownRoutes", routeNameLower);
                            break;
                    }
                }
                else
                {
                    errorMessage = GenerateErrorMessage("ApiKey");
                }
            }
            else
            {
                errorMessage = GenerateErrorMessage("HttpMethod", "POST", hl.Request.HttpMethod);
            }
            throw new ExceptionWithCode((int)HttpStatusCode.BadRequest, errorMessage);
        }

        private static string GenerateErrorMessage(string arg, string expected = null, string actual = null)
        {
            return $"Error! Argument {arg} Expected: {expected ?? "not null"} but was: {actual ?? "null"}";
        }

        ~HttpServer()
        {
            _serverThread.Abort();
            _listener.Stop();
            _logger.Log($"Server disposed{Environment.NewLine}*****");
        }
    }

    class ExceptionWithCode : Exception
    {
        public int Code { get; private set; }
        public ExceptionWithCode(int code) : base()
        {
            Code = code;
        }

        public ExceptionWithCode(int code, string message) : base(message)
        {
            Code = code;
        }
    }

    static class KnownRoutes
    {
        public const string Config = "config";

        public const string Upload = "upload";
    }
}

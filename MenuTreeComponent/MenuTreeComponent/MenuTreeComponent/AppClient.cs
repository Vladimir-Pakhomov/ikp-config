using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MenuTreeComponent
{
    public static class AppClient
    {
        private static readonly HttpClient Client = new HttpClient() { Timeout = TimeSpan.MaxValue };

        public static async Task<bool> Ping(string address)
        {
            try {
                var response = await Client.GetAsync($"{address}/ping");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static async void UploadFile(string address, string apiKey, string publicationName, Command executionContext)
        {
            using (var content = new MultipartFormDataContent())
            {
                try
                {
                    executionContext.ExecutionStart();
                    using (FileStream fs = File.Open(executionContext.FileName, FileMode.Open, FileAccess.Read))
                    {
                        content.Add(new StreamContent(fs));
                    }
                    using (var response = await Client.PostAsync($"{address}/upload?apiKey={apiKey}&publicationName={publicationName}&fileName={executionContext.FileName}", content))
                    {
                        executionContext.ExecutionEnd(response.IsSuccessStatusCode ? PStatus.Success : PStatus.Failed);
                    }
                }
                catch (Exception)
                {
                    executionContext.ExecutionEnd(PStatus.Failed);
                }
            }
        }
    }
}

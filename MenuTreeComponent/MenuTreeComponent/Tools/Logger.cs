using System;
using System.IO;
using System.Threading;

namespace Tools
{
    public class Logger
    {
        private string _logPath;
        private string _logName;

        private string filePath
        {
            get
            {
                return Path.Combine(_logPath, $"{DateTime.Now.ToString("yyyy-MM-dd")}_{_logName}.log");
            }
        }

        public Logger(string path, string logName)
        {
            _logPath = path;
            if (!Directory.Exists(_logPath))
                Directory.CreateDirectory(_logPath);
            _logName = logName;
        }

        public void Log(string message)
        {
            if (!File.Exists(filePath))
            {
                using (FileStream fs = File.Create(filePath)) { }
            }
            StreamWriter writer = new StreamWriter(filePath, true);
            writer.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} THRD={Thread.CurrentThread.ManagedThreadId} :: {message}");
            writer.Close();
        }
    }
}

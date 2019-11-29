using System;
using System.IO;

namespace ScDataTransfer.Utils.Logging
{
    public class FIleLogger : BaseLogger
    {
        private readonly string _outputDir;
        private readonly string _filePath;
        private readonly object _lockObj = new object();
        public FIleLogger(string outputDir)
        {
            _outputDir = outputDir;
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _outputDir, $"log_{DateTime.Now.ToString(DefaultDateTimeFormat)}.txt");
        }

        public override void SetMessage(string msg, string dtFormat)
        {
            lock (_lockObj)
            {
                using (var log = new StreamWriter(_filePath, true))
                {
                    log.WriteLine($"{DateTime.Now.ToString(dtFormat)} {msg}");
                }
            }
        }
    }
}

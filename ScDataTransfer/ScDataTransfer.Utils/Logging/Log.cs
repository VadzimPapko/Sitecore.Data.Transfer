using ScDataTransfer.Utils.Interfaces.Logging;
using System;
using System.Collections.Generic;

namespace ScDataTransfer.Utils.Logging
{
    public class Log 
    {
        private static List<ILogger> _loggers;

        private static List<ILogger> Loggers =>
            _loggers ?? (_loggers = new List<ILogger>()
            {
                new FIleLogger(AppDomain.CurrentDomain.BaseDirectory),
                new ConsoleLogger()
            });

        public static void SetMessage(Exception ex)
        {
            foreach (var l in Loggers)
            {
                l.SetMessage(ex);
            }
        }

        public static void SetMessage(string msg)
        {
            foreach (var l in Loggers)
            {
                l.SetMessage(msg);
            }
        }

        public static void SetMessage(string msg, string dtFormat)
        {
            foreach (var l in Loggers)
            {
                l.SetMessage(msg, dtFormat);
            }
        }
    }

}

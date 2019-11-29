using System;

namespace ScDataTransfer.Utils.Logging
{
    public class ConsoleLogger : BaseLogger
    {
        public override void SetMessage(string msg, string dtFormat)
        {
            Console.WriteLine($"{DateTime.Now.ToString(dtFormat)} {msg}");
        }
    }
}

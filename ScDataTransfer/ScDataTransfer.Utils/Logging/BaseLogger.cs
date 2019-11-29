using ScDataTransfer.Utils.Interfaces.Logging;
using System;

namespace ScDataTransfer.Utils.Logging
{
    public abstract class BaseLogger : ILogger
    {
        public string DefaultDateTimeFormat => "dd-MMM HH-mm-ss.FFF";

        public virtual void SetMessage(Exception ex)
        {
            if (ex == null) return;
            SetMessage(ex.Message);
            SetMessage(ex.StackTrace);
            if (ex.InnerException == null) return;
            SetMessage("----inner exception-----");
            SetMessage(ex.InnerException);
        }

        public virtual void SetMessage(string msg)
        {
            SetMessage(msg, DefaultDateTimeFormat);
        }

        public abstract void SetMessage(string msg, string dtFormat);
    }
}

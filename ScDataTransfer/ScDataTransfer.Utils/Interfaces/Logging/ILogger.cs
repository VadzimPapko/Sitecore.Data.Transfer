using System;

namespace ScDataTransfer.Utils.Interfaces.Logging
{
    public interface ILogger
    {
        void SetMessage(string msg);
        void SetMessage(string msg, string dtFormat);
        void SetMessage(Exception ex);
    }
}
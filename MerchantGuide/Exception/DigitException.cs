using System;

namespace MerchantGuide.Exception
{
    /// <summary>
    ///     数字位异常
    /// </summary>
    public class DigitException : ApplicationException
    {
        public DigitException()
        {
        }

        public DigitException(string msg)
            : base(msg)
        {
        }

        public DigitException(string msg, System.Exception innerException)
            : base(msg, innerException)
        {
        }
    }
}
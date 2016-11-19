using System;

namespace MerchantGuide.Exception
{
    /// <summary>
    ///     数字异常
    /// </summary>
    public class NumeralException : ApplicationException
    {
        public NumeralException()
        {
        }

        public NumeralException(string msg)
            : base(msg)
        {
        }

        public NumeralException(string msg, System.Exception innerException)
            : base(msg, innerException)
        {
        }
    }
}
using System;

namespace MerchantGuide.Exception
{
    /// <summary>
    ///     数字位工厂异常
    /// </summary>
    public class DigitFactoryException : ApplicationException
    {
        public DigitFactoryException()
        {
        }

        public DigitFactoryException(string msg)
            : base(msg)
        {
        }

        public DigitFactoryException(string msg, System.Exception innerException)
            : base(msg, innerException)
        {
        }
    }
}
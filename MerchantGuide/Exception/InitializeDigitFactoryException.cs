using System;

namespace MerchantGuide.Exception
{
    /// <summary>
    ///     初始化数字位工厂异常
    /// </summary>
    public class InitializeDigitFactoryException : ApplicationException
    {
        public InitializeDigitFactoryException()
        {
        }

        public InitializeDigitFactoryException(string msg)
            : base(msg)
        {
        }

        public InitializeDigitFactoryException(string msg, System.Exception innerException)
            : base(msg, innerException)
        {
        }
    }
}
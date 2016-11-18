using System;

namespace MerchantGuide.Exception
{
    /// <summary>
    ///     获取数字位异常
    /// </summary>
    public class GetDigitException : ApplicationException
    {
        public GetDigitException()
        {
        }

        public GetDigitException(string msg)
            : base(msg)
        {
        }

        public GetDigitException(string msg, System.Exception innerException)
            : base(msg, innerException)
        {
        }
    }
}
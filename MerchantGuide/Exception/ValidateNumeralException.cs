using System;

namespace MerchantGuide.Exception
{
    /// <summary>
    ///     验证数字异常
    /// </summary>
    public class ValidateNumeralException : ApplicationException
    {
        public ValidateNumeralException()
        {
        }

        public ValidateNumeralException(string msg)
            : base(msg)
        {
        }

        public ValidateNumeralException(string msg, System.Exception innerException)
            : base(msg, innerException)
        {
        }
    }
}
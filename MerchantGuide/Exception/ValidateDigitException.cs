using System;

namespace MerchantGuide.Exception
{
    /// <summary>
    ///     验证数字位异常
    /// </summary>
    public class ValidateDigitException : ApplicationException
    {
        public ValidateDigitException()
        {
        }

        public ValidateDigitException(string msg)
            : base(msg)
        {
        }

        public ValidateDigitException(string msg, System.Exception innerException)
            : base(msg, innerException)
        {
        }
    }
}
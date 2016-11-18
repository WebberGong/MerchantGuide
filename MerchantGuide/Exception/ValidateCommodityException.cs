using System;

namespace MerchantGuide.Exception
{
    /// <summary>
    ///     验证商品异常
    /// </summary>
    public class ValidateCommodityException : ApplicationException
    {
        public ValidateCommodityException()
        {
        }

        public ValidateCommodityException(string msg)
            : base(msg)
        {
        }

        public ValidateCommodityException(string msg, System.Exception innerException)
            : base(msg, innerException)
        {
        }
    }
}
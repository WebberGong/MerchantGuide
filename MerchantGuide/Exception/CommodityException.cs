using System;

namespace MerchantGuide.Exception
{
    /// <summary>
    ///     商品异常
    /// </summary>
    public class CommodityException : ApplicationException
    {
        public CommodityException()
        {
        }

        public CommodityException(string msg)
            : base(msg)
        {
        }

        public CommodityException(string msg, System.Exception innerException)
            : base(msg, innerException)
        {
        }
    }
}
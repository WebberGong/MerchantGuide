using System;

namespace MerchantGuide.Exception
{
    /// <summary>
    ///     输入行解析异常
    /// </summary>
    public class ParseInputLineException : ApplicationException
    {
        private const string Msg = "I have no idea what you are talking about";

        public ParseInputLineException()
            : base(Msg)
        {
        }

        public ParseInputLineException(System.Exception innerException)
            : base(Msg, innerException)
        {
        }
    }
}
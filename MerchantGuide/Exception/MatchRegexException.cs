using System;

namespace MerchantGuide.Exception
{
    /// <summary>
    ///     匹配正则表达式异常
    /// </summary>
    public class MatchRegexException : ApplicationException
    {
        private const string Msg = "Match regex failed";

        public MatchRegexException()
            : base(Msg)
        {
        }

        public MatchRegexException(System.Exception innerException)
            : base(Msg, innerException)
        {
        }
    }
}
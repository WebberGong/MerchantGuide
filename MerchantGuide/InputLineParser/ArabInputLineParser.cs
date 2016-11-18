using System;
using System.Linq;
using System.Text.RegularExpressions;
using MerchantGuide.Commodity;
using MerchantGuide.Exception;
using MerchantGuide.InputLine;
using MerchantGuide.Numeral;
using MerchantGuide.Transaction;

namespace MerchantGuide.InputLineParser
{
    /// <summary>
    ///     阿拉伯输入行解析器
    /// </summary>
    public class ArabInputLineParser : InputParser<ArabDigit>
    {
        private static ArabInputLineParser _instance;
        private static readonly object Locker = new object();

        public override Regex DigitConditionRegex
        {
            get
            {
                var symbolTextRegex = string.Empty;
                var symbolTexts = Enum.GetNames(typeof (ArabSymbol));
                symbolTextRegex = symbolTexts.Aggregate(symbolTextRegex,
                    (current, symbolText) => current + symbolText + "|");
                if (symbolTextRegex.Length > 0)
                {
                    symbolTextRegex = symbolTextRegex.Substring(0, symbolTextRegex.Length - 1);
                }
                var digitConditionRegex = new Regex("^\\s*([A-Za-z]+)\\s+is\\s+(" + symbolTextRegex + ")\\s*$");
                return digitConditionRegex;
            }
        }

        public override Regex CommodityConditionRegex
        {
            get
            {
                var commodityConditionRegex = new Regex("^\\s*([A-Za-z]+\\s+)+\\s*is\\s+(\\d+)\\s+Credits\\s*$");
                return commodityConditionRegex;
            }
        }

        public override Regex NumeralQuestionRegex
        {
            get
            {
                var numeralQuestionRegex = new Regex("^\\s*how\\s+much\\s+is(\\s+[A-Za-z]+)+\\s*\\?$");
                return numeralQuestionRegex;
            }
        }

        public override Regex TransactionQuestionRegex
        {
            get
            {
                var transactionQuestionRegex = new Regex("^\\s*how\\s+many\\s+Credits\\s+is(\\s+[A-Za-z]+)+\\s*\\?$");
                return transactionQuestionRegex;
            }
        }

        public static ArabInputLineParser Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new ArabInputLineParser();
                        }
                    }
                }
                return _instance;
            }
        }

        protected override DigitCondition<ArabDigit> ParseToDigitCondition(string content, GroupCollection groups)
        {
            if (groups.Count == 3)
            {
                return new DigitCondition<ArabDigit>(content,
                    Enum.Parse(typeof (ArabSymbol), groups[2].Value.Trim()).ToString(),
                    groups[1].Value.Trim(), ArabDigitFactory.Instance);
            }
            throw new MatchRegexException();
        }

        protected override CommodityCondition ParseToCommodityCondition(string content, GroupCollection groups)
        {
            if (groups.Count == 3 && groups[1].Captures.Count > 0)
            {
                var commodityName = string.Empty;
                Numeral<ArabDigit> numeral = new ArabNumeral();
                for (var i = 0; i < groups[1].Captures.Count; i++)
                {
                    if (i < groups[1].Captures.Count - 1)
                    {
                        numeral.AddDigit(groups[1].Captures[i].Value.Trim());
                    }
                    else
                    {
                        commodityName = groups[1].Captures[i].Value.Trim();
                    }
                }
                return new CommodityCondition(content, commodityName, numeral.GetValue(), decimal.Parse(groups[2].Value));
            }
            throw new MatchRegexException();
        }

        protected override NumeralQuestion<ArabDigit> ParseToNumeralQuestion(string content, GroupCollection groups)
        {
            if (groups.Count == 2 && groups[1].Captures.Count > 0)
            {
                Numeral<ArabDigit> numeral = new ArabNumeral();
                foreach (Capture capture in groups[1].Captures)
                {
                    numeral.AddDigit(capture.Value.Trim());
                }
                return new NumeralQuestion<ArabDigit>(content, numeral);
            }
            throw new MatchRegexException();
        }

        protected override TransactionQuestion<ArabDigit> ParseToTransactionQuestion(string content,
            GroupCollection groups)
        {
            if (groups.Count == 2 && groups[1].Captures.Count > 0)
            {
                var commodityName = string.Empty;
                Numeral<ArabDigit> numeral = new ArabNumeral();
                for (var i = 0; i < groups[1].Captures.Count; i++)
                {
                    if (i < groups[1].Captures.Count - 1)
                    {
                        numeral.AddDigit(groups[1].Captures[i].Value.Trim());
                    }
                    else
                    {
                        commodityName = groups[1].Captures[i].Value.Trim();
                    }
                }
                var transaction = new Transaction<ArabDigit>(CommodityFactory.Instance.GetCommodity(commodityName),
                    numeral);
                return new TransactionQuestion<ArabDigit>(content, transaction);
            }
            throw new MatchRegexException();
        }
    }
}
using System;
using System.Linq;
using System.Text.RegularExpressions;
using MerchantGuide.Commodity;
using MerchantGuide.Digit;
using MerchantGuide.Exception;
using MerchantGuide.InputLine;
using MerchantGuide.Numeral;
using MerchantGuide.Transaction;

namespace MerchantGuide.InputLineParser
{
    /// <summary>
    ///     银河系输入行解析器
    /// </summary>
    public class GalaxyInputLineParser : InputParser<GalaxyDigit>
    {
        private static GalaxyInputLineParser _instance;
        private static readonly object Locker = new object();

        public override Regex DigitConditionRegex
        {
            get
            {
                var symbolTextRegex = string.Empty;
                var symbolTexts = Enum.GetNames(typeof (GalaxySymbol));
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
                var commodityConditionRegex = new Regex("^\\s*([A-Za-z]+\\s+){2,}\\s*is\\s+(\\d+)\\s+Credits\\s*$");
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

        public static GalaxyInputLineParser Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new GalaxyInputLineParser();
                        }
                    }
                }
                return _instance;
            }
        }

        protected override DigitCondition<GalaxyDigit> ParseToDigitCondition(string content, GroupCollection groups)
        {
            if (groups.Count == 3)
            {
                return new DigitCondition<GalaxyDigit>(content,
                    Enum.Parse(typeof (GalaxySymbol), groups[2].Value.Trim()).ToString(),
                    groups[1].Value.Trim(), GalaxyDigitFactory.Instance);
            }
            throw new MatchRegexException();
        }

        protected override CommodityCondition ParseToCommodityCondition(string content, GroupCollection groups)
        {
            if (groups.Count == 3 && groups[1].Captures.Count > 0)
            {
                var commodityName = string.Empty;
                Numeral<GalaxyDigit> numeral = new GalaxyNumeral();
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

        protected override NumeralQuestion<GalaxyDigit> ParseToNumeralQuestion(string content, GroupCollection groups)
        {
            if (groups.Count == 2 && groups[1].Captures.Count > 0)
            {
                Numeral<GalaxyDigit> numeral = new GalaxyNumeral();
                foreach (Capture capture in groups[1].Captures)
                {
                    numeral.AddDigit(capture.Value.Trim());
                }
                return new NumeralQuestion<GalaxyDigit>(content, numeral);
            }
            throw new MatchRegexException();
        }

        protected override TransactionQuestion<GalaxyDigit> ParseToTransactionQuestion(string content,
            GroupCollection groups)
        {
            if (groups.Count == 2 && groups[1].Captures.Count > 0)
            {
                var commodityName = string.Empty;
                Numeral<GalaxyDigit> numeral = new GalaxyNumeral();
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
                var transaction = new Transaction<GalaxyDigit>(CommodityFactory.Instance.GetCommodity(commodityName),
                    numeral);
                return new TransactionQuestion<GalaxyDigit>(content, transaction);
            }
            throw new MatchRegexException();
        }
    }
}
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MerchantGuide.InputLine;

namespace MerchantGuide.InputLineParser
{
    /// <summary>
    ///     输入行解析器
    /// </summary>
    public abstract class InputParser<TDigit> where TDigit : Digit.Digit
    {
        protected readonly IDictionary<ParseType, Regex> RegexDictionary = new Dictionary<ParseType, Regex>();

        protected InputParser()
        {
            InitRegexes();
        }

        public abstract Regex DigitConditionRegex { get; }

        public abstract Regex CommodityConditionRegex { get; }

        public abstract Regex NumeralQuestionRegex { get; }

        public abstract Regex TransactionQuestionRegex { get; }

        private void InitRegexes()
        {
            RegexDictionary.Add(ParseType.DigitCondition, DigitConditionRegex);
            RegexDictionary.Add(ParseType.CommodityCondition, CommodityConditionRegex);
            RegexDictionary.Add(ParseType.NumeralQuestion, NumeralQuestionRegex);
            RegexDictionary.Add(ParseType.TransactionQuestion, TransactionQuestionRegex);
        }

        public InputLine.InputLine Parse(string txt)
        {
            foreach (var item in RegexDictionary)
            {
                var matches = item.Value.Matches(txt);
                if (matches.Count > 0)
                {
                    var groups = matches[0].Groups;
                    switch (item.Key)
                    {
                        case ParseType.DigitCondition:
                            return ParseToDigitCondition(txt, groups);
                        case ParseType.CommodityCondition:
                            return ParseToCommodityCondition(txt, groups);
                        case ParseType.NumeralQuestion:
                            return ParseToNumeralQuestion(txt, groups);
                        case ParseType.TransactionQuestion:
                            return ParseToTransactionQuestion(txt, groups);
                        default:
                            break;
                    }
                }
            }
            return new UnrecognizedInputLine(txt);
        }

        protected abstract DigitCondition<TDigit> ParseToDigitCondition(string content, GroupCollection groups);

        protected abstract CommodityCondition ParseToCommodityCondition(string content, GroupCollection groups);

        protected abstract NumeralQuestion<TDigit> ParseToNumeralQuestion(string content, GroupCollection groups);

        protected abstract TransactionQuestion<TDigit> ParseToTransactionQuestion(string content, GroupCollection groups);
    }
}
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MerchantGuide.Exception;
using MerchantGuide.InputLine;
using MerchantGuide.Numeral;

namespace MerchantGuide.InputLineParser
{
    /// <summary>
    ///     输入行解析器
    /// </summary>
    public abstract class InputParser<T> where T : Digit
    {
        protected readonly IDictionary<ParseType, Regex> Regexes = new Dictionary<ParseType, Regex>();

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
            Regexes.Add(ParseType.DigitCondition, DigitConditionRegex);
            Regexes.Add(ParseType.CommodityCondition, CommodityConditionRegex);
            Regexes.Add(ParseType.NumeralQuestion, NumeralQuestionRegex);
            Regexes.Add(ParseType.TransactionQuestion, TransactionQuestionRegex);
        }

        public InputLine.InputLine Parse(string txt)
        {
            foreach (var item in Regexes)
            {
                var matches = item.Value.Matches(txt);
                if (matches.Count > 0)
                {
                    try
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
                    catch (System.Exception ex)
                    {
                        throw new ParseInputLineException(ex);
                    }
                }
            }
            throw new ParseInputLineException();
        }

        protected abstract DigitCondition<T> ParseToDigitCondition(string content, GroupCollection groups);

        protected abstract CommodityCondition ParseToCommodityCondition(string content, GroupCollection groups);

        protected abstract NumeralQuestion<T> ParseToNumeralQuestion(string content, GroupCollection groups);

        protected abstract TransactionQuestion<T> ParseToTransactionQuestion(string content, GroupCollection groups);
    }
}
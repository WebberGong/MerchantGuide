using System.Collections.Generic;
using MerchantGuide.Exception;

namespace MerchantGuide.Numeral
{
    /// <summary>
    ///     银河系数字
    /// </summary>
    public class GalaxyNumeral : Numeral<GalaxyDigit>
    {
        public override GalaxyDigit GetDigit(string symbolText)
        {
            return GalaxyDigitFactory.Instance.GetDigit(symbolText);
        }

        public override GalaxyDigit GetDigit(int value)
        {
            return GalaxyDigitFactory.Instance.GetDigit(value);
        }

        public override int GetValue()
        {
            IDictionary<int, int> repeatCountDic = new Dictionary<int, int>();
            GalaxyDigit previous = null;
            var value = 0;
            foreach (var item in Digits)
            {
                var current = item;
                if (previous != null)
                {
                    if (previous.Value > current.Value)
                    {
                        SetValueIfPreviousIsGreaterThanCurrent(repeatCountDic, previous, current, ref value);
                    }
                    else if (previous.Value == current.Value)
                    {
                        SetValueIfPreviousIsEqualToCurrent(repeatCountDic, previous, current, ref value);
                    }
                    else
                    {
                        SetValueIfPreviousIsLessThanCurrent(repeatCountDic, previous, current, ref value);
                    }
                }
                else
                {
                    value += item.Value;
                }
                previous = item;
            }
            return value;
        }

        private void SetValueIfPreviousIsGreaterThanCurrent(
            IDictionary<int, int> repeatCountDic, GalaxyDigit previous, GalaxyDigit current, ref int value)
        {
            value += current.Value;
            if (repeatCountDic.ContainsKey(previous.Value))
            {
                repeatCountDic.Remove(previous.Value);
            }
        }

        private void SetValueIfPreviousIsEqualToCurrent(
            IDictionary<int, int> repeatCountDic, GalaxyDigit previous, GalaxyDigit current, ref int value)
        {
            if (previous.CanBeRepeated && current.CanBeRepeated)
            {
                if (repeatCountDic.ContainsKey(current.Value))
                {
                    repeatCountDic[current.Value]++;
                }
                else
                {
                    repeatCountDic.Add(current.Value, 2);
                }
                if (repeatCountDic[current.Value] < 4)
                {
                    value += current.Value;
                }
                else
                {
                    throw new ValidateNumeralException("The digit '" + current.SymbolText +
                                                       "' should not be repeated more than 3 times");
                }
            }
            else
            {
                throw new ValidateNumeralException("The digit '" + current.SymbolText + "' should not be repeated");
            }
        }

        private void SetValueIfPreviousIsLessThanCurrent(
            IDictionary<int, int> repeatCountDic, GalaxyDigit previous, GalaxyDigit current, ref int value)
        {
            if (!repeatCountDic.ContainsKey(previous.Value))
            {
                if (previous.CanBeSubtracted)
                {
                    if (current.Value/previous.Value <= 10)
                    {
                        value -= previous.Value*2;
                        value += current.Value;
                    }
                    else
                    {
                        throw new ValidateNumeralException("The digit '" + previous.SymbolText +
                                                           "' should not be subtracted between more than one order of magnitude");
                    }
                }
                else
                {
                    throw new ValidateNumeralException("The digit '" + previous.SymbolText +
                                                       "' should not be subtracted");
                }
            }
            else
            {
                throw new ValidateNumeralException("The digit '" + current.SymbolText +
                                                   "' should not greater than the previous digit if the previous digit was repeated");
            }
        }
    }
}
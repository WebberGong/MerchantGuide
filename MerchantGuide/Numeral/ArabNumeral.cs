using System;
using MerchantGuide.Exception;

namespace MerchantGuide.Numeral
{
    /// <summary>
    ///     阿拉伯数字
    /// </summary>
    public class ArabNumeral : Numeral<ArabDigit>
    {
        public override ArabDigit GetDigit(string symbolText)
        {
            return ArabDigitFactory.Instance.GetDigit(symbolText);
        }

        public override ArabDigit GetDigit(int value)
        {
            return ArabDigitFactory.Instance.GetDigit(value);
        }

        public override int GetValue()
        {
            var value = 0;
            var count = Digits.Count;
            for (var i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    if (Digits[i].CanBeFirst)
                    {
                        value += Digits[i].Value*(int) Math.Pow(10, count - 1 - i);
                    }
                    else
                    {
                        throw new ValidateNumeralException("Arab numeral can not started with zero.");
                    }
                }
                else
                {
                    value += Digits[i].Value*(int) Math.Pow(10, count - 1 - i);
                }
            }
            return value;
        }
    }
}
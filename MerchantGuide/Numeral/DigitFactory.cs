using System.Collections.Generic;
using System.Linq;
using MerchantGuide.Exception;

namespace MerchantGuide.Numeral
{
    /// <summary>
    ///     数字位工厂
    /// </summary>
    public abstract class DigitFactory<T> where T : Digit
    {
        protected readonly IDictionary<int, T> Digits = new Dictionary<int, T>();
        protected readonly IDictionary<string, T> DigitsSymbolText = new Dictionary<string, T>();

        public int Count
        {
            get { return Digits.Count; }
        }

        public abstract void Initialize();

        protected void AddDigit(T digit)
        {
            if (digit != null)
            {
                if (!Digits.ContainsKey(digit.Value))
                {
                    if (!DigitsSymbolText.ContainsKey(digit.SymbolText))
                    {
                        DigitsSymbolText.Add(digit.SymbolText, digit);
                        Digits.Add(digit.Value, digit);
                    }
                    else
                    {
                        throw new InitializeDigitFactoryException("Symbol text can not be repeated");
                    }
                }
                else
                {
                    Digits[digit.Value] = digit;
                }
            }
            else
            {
                throw new InitializeDigitFactoryException("Not allowed to add a null value");
            }
        }

        public T GetDigit(int value)
        {
            return Digits.Values.FirstOrDefault(x => x.Value == value);
        }

        public T GetDigit(string symbolText)
        {
            return Digits.Values.FirstOrDefault(x => x.SymbolText == symbolText);
        }

        public void SetDigitSymbolText(int value, string symbolText)
        {
            var digit = GetDigit(value);
            digit.SymbolText = symbolText;
        }

        public void SetDigitSymbolText(string originalSymbolText, string substitutiveSymbolText)
        {
            var digit = GetDigit(originalSymbolText);
            digit.SymbolText = substitutiveSymbolText;
        }

        protected void Clear()
        {
            DigitsSymbolText.Clear();
            Digits.Clear();
        }
    }
}
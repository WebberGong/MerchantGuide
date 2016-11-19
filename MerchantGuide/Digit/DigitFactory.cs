using System.Collections.Generic;
using System.Linq;
using MerchantGuide.Exception;

namespace MerchantGuide.Digit
{
    /// <summary>
    ///     数字位工厂
    /// </summary>
    public abstract class DigitFactory<TDigit> where TDigit : Digit
    {
        private readonly IDictionary<string, TDigit> _digitDictionary = new Dictionary<string, TDigit>();
        protected readonly IDictionary<int, TDigit> DigitDictionary = new Dictionary<int, TDigit>();

        public int Count
        {
            get { return DigitDictionary.Count; }
        }

        public abstract void Initialize();

        protected void AddDigit(TDigit digit)
        {
            if (digit != null)
            {
                if (!DigitDictionary.ContainsKey(digit.Value))
                {
                    if (!_digitDictionary.ContainsKey(digit.SymbolText))
                    {
                        _digitDictionary.Add(digit.SymbolText, digit);
                        DigitDictionary.Add(digit.Value, digit);
                    }
                    else
                    {
                        throw new DigitFactoryException("Symbol text can not be repeated.");
                    }
                }
                else
                {
                    DigitDictionary[digit.Value] = digit;
                }
            }
            else
            {
                throw new DigitFactoryException("Not allowed to add a null value.");
            }
        }

        public TDigit GetDigit(int value)
        {
            return DigitDictionary.Values.FirstOrDefault(x => x.Value == value);
        }

        public TDigit GetDigit(string symbolText)
        {
            return DigitDictionary.Values.FirstOrDefault(x => x.SymbolText == symbolText);
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
            _digitDictionary.Clear();
            DigitDictionary.Clear();
        }
    }
}
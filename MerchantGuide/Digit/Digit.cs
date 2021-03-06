﻿using System.Text.RegularExpressions;
using MerchantGuide.Exception;

namespace MerchantGuide.Digit
{
    /// <summary>
    ///     数字位
    /// </summary>
    public abstract class Digit
    {
        private string _symbolText;
        private int _value;

        protected Digit(int value, string symbolText)
        {
            Value = value;
            SymbolText = symbolText;
        }

        public int Value
        {
            get { return _value; }
            private set
            {
                if (value < 0)
                {
                    throw new DigitException("Digit value should not be negative.");
                }
                _value = value;
            }
        }

        public string SymbolText
        {
            get { return _symbolText; }
            set
            {
                var regex = new Regex("^([A-Za-z]+){1}$");
                if (string.IsNullOrEmpty(value) || !regex.IsMatch(value))
                {
                    throw new DigitException("Digit symbol text can contains English characters only.");
                }
                _symbolText = value;
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using MerchantGuide.Exception;

namespace MerchantGuide.Numeral
{
    /// <summary>
    ///     数字
    /// </summary>
    public abstract class Numeral<TDigit> : IPrintable where TDigit : Digit.Digit
    {
        public const string Zero = "Zero";
        protected readonly IList<TDigit> Digits = new List<TDigit>();

        public int Length
        {
            get { return Digits.Count; }
        }

        public void Print()
        {
            Console.WriteLine(GetSymbolText() + " is " + GetValue());
        }

        public abstract TDigit GetDigit(string symbolText);

        public abstract TDigit GetDigit(int value);

        public Numeral<TDigit> AddDigit(string symbolText)
        {
            var digit = GetDigit(symbolText);
            if (digit != null)
            {
                Digits.Add(digit);
            }
            else
            {
                throw new NumeralException("Can not get digit from symbol text.");
            }
            return this;
        }

        public Numeral<TDigit> AddDigit(int value)
        {
            var digit = GetDigit(value);
            if (digit != null)
            {
                Digits.Add(digit);
            }
            else
            {
                throw new NumeralException("Can not get digit from value.");
            }
            return this;
        }

        public abstract int GetValue();

        public string GetSymbolText()
        {
            var symbolText = Digits.Aggregate(string.Empty, (current, item) => current + item.SymbolText + " ");
            if (symbolText.Length > 0)
            {
                symbolText = symbolText.Substring(0, symbolText.Length - 1);
            }
            if (string.IsNullOrEmpty(symbolText))
            {
                symbolText = Zero;
            }
            return symbolText;
        }
    }
}
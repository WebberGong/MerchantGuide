using System;
using MerchantGuide.Numeral;

namespace MerchantGuide.Transaction
{
    /// <summary>
    ///     交易
    /// </summary>
    public class Transaction<TDigit> : IPrintable where TDigit : Digit.Digit
    {
        public Transaction(Commodity.Commodity commodity, Numeral<TDigit> number)
        {
            Commodity = commodity;
            Number = number;
        }

        public Commodity.Commodity Commodity { get; private set; }

        public Numeral<TDigit> Number { get; private set; }

        public void Print()
        {
            Console.WriteLine(Number.GetSymbolText() + " " + Commodity.Name + " is " + (int) GetAmount() + " " +
                              MerchantGuide.Commodity.Commodity.CurrencyUnit);
        }

        public decimal GetAmount()
        {
            return Number.GetValue()*Commodity.Price;
        }
    }
}
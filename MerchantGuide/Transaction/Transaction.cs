using System;
using MerchantGuide.Numeral;

namespace MerchantGuide.Transaction
{
    /// <summary>
    ///     交易
    /// </summary>
    public class Transaction<T> : IPrintable where T : Digit
    {
        public Transaction(Commodity.Commodity commodity, Numeral<T> number)
        {
            Commodity = commodity;
            Number = number;
        }

        public Commodity.Commodity Commodity { get; set; }

        public Numeral<T> Number { get; set; }

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
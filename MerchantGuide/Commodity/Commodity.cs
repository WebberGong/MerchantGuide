using System.Text.RegularExpressions;
using MerchantGuide.Exception;

namespace MerchantGuide.Commodity
{
    /// <summary>
    ///     商品
    /// </summary>
    public class Commodity
    {
        //货币单位
        public const string CurrencyUnit = "Credits";
        private string _name;
        private decimal _price;

        public Commodity(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name
        {
            get { return _name; }
            private set
            {
                var regex = new Regex("([A-Za-z]+)");
                if (string.IsNullOrEmpty(value) || !regex.IsMatch(value))
                {
                    throw new ValidateCommodityException("Commodity name can only contains English characters");
                }
                _name = value;
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value < 0m)
                {
                    throw new ValidateCommodityException("Commodity price should not be negative");
                }
                _price = value;
            }
        }
    }
}
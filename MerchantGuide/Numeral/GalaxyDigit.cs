namespace MerchantGuide.Numeral
{
    /// <summary>
    ///     银河系数字位
    /// </summary>
    public class GalaxyDigit : Digit
    {
        public GalaxyDigit(GalaxySymbol symbol)
            : base((int) symbol, symbol.ToString())
        {
        }

        public bool CanBeRepeated
        {
            get
            {
                if (Value == (int) GalaxySymbol.V ||
                    Value == (int) GalaxySymbol.L ||
                    Value == (int) GalaxySymbol.D)
                {
                    return false;
                }
                return true;
            }
        }

        public bool CanBeSubtracted
        {
            get
            {
                if (Value == (int) GalaxySymbol.V ||
                    Value == (int) GalaxySymbol.L ||
                    Value == (int) GalaxySymbol.D)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
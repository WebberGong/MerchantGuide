namespace MerchantGuide.Digit
{
    /// <summary>
    ///     阿拉伯数字位
    /// </summary>
    public class ArabDigit : Digit
    {
        public ArabDigit(ArabSymbol symbol)
            : base((int) symbol, symbol.ToString())
        {
        }

        public bool CanBeFirst
        {
            get
            {
                if (Value == (int) ArabSymbol.Zero)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
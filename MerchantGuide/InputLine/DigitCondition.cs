using MerchantGuide.Numeral;

namespace MerchantGuide.InputLine
{
    /// <summary>
    ///     数字位设置条件
    /// </summary>
    public class DigitCondition<T> : InputLine where T : Digit
    {
        private readonly DigitFactory<T> _factory;

        public DigitCondition(string content, string originalSymbolText, string substitutiveSymbolText,
            DigitFactory<T> factory)
            : base(content)
        {
            OriginalSymbolText = originalSymbolText;
            SubstitutiveSymbolText = substitutiveSymbolText;

            _factory = factory;
        }

        public string OriginalSymbolText { get; private set; }

        public string SubstitutiveSymbolText { get; private set; }

        public override void Excute()
        {
            var digit = _factory.GetDigit(OriginalSymbolText);
            if (digit != null)
            {
                _factory.SetDigitSymbolText(digit.Value, SubstitutiveSymbolText);
            }
        }
    }
}
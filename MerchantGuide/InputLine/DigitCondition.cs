using MerchantGuide.Digit;

namespace MerchantGuide.InputLine
{
    /// <summary>
    ///     数字位设置条件
    /// </summary>
    public class DigitCondition<TDigit> : InputLine where TDigit : Digit.Digit
    {
        private readonly DigitFactory<TDigit> _factory;

        public DigitCondition(string content, string originalSymbolText, string substitutiveSymbolText,
            DigitFactory<TDigit> factory)
            : base(content)
        {
            OriginalSymbolText = originalSymbolText;
            SubstitutiveSymbolText = substitutiveSymbolText;

            _factory = factory;
        }

        public string OriginalSymbolText { get; private set; }

        public string SubstitutiveSymbolText { get; private set; }

        public override void Process()
        {
            var digit = _factory.GetDigit(OriginalSymbolText);
            if (digit != null)
            {
                _factory.SetDigitSymbolText(digit.Value, SubstitutiveSymbolText);
            }
        }
    }
}
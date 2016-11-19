using MerchantGuide.Numeral;

namespace MerchantGuide.InputLine
{
    /// <summary>
    ///     数字问题
    /// </summary>
    public class NumeralQuestion<TDigit> : InputLine where TDigit : Digit.Digit
    {
        public NumeralQuestion(string content, Numeral<TDigit> number)
            : base(content)
        {
            Number = number;
        }

        public Numeral<TDigit> Number { get; private set; }

        public override void Process()
        {
            Number.Print();
        }
    }
}
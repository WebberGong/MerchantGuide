using MerchantGuide.Numeral;

namespace MerchantGuide.InputLine
{
    /// <summary>
    ///     数字问题
    /// </summary>
    public class NumeralQuestion<T> : InputLine where T : Digit
    {
        public NumeralQuestion(string content, Numeral<T> number)
            : base(content)
        {
            Number = number;
        }

        public Numeral<T> Number { get; private set; }

        public override void Excute()
        {
            Number.Print();
        }
    }
}
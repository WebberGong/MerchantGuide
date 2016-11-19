using System;

namespace MerchantGuide.Digit
{
    /// <summary>
    ///     阿拉伯数字位工厂
    /// </summary>
    public class ArabDigitFactory : DigitFactory<ArabDigit>
    {
        private static ArabDigitFactory _instance;
        private static readonly object Locker = new object();

        private ArabDigitFactory()
        {
            Initialize();
        }

        public static ArabDigitFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new ArabDigitFactory();
                        }
                    }
                }
                return _instance;
            }
        }

        public sealed override void Initialize()
        {
            var symbolTexts = Enum.GetNames(typeof (ArabSymbol));
            foreach (var symbolText in symbolTexts)
            {
                ArabSymbol symbol;
                if (Enum.TryParse(symbolText, out symbol))
                {
                    AddDigit(new ArabDigit(symbol));
                }
            }
        }
    }
}
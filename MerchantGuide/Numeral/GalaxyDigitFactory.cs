using System;

namespace MerchantGuide.Numeral
{
    /// <summary>
    ///     银河系数字位工厂
    /// </summary>
    public class GalaxyDigitFactory : DigitFactory<GalaxyDigit>
    {
        private static GalaxyDigitFactory _instance;
        private static readonly object Locker = new object();

        private GalaxyDigitFactory()
        {
            Initialize();
        }

        public static GalaxyDigitFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new GalaxyDigitFactory();
                        }
                    }
                }
                return _instance;
            }
        }

        public sealed override void Initialize()
        {
            Clear();

            var symbolTexts = Enum.GetNames(typeof (GalaxySymbol));
            foreach (var symbolText in symbolTexts)
            {
                GalaxySymbol symbol;
                if (Enum.TryParse(symbolText, out symbol))
                {
                    AddDigit(new GalaxyDigit(symbol));
                }
            }
        }
    }
}
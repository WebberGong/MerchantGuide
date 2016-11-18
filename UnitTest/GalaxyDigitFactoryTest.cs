using System;
using MerchantGuide.Numeral;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class GalaxyDigitFactoryTest : TestBase
    {
        [TestMethod]
        public void GalaxyDigitFactory_Constructor()
        {
            var factory = GalaxyDigitFactory.Instance;
            var count = Enum.GetNames(typeof (GalaxySymbol)).Length;
            Assert.AreEqual(count, factory.Count);
        }
    }
}
using MerchantGuide.Digit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class GalaxyDigitTest : TestBase
    {
        [TestMethod]
        public void GalaxyDigit_CanBeRepeated_Yes()
        {
            var digit = new GalaxyDigit(GalaxySymbol.I);
            Assert.AreEqual(true, digit.CanBeRepeated);
        }

        [TestMethod]
        public void GalaxyDigit_CanBeRepeated_No()
        {
            var digit = new GalaxyDigit(GalaxySymbol.V);
            Assert.AreEqual(false, digit.CanBeRepeated);
        }

        [TestMethod]
        public void GalaxyDigit_CanBeSubtracted_Yes()
        {
            var digit = new GalaxyDigit(GalaxySymbol.I);
            Assert.AreEqual(true, digit.CanBeSubtracted);
        }

        [TestMethod]
        public void GalaxyDigit_CanBeSubtracted_No()
        {
            var digit = new GalaxyDigit(GalaxySymbol.V);
            Assert.AreEqual(false, digit.CanBeSubtracted);
        }
    }
}
using System;
using MerchantGuide.Digit;
using MerchantGuide.Numeral;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class GalaxyNumeralTest : TestBase
    {
        [TestMethod]
        public void GalaxyNumeral_Length_Zero()
        {
            var numeral = new GalaxyNumeral();
            Assert.AreEqual(0, numeral.Length);
        }

        [TestMethod]
        public void GalaxyNumeral_Length_NotZero()
        {
            var numeral = new GalaxyNumeral();
            numeral.AddDigit("V");
            Assert.AreEqual(1, numeral.Length);
        }

        [TestMethod]
        public void GalaxyNumeral_AddDigit_SymbolText_Normal()
        {
            var numeral = new GalaxyNumeral();
            numeral.AddDigit("I");
            Assert.AreEqual(1, numeral.Length);
        }

        [TestMethod]
        public void GalaxyNumeral_AddDigit_SymbolText_Failed()
        {
            try
            {
                var numeral = new GalaxyNumeral();
                numeral.AddDigit("Webber");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Can not get digit from symbol text.", ex.Message);
            }
        }

        [TestMethod]
        public void GalaxyNumeral_AddDigit_Value_Normal()
        {
            var numeral = new GalaxyNumeral();
            numeral.AddDigit(1);
            Assert.AreEqual(1, numeral.Length);
        }

        [TestMethod]
        public void GalaxyNumeral_AddDigit_Value_Failed()
        {
            try
            {
                var numeral = new GalaxyNumeral();
                numeral.AddDigit(8);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Can not get digit from value.", ex.Message);
            }
        }

        [TestMethod]
        public void GalaxyNumeral_GetValue_Normal()
        {
            var numeral = new GalaxyNumeral();
            numeral.AddDigit("X").AddDigit("X").AddDigit("X").AddDigit("I").AddDigit("V");
            Assert.AreEqual(34, numeral.GetValue());

            numeral = new GalaxyNumeral();
            numeral.AddDigit("M").AddDigit("C").AddDigit("M").AddDigit("I").AddDigit("I").AddDigit("I");
            Assert.AreEqual(1903, numeral.GetValue());

            numeral = new GalaxyNumeral();
            numeral.AddDigit("X").AddDigit("C").AddDigit("I").AddDigit("X");
            Assert.AreEqual(99, numeral.GetValue());

            numeral = new GalaxyNumeral();
            numeral.AddDigit("X").AddDigit("X").AddDigit("X").AddDigit("V");
            Assert.AreEqual(35, numeral.GetValue());

            numeral = new GalaxyNumeral();
            numeral.AddDigit("X").AddDigit("X").AddDigit("X").AddDigit("I").AddDigit("X");
            Assert.AreEqual(39, numeral.GetValue());

            numeral = new GalaxyNumeral();
            numeral.AddDigit("C").AddDigit("X").AddDigit("X").AddDigit("X").AddDigit("V")
                .AddDigit("I").AddDigit("I").AddDigit("I");
            Assert.AreEqual(138, numeral.GetValue());
        }

        [TestMethod]
        public void GalaxyNumeral_GetValue_Failed()
        {
            try
            {
                var numeral = new GalaxyNumeral();
                numeral.AddDigit("X").AddDigit("I").AddDigit("I").AddDigit("I").AddDigit("I");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("should not be repeated more than 3 times."));
            }

            try
            {
                var numeral = new GalaxyNumeral();
                numeral.AddDigit("C").AddDigit("V").AddDigit("V").AddDigit("I").AddDigit("I");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("should not be repeated."));
            }

            try
            {
                var numeral = new GalaxyNumeral();
                numeral.AddDigit("C").AddDigit("V").AddDigit("V").AddDigit("I").AddDigit("I");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("should not be repeated."));
            }

            try
            {
                var numeral = new GalaxyNumeral();
                numeral.AddDigit("I").AddDigit("C");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("should not be subtracted between more than one order of magnitude."));
            }

            try
            {
                var numeral = new GalaxyNumeral();
                numeral.AddDigit("V").AddDigit("X");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("should not be subtracted."));
            }

            try
            {
                var numeral = new GalaxyNumeral();
                numeral.AddDigit("X").AddDigit("X").AddDigit("X").AddDigit("C").AddDigit("V")
                    .AddDigit("I").AddDigit("I").AddDigit("I");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(
                    ex.Message.Contains("should not greater than the previous digit if the previous digit was repeated."));
            }
        }

        [TestMethod]
        public void GalaxyNumeral_GetSymbolText_Normal()
        {
            var numeral = new GalaxyNumeral();
            numeral.AddDigit("X").AddDigit("X").AddDigit("X").AddDigit("I").AddDigit("V");
            Assert.AreEqual("X X X I V", numeral.GetSymbolText());
        }

        [TestMethod]
        public void GalaxyNumeral_GetSymbolText_Empty()
        {
            var numeral = new GalaxyNumeral();
            Assert.AreEqual(Numeral<GalaxyDigit>.Zero, numeral.GetSymbolText());
        }
    }
}
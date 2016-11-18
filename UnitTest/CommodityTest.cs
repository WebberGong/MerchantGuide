using System;
using MerchantGuide.Commodity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class CommodityTest : TestBase
    {
        [TestMethod]
        public void Commodity_Name_Normal()
        {
            var commodity = new Commodity("Gold", 100m);
            Assert.AreEqual("Gold", commodity.Name);
        }

        [TestMethod]
        public void Commodity_Name_ContainsWhiteSpace()
        {
            try
            {
                var commodity = new Commodity("Gold Block", 100m);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Commodity name can only contains English characters.", ex.Message);
            }
        }

        [TestMethod]
        public void Commodity_Name_ContainsNumbers()
        {
            try
            {
                var commodity = new Commodity("Gold123", 100m);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Commodity name can only contains English characters.", ex.Message);
            }
        }

        [TestMethod]
        public void Commodity_Name_ContainsOtherCharacters()
        {
            try
            {
                var commodity = new Commodity("Gold*?", 100m);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Commodity name can only contains English characters", ex.Message);
            }
        }

        [TestMethod]
        public void Commodity_Name_Empty()
        {
            try
            {
                var commodity = new Commodity(string.Empty, 100m);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Commodity name can only contains English characters", ex.Message);
            }
        }

        [TestMethod]
        public void Commodity_Name_Null()
        {
            try
            {
                var commodity = new Commodity(null, 100m);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Commodity name can only contains English characters", ex.Message);
            }
        }

        [TestMethod]
        public void Commodity_Price_Normal()
        {
            var commodity = new Commodity("Gold", 100m);
            Assert.AreEqual(100, commodity.Price);
        }

        [TestMethod]
        public void Commodity_Price_Negative()
        {
            try
            {
                var commodity = new Commodity("Gold", -100m);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Commodity price should not be negative", ex.Message);
            }
        }
    }
}
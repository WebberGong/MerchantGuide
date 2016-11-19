using System;
using MerchantGuide.Commodity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class CommodityFactoryTest : TestBase
    {
        [TestMethod]
        public void CommodityFactory_GetCommodity_Normal()
        {
            CommodityFactory.Instance.Clear();
            var result = CommodityFactory.Instance.GetCommodity("Gold");
            Assert.IsTrue(result != null && result.Name == "Gold" && result.Price == default(decimal));
        }

        [TestMethod]
        public void CommodityFactory_GetCommodity_Repeat()
        {
            CommodityFactory.Instance.Clear();
            var result1 = CommodityFactory.Instance.GetCommodity("Gold");
            var result2 = CommodityFactory.Instance.GetCommodity("Gold");
            Assert.IsTrue(result1 == result2 && CommodityFactory.Instance.Count == 1);
        }

        [TestMethod]
        public void CommodityFactory_SetPrice_Normal()
        {
            CommodityFactory.Instance.Clear();
            CommodityFactory.Instance.SetPrice("Gold", 100m);
            var result = CommodityFactory.Instance.GetCommodity("Gold");
            Assert.IsTrue(result != null && result.Name == "Gold" && result.Price == 100m);
        }


        [TestMethod]
        public void CommodityFactory_SetPrice_Negative()
        {
            try
            {
                CommodityFactory.Instance.Clear();
                CommodityFactory.Instance.SetPrice("Gold", -100m);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Commodity price should not be negative.", ex.Message);
            }
        }

        [TestMethod]
        public void CommodityFactory_SetPrice_Repeated()
        {
            CommodityFactory.Instance.Clear();
            CommodityFactory.Instance.SetPrice("Gold", 100m);
            CommodityFactory.Instance.SetPrice("Gold", 50m);
            var result = CommodityFactory.Instance.GetCommodity("Gold");
            Assert.IsTrue(result != null && result.Name == "Gold" && result.Price == 50m &&
                          CommodityFactory.Instance.Count == 1);
        }

        [TestMethod]
        public void CommodityFactory_Clear()
        {
            var result1 = CommodityFactory.Instance.GetCommodity("GoldOne");
            var result2 = CommodityFactory.Instance.GetCommodity("GoldTwo");
            CommodityFactory.Instance.Clear();
            Assert.IsTrue(CommodityFactory.Instance.Count == 0);
        }

        [TestMethod]
        public void CommodityFactory_Count_Zero()
        {
            CommodityFactory.Instance.Clear();
            Assert.IsTrue(CommodityFactory.Instance.Count == 0);
        }

        [TestMethod]
        public void CommodityFactory_Count_NotZero()
        {
            CommodityFactory.Instance.Clear();
            var result1 = CommodityFactory.Instance.GetCommodity("GoldOne");
            var result2 = CommodityFactory.Instance.GetCommodity("GoldTwo");
            Assert.IsTrue(CommodityFactory.Instance.Count == 2);
        }
    }
}
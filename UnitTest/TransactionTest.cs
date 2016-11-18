using MerchantGuide.Commodity;
using MerchantGuide.Numeral;
using MerchantGuide.Transaction;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class TransactionTest : TestBase
    {
        [TestMethod]
        public void Transaction_GetAmount_Normal()
        {
            CommodityFactory.Instance.SetPrice("Gold", 100m);
            var number = new GalaxyNumeral();
            number.AddDigit("I").AddDigit("V");
            var transaction = new Transaction<GalaxyDigit>(CommodityFactory.Instance.GetCommodity("Gold"), number);
            Assert.AreEqual(400, transaction.GetAmount());
        }

        [TestMethod]
        public void Transaction_GetAmount_Zero()
        {
            CommodityFactory.Instance.SetPrice("Gold", 0m);
            var number = new GalaxyNumeral();
            number.AddDigit("I").AddDigit("V");
            var transaction = new Transaction<GalaxyDigit>(CommodityFactory.Instance.GetCommodity("Gold"), number);
            Assert.AreEqual(0, transaction.GetAmount());

            CommodityFactory.Instance.SetPrice("Gold", 100m);
            number = new GalaxyNumeral();
            transaction = new Transaction<GalaxyDigit>(CommodityFactory.Instance.GetCommodity("Gold"), number);
            Assert.AreEqual(0, transaction.GetAmount());
        }
    }
}
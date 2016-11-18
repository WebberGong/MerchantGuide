using MerchantGuide.Commodity;
using MerchantGuide.Numeral;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class TestBase
    {
        [TestInitialize]
        public void Init()
        {
        }

        [TestCleanup]
        public void Clean()
        {
            CommodityFactory.Instance.Clear();
            GalaxyDigitFactory.Instance.Initialize();
        }
    }
}
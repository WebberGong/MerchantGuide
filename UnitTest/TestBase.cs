using MerchantGuide.Commodity;
using MerchantGuide.Digit;
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
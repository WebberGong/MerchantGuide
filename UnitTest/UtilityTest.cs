using System.IO;
using MerchantGuide;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UtilityTest
    {
        [TestMethod]
        public void Utility_ReadTxt_Normal()
        {
            var inputLines = Utility.ReadTxt("./Resource/GalaxyInput.txt");
            Assert.AreEqual(12, inputLines.Count);
        }

        [TestMethod, ExpectedException(typeof (FileNotFoundException))]
        public void Utility_ReadTxt_FileNotFound()
        {
            var inputLines = Utility.ReadTxt("./Resource/GalaxyInput_1.txt");
        }
    }
}
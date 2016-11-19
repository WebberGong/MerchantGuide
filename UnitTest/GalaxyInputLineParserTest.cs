using MerchantGuide.Digit;
using MerchantGuide.InputLine;
using MerchantGuide.InputLineParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class GalaxyInputLineParserTest : TestBase
    {
        [TestMethod]
        public void GalaxyInputParser_Parse_Normal()
        {
            var inputLine = GalaxyInputLineParser.Instance.Parse("glob is I");
            var digitCondition = inputLine as DigitCondition<GalaxyDigit>;
            if (digitCondition != null)
            {
                digitCondition.Process();
            }
            Assert.IsTrue(digitCondition != null && digitCondition.OriginalSymbolText == "I" &&
                          digitCondition.SubstitutiveSymbolText == "glob");

            inputLine = GalaxyInputLineParser.Instance.Parse("glob glob Silver is 34 Credits");
            var commodityCondition = inputLine as CommodityCondition;
            if (commodityCondition != null)
            {
                commodityCondition.Process();
            }
            Assert.IsTrue(commodityCondition != null && commodityCondition.CommodityName == "Silver" &&
                          commodityCondition.Number == 2 && commodityCondition.TotalAmount == 34);

            inputLine = GalaxyInputLineParser.Instance.Parse("how much is glob glob ?");
            var numeralQuestion = inputLine as NumeralQuestion<GalaxyDigit>;
            Assert.IsTrue(numeralQuestion != null && numeralQuestion.Number.GetValue() == 2);

            inputLine = GalaxyInputLineParser.Instance.Parse("how many Credits is glob glob glob Silver ?");
            var transactionQuestion = inputLine as TransactionQuestion<GalaxyDigit>;
            Assert.IsTrue(transactionQuestion != null && transactionQuestion.Transaction.Number.GetValue() == 3 &&
                          transactionQuestion.Transaction.Commodity.Name == "Silver" &&
                          transactionQuestion.Transaction.GetAmount() == 51);

            inputLine = GalaxyInputLineParser.Instance.Parse("glob is     I");
            digitCondition = inputLine as DigitCondition<GalaxyDigit>;
            if (digitCondition != null)
            {
                digitCondition.Process();
            }
            Assert.IsTrue(digitCondition != null && digitCondition.OriginalSymbolText == "I" &&
                          digitCondition.SubstitutiveSymbolText == "glob");

            inputLine = GalaxyInputLineParser.Instance.Parse("glob glob   Silver   is 34  Credits");
            commodityCondition = inputLine as CommodityCondition;
            if (commodityCondition != null)
            {
                commodityCondition.Process();
            }
            Assert.IsTrue(commodityCondition != null && commodityCondition.CommodityName == "Silver" &&
                          commodityCondition.Number == 2 && commodityCondition.TotalAmount == 34);

            inputLine = GalaxyInputLineParser.Instance.Parse("how   much is glob glob   ?");
            numeralQuestion = inputLine as NumeralQuestion<GalaxyDigit>;
            Assert.IsTrue(numeralQuestion != null && numeralQuestion.Number.GetValue() == 2);

            inputLine = GalaxyInputLineParser.Instance.Parse("how   much     is glob   glob?");
            numeralQuestion = inputLine as NumeralQuestion<GalaxyDigit>;
            Assert.IsTrue(numeralQuestion != null && numeralQuestion.Number.GetValue() == 2);

            inputLine = GalaxyInputLineParser.Instance.Parse("how many   Credits is    glob glob   glob Silver?");
            transactionQuestion = inputLine as TransactionQuestion<GalaxyDigit>;
            Assert.IsTrue(transactionQuestion != null && transactionQuestion.Transaction.Number.GetValue() == 3 &&
                          transactionQuestion.Transaction.Commodity.Name == "Silver" &&
                          transactionQuestion.Transaction.GetAmount() == 51);
        }

        [TestMethod]
        public void GalaxyInputParser_Parse_Failed()
        {
            var inputLine = GalaxyInputLineParser.Instance.Parse("glob is I");
            var digitCondition = inputLine as DigitCondition<GalaxyDigit>;
            if (digitCondition != null)
            {
                digitCondition.Process();
            }

            inputLine = GalaxyInputLineParser.Instance.Parse(
                "how much wood could a woodchuck chuck if a woodchuck could chuck wood");
            Assert.AreEqual(inputLine.GetType(), typeof (UnrecognizedInputLine));

            inputLine = GalaxyInputLineParser.Instance.Parse("glob 123 is I");
            Assert.AreEqual(inputLine.GetType(), typeof (UnrecognizedInputLine));

            inputLine = GalaxyInputLineParser.Instance.Parse("glob is 34 Credits");
            Assert.AreEqual(inputLine.GetType(), typeof (UnrecognizedInputLine));

            inputLine = GalaxyInputLineParser.Instance.Parse("how much is glob 123 glob ?");
            Assert.AreEqual(inputLine.GetType(), typeof (UnrecognizedInputLine));

            inputLine = GalaxyInputLineParser.Instance.Parse("how many Credits is glob glob glob Silver 123 ?");
            Assert.AreEqual(inputLine.GetType(), typeof (UnrecognizedInputLine));

            inputLine = GalaxyInputLineParser.Instance.Parse("how many Credits is glob * glob glob Silver?");
            Assert.AreEqual(inputLine.GetType(), typeof (UnrecognizedInputLine));
        }
    }
}
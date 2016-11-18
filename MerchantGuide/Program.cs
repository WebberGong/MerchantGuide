using System;
using MerchantGuide.InputLineParser;
using MerchantGuide.Numeral;

namespace MerchantGuide
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ParseInput("./Resource/GalaxyInput.txt", GalaxyInputLineParser.Instance, GalaxyDigitFactory.Instance);
            Console.WriteLine(new string('-', 40));
            ParseInput("./Resource/ArabInput.txt", ArabInputLineParser.Instance, ArabDigitFactory.Instance);

            var read = Console.Read();
        }

        private static void ParseInput<TDigit>(string inputPath, InputParser<TDigit> parser,
            DigitFactory<TDigit> factory) where TDigit : Digit
        {
            var inputLines = Utility.ReadTxt(inputPath);
            foreach (var txt in inputLines)
            {
                try
                {
                    var inputLine = parser.Parse(txt);
                    inputLine.Excute();
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message +
                                      (ex.InnerException == null ? string.Empty : "\r\n" + ex.InnerException.Message));
                }
            }
        }
    }
}
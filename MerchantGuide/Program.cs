using System;
using MerchantGuide.InputLineParser;
using MerchantGuide.Numeral;

namespace MerchantGuide
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ProcessInput("./Resource/GalaxyInput.txt", GalaxyInputLineParser.Instance);
            Console.WriteLine(new string('-', 40));
            ProcessInput("./Resource/ArabInput.txt", ArabInputLineParser.Instance);

            var read = Console.Read();
        }

        private static void ProcessInput<TDigit>(string inputPath, InputParser<TDigit> parser) where TDigit : Digit
        {
            var inputLines = Utility.ReadTxt(inputPath);
            foreach (var txt in inputLines)
            {
                try
                {
                    var inputLine = parser.Parse(txt);
                    inputLine.Process();
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
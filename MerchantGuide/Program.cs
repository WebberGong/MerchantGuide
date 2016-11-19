using System;
using MerchantGuide.Digit;
using MerchantGuide.Input;
using MerchantGuide.InputLineParser;

namespace MerchantGuide
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var galaxyInput = new Input<GalaxyDigit>("./Resource/GalaxyInput.txt", GalaxyInputLineParser.Instance);
            galaxyInput.Process();
            //Console.WriteLine(new string('-', 40));
            //var arabInput = new Input<ArabDigit>("./Resource/ArabInput.txt", ArabInputLineParser.Instance);
            //arabInput.Process();

            var read = Console.Read();
        }
    }
}
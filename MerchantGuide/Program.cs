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

            var read = Console.Read();
        }
    }
}
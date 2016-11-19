using System;
using System.Collections.Generic;
using MerchantGuide.InputLineParser;

namespace MerchantGuide.Input
{
    /// <summary>
    ///     输入对象
    /// </summary>
    /// <typeparam name="TDigit"></typeparam>
    public class Input<TDigit> where TDigit : Digit.Digit
    {
        public Input(string filePath, InputParser<TDigit> parser)
        {
            InputLines = Utility.ReadTxt(filePath);
            Parser = parser;
        }

        public Input(IList<string> inputLines, InputParser<TDigit> parser)
        {
            InputLines = inputLines;
            Parser = parser;
        }

        public IList<string> InputLines { get; private set; }

        public InputParser<TDigit> Parser { get; private set; }

        public void Process()
        {
            foreach (var txt in InputLines)
            {
                try
                {
                    var inputLine = Parser.Parse(txt);
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
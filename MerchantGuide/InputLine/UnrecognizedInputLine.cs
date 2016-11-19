using System;

namespace MerchantGuide.InputLine
{
    /// <summary>
    ///     不可识别的输入行
    /// </summary>
    public class UnrecognizedInputLine : InputLine
    {
        private const string Message = "I have no idea what you are talking about";

        public UnrecognizedInputLine(string content) : base(content)
        {
        }

        public override void Process()
        {
            Console.WriteLine(Message);
        }
    }
}
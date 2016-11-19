namespace MerchantGuide.InputLine
{
    /// <summary>
    ///     输入行
    /// </summary>
    public abstract class InputLine
    {
        protected InputLine(string content)
        {
            Content = content;
        }

        public string Content { get; private set; }

        public abstract void Process();
    }
}
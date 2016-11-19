using MerchantGuide.Transaction;

namespace MerchantGuide.InputLine
{
    /// <summary>
    ///     交易问题
    /// </summary>
    public class TransactionQuestion<TDigit> : InputLine where TDigit : Digit.Digit
    {
        public TransactionQuestion(string content, Transaction<TDigit> transaction)
            : base(content)
        {
            Transaction = transaction;
        }

        public Transaction<TDigit> Transaction { get; private set; }

        public override void Process()
        {
            Transaction.Print();
        }
    }
}
using MerchantGuide.Numeral;
using MerchantGuide.Transaction;

namespace MerchantGuide.InputLine
{
    /// <summary>
    ///     交易问题
    /// </summary>
    public class TransactionQuestion<T> : InputLine where T : Digit
    {
        public TransactionQuestion(string content, Transaction<T> transaction)
            : base(content)
        {
            Transaction = transaction;
        }

        public Transaction<T> Transaction { get; private set; }

        public override void Process()
        {
            Transaction.Print();
        }
    }
}
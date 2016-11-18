using MerchantGuide.Commodity;

namespace MerchantGuide.InputLine
{
    /// <summary>
    ///     商品设置条件
    /// </summary>
    public class CommodityCondition : InputLine
    {
        public CommodityCondition(string content, string commodityName, int number, decimal totalAmount)
            : base(content)
        {
            CommodityName = commodityName;
            Number = number;
            TotalAmount = totalAmount;
        }

        public string CommodityName { get; private set; }

        public int Number { get; private set; }

        public decimal TotalAmount { get; private set; }

        public override void Excute()
        {
            CommodityFactory.Instance.SetPrice(CommodityName, TotalAmount/Number);
        }
    }
}
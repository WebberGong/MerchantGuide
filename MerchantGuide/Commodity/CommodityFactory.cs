using System.Collections.Generic;

namespace MerchantGuide.Commodity
{
    /// <summary>
    ///     商品工厂
    /// </summary>
    public class CommodityFactory
    {
        private static CommodityFactory _instance;
        private static readonly object Locker = new object();
        private readonly IDictionary<string, Commodity> _commodities = new Dictionary<string, Commodity>();

        private CommodityFactory()
        {
        }

        public static CommodityFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new CommodityFactory();
                        }
                    }
                }
                return _instance;
            }
        }

        public int Count
        {
            get { return _commodities.Count; }
        }

        public Commodity GetCommodity(string name)
        {
            if (_commodities.ContainsKey(name))
            {
                return _commodities[name];
            }
            var commodity = new Commodity(name, default(decimal));
            _commodities.Add(name, commodity);
            return commodity;
        }

        public void SetPrice(string name, decimal price)
        {
            var commodity = GetCommodity(name);
            commodity.Price = price;
        }

        public void Clear()
        {
            _commodities.Clear();
        }
    }
}
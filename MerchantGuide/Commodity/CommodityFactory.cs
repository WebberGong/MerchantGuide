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
        private readonly IDictionary<string, Commodity> _commoditieDictionary = new Dictionary<string, Commodity>();

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
            get { return _commoditieDictionary.Count; }
        }

        public Commodity GetCommodity(string name)
        {
            if (_commoditieDictionary.ContainsKey(name))
            {
                return _commoditieDictionary[name];
            }
            var commodity = new Commodity(name, default(decimal));
            _commoditieDictionary.Add(name, commodity);
            return commodity;
        }

        public void SetPrice(string name, decimal price)
        {
            var commodity = GetCommodity(name);
            commodity.Price = price;
        }

        public void Clear()
        {
            _commoditieDictionary.Clear();
        }
    }
}
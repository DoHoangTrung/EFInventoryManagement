using QuanLyKhoHang.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAO
{
    public class ProductCanSellDAO
    {
        private InventoryContext db = new InventoryContext();
        private ProductCanSellDAO() { }

        private static ProductCanSellDAO instance;

        public static ProductCanSellDAO Instance
        {
            get { if (instance == null) instance = new ProductCanSellDAO(); return instance; }
            private set { }
        }

        public List<ProductCanSellView> GetProductCanSell()
        {
            var canSell = (from p in db.ProductCanSellViews
                           select p).ToList();
            return canSell;
        }

        public List<ProductCanSellView> GetProductCanSellByType(string idType)
        {
            var canSell = (from p in db.ProductCanSellViews
                           where p.IDType == idType
                           select p).ToList();
            return canSell;
        }

        public ProductCanSellView GetProductCanSellByProductID(string idProduct)
        {
            return db.ProductCanSellViews.Where(p => p.ProductID == idProduct).FirstOrDefault();
        }
    }
}

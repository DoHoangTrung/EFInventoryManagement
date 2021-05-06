using QuanLyKhoHang.Entity;
using QuanLyKhoHang.Entity_EF;
using QuanLyKhoHang.Entity_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAO
{
    public class ProductCanSellDTO
    {
        private InventoryContext db = new InventoryContext();
        private ProductCanSellDTO() { }

        private static ProductCanSellDTO instance;

        public static ProductCanSellDTO Instance
        {
            get { if (instance == null) instance = new ProductCanSellDTO(); return instance; }
            private set { }
        }

        public List<ProductCanSellDAT> GetProductCanSellByType(string idType)
        {
            
        }

    }
}

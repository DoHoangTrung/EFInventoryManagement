using QuanLyKhoHang.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAO
{
    public class ProductTypeDAO
    {
        InventoryContext db = new InventoryContext();

        private static ProductTypeDAO instance;
        public static ProductTypeDAO Instance
        {
            get { if (instance == null) instance = new ProductTypeDAO(); return instance; }
            private set { }
        }

        public List<ProductType> GetListProductTypes()
        {
            List<ProductType> productTypes = db.ProductTypes.ToList();
            return productTypes;
        }

        public string GetIDByName(string name)
        {
            string id = (from pt in db.ProductTypes
                         where pt.Name == name
                         select pt.ID).FirstOrDefault<string>();
            return id;
        }

        public string GetTypeByID(string id)
        {
            string name = (from pt in db.ProductTypes
                           where pt.ID == id
                           select pt.Name).FirstOrDefault<string>();

            return name;
        }

        
    }
}

using QuanLyKhoHang.DTO;
using QuanLyKhoHang.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAO
{
    
    public class ProductDAO
    {
        private static ProductDAO instance;
        public static ProductDAO Instance 
        { 
            get 
            {
                if (instance == null) instance = new ProductDAO(); return instance;
            } 
            private set { } 
        }

        InventoryContext db = new InventoryContext();

        public List<Product> GetListProduct()
        {
            List<Product> products = new List<Product>();
            products = db.Products.ToList();

            return products;
        }

        public List<ProductAndType> GetListProductAndType()
        {
            var products = (from p in db.Products
                            join t in db.ProductTypes
                            on p.IdType equals t.ID
                            select new ProductAndType()
                            {
                                ProductField = p,
                                TypeField = t.Name
                            }
                            ).ToList();

            return products;
        }

        public int InsertProduct(string id, string name, string unit, string typeID)
        {
            int rowAffected = 0;

            Product product = new Product();
            product.ID = id;
            product.Name = name;
            product.Unit = unit;
            product.IdType = typeID;

            db.Products.Add(product);
            rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public int UpdateProduct(string id, string name, string unit, string typeID)
        {
            int rowAffected = 0;

            Product product = db.Products.Find(id);
            product.Name = name;
            product.Unit = unit;
            product.IdType = typeID;

            rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public int DeleteProductByID(string id)
        {
            int rowAffected = 0;

            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public List<string> GetListProductID()
        {
            List<string> IDs = (from p in db.Products
                                select p.ID).ToList();
            return IDs;
        }

        public bool IsIDDuplicate(string id)
        {
            bool check = false;
            List<string> list = GetListProductID();
            foreach (string s in list)
            {
                if (id == s)
                {
                    check = true;
                    break;
                }

            }
            return check;
        }
    }
}

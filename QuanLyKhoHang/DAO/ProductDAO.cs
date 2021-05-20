using PagedList;
using QuanLyKhoHang.DTO;
using QuanLyKhoHang.Entity;
using QuanLyKhoHang.Helper;
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
            if (!string.IsNullOrEmpty(name))
            {
                int rowAffected = 0;

                Product product = db.Products.Find(id);
                product.Name = name;
                product.Unit = unit;
                product.IdType = typeID;

                rowAffected = db.SaveChanges();

                return rowAffected;
            }
            return -1;
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

        public Product GetProductByID(string id)
        {
            return db.Products.Find(id);
        }

        public List<Product> GetListProductOutOfReceiveVoucher(string idReceiveVoucher)
        {
            List<string> iDProductsInVoucher = (from v in db.ReceiveVoucherInfoes
                                                where v.IDReceiveVoucher == idReceiveVoucher
                                                select v.IDProduct).ToList();

            //get product not in receive voucher
            List<Product> products = db.Products.Where(p => !iDProductsInVoucher.Contains(p.ID)).ToList();

            return products;
        }

        public string GetNameByID(string idProduct)
        {
            string name = (from p in db.Products
                           where p.ID == idProduct
                           select p.Name).FirstOrDefault();
            return name;
        }

        public List<ProductDTO> GetList(SearchModel seachModel, int pageNum =1, int pageSize = Const.pageSize)
        {
            var products = db.Database.SqlQuery<ProductDTO>("select * from ProductDTO").ToList();

            //search by key words
            if (!string.IsNullOrEmpty(seachModel.KeyWords))
            {
                products = products.Where(
                    p =>
                    {
                        string str, keyW;// find s1 in s0
                        str = p.ID + " " + p.Name + " " + p.Unit + " " + p.TypeName;
                        keyW = seachModel.KeyWords;

                        str = str.Format();
                        keyW = keyW.Format();

                        if (str.Contains(keyW))
                            return true;
                        else
                            return false;
                    }
                ).Select(p=>p).ToList();
            }

            return products;
        }


    }
}

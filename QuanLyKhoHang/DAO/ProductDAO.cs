using PagedList;
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

        public List<Product> Search(string keyWord)
        {
            List<Product> products = db.Products.ToList();

            var result = products.Where(
                    p =>
                    {
                        string str, keyW;// find s1 in s0
                        str = p.ID + " " + p.Name + " " + p.Unit + " " + p.ProductType.Name;
                        keyW = keyWord;

                        str = str.Format();
                        keyW = keyW.Format();

                        if (str.Contains(keyW))
                            return true;
                        else
                            return false;
                    }
                ).Select(p => p).ToList();

            return result;
        }

        public async Task<IPagedList<ProductDTO>> GetPagedListProductDTOs(int pageNum = 1, int pageSize = 10)
        {
            return await Task.Run(() =>
            {
                var productDTOs = (from p in db.Products
                                   join t in db.ProductTypes on p.IdType equals t.ID
                                   select new ProductDTO()
                                   {
                                       ID = p.ID,
                                       Name = p.Name,
                                       Unit = p.Unit,
                                       TypeName = t.Name
                                   }).OrderBy(p => p.ID).ToPagedList(pageNum, pageSize);
                return productDTOs;
            });
        }
    }
}

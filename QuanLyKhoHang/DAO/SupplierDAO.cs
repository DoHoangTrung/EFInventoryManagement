using PagedList;
using QuanLyKhoHang.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAL
{
    public class SupplierDAO
    {
        private InventoryContext db = new InventoryContext();
        private SupplierDAO() { }

        private static SupplierDAO instance;

        public static SupplierDAO Instance
        {
            get { if (instance == null) instance = new SupplierDAO(); return instance; }
            private set { }
        }

        public List<Supplier> GetListSupplier()
        {
            List<Supplier> suppliers = new List<Supplier>();

            suppliers = db.Suppliers.ToList();

            return suppliers;
        }

        public int InsertSupplier(string id, string name, string address, string phoneNumber, string email)
        {
            Supplier supplier = new Supplier();
            supplier.ID = id;
            supplier.Name = name;
            supplier.Address = address;
            supplier.Phone = phoneNumber;
            supplier.Email = email;
            db.Suppliers.Add(supplier);

            int rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public int DeleteSupplier(string id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);

            int rowAffected = db.SaveChanges();
            return rowAffected;
        }

        public int UpdateSupplier(string id, string name, string address, string phoneNumber, string email)
        {
            int rowAffected = 0;

            Supplier supplier = db.Suppliers.Find(id);

            supplier.Name = name;
            supplier.Address = address;
            supplier.Phone = phoneNumber;
            supplier.Email = email;

            rowAffected = db.SaveChanges();
            return rowAffected;
        }

        public List<string> GetListSupplierID()
        {
            List<string> listID = (from s in db.Suppliers
                          select s.ID).ToList();

            return listID;
        }

        public bool CheckID(string _id)
        {
            bool ANDCondition = true;

            bool checkLenght;
            if (_id.Length == 0 || _id.Length > 30)
            {
                checkLenght = false;
            }
            else
            {
                checkLenght = true;
            }

            bool Duplicate = false;
            List<string> listID = SupplierDAO.Instance.GetListSupplierID();
            foreach (string id in listID)
            {
                if (_id == id)
                {
                    Duplicate = true;
                    break;
                }
            }

            ANDCondition = checkLenght && !Duplicate;
            return ANDCondition;
        }

        public string GetNameByID(string idSupplier)
        {
            Supplier supplier = db.Suppliers.Find(idSupplier);
            return supplier.Name;
        }

        public List<Supplier> Search(string keyWord)
        {
            List<Supplier> suppliers = db.Suppliers.ToList();

            var result = suppliers.Where(
                    s =>
                    {
                        string str, keyW;// find s1 in s0
                        str = s.ID + " " + s.Name + " " + s.Address + " " + s.Email + s.Phone;
                        keyW = keyWord;

                        str = str.Format();
                        keyW = keyW.Format();

                        if (str.Contains(keyW))
                            return true;
                        else
                            return false;
                    }
                ).Select(s => s).ToList();

            return result;
        }

        public async Task<IPagedList<Supplier>> GetPagedList(int pageNum =1, int pageSize=20)
        {
            return await Task.Run(() =>
            {
                var data = db.Suppliers.ToList();
                return data.ToPagedList<Supplier>(pageNum, pageSize);
            });
        }
    }
}

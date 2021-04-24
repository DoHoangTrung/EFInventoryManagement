using QuanLyKhoHang.DAT;
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

        public DataTable GetSupplier()
        {
            string query = "select * from NhaCungCap";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public List<Supplier1> GetListSupplier1()
        {
            DataTable dt = GetSupplier();
            List<Supplier1> list = new List<Supplier1>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Supplier1(row));
            }
            return list;
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

        public Supplier1 GetSupplierByID(string id)
        {
            string query = $"select * from NhaCungCap where id = '{id}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            if (dt != null)
            {
                Supplier1 supplier = new Supplier1(dt.Rows[0]);
                return supplier;
            }
            return null;
        }

        public List<Supplier1> SearchSupplier( string idSearch, string nameSearch, string addressSearch, string phoneNumberSearch, string emailSearch)
        {
            List<Supplier1> suppliers = GetListSupplier1();
            IEnumerable<Supplier1> searchList = null;
            if (idSearch != "")
            {
                searchList = suppliers.Where(sp =>
                {
                    bool checkID, checkName, checkAddress, checkPhoneNumber, checkEmail;
                    checkID = sp.ID.LowerCaseAndRemoveAccents().Contains(idSearch);
                    checkName = sp.Name.LowerCaseAndRemoveAccents().Contains(nameSearch);
                    checkAddress = sp.Address.LowerCaseAndRemoveAccents().Contains(addressSearch);
                    checkPhoneNumber = sp.PhoneNumber.LowerCaseAndRemoveAccents().Contains(phoneNumberSearch);
                    checkEmail = sp.Email.LowerCaseAndRemoveAccents().Contains(emailSearch);
                    return checkID && checkName && checkAddress && checkPhoneNumber && checkEmail;
                }
                );
                return searchList.ToList();
            }
            return null;
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
    }
}

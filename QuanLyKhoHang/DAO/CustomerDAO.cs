using QuanLyKhoHang.DTO;
using QuanLyKhoHang.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAL
{
    public class CustomerDAO
    {
        InventoryContext db = new InventoryContext();

        private static CustomerDAO instance;
        private CustomerDAO() { }

        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return instance; }
            private set { }
        }

        public List<Customer> GetListCustomer()
        {
            List<Customer> customers = db.Customers.ToList();
            return customers;
        }

        public Customer NewCustomer(string id, string name, string address, string phoneNumber, string email)
        {
            Customer customer = new Customer();
            customer.ID = id;
            customer.Name = name;
            customer.Address = address;
            customer.Phone = phoneNumber;
            customer.Email = email;

            return customer;
        }
        public List<string> GetListCustomerID()
        {
            List<string> listID = (from c in db.Customers
                                  select c.ID).ToList();
            return listID;
        }

        public int InsertCustomer(string id, string name, string address, string phoneNumber, string email)
        {

            Customer customer = NewCustomer(id, name, address, phoneNumber, email);
            db.Customers.Add(customer);

            int rowAffected = db.SaveChanges();
            return rowAffected;
        }

        public int DeleteCustomer(string id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            int rowAffected = db.SaveChanges();
            return rowAffected;
        }

        public int UpdateCustomer(string id, string name, string address, string phoneNumber, string email)
        {
            Customer customer = db.Customers.Find(id);
            customer.Name = name;
            customer.Address = address;
            customer.Phone = phoneNumber;
            customer.Email = email;

            int rowAffected = db.SaveChanges();
            return rowAffected;
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

            bool notDuplicate = true;
            List<string> listID = CustomerDAO.Instance.GetListCustomerID();
            foreach (string id in listID)
            {
                if (_id == id)
                {
                    notDuplicate = false;
                    break;
                }
            }

            ANDCondition = checkLenght && notDuplicate;
            return ANDCondition;
        }

        public Customer GetCustomerByID(string idCustomer)
        {
            return db.Customers.Find(idCustomer);
        }

    }
}

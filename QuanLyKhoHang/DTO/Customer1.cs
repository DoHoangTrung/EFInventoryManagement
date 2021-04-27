using QuanLyKhoHang.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DTO
{
    public class Customer1
    {
        private string iD;
        private string name;
        private string address;
        private string phoneNumber;
        private string email;

        public Customer1(string iD, string name, string address, string phoneNumber, string email)
        {
            this.iD = iD;
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public Customer1(DataRow row)
        {
            this.iD = row["iD"].ToString();
            this.name = row["ten"].ToString();
            this.address = row["dc"].ToString();
            this.phoneNumber = row["sdt"].ToString();
            this.email = row["email"].ToString();
        }

        public string ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }

        
    }
}

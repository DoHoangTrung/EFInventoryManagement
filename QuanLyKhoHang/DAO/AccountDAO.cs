using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhoHang.DAL;
using System.Data;
using QuanLyKhoHang.Entity;

namespace QuanLyKhoHang.DAL
{
    public class AccountDAO
    { 
        private InventoryContext db;

        public AccountDAO()
        {
            db = new InventoryContext();
        }

        public bool Login(string userName, string passWord)
        {
            bool result = false;

            var account = (from a in db.Accounts
                           where a.UserName == userName && a.PassWord == passWord
                           select a).ToList();
            if(account.Count == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhoHang.DAL;
using System.Data;

namespace QuanLyKhoHang.DAL
{
    public class AccountDAO
    {
        private AccountDAO() { }

        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { }
        }

        public bool Login(string userName, string passWord)
        {
            bool check = true;
            /*string query = "exec dbo.GetAccountByUserName @userName , @passWord";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, userName, passWord);
            return data.Rows.Count > 0;*/
            return check;
        }
    }
}

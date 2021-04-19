using QuanLyKhoHang.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAO
{
    public class MyDataBase
    {
        private static MyDataBase instance;

        private MyDataBase() { }

        public static MyDataBase Instance {
            get { if (instance == null) instance = new MyDataBase(); return instance; }
            private set { }
        }

    }
}

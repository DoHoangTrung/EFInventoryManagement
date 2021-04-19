using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAT
{
    public class Good1
    {
        private string iD;
        private string name;
        private string unit;

        public Good1()
        {
            this.iD = string.Empty;
            this.name = string.Empty;
            this.unit = string.Empty;
        }

        public Good1(string iD, string name, string unit)
        {
            this.iD = iD;
            this.name = name;
            this.unit = unit;
        }

        public Good1(DataRow row)
        {
            this.iD = row["ID"].ToString();
            this.name = row["ten"].ToString();
            this.unit = row["DonVi"].ToString();
        }


        public string ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Unit { get => unit; set => unit = value; }

    }
}

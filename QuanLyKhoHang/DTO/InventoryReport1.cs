using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyKhoHang.DAT
{
    public class InventoryReport1
    {
        // tao bang join 
        private string iDGood;
        private string nameGood;
        private int sumInput;
        private int sumOutput;
        private int balanceNumber;

        public InventoryReport1(string iDGood, string nameGood, int sumInput, int sumOutput, int balanceNumber)
        {
            this.iDGood = iDGood;
            this.nameGood = nameGood;
            this.sumInput = sumInput;
            this.sumOutput = sumOutput;
            this.balanceNumber = balanceNumber;
        }
        public InventoryReport1(DataRow row)
        {
            this.iDGood = row["id san pham"].ToString();
            this.nameGood = row["ten san pham"].ToString();
            if (!int.TryParse(row["tong nhap"].ToString(), out this.sumInput)) this.sumInput = 0;
            if (!int.TryParse(row["tong xuat"].ToString(), out this.sumOutput)) this.sumOutput = 0;
            this.balanceNumber = this.sumInput - this.sumOutput;
        }


        public string IDGood { get => iDGood; set => iDGood = value; }
        public string NameGood { get => nameGood; set => nameGood = value; }
        public int SumInput { get => sumInput; set => sumInput = value; }
        public int SumOutput { get => sumOutput; set => sumOutput = value; }
        public int BalanceNumber { get => balanceNumber; set => balanceNumber = value; }
    }
}

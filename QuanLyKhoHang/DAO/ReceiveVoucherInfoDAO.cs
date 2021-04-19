using QuanLyKhoHang.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAO
{
    public class ReceiveVoucherInfoDAO
    {
        private static ReceiveVoucherInfoDAO instance;
        public static ReceiveVoucherInfoDAO Instance
        {
            get
            {
                if (instance == null) instance = new ReceiveVoucherInfoDAO(); return instance;
            }
            private set { }
        }

        InventoryContext db = new InventoryContext();

        public int InsertReceiveVoucherInfo(string idProduct,string idVoucher, int quantityInput, int priceInput, int priceOutput, int quantityOutput, string note)
        {
            int rowAffected = 0;

            ReceicveVoucherInfo voucherInfo = new ReceicveVoucherInfo();
            voucherInfo.IDProduct = idProduct;
            voucherInfo.IDReceiveVoucher = idVoucher;
            voucherInfo.QuatityInput = quantityInput;
            voucherInfo.PriceInput = priceInput;
            voucherInfo.QuatityOutput = quantityOutput;
            voucherInfo.PriceOutput = priceOutput;
            voucherInfo.Note = note;

            db.ReceicveVoucherInfoes.Add(voucherInfo);
            rowAffected = db.SaveChanges();

            return rowAffected;
        }
    }
}

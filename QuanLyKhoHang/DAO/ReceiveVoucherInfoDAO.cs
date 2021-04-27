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

        public int InsertReceiveVoucherInfo(string idProduct,string idVoucher, int quantityInput, int priceInput, int quantityOutput, string note)
        {
            int rowAffected = 0;

            ReceiveVoucherInfo voucherInfo = new ReceiveVoucherInfo();
            voucherInfo.IDProduct = idProduct;
            voucherInfo.IDReceiveVoucher = idVoucher;
            voucherInfo.QuantityInput = quantityInput;
            voucherInfo.PriceInput = priceInput;
            voucherInfo.QuantityOutput = quantityOutput;
            voucherInfo.Note = note;

            db.ReceiveVoucherInfoes.Add(voucherInfo);
            rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public int InsertReceiveVoucherInfo(ReceiveVoucherInfo infoes)
        {
            int rowAffected = 0;

            db.ReceiveVoucherInfoes.Add(infoes);

            rowAffected = db.SaveChanges();

            return rowAffected;
        }
        public int InsertReceiveVoucherInfo(List<ReceiveVoucherInfo> infoes)
        {
            int rowAffected = 0;

            foreach (var info in infoes)
            {
                db.ReceiveVoucherInfoes.Add(info);
            }

            rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public ReceiveVoucherInfo InitReceiveVoucherInfo(string idProduct, string idVoucher, int quantityInput, int priceInput, int quantityOutput, string note)
        {
            ReceiveVoucherInfo voucherInfo = new ReceiveVoucherInfo();
            voucherInfo.IDProduct = idProduct;
            voucherInfo.IDReceiveVoucher = idVoucher;
            voucherInfo.QuantityInput = quantityInput;
            voucherInfo.PriceInput = priceInput;
            voucherInfo.QuantityOutput = quantityOutput;
            voucherInfo.Note = note;

            return voucherInfo;
        }

        public int UpdateReceiveVoucherInfo(ReceiveVoucherInfo voucherInfo)
        {
            int rowAffected = 0;
            string idProduct, idVoucher;
            idProduct = voucherInfo.IDProduct;
            idVoucher = voucherInfo.IDReceiveVoucher;

            ReceiveVoucherInfo voucherInfoUpdate = db.ReceiveVoucherInfoes.Find(idProduct, idVoucher);
            voucherInfoUpdate.PriceInput = voucherInfo.PriceInput;
            voucherInfoUpdate.QuantityInput = voucherInfo.QuantityInput;
            voucherInfoUpdate.QuantityOutput = voucherInfo.QuantityOutput;
            voucherInfoUpdate.Note = voucherInfo.Note;

            rowAffected = db.SaveChanges();
            return rowAffected;
        }

        public int RemoveReceiveVoucherInfoNeverSell(string idRecevieVoucher)
        {
            int rowAffected = 0;
            var infoNeverSell = (from i in db.ReceiveVoucherInfoes
                             where i.IDReceiveVoucher == idRecevieVoucher && i.QuantityOutput == 0
                             select i).ToList();

            foreach (var info in infoNeverSell)
            {
                db.ReceiveVoucherInfoes.Remove(info);
            }

            rowAffected = db.SaveChanges();
            return rowAffected;
        }

        public int RemoveReceiveVoucherInfoByID(string idProduct,string idReceiveVoucher)
        {
            ReceiveVoucherInfo info = db.ReceiveVoucherInfoes.Find(idProduct, idReceiveVoucher);
            db.ReceiveVoucherInfoes.Remove(info);
            int rowAffected = db.SaveChanges();
            return rowAffected;
        }

        public List<ReceiveVoucherInfo> GetReceiveVoucherInfos()
        {
            return db.ReceiveVoucherInfoes.ToList();
        }
    }
}

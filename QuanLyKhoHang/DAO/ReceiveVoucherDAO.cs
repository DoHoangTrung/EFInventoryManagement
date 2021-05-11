using QuanLyKhoHang.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAO
{
    public class ReceiveVoucherDAO
    {
        private static ReceiveVoucherDAO instance;

        InventoryContext db = new InventoryContext();

        public static ReceiveVoucherDAO Instance
        {
            get { if (instance == null) instance = new ReceiveVoucherDAO(); return instance; }
            set { }
        }

        #region method
        public List<ReceiveVoucher> GetListReceiveVoucher()
        {
            List<ReceiveVoucher> receiveVouchers = db.ReceiveVouchers.ToList();

            foreach (var voucher in receiveVouchers)
            {
                // a receive voucher has a list receiveVoucherInfos, a receiveVoucherInfos has a product
                List<ReceiveVoucherInfo> voucherInfos = (from info in db.ReceiveVoucherInfoes
                                                         where info.IDReceiveVoucher == voucher.ID
                                                         select info).ToList();

                foreach (var vInfo in voucherInfos)
                {
                    Product product = db.Products.Find(vInfo.IDProduct);
                    vInfo.Product = product;
                }

                voucher.ReceiveVoucherInfoes = voucherInfos;

                // a receive voucher have a supplier
                Supplier supplier = db.Suppliers.Find(voucher.IDSupplier);
                voucher.Supplier = supplier;

            }

            return receiveVouchers;
        }

        public List<ReceiveVoucherInfo> Search(string keyWord)
        {
            List<ReceiveVoucherInfo> receiveVoucherInfos = db.ReceiveVoucherInfoes.ToList();
            var searchList = receiveVoucherInfos.Where((i) =>
            {
                //find keywords in text
                string text, key;
                text = i.IDReceiveVoucher + " " + i.IDProduct + " " + i.Product.Name + " " + i.Product.Unit + " "
                + i.Note + " " + i.ReceiveVoucher.ID + " " + i.ReceiveVoucher.Supplier.Name + " " + i.ReceiveVoucher.Supplier.Phone
                + " " + i.ReceiveVoucher.Supplier.Address + " " + i.ReceiveVoucher.Supplier.Email;
                key = keyWord;

                text = text.Format();
                key = key.Format();

                if (text.Contains(key))
                    return true;
                else
                    return false;
            }).Select(i => i).ToList();

            return searchList;
        }

        public List<string> GetListID()
        {
            List<string> IDs = (from v in db.ReceiveVouchers
                                select v.ID).ToList<string>();
            return IDs;
        }

        public bool CheckID(string _id)
        {
            bool result = true;

            bool checkLength = true;
            if (_id.Length == 0 || _id.Length > 30)
            {
                checkLength = false;
            }

            bool notDuplicate = true;
            List<string> listID = GetListID();
            foreach (string id in listID)
            {
                if (_id == id)
                {
                    notDuplicate = false;
                    break;
                }
            }

            result = checkLength && notDuplicate;
            return result;
        }

        public int InserReceivetVoucher(string id, DateTime date, string IDSupplier)
        {
            int rowAffected = 0;

            ReceiveVoucher v = new ReceiveVoucher();
            v.ID = id;
            v.Date = date;
            v.IDSupplier = IDSupplier;

            db.ReceiveVouchers.Add(v);
            rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public ReceiveVoucher GetReceiveVoucherAllInfoByID(string id)
        {
            ReceiveVoucher voucher = db.ReceiveVouchers.Find(id);
            //a receive voucher has a supplier
            voucher.Supplier = db.Suppliers.Find(voucher.IDSupplier);

            //a receive voucher has a list of infomation
            voucher.ReceiveVoucherInfoes = (from i in db.ReceiveVoucherInfoes
                                            where i.IDReceiveVoucher == voucher.ID
                                            select i).ToList();
            foreach (var vInfo in voucher.ReceiveVoucherInfoes)
            {
                //in a voucher information has a product 
                vInfo.Product = db.Products.Find(vInfo.IDProduct);
            }

            return voucher;
        }

        public int UpdateReceiveVoucher(ReceiveVoucher voucherUpdate)
        {
            int rowAffected = 0;
            string idVoucher = voucherUpdate.ID;

            ReceiveVoucher voucher = db.ReceiveVouchers.Find(idVoucher);
            voucher.IDSupplier = voucherUpdate.IDSupplier;
            voucher.Date = voucherUpdate.Date;

            rowAffected = db.SaveChanges();

            return rowAffected;
        }

        public bool HaveTheProductBeenSold(string idVoucher)
        {
            bool check = false;

            ReceiveVoucher voucher = GetReceiveVoucherAllInfoByID(idVoucher);
            foreach (var info in voucher.ReceiveVoucherInfoes)
            {
                if (info.QuantityOutput > 0) check = true;
                break;
            }

            return check;
        }

        public int RemoveReceiveVoucher(string idVoucher)
        {
            int rowAffected = 0;
            //we check HaveTheProductBeenSold before event remove fire
            ReceiveVoucher voucher = GetReceiveVoucherAllInfoByID(idVoucher);

            //step1: remove voucher info 
            foreach (var info in voucher.ReceiveVoucherInfoes)
            {
                ReceiveVoucherInfoDAO.Instance.RemoveReceiveVoucherInfoByID(info.IDProduct, info.IDReceiveVoucher);
            }
            //step2: remove voucher
            db.ReceiveVouchers.Remove(voucher);

            rowAffected = db.SaveChanges();
            
            return rowAffected;
        }
        #endregion
    }
}

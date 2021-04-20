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
                List<ReceicveVoucherInfo> voucherInfos = (from info in db.ReceicveVoucherInfoes
                                                   where info.IDReceiveVoucher == voucher.ID
                                                   select info).ToList();

                foreach (var vInfo in voucherInfos)
                {
                    Product product = db.Products.Find(vInfo.IDProduct);
                    vInfo.Product = product;
                }
                
                voucher.ReceicveVoucherInfoes = voucherInfos;

                // a receive voucher have a supplier
                Supplier supplier = db.Suppliers.Find(voucher.IDSupplier);
                voucher.Supplier = supplier;

            }

            return receiveVouchers;
        }

        public List<string> GetListID()
        {
            List<string> IDs =( from v in db.ReceiveVouchers
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
            voucher.ReceicveVoucherInfoes = (from i in db.ReceicveVoucherInfoes
                                                      where i.IDReceiveVoucher == voucher.ID
                                                      select i).ToList();
            foreach (var vInfo in voucher.ReceicveVoucherInfoes)
            {
                //in a voucher information has a product 
                vInfo.Product = db.Products.Find(vInfo.IDProduct);
            }

            return voucher;
        }

        

        #endregion
    }
}

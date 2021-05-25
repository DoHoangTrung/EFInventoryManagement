using QuanLyKhoHang.DAL;
using QuanLyKhoHang.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAO
{
    public class DeliveryVoucherDAO
    {
        private InventoryContext db = new InventoryContext();

        private static DeliveryVoucherDAO instance;

        public static DeliveryVoucherDAO Instance
        {
            get { if (instance == null) instance = new DeliveryVoucherDAO(); return instance; }
            private set { }
        }

        public List<DeliveryVoucher> GetDeliveryVouchersAllInfo()
        {
            List<DeliveryVoucher> deliveryVouchers = db.DeliveryVouchers.ToList();
            foreach (var voucher in deliveryVouchers)
            {
                Customer customerInVoucher = CustomerDAO.Instance.GetByID(voucher.IDCustomer);
                voucher.Customer = customerInVoucher;

                List<DeliveryVoucherInfo> deliveryVoucherInfos = DeliveryVoucherInfoDAO.Instance.GetDeliveryVoucherInfosByIDVoucher(voucher.ID);
                foreach (var info in deliveryVoucherInfos)
                {
                    Product productInVoucher = ProductDAO.Instance.GetByID(info.IDProduct);
                    info.Product = productInVoucher;
                }

                voucher.DeliveryVoucherInfoes = deliveryVoucherInfos;
            }

            return deliveryVouchers;
        }

        public DeliveryVoucher GetByID(string idVoucher)
        {
            DeliveryVoucher deliveryVouchers = db.DeliveryVouchers.Find(idVoucher);

            return deliveryVouchers;
        }

        public List<string> GetListID()
        {
            var ids = (from v in db.DeliveryVouchers
                       select v.ID).ToList();
            return ids;
        }

        public void Insert(string idVoucher, string idCustomer, DateTime date,List<DeliveryVoucherInfo> voucherInfos)
        {
            DeliveryVoucher newVoucher = new DeliveryVoucher();
            newVoucher.ID = idVoucher;
            newVoucher.Date = date;
            newVoucher.IDCustomer = idCustomer;
            foreach (var info in voucherInfos)
            {
                newVoucher.DeliveryVoucherInfoes.Add(info);
            }
            db.DeliveryVouchers.Add(newVoucher);
            db.SaveChanges();
            db.Entry(newVoucher).Reference(p => p.Customer).Load();
        }

        public List<DeliveryVoucher> GetList()
        {
            return db.DeliveryVouchers.ToList();
        }

        public int DeleteByID(string idDeliveryVoucher)
        {
            int rowAffected = 0;
            DeliveryVoucher voucher = db.DeliveryVouchers.Find(idDeliveryVoucher);
            int row = db.DeliveryVoucherInfoes.Count();
            if (voucher != null)
            {
                if (voucher.DeliveryVoucherInfoes.Count > 0)
                {
                    foreach (var info in voucher.DeliveryVoucherInfoes.ToList())
                    {
                        voucher.DeliveryVoucherInfoes.Remove(info);
                    }
                }

                DeliveryVoucher v = db.DeliveryVouchers.Find(idDeliveryVoucher);

                db.DeliveryVouchers.Remove(voucher);
                rowAffected = db.SaveChanges();
            }

            return rowAffected;
        }
    }
}
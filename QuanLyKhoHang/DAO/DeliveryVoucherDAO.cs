using QuanLyKhoHang.DAL;
using QuanLyKhoHang.Entity;
using System;
using System.Collections.Generic;
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
                Customer customerInVoucher = CustomerDAO.Instance.GetCustomerByID(voucher.IDCustomer);
                voucher.Customer = customerInVoucher;

                List<DeliveryVoucherInfo> deliveryVoucherInfos = DeliveryVoucherInfoDAO.Instance.GetDeliveryVoucherInfosByIDVoucher(voucher.ID);
                foreach (var info in deliveryVoucherInfos)
                {
                    Product productInVoucher = ProductDAO.Instance.GetProductByID(info.IDProduct);
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

        public void Insert(DeliveryVoucher v)
        {
            if (v != null)
            {
                db.DeliveryVouchers.Add(v);
                db.SaveChanges();
            }
        }

        public List<DeliveryVoucher> GetList()
        {
            return db.DeliveryVouchers.ToList();
        }

        public void DeleteByID(string idDeliveryVoucher)
        {
            DeliveryVoucher voucher = db.DeliveryVouchers.Find(idDeliveryVoucher);
            if(voucher.DeliveryVoucherInfoes != null)
            {
                db.DeliveryVouchers.Remove(voucher);
                db.SaveChanges();
            }
            else
            {
                db.DeliveryVoucherInfoes.RemoveRange(voucher.DeliveryVoucherInfoes);
                db.DeliveryVouchers.Remove(voucher);
                db.SaveChanges();
            }
        }
    }
}
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
        public DeliveryVoucher GetDeliveryVouchersAllInfoByID(string idVoucher)
        {
            DeliveryVoucher deliveryVouchers = db.DeliveryVouchers.Find(idVoucher);
            Customer customerInVoucher = CustomerDAO.Instance.GetCustomerByID(deliveryVouchers.IDCustomer);
            deliveryVouchers.Customer = customerInVoucher;

            List<DeliveryVoucherInfo> deliveryVoucherInfos = DeliveryVoucherInfoDAO.Instance.GetDeliveryVoucherInfosByIDVoucher(deliveryVouchers.ID);
            foreach (var info in deliveryVoucherInfos)
            {
                Product productInVoucher = ProductDAO.Instance.GetProductByID(info.IDProduct);
                info.Product = productInVoucher;
            }

            deliveryVouchers.DeliveryVoucherInfoes = deliveryVoucherInfos;

            return deliveryVouchers;
        }
    }
}
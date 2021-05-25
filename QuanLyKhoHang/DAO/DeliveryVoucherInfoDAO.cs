using QuanLyKhoHang.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAO
{
    public class DeliveryVoucherInfoDAO
    {
        private InventoryContext db = new InventoryContext();

        private static DeliveryVoucherInfoDAO instance;

        public static DeliveryVoucherInfoDAO Instance
        {
            get { if (instance == null) instance = new DeliveryVoucherInfoDAO(); return instance; }
            set { }
        }

        public List<DeliveryVoucherInfo> GetDeliveryVoucherInfosByIDVoucher(string idVoucher)
        {
            List<DeliveryVoucherInfo> deliveryVoucherInfos = (from i in db.DeliveryVoucherInfoes
                                                              where i.IDDeliveryVoucher == idVoucher
                                                              select i).ToList();
            return deliveryVoucherInfos;
        }

        public void Insert(DeliveryVoucherInfo info)
        {
            if (info != null)
            {
                db.DeliveryVoucherInfoes.Add(info);
                db.SaveChanges();
                db.Entry(info).Reference(i=>i.DeliveryVoucher).Load();
            }
        }


        public int Delete (DeliveryVoucherInfo _info)
        {
            int rowAffected = 0;
            DeliveryVoucherInfo info = db.DeliveryVoucherInfoes.Find(_info.IDProduct, _info.IDDeliveryVoucher, _info.IDReceiveVoucher);
            if(info!= null)
            {
                db.DeliveryVoucherInfoes.Remove(info);
                rowAffected = db.SaveChanges();
            }

            return rowAffected;
        }
    }
}
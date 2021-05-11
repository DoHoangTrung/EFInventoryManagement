using QuanLyKhoHang.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAO
{
    public class DeliveryVoucherInfoViewDAO
    {
        private InventoryContext db;
        public DeliveryVoucherInfoViewDAO()
        {
            db = new InventoryContext();
        }

        public List<DeliveryVoucherInfoView> GetListByIDVoucher(string deliveryVoucherID)
        {
            var dataQuery = (from v in db.DeliveryVoucherInfoViews
                             where v.DeliveryVoucherID == deliveryVoucherID
                             select v).ToList();
            return dataQuery;
        }
    }
}

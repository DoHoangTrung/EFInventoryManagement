using QuanLyKhoHang.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAO
{
    public class DeliveryVoucherViewDAO
    {
        private InventoryContext db;
        public DeliveryVoucherViewDAO()
        {
            db = new InventoryContext();
        }

        public List<DeliveryVoucherView> GetList()
        {
            return db.DeliveryVoucherViews.ToList();
        }

        public List<DeliveryVoucherView> Search(string keyWord)
        {
            List<DeliveryVoucherView> voucherViews = db.DeliveryVoucherViews.ToList();

            var searchList = voucherViews.Where((v) =>
            {
                //find keywords in text
                string text, key;
                text = v.VoucherID + " " + v.ProductName + " " + v.Unit + " " + v.CustomerName + " "
                + v.Phone + " " + v.ProductID + " " + v.CustomerID;
                key = keyWord;

                text = text.Format();
                key = key.Format();

                if (text.Contains(key))
                    return true;
                else
                    return false;
            }).Select(v => v).ToList();

            return searchList;
        }
    }
}

using PagedList;
using QuanLyKhoHang.Entity;
using QuanLyKhoHang.Helper;
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

        public List<DeliveryVoucherView> SearchByWords(string keyWord)
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
        public List<DeliveryVoucherView> SearchByWords(List<DeliveryVoucherView> voucherViews, string keyWord)
        {
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

        public List<DeliveryVoucherView> SearchByTimeRange(DateTime fromTime, DateTime toTime)
        {
            List<DeliveryVoucherView> voucherViews = db.DeliveryVoucherViews.ToList();

            var result = voucherViews.Where((v) =>
            {
                return v.Date >= fromTime && v.Date <= toTime;
            }).Select(v => v).ToList();

            return result;
        }
        public List<DeliveryVoucherView> SearchByTimeRange(List<DeliveryVoucherView> voucherViews, DateTime fromTime, DateTime toTime)
        {
            var result = voucherViews.Where((v) =>
            {
                return v.Date >= fromTime && v.Date <= toTime;
            }).Select(v => v).ToList();

            return result;
        }

        public List<DeliveryVoucherView> GetList(SearchModel searchModel)
        {
            var vouchers = db.DeliveryVoucherViews.ToList();

            if (!string.IsNullOrEmpty(searchModel.KeyWords))
            {
                vouchers = vouchers.Where((v) =>
                {
                    //find keywords in text
                    string text, key;
                    text = v.VoucherID + " " + v.ProductName + " " + v.Unit + " " + v.CustomerName + " "
                    + v.Phone + " " + v.ProductID + " " + v.CustomerID;
                    key = searchModel.KeyWords;

                    text = text.Format();
                    key = key.Format();

                    if (text.Contains(key))
                        return true;
                    else
                        return false;
                }).Select(v => v).ToList();
            }

            if (searchModel.MaxValue != null)
            {
                int max, min;
                max = (int)searchModel.MaxValue;
                min = (int)searchModel.MinValue;

                vouchers = vouchers.Where(v =>
                {
                    return min <= v.PriceOutput && v.PriceOutput <= max;

                }).Select(v => v).ToList();
            }

            if (searchModel.FromDate != null)
            {
                DateTime fromDate, toDate;
                fromDate = (DateTime)searchModel.FromDate;
                toDate = (DateTime)searchModel.ToDate;

                vouchers = vouchers.Where(v =>
                {
                    return fromDate <= v.Date && v.Date <= toDate;

                }).Select(v => v).ToList();
            }
            return vouchers;
        }
    }
}

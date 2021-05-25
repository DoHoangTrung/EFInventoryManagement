using PagedList;
using QuanLyKhoHang.DTO;
using QuanLyKhoHang.Entity;
using QuanLyKhoHang.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAO
{
    public class ReportDAO
    {
        private InventoryContext db;

        public ReportDAO()
        {
            db = new InventoryContext();
        }

        public List<ReportDTO> GetList(SearchModel searchModel)
        {
            List<ReportDTO> reports = new List<ReportDTO>();

            if (searchModel.FromDate != null)
            {
                DateTime fromDate, toDate;
                fromDate = (DateTime)searchModel.FromDate;
                toDate = (DateTime)searchModel.ToDate;

                reports = db.Database.SqlQuery<ReportDTO>(
                "EXEC ShowReportByDuration @fromDateReport ,@toDateReport",
                new SqlParameter("fromDateReport", fromDate),
                new SqlParameter("toDateReport", toDate)
                ).ToList();


                //search by duration --> search by keyWords and numbers(price)
                if (!string.IsNullOrEmpty(searchModel.KeyWords))
                {
                    reports = reports.Where((r) =>
                    {
                        //find keywords in text
                        string text, key;
                        text = r.ProductID + " " + r.ProductName + " " + r.ProductUnit;
                        key = searchModel.KeyWords;

                        text = text.Format();
                        key = key.Format();

                        if (text.Contains(key))
                            return true;
                        else
                            return false;
                    }).Select(r => r).ToList();
                }


                if (searchModel.MaxValue != null)
                {
                    int max, min;
                    max = (int)searchModel.MaxValue;
                    min = (int)searchModel.MinValue;

                    reports = reports.Where(r =>
                    {
                        bool checkReceivePrice =  min <= r.ReceivePrice && r.ReceivePrice <= max;
                        bool checkDeliveryPrice =  min <= r.DeliveryPrice && r.DeliveryPrice <= max;

                        return checkDeliveryPrice || checkDeliveryPrice;
                    }).Select(v => v).ToList();
                }
            }

            return reports;
        }

        public List<ReportDTO> GetPagedListByDuration(DateTime fromDate, DateTime toDate, int pageNum = 1, int pageSize = 20)
        {
            var reports = db.Database.SqlQuery<ReportDTO>(
                "EXEC dbo.ShowReportByDuration @fromDateReport1 ,@toDateReport1",
                new SqlParameter("fromDateReport1", fromDate),
                new SqlParameter("toDateReport1", toDate)
                ).OrderBy(r => r.ProductID).ToList();

            return reports;
        }

        public List<ReportDTO> GetList()
        {
            var reports = db.Database.SqlQuery<ReportDTO>("EXEC ShowReports").ToList();
            return reports;
        }

        public List<ReportDTO> SearchByWords(List<ReportDTO> reports, string keyWord)
        {
            var searchList = reports.Where((r) =>
            {
                string text, key;
                text = r.ProductID + "" + r.ProductName + "" + r.ProductUnit;
                key = keyWord;

                text = text.Format();
                key = key.Format();

                if (text.Contains(key))
                    return true;
                else
                    return false;
            }).Select(r => r).ToList();

            return searchList;
        }
    }
}

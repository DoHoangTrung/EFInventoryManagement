using PagedList;
using QuanLyKhoHang.DTO;
using QuanLyKhoHang.Entity;
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

        public async Task<IPagedList<ReportDTO>> GetListByDuration(DateTime fromDate, DateTime toDate, int pageNum = 1, int pageSize = 20)
        {
            return await Task.Run(() =>
            {
                var reports = db.Database.SqlQuery<ReportDTO>(
                    "EXEC ShowReportByDuration @fromDateReport ,@toDateReport",
                    new SqlParameter("fromDateReport", fromDate),
                    new SqlParameter("toDateReport", toDate)
                    ).ToList();

                var result = reports.ToPagedList(pageNum, pageSize);
                return result;
            });
        }

        public List<ReportDTO> GetPagedListByDuration(DateTime fromDate, DateTime toDate, int pageNum = 1, int pageSize = 20)
        {
            var reports = db.Database.SqlQuery<ReportDTO>(
                "EXEC dbo.ShowReportByDuration @fromDateReport1 ,@toDateReport1",
                new SqlParameter("fromDateReport1", fromDate),
                new SqlParameter("toDateReport1", toDate)
                ).OrderBy(r=>r.ProductID).ToList();

            return reports;
        }

        public List<ReportDTO> GetList()
        {
            var reports = db.Database.SqlQuery<ReportDTO>("EXEC ShowReports").ToList();
            return reports;
        }

        public List<ReportDTO> SearchByWords(List<ReportDTO> reports,string keyWord)
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

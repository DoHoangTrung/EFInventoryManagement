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

        public List<ReportDTO> GetListByDuration(DateTime fromDate, DateTime toDate)
        {
            List<ReportDTO> reports = new List<ReportDTO>();

            reports = db.Database.SqlQuery<ReportDTO>(
                "EXEC ShowReportByDuration @fromDate ,@toDate",
                new SqlParameter("fromDate", fromDate),
                new SqlParameter("toDate", toDate)
                ).ToList();

            return reports;
        }
    }
}

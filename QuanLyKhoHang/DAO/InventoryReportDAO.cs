using QuanLyKhoHang.DAT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAL
{
    public class InventoryReportDAO
    {
        private InventoryReportDAO() { }

        private static InventoryReportDAO instance;

        public static InventoryReportDAO Instance 
        {
            get { if (instance == null) instance = new InventoryReportDAO(); return instance; }
            private set { }
        }

        public DataTable GetDataOfInventoryReport()
        {
            string query = "exec dbo.GetDataOfInventoryReport";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public List<InventoryReport1> GetListInventoryReport()
        {
            List<InventoryReport1> list = new List<InventoryReport1>();

            DataTable dt = GetDataOfInventoryReport();
            foreach(DataRow row in dt.Rows)
            {
                InventoryReport1 iR = new InventoryReport1(row);
                list.Add(iR);
            }
            return list;
        }
        public List<InventoryReport1> GetListInventoryReport(DataTable dt)
        {
            if (dt != null)
            {
                List<InventoryReport1> list = new List<InventoryReport1>();

                foreach (DataRow row in dt.Rows)
                {
                    InventoryReport1 iR = new InventoryReport1(row);
                    list.Add(iR);
                }
                return list;
            }
            return null;
        }

        public List<InventoryReport1> GetListInventoryReportFromDateToDate(DateTime fromDate,DateTime toDate)
        {
            string query = "exec dbo.GetDataOfInventoryReportBetweenDate @fromdate , @toDate ";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query,fromDate,toDate);

            List<InventoryReport1> list = GetListInventoryReport(dt);
            return list;
        }
    }
}

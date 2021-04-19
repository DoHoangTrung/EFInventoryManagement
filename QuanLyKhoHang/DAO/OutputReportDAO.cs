using QuanLyKhoHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAL
{
    public class OutputReportDAO
    {
        private static OutputReportDAO instance;
        private OutputReportDAO() { }

        public static OutputReportDAO Instance 
        {
            get { if (instance == null) instance = new OutputReportDAO(); return instance; }
            private set => instance = value; 
        }

        public DataTable GetDataOfOutputVoucher()
        {
            string query = "exec dbo.HienThiPhieuXuat";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public List<OutputReport1> GetlistOutputVoucher()
        {
            List<OutputReport1> list = new List<OutputReport1>();
            DataTable dt = GetDataOfOutputVoucher();
            foreach (DataRow row in dt.Rows)
            {
                OutputReport1 voucher = new OutputReport1(row);
                list.Add(voucher);
            }
            return list;
        }

        
    }
}

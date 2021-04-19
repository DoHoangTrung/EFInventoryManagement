using QuanLyKhoHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAL
{
    public class InputVoucherDAO
    {
        private InputVoucherDAO() { }

        private static InputVoucherDAO instance;

        public static InputVoucherDAO Instance
        {
            get { if (instance == null) instance = new InputVoucherDAO(); return instance; }
            private set { }
        }
        public DataTable GetDataInputVoucher()
        {
            string query = "exec dbo.ShowInputVoucher";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public List<InputVoucher1> GetListInputVoucher()
        {
            List<InputVoucher1> list = new List<InputVoucher1>();
            DataTable dt = GetDataInputVoucher();
            foreach (DataRow row in dt.Rows)
            {
                InputVoucher1 voucher = new InputVoucher1(row);
                list.Add(voucher);
            }
            return list;
        }
            
        public void AddInputVoucher()
        {

        }

        public List<string> GetListID()
        {
            List<string> listID = new List<string>();
            string query = "SELECT ID FROM PhieuNhap";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                string s = row["ID"].ToString();
                listID.Add(s);
            }
            return listID;
        }

        public bool CheckID(string _id)
        {
            bool result = true;

            bool checkLength = true;
            if(_id.Length ==0 || _id.Length > 30)
            {
                checkLength = false;
            }

            bool notDuplicate = true;
            List<string> listID = GetListID();
            foreach (string id in listID)
            {
                if (_id == id)
                {
                    notDuplicate = false;
                    break;
                }
            }

            result = checkLength && notDuplicate;
            return result;
        }

        public int InsertInputVoucher(string idVoucher, string idSupplier, DateTime inputDate)
        {
            string query = "EXEC dbo.InsertPhieuNhap @id , @idncc , @date";
            int rowAffected = DataProvider.Instance.ExecuteNonQuery(query,idVoucher,idSupplier,inputDate);
            return rowAffected;
        }

        public int InsertInputVoucherInfor(string idPhieu, string idGood, int inputCount, int intputPrice, int outputPrice)
        {
            string query = "EXEC dbo.InsertThongTinPhieuNhap @idPhieu , @idSP , @soLuongNhap , @giaNhap , @giaXuat";
            int rowAffedted = DataProvider.Instance.ExecuteNonQuery(query, idPhieu, idGood, inputCount, intputPrice, outputPrice);
            return rowAffedted;
        }
    }
}

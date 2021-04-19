using QuanLyKhoHang.DAT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAL
{
    public class GoodDAO
    {
        private GoodDAO() { }

        private static GoodDAO instance;

        public static GoodDAO Instance
        {
            get { if (instance == null) instance = new GoodDAO(); return instance; }
            private set { }
        }

        public DataTable GetDataOfGoods()
        {
            string query = "select * from Sanpham";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public List<Good1> GetListGoods()
        {
            List<Good1> list = new List<Good1>();

            DataTable dt = GetDataOfGoods();
            foreach (DataRow row in dt.Rows)
            {
                Good1 g = new Good1(row);
                list.Add(g);
            }

            return list;
        }

        public List<Good1> GetListGoods(DataTable dt)
        {
            List<Good1> list = new List<Good1>();

            foreach (DataRow row in dt.Rows)
            {
                Good1 g = new Good1(row);
                list.Add(g);
            }

            return list;
        }

        public int InsertGood(string id, string name, string unit)
        {
            int count = 0;

            string query = "exec dbo.InsertGood @id , @name , @donvi";
            count = DataProvider.Instance.ExecuteNonQuery(query, id, name, unit);

            return count;
        }

        public int DeleteGood(string id)
        {
            string query = "exec dbo.DeleteGood @id";

            int numberRowAffected = DataProvider.Instance.ExecuteNonQuery(query, id);

            return numberRowAffected;
        }

        public int UpdateGoodWhereID(string id, string name, string unit)
        {
            string query = "exec dbo.UpdateGood @id , @name , @unit ";
            int rowAffected = DataProvider.Instance.ExecuteNonQuery(query, id, name, unit);
            return rowAffected;
        }
        public int UpdateGoodName(string id, string name)
        {
            string query = "exec dbo.UpdateGoodName @id , @name";
            int rowAffected = DataProvider.Instance.ExecuteNonQuery(query, id, name);
            return rowAffected;
        }
        public int UpdateGoodUnit(string id, string unit)
        {
            string query = "exec dbo.UpdateGoodUnit @id , @unit ";
            int rowAffected = DataProvider.Instance.ExecuteNonQuery(query, id, unit);
            return rowAffected;
        }

        public List<Good1> SearchGood(string id, string name, string unit)
        {
            List<Good1> listGoods = GoodDAO.Instance.GetListGoods();
            IEnumerable<Good1> searchList = listGoods.Where((g) =>
            {
                bool conditionID, conditionName, conditionUnit;
                if (id != "")
                    conditionID = IsContainable(g.ID, id);
                else
                    conditionID = true;

                if (name != "")
                    conditionName = IsContainable(g.Name, name);
                else
                    conditionName = true;

                if (unit != "")
                    conditionUnit = IsContainable(g.Unit, unit);
                else
                    conditionUnit = true;

                return conditionID && conditionName && conditionUnit;
            });

            return searchList.ToList();
        }

        bool IsContainable(string input, string searchString)
        {
            bool check = true;
            string unaccentStr = input.LowerCaseAndRemoveAccents();
            string pattern = string.Format(@".*\b{0}\b.*", searchString);

            check = Regex.IsMatch(unaccentStr.ToLower(), pattern);
            return check;
        }

        public List<string> GetListGoodID()
        {
            string query = "select ID from SanPham";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);

            List<string> list = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                string s = row["id"].ToString();
                list.Add(s);
            }
            return list;
        }

        public bool IsIDDuplicate(string id)
        {
            bool check = false;
            List<string> list = GetListGoodID();
            foreach (string s in list)
            {
                if (id == s)
                {
                    check = true;
                    break;
                }

            }
            return check;
        }

        public Good1 GetGoodByID(string id)
        {
            string query = $"SELECT * FROM SanPham WHERE ID = '{id}'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            Good1 Good1 = new Good1(dt.Rows[0]);
            return Good1;
        }
    }
}
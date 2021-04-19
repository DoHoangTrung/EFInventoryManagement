using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DAL
{
    public class DataProvider
    {
        private DataProvider() { }

        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set {}
        }

        private string connectStr = @"Data Source=LAPTOP-2LOOES1H\SQLEXPRESS;Initial Catalog=QuanLyKho;Integrated Security=True; Connection Timeout = 30;";

        public DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();

            using (SqlConnection sqlConnect = new SqlConnection(connectStr))
            {

                sqlConnect.Open();
                
                SqlCommand cmd = new SqlCommand(query, sqlConnect);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(table);
               
            }

            return table;
        }

        public DataTable ExecuteQuery(string query, params object[] parameters)
        {
            DataTable table = new DataTable();

            using (SqlConnection sqlConnect = new SqlConnection(connectStr))
            {
                
                sqlConnect.Open();

                SqlCommand cmd = new SqlCommand(query, sqlConnect);

                if (parameters.Length > 0)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (var item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
            }

            return table;
        }

        public int ExecuteNonQuery(string query, params object[] parameters)
        {
            int count = 0;

            using (SqlConnection sqlConnect = new SqlConnection(connectStr))
            {

                sqlConnect.Open();

                SqlCommand cmd = new SqlCommand(query, sqlConnect);

                if (parameters.Length > 0)
                {
                    string[] listPara = query.Split(' ');

                    int i = 0;
                    foreach (var para in listPara)
                    {
                        if (para.Contains("@"))
                        {
                            cmd.Parameters.Add(para,parameters[i]);
                            i++;
                        }
                    }
                }
                count = cmd.ExecuteNonQuery();

                /*try
                {
                    count = cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                }*/
            }

            return count;
        }
    }
}

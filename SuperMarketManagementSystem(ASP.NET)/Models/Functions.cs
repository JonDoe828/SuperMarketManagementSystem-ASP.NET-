using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SuperMarketManagementSystem_ASP.NET_.Models
{
    public class Functions
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        //private DataTable dt;
        private SqlDataAdapter sda;
        private string ConStr;
        public Functions()
        {
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\D\Documents\SupermarketDb.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }

        public DataTable GetData(string Query)
        {
            DataTable dt = new DataTable();
            sda = new SqlDataAdapter(Query, ConStr);
            sda.Fill(dt);
            return dt;
        }
        //Overloading for GetData(),Different parameter lists
        public DataTable GetData(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dt = new DataTable();

            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }

            using (SqlCommand cmd = new SqlCommand(query, Con))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }

            Con.Close();
            return dt;
        }

        public int SetData(string query, Dictionary<string, object> parameters = null)
        {
            int cnt = 0;

            // 确保连接已关闭，然后打开
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }

            // 设置命令文本
            Cmd.CommandText = query;

            // 清除并添加参数
            Cmd.Parameters.Clear();
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    Cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            // 执行命令并获取受影响的行数
            cnt = Cmd.ExecuteNonQuery();

            // 关闭连接
            Con.Close();

            return cnt;
        }
        public object GetScalar(string query, Dictionary<string, object> parameters = null)
        {
            object result = null;

            // 确保连接已打开
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }

            using (SqlCommand cmd = new SqlCommand(query, Con))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                result = cmd.ExecuteScalar();
            }

            // 关闭连接
            Con.Close();
            return result;
        }

    }
}
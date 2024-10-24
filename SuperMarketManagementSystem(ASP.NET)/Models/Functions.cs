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
        private string Constr;

        public Functions()
        {
            // 初始化数据库连接字符串
            Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\D\Documents\SupermarketDb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            Con = new SqlConnection(Constr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }

        // 获取数据的方法
        public DataTable GetData(string Query)
        {
            DataTable dt = new DataTable();

            try
            {
                // 使用 SqlDataAdapter 填充 DataTable
                using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(Query, Con))
                {
                    SqlDataAdapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                // 处理异常并打印错误信息
                Console.WriteLine($"查询数据时出错: {ex.Message}");
            }

            return dt;
        }

        // 设置数据（插入、更新、删除）的方法
        public int SetData(string Query)
        {
            int cnt = 0;

            try
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }

                Cmd.CommandText = Query;
                cnt = Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // 处理异常并打印错误信息
                Console.WriteLine($"设置数据时出错: {ex.Message}");
            }
            finally
            {
                // 确保连接被关闭
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }

            return cnt;
        }
    }
}
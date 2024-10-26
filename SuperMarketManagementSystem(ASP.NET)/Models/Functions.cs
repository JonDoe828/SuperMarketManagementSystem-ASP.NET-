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
            // Initialize the database connection string
            Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\D\Documents\SupermarketDb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            Con = new SqlConnection(Constr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }

        // Methods for obtaining data
        public DataTable GetData(string Query)
        {
            DataTable dt = new DataTable();

            try
            {
                // Populating a DataTable using a SqlDataAdapter
                using (SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(Query, Con))
                {
                    SqlDataAdapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and print error messages
                Console.WriteLine($"Error querying data: {ex.Message}");
            }

            return dt;
        }

        // Methods for setting data (insert, update, delete)
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
                // Handle exceptions and print error messages
                Console.WriteLine($"Error setting data: {ex.Message}");
            }
            finally
            {
                // Make sure the connection is closed
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }

            return cnt;
        }
    }
}
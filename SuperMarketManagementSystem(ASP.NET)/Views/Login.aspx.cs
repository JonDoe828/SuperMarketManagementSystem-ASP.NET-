using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
//using the Anonymous method with LINQ using Lambda expression
namespace SuperMarketManagementSystem_ASP.NET_.Views
{
    public partial class Login : System.Web.UI.Page
    {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
        }

        public static string UName = "";
        public static int User;

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            // Check if input is empty
            if (string.IsNullOrEmpty(UnameTb.Value) || string.IsNullOrEmpty(PasswordTb.Value))
            {
                ErrMsg.Text = "Please enter your username and password!";
                return;
            }

            // Administrator login
            if (UnameTb.Value == "Admin@admin.com" && PasswordTb.Value == "password")
            {
                Response.Redirect("Admin/Products.aspx");
                return;
            }

            // Parameterized queries
            string query = "SELECT * FROM UserTbl WHERE UserEmail = @UserEmail AND UserPass = @UserPass";
            var parameters = new Dictionary<string, object>
            {
                { "@UserEmail", UnameTb.Value },
                { "@UserPass", PasswordTb.Value }
            };

            DataTable dt = Con.GetData(query, parameters);

            // Checking for matching rows using LINQ
            var userRow = dt.AsEnumerable().FirstOrDefault(row =>
                row.Field<string>("UserEmail") == UnameTb.Value &&
                row.Field<string>("UserPass") == PasswordTb.Value);

            if (userRow == null)
            {
                ErrMsg.Text = "Wrong username or password!";
            }
            else
            {
                // Extracting User ID and User Name with Lambda Expressions
                UName = userRow.Field<string>("UserEmail");
                User = userRow.Field<int>("UserId");

                // Redirect to customer page
                Response.Redirect("Customer/Billing.aspx");
            }
        }
    }
}

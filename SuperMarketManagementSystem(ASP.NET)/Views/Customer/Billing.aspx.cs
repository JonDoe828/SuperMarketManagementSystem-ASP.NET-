using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperMarketManagementSystem_ASP.NET_.Views.Customer
{

    public partial class Billing : System.Web.UI.Page
    {
        Models.Functions Con;
        int customer = Login.User;
        string CName = Login.UName;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowProducts();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5]
                {
                    new DataColumn("Id"),
                    new DataColumn("Product Name"),
                    new DataColumn("Price"),
                    new DataColumn("Amount"),
                    new DataColumn("Total"),
                });
                ViewState["Bill"] = dt;
                this.BindGrid();
            }
        }
        protected void BindGrid()
        {
            ShoppingCartList.DataSource = ViewState["Bill"];
            ShoppingCartList.DataBind();
        }
        private void ShowProducts()
        {
            string Query = "Select PId, PName, PPrice,PQty from ProductTbl";
            ProductList.DataSource = Con.GetData(Query);
            ProductList.DataBind();
            ProductList.HeaderRow.Cells[1].Text = "ID";
            ProductList.HeaderRow.Cells[2].Text = "Product Name";
            //ProductList.HeaderRow.Cells[3].Text = "Manufacturer";
            //ProductList.HeaderRow.Cells[4].Text = "Category";
            ProductList.HeaderRow.Cells[4].Text = "Total inventory";
            ProductList.HeaderRow.Cells[3].Text = "Product Prices";

        }
        int key = 0;
        int stock = 0;
        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PnameTb.Value = ProductList.SelectedRow.Cells[2].Text;
            PriceTb.Value = ProductList.SelectedRow.Cells[3].Text;
            stock = Convert.ToInt32(ProductList.SelectedRow.Cells[4].Text);

            if (PnameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ProductList.SelectedRow.Cells[1].Text);
            }
        }

        private void UpdateStock()
        {
            int NewQty;
            NewQty = Convert.ToInt32(ProductList.SelectedRow.Cells[4].Text) - Convert.ToInt32(QtyTb.Value);
            string Query = "Update ProductTbl set PQty={0} where PId={1}";
            Query = string.Format(Query, NewQty, ProductList.SelectedRow.Cells[1].Text);
            Con.SetData(Query);
            ShowProducts();
        }



        private void InsertBill()
        {
            try
            {
                // Check if customer is valid
                string checkCustomerQuery = "SELECT COUNT(1) FROM UserTbl WHERE UserId = @UserId";
                var checkCustomerParams = new Dictionary<string, object>
        {
            { "@UserId", customer }
        };

                int customerExists = Convert.ToInt32(Con.GetScalar(checkCustomerQuery, checkCustomerParams));

                if (customerExists == 0)
                {
                    // Display error message
                    ErrMsg.Text = "Customer ID not found. Please make sure the customer is valid.";
                    return;
                }

                // Check if GrdTotalTb.Text is a valid integer
                int totalAmount;
                if (!int.TryParse(GrdTotalTb.Text, out totalAmount))
                {
                    ErrMsg.Text = "Invalid total amount. Please enter a valid number.";
                    return;
                }

                // Inserting billing records using parameterized queries
                string insertBillQuery = "INSERT INTO BillTbl (PDate, Customer, Amount) VALUES (@PDate, @Customer, @Amount)";
                var insertBillParams = new Dictionary<string, object>
        {
            { "@PDate", DateTime.Today.Date },
            { "@Customer", customer },
            { "@Amount", totalAmount }
        };

                Con.SetData(insertBillQuery, insertBillParams);
                ErrMsg.Text = "Bill inserted successfully!";
            }
            catch (SqlException sqlEx)
            {
                ErrMsg.Text = $"SQL Error: {sqlEx.Message}";
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                ErrMsg.Text = $"Error: {ex.Message}";
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        int GrdTotal = 0;
        int Amount;
        protected void AddToBillBtn_Click(object sender, EventArgs e)
        {
            if (PnameTb.Value == "" || QtyTb.Value == "" || PriceTb.Value == "")
            {

            }
            else
            {
                int total = Convert.ToInt32(QtyTb.Value) * Convert.ToInt32(PriceTb.Value);
                DataTable dt = (DataTable)ViewState["Bill"];
                dt.Rows.Add(ShoppingCartList.Rows.Count + 1,
                    PnameTb.Value.Trim(),
                    PriceTb.Value.Trim(),
                    QtyTb.Value.Trim(),
                    total);

                ViewState["Bill"] = dt;

                this.BindGrid();
                UpdateStock();
                GrdTotal = 0;
                for (int i = 0; i < ShoppingCartList.Rows.Count; i++)
                {
                    GrdTotal = GrdTotal + Convert.ToInt32(ShoppingCartList.Rows[i].Cells[4].Text);
                }
                Amount = GrdTotal;
                MoneyLabel.Text = "AU$";
                GrdTotalTb.Text = Convert.ToString(GrdTotal);
                PnameTb.Value = "";
                QtyTb.Value = "";
                PriceTb.Value = "";
            }


        }

        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Insert new billing information into the database
                InsertBill();

                // Query the latest billing records
                string queryLatestBill = "SELECT TOP 1 * FROM BillTbl WHERE Customer = @Customer ORDER BY BillId DESC";
                var parameters = new Dictionary<string, object>
        {
            { "@Customer", customer }
        };
                DataTable latestBill = Con.GetData(queryLatestBill, parameters);

                if (latestBill.Rows.Count > 0)
                {
                    // Display the latest billing information (e.g. in a tab)
                    DataRow billRow = latestBill.Rows[0];
                    BillContent.Text = $"Date: {billRow["PDate"]}, Customer ID: {billRow["Customer"]}, Amount: {billRow["Amount"]}";

                    // Print function
                    ClientScript.RegisterStartupScript(this.GetType(), "Print", "window.print();", true);
                }
                else
                {
                    ErrMsg.Text = "No bill record found.";
                }
            }
            catch (Exception ex)
            {
                ErrMsg.Text = $"Print Error: {ex.Message}";
                Console.WriteLine($"Print Error: {ex.Message}");
            }
        }
    }
}
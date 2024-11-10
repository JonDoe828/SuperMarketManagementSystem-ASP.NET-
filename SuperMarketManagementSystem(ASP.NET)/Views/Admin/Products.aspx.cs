using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace SuperMarketManagementSystem_ASP.NET_.Views.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowProducts();
                GetCategories();
                GetManufactors();
            }
        }
        public void ShowProducts()
        {
            string Query = "Select * from ProductTbl";
            ProductList.DataSource = Con.GetData(Query);
            ProductList.DataBind();

            ProductList.HeaderRow.Cells[1].Text = "ID";
            ProductList.HeaderRow.Cells[2].Text = "Product Name";
            ProductList.HeaderRow.Cells[3].Text = "Manufacturers";
            ProductList.HeaderRow.Cells[4].Text = "Category";
            ProductList.HeaderRow.Cells[5].Text = "Quantity";
            ProductList.HeaderRow.Cells[6].Text = "Price";

        }
        private void GetCategories()
        {
            string Query = "select * from CategoryTbl";
            PCategory.DataTextField = Con.GetData(Query).Columns["CategoryName"].ToString();
            PCategory.DataValueField = Con.GetData(Query).Columns["CategoryId"].ToString();
            PCategory.DataSource = Con.GetData(Query);
            PCategory.DataBind();
        }
        private void GetManufactors()
        {
            string Query = "select * from ManufacturerTbl";
            PManufact.DataTextField = Con.GetData(Query).Columns["ManufacturerName"].ToString();
            PManufact.DataValueField = Con.GetData(Query).Columns["ManufacturerId"].ToString();
            PManufact.DataSource = Con.GetData(Query);
            PManufact.DataBind();
        }


        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PName.Value == "" || PManufact.SelectedIndex == -1 || PCategory.SelectedIndex == -1 || PPrice.Value == "" || PQty.Value == "")
                {
                    ErrMsg.Text = "Information Lack";
                }
                else
                {
                    string PrName = PName.Value;
                    string PrManufact = PManufact.SelectedValue.ToString();
                    string PCat = PCategory.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(PQty.Value);
                    int Price = Convert.ToInt32(PPrice.Value);

                    string Query = "insert into ProductTbl values('{0}','{1}','{2}',{3},{4})";
                    Query = string.Format(Query, PrName, PrManufact, PCat, Quantity, Price);
                    Con.SetData(Query);
                    ShowProducts();
                    ErrMsg.Text = "Product Information has been Added!";
                    PName.Value = "";
                    PManufact.SelectedIndex = -1;
                    PCategory.SelectedIndex = -1;
                    PQty.Value = "";
                    PPrice.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PName.Value == "" || PManufact.SelectedIndex == -1 || PCategory.SelectedIndex == -1 || PPrice.Value == "" || PQty.Value == "")
                {
                    ErrMsg.Text = "Information Lack";
                }
                else
                {
                    string PrName = PName.Value;
                    string PrManufact = PManufact.SelectedValue.ToString();
                    string PCat = PCategory.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(PQty.Value);
                    int Price = Convert.ToInt32(PPrice.Value);

                    string Query = "update ProductTbl set PName='{0}',PManufact = '{1}',PCategory = '{2}',PQty = '{3}', PPrice = '{4}' where PId = {5}";
                    Query = string.Format(Query, PrName, PrManufact, PCat, Quantity, Price, ProductList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowProducts();
                    ErrMsg.Text = "Product Information has been updated!";
                    PName.Value = "";
                    PManufact.SelectedIndex = -1;
                    PCategory.SelectedIndex = -1;
                    PQty.Value = "";
                    PPrice.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PName.Value == "" || PManufact.SelectedIndex == -1 || PCategory.SelectedIndex == -1 || PPrice.Value == "" || PQty.Value == "")
                {
                    ErrMsg.Text = "Information Lack";
                }
                else
                {
                    string PrName = PName.Value;
                    string PrManufact = PManufact.SelectedValue.ToString();
                    string PCat = PCategory.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(PQty.Value);
                    int Price = Convert.ToInt32(PPrice.Value);

                    string Query = "delete from ProductTbl where PId = {0}";
                    Query = string.Format(Query, ProductList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowProducts();
                    ErrMsg.Text = "Product Information has been Deleted!";
                    PName.Value = "";
                    PManufact.SelectedIndex = -1;
                    PCategory.SelectedIndex = -1;
                    PQty.Value = "";
                    PPrice.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
        int key = 0;
        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PName.Value = ProductList.SelectedRow.Cells[2].Text;
            PManufact.SelectedValue = ProductList.SelectedRow.Cells[3].Text;
            PCategory.SelectedValue = ProductList.SelectedRow.Cells[4].Text;
            PQty.Value = ProductList.SelectedRow.Cells[5].Text;
            PPrice.Value = ProductList.SelectedRow.Cells[6].Text;
            if (PName.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ProductList.SelectedRow.Cells[1].Text);
            }
        }
    }
}
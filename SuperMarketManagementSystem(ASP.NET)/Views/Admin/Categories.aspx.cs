using SuperMarketManagementSystem_ASP.NET_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SuperMarketManagementSystem_ASP.NET_.Views.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        private Functions Con;

        // Using ViewState to save key values
        private int key
        {
            get { return ViewState["key"] != null ? (int)ViewState["key"] : 0; }
            set { ViewState["key"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Functions();
            if (!IsPostBack)
            {
                ShowCategories();
            }
        }

        private void ShowCategories()
        {
            // Use Con.GetData to query and convert the result into List<Category> (Generics)
            List<Category> categoryList = Con.GetData("SELECT * FROM CategoryTbl").AsEnumerable()
                .Select(row => new Category
                {
                    CatId = row.Field<int>("CategoryId"),
                    CatName = row.Field<string>("CategoryName"),
                    CatDescription = row.Field<string>("CategoryDescrption")
                }).ToList();

            CategoryList.DataSource = categoryList;
            CategoryList.DataBind();

            // Set the header name
            if (CategoryList.HeaderRow != null)
            {
                CategoryList.HeaderRow.Cells[1].Text = "ID";
                CategoryList.HeaderRow.Cells[2].Text = "Category";
                CategoryList.HeaderRow.Cells[3].Text = "Description";
            }
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CategoryName.Value) || string.IsNullOrWhiteSpace(CatDetail.Value))
                {
                    ErrMsg.Text = "Information is lacking!";
                    return;
                }

                // Use parameterized queries when inserting data to prevent SQL injection
                string query = "INSERT INTO CategoryTbl (CategoryName, CategoryDescrption) VALUES (@CName, @CDesc)";
                var parameters = new Dictionary<string, object>
                {
                    { "@CName", CategoryName.Value },
                    { "@CDesc", CatDetail.Value }
                };

                Con.SetData(query, parameters);
                ShowCategories();
                ErrMsg.Text = "Category Information has been added!";
                ClearForm();
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        protected void CategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryList.SelectedRow != null)
            {
                CategoryName.Value = CategoryList.SelectedRow.Cells[2].Text;
                CatDetail.Value = CategoryList.SelectedRow.Cells[3].Text;
                key = Convert.ToInt32(CategoryList.SelectedRow.Cells[1].Text); // Storing the key in ViewState
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CategoryName.Value) || string.IsNullOrWhiteSpace(CatDetail.Value))
                {
                    ErrMsg.Text = "Information is lacking!";
                    return;
                }

                if (key == 0)
                {
                    ErrMsg.Text = "Select a category to edit.";
                    return;
                }

                // Update Query
                string query = "UPDATE CategoryTbl SET CategoryName = @CName, CategoryDescrption = @CDesc WHERE CategoryId = @Key";
                var parameters = new Dictionary<string, object>
                {
                    { "@CName", CategoryName.Value },
                    { "@CDesc", CatDetail.Value },
                    { "@Key", key }
                };

                Con.SetData(query, parameters);
                ShowCategories();
                ErrMsg.Text = "Category Information has been updated!";
                ClearForm();
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    ErrMsg.Text = "Select a category to delete.";
                    return;
                }

                // Delete Query
                string query = "DELETE FROM CategoryTbl WHERE CategoryId = @Key";
                var parameters = new Dictionary<string, object>
                {
                    { "@Key", key }
                };

                Con.SetData(query, parameters);
                ShowCategories();
                ErrMsg.Text = "Category Information has been deleted!";
                ClearForm();
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        private void ClearForm()
        {
            CategoryName.Value = string.Empty;
            CatDetail.Value = string.Empty;
            key = 0; // reset key
        }
    }

    // Class definitions are used to store classification information
    public class Category
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public string CatDescription { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperMarketManagementSystem_ASP.NET_.Views.Admin
{
    public partial class Suppliers : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowManmufactures();
        }
        private void ShowManmufactures()
        {
            string Query = "Select * from ManufacturerTbl";
            ManufactList.DataSource = Con.GetData(Query);
            ManufactList.DataBind();

            ManufactList.HeaderRow.Cells[1].Text = "ID";
            ManufactList.HeaderRow.Cells[2].Text = "Manufacturer";
            ManufactList.HeaderRow.Cells[3].Text = "License";
            ManufactList.HeaderRow.Cells[4].Text = "Origin";
        }
                   
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ManufacturerId.Value == "" || LicenseNum.Value == "" || PlaceCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Information Lack";
                }
                else
                {
                    string MName = ManufacturerId.Value;
                    string PerNum = LicenseNum.Value;
                    string Origin = PlaceCb.SelectedItem.ToString();

                    string Query = "insert into ManufacturerTbl values('{0}','{1}','{2}')";
                    Query = string.Format(Query, MName, PerNum, Origin);
                    Con.SetData(Query);
                    ShowManmufactures();
                    ErrMsg.Text = "Manufacturer Information has been added!";
                    ManufacturerId.Value = "";
                    LicenseNum.Value = "";
                    PlaceCb.SelectedIndex = -1;
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        int key = 0;
        protected void ManufactList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManufacturerId.Value = ManufactList.SelectedRow.Cells[2].Text;
            LicenseNum.Value = ManufactList.SelectedRow.Cells[3].Text;
            PlaceCb.SelectedValue= ManufactList.SelectedRow.Cells[4].Text;
            if (ManufacturerId.Value=="")
            {
                key = 0;
            }
            else {
            
                key=Convert.ToInt32(ManufactList.SelectedRow.Cells[1].Text);
            }          
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ManufacturerId.Value == "" || LicenseNum.Value == "" || PlaceCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Information Lack";
                }
                else
                {
                    string MName = ManufacturerId.Value;
                    string PerNum = LicenseNum.Value;
                    string Origin = PlaceCb.SelectedItem.ToString();

                    string Query = "update ManufacturerTbl set ManufacturerName = '{0}', LicenseNum = '{1}', Origin = '{2}' where ManufacturerId = {3}";
                    Query = string.Format(Query, MName, PerNum, Origin, ManufactList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowManmufactures();
                    ErrMsg.Text = "Manufacturer Information has been Edited!";
                    ManufacturerId.Value = "";
                    LicenseNum.Value = "";
                    PlaceCb.SelectedIndex = -1;
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
                if (ManufacturerId.Value == "" || LicenseNum.Value == "" || PlaceCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Please Select One Data!";
                }
                else
                {
                    string MName = ManufacturerId.Value;
                    string PerNum = LicenseNum.Value;
                    string Origin = PlaceCb.SelectedItem.ToString();

                    string Query = "delete from ManufacturerTbl where ManufacturerId = {0}";
                    Query = string.Format(Query, ManufactList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowManmufactures();
                    ErrMsg.Text = "Manufacturer Information has been Deleted!";
                    ManufacturerId.Value = "";
                    LicenseNum.Value = "";
                    PlaceCb.SelectedIndex = -1;
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }

        }
    }
}
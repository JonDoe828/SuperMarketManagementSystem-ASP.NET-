using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperMarketManagementSystem_ASP.NET_.Views.Admin
{
    public partial class Consumers : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowUsers();
        }
        private void ShowUsers()
        {
            string Query = "Select * from UserTbl";
            UserList.DataSource = Con.GetData(Query);
            UserList.DataBind();

            UserList.HeaderRow.Cells[1].Text = "ID";
            UserList.HeaderRow.Cells[2].Text = "User Name";
            UserList.HeaderRow.Cells[3].Text = "Email";
            UserList.HeaderRow.Cells[4].Text = "Phone Number";
            UserList.HeaderRow.Cells[5].Text = "Password";
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserName.Value == "" || UserEmail.Value == "" || UserPhone.Value == ""|| UserPassword.Value=="")
                {
                    ErrMsg.Text = "Information Lack";
                }
                else
                {
                    string UName = UserName.Value;
                    string UEmail = UserEmail.Value;
                    string UPhone = UserPhone.Value;
                    string UAddress = UserPassword.Value;
                    string Query = "update UserTbl set UserName = '{0}', UserEmail = '{1}', UserPhone = '{2}', UserPassword = '{3}' where UserId = {4}";
                    Query = string.Format(Query, UName, UEmail, UPhone, UAddress, UserList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowUsers();
                    ErrMsg.Text = "User Information has been Edited!";
                    UserName.Value = "";
                    UserEmail.Value = "";
                    UserPhone.Value = "";
                    UserPassword.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserName.Value == "" || UserEmail.Value == "" || UserPhone.Value == "" || UserPassword.Value == "")
                {
                    ErrMsg.Text = "Information Lack";
                }
                else
                {
                    string UName = UserName.Value;
                    string UEmail = UserEmail.Value;
                    string UPhone = UserPhone.Value;
                    string UAddress = UserPassword.Value;
                    string Query = "insert into UserTbl values('{0}','{1}','{2}','{3}')";
                    Query = string.Format(Query, UName, UEmail, UPhone, UAddress);
                    Con.SetData(Query);
                    ShowUsers();
                    ErrMsg.Text = "User Information has been Saved!";
                    UserName.Value = "";
                    UserEmail.Value = "";
                    UserPhone.Value = "";
                    UserPassword.Value = "";
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
                if (UserName.Value == "" || UserEmail.Value == "" || UserPhone.Value == "" || UserPassword.Value == "")
                {
                    ErrMsg.Text = "Information Lack";
                }
                else
                {
                    string UName = UserName.Value;
                    string UEmail = UserEmail.Value;
                    string UPhone = UserPhone.Value;
                    string UAddress = UserPassword.Value;
                    string Query = "delete from UserTbl where UserId = {0}";
                    Query = string.Format(Query, UserList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowUsers();
                    ErrMsg.Text = "User Information has been Deleted!";
                    UserName.Value = "";
                    UserEmail.Value = "";
                    UserPhone.Value = "";
                    UserPassword.Value = "";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }
        int key = 0;
        protected void UserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserName.Value = UserList.SelectedRow.Cells[2].Text;
            UserEmail.Value = UserList.SelectedRow.Cells[3].Text;
            UserPhone.Value = UserList.SelectedRow.Cells[4].Text;
            UserPassword.Value = UserList.SelectedRow.Cells[5].Text;
            if (UserName.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UserList.SelectedRow.Cells[1].Text);
            }
        }
    }
}
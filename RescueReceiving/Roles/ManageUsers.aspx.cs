using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace RescueReceiving.Administration
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            initNew();
        }

        private void initNew()
        {
            MembershipUserCollection members = Membership.GetAllUsers();
            foreach (MembershipUser member in members)
            {
                // New row for table
                //
                var row = new TableRow();

                // User name
                //
                var cell = new TableCell();
                cell.Text = member.UserName;
                row.Cells.Add(cell);

                // Creation date
                //
                cell = new TableCell();
                cell.Text = member.CreationDate.ToShortDateString();
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Cells.Add(cell);

                // Last online date
                //
                cell = new TableCell();
                cell.Text = member.LastLoginDate.ToShortDateString();
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Cells.Add(cell);

                // Is admin?
                //
                cell = new TableCell();
                cell.HorizontalAlign = HorizontalAlign.Center;

                var checkbox = new CheckBox();
                checkbox.ID = "cbAdmin" + member.UserName;
                checkbox.Checked = Roles.IsUserInRole(member.UserName, "Admin");

                cell.Controls.Add(checkbox);
                row.Cells.Add(cell);

                // Commands
                //
                cell = new TableCell();
                cell.HorizontalAlign = HorizontalAlign.Center;

                var button = new Button();
                button.ID = "btnUpd" + member.UserName;
                button.Click += Update_OnClick;
                button.Text = "Update";

                cell.Controls.Add(button);

                button = new Button();
                button.ID = "btnDel" + member.UserName;
                button.Click += Delete_OnClick;
                button.Text = "Delete";

                cell.Controls.Add(button);

                row.Cells.Add(cell);

                tblUsers.Rows.Add(row);
            }
        }

        protected void Delete_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            string userName = btn.ID.Substring(6);
            Membership.DeleteUser(userName);
            Response.Redirect(Request.Path);
        }

        protected void Update_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string userName = btn.ID.Substring(6);
            CheckBox cb = (CheckBox) FindControlByID(this, "cbAdmin" + userName);
            if (cb.Checked)
            {
                try
                {
                    Roles.AddUserToRole(userName, "Admin");
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    Roles.RemoveUserFromRole(userName, "Admin");
                }
                catch
                {
                }
            }
        }

        protected void btnCreateNewUser_Click(object sender, EventArgs e)
        {
            if (string.Compare(tbPassword.Text, tbConfirmPassword.Text) == 0)
            {
                MembershipUser newUser = Membership.CreateUser(tbUserName.Text, tbPassword.Text, tbEmail.Text);
                if (cbIsAdmin.Checked)
                {
                    Roles.AddUserToRole(newUser.UserName, "Admin");
                }
            }
            Response.Redirect(Request.Path);
        }

        private static Control FindControlByID(Control parent, String id)
        {
            if (parent == null)
            {
                return null;
            }
            foreach (Control control in parent.Controls)
            {
                if (control.ID == id)
                {
                    return control;
                }
                Control child = FindControlByID(control, id);
                if (child != null)
                {
                    return child;
                }
            }
            return null;
        }

    }
}
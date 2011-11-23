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
            // Roles, AddUserToRule, RemoveUserFromRole, IsUserInRole
            // GetRolesForUser
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
                checkbox.Text = "Admin";
                checkbox.Checked = Roles.IsUserInRole(member.UserName, "Admin");
                
                cell.Controls.Add(checkbox);
                row.Cells.Add(cell);

                // Commands
                //
                cell = new TableCell();
                cell.HorizontalAlign = HorizontalAlign.Center;
                
                var button = new Button();
                button.Text = "Update";

                cell.Controls.Add(button);
                
                button = new Button();
                button.Text = "Delete";
                
                cell.Controls.Add(button);

                row.Cells.Add(cell);

                tblUsers.Rows.Add(row);
            }
        }
    }
}
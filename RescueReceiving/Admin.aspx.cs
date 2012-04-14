using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RescueReceiving
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Roles/ManageUsers.aspx");
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/import.aspx");
        }
    }
}
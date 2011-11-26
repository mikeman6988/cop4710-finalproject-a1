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

        protected void btnReport_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbStartdate.Text) && String.IsNullOrEmpty(tbStopdate.Text))
            {
                Response.Redirect("~/report.aspx");
            }
            else //if
            {
                String x = null;                
                if (!String.IsNullOrEmpty(tbStartdate.Text) && !String.IsNullOrEmpty(tbStopdate.Text))
                {
                    x += "start=" + Server.UrlEncode(tbStartdate.Text);
                    x += "&stop=" + Server.UrlEncode(tbStopdate.Text);
                }
                else if (!String.IsNullOrEmpty(tbStartdate.Text))
                {
                    x += "start=" + Server.UrlEncode(tbStartdate.Text);
                }
                else
                {
                    x += "stop=" + Server.UrlEncode(tbStopdate.Text);
                }

                Response.Redirect("~/report.aspx?" + x);

            }
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/import.aspx");
        }
    }
}
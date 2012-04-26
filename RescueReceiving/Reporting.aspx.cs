using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RescueReceiving
{
    public partial class Reporting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbStartdate.Text) && String.IsNullOrEmpty(tbStopdate.Text))
            {
                Response.Redirect("~/report.aspx");
            }
            else //if
            {
                string x = getQueryString();                
                Response.Redirect("~/report.aspx?" + x);
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbStartdate.Text) && String.IsNullOrEmpty(tbStopdate.Text))
            {
                Response.Redirect("~/Export.aspx");
            }
            else //if
            {
                String x = getQueryString();
                Response.Redirect("~/Export.aspx?" + x);
            }
        }

        private string getQueryString()
        {
            string str = string.Empty;
            if (!String.IsNullOrEmpty(tbStartdate.Text) && !String.IsNullOrEmpty(tbStopdate.Text))
            {
                str += "start=" + Server.UrlEncode(tbStartdate.Text);
                str += "&stop=" + Server.UrlEncode(tbStopdate.Text);
            }
            else if (!String.IsNullOrEmpty(tbStartdate.Text))
            {
                str += "start=" + Server.UrlEncode(tbStartdate.Text);
            }
            else
            {
                str += "stop=" + Server.UrlEncode(tbStopdate.Text);
            }
            return str;
        }
    }
}
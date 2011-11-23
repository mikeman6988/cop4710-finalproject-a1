using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRDataLayer;

namespace RescueReceiving
{
    public partial class report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RRDataManager mgr = (RRDataManager)Application["RRDataManager"];
            List<RRDataObject> myCalls = mgr.getRecordsForQuery();
            Response.Write("<table border>");
            Response.Write("<tr>");
            List<String> myfnames = mgr.getFieldNames();
            foreach (String val in myfnames)
            {
                Response.Write("<th>" + val.ToString() + "</th>");
            }
            Response.Write("</tr>");
            foreach (var call in myCalls)
            {
                Response.Write("<tr>");

                foreach (var key in call.Keys)
                {
                    Response.Write("<td>");

                    Response.Write(call[key].ToString());
                    Response.Write("</td>");
                }

                Response.Write("</tr>");

            }
            Response.Write("</table>");
        }
    }
}
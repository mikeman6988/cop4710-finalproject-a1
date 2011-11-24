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
            List<RRDataObject> myCalls = null;
            RRDataManager mgr = (RRDataManager)Application["RRDataManager"];
            String start = Request.QueryString["start"];
            String stop = Request.QueryString["stop"];
            Nullable<DateTime> dtstart = null;
            Nullable<DateTime> dtstop = null;
            if (!String.IsNullOrEmpty(start))
            {
                dtstart = DateTime.Parse(Server.UrlDecode(start));
            }
            if (!String.IsNullOrEmpty(stop))
            {
                dtstop = DateTime.Parse(Server.UrlDecode(stop));
                dtstop = dtstop.Value.AddMinutes((24 * 60) - 1);
                dtstop = dtstop.Value.AddSeconds(59);

            }


            if (String.IsNullOrEmpty(start) && String.IsNullOrEmpty(stop))
            {
                myCalls = mgr.getRecordsForQuery();
            }
            else //if
            {

                if (!String.IsNullOrEmpty(start) && !String.IsNullOrEmpty(stop))
                {
                    myCalls = mgr.getRecordsForQuery(dtstart, dtstop);
                }
                else if (!String.IsNullOrEmpty(start))
                {
                    myCalls = mgr.getRecordsForQueryStart(dtstart);
                }
                else
                {
                    myCalls = mgr.getRecordsForQueryStop(dtstop);
                }



            }



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
                    if (key.Equals("created_date_time"))
                    {
                        Response.Write("<td><a href=\"create.aspx?callid=" + Server.UrlEncode(call[key].ToString()) +"\">");
                        Response.Write(call[key].ToString());
                        Response.Write("</a></td>");
                    }
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
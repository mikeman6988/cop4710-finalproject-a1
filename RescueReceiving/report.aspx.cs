using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
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

            var row = new TableRow();
            row.Font.Bold = true;

            List<String> myfnames = mgr.getFieldNames();
            foreach (String val in myfnames)
            {
                var cell = new TableCell();
                cell.Text = val.ToString();
                cell.HorizontalAlign = HorizontalAlign.Center;

                row.Cells.Add(cell);
            }
            tblReport.Rows.Add(row);

            foreach (var call in myCalls)
            {
                row = new TableRow();

                foreach (var key in call.Keys)
                {
                    var cell = new TableCell();
                    if (key.Equals("created_date_time"))
                    {
                        cell.Text = "<a href=\"create.aspx?callid=" + Server.UrlEncode(call[key].ToString()) + "\">";
                        cell.Text += call[key].ToString();
                        cell.Text += "</a></td>";
                    }
                    else
                    {
                        cell.Text = call[key].ToString();
                    }
                    row.Cells.Add(cell);
                }

                tblReport.Rows.Add(row);
            }
        }
    }
}
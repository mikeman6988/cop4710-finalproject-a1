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

            var headers = new Dictionary<string, string>();
            headers.Add("created_date_time", "Date");
            headers.Add("unitname", "Unit");
            headers.Add("age", "Age");
            headers.Add("sex", "Sex");
            headers.Add("categoryname", "Category");
            headers.Add("ccdescription", "CC/Description");
            headers.Add("bp_sys1", "BP");
            headers.Add("pulse1", "Pulse");
            headers.Add("resp1", "Resp");
            headers.Add("o2_sat1", "O2 Sat");
            headers.Add("bgl1", "BGL#1/#2");
            headers.Add("loc", "LOC");
            headers.Add("gcs", "GCS");
            headers.Add("t_a", "T/A");
            headers.Add("s_a", "S/A");
            headers.Add("stemi", "Stemi");
            headers.Add("deptname", "Dept");
            headers.Add("level", "Level");
            headers.Add("resus", "Resus");
            headers.Add("eta", "ETA");
            headers.Add("mult_pat", "MPS");

            List<String> myfnames = mgr.getFieldNames();
            foreach (String val in myfnames)
            {
                if (!headers.ContainsKey(val))
                {
                    continue;
                }

                var cell = new TableCell();
                cell.Wrap = true;
                cell.Text = headers[val];
                cell.HorizontalAlign = HorizontalAlign.Center;

                row.Cells.Add(cell);

                if (string.Compare("created_date_time", val, true) == 0)
                {
                    cell = new TableCell();
                    cell.Wrap = true;
                    cell.Text = "Time";
                    cell.HorizontalAlign = HorizontalAlign.Center;

                    row.Cells.Add(cell);
                }
            }
            tblReport.Rows.Add(row);

            foreach (var call in myCalls)
            {
                row = new TableRow();
                foreach (var key in call.Keys)
                {
                    if (!headers.ContainsKey(key))
                    {
                        continue;
                    }

                    var cell = new TableCell();
                    if (string.Compare("created_date_time", key, true) == 0)
                    {
                        DateTime created = (DateTime)call[key];

                        cell.Text = "<a href=\"create.aspx?callid=" + Server.UrlEncode(call[key].ToString()) + "\">";
                        cell.Text += created.ToShortDateString();
                        cell.Text += "</a></td>";

                        row.Cells.Add(cell);

                        cell = new TableCell();
                        TimeSpan time = created.TimeOfDay;
                        cell.Text = time.ToString("hhmm");
                        //cell.Text = created.ToShortTimeString();

                    }
                    else if (string.Compare("age", key, true) == 0)
                    {
                        if ((int)call["age"] != -1)
                        {
                            cell.Text = call["age"].ToString();
                            if (string.Compare(call["age_interval"].ToString(), "M", true) == 0)
                            {
                                cell.Text += " MOS";
                            }
                            else if (string.Compare(call["age_interval"].ToString(), "W", true) == 0)
                            {
                                cell.Text += " WKS";
                            }
                        }
                    }
                    else if (string.Compare("ccdescription", key, true) == 0)
                    {
                        cell.Width = Unit.Pixel(200);
                        cell.Wrap = true;
                        cell.Text = call["ccdescription"].ToString();
                        if (!string.IsNullOrEmpty(call["cc"].ToString()))
                        {
                            cell.Text += "<br/>" + call["cc"].ToString();
                        }
                    }
                    else if (string.Compare("bp_sys1", key, true) == 0)
                    {
                        if ((int)call["bp_sys1"] != -1 && (int)call["bp_dia1"] != -1)
                        {
                            cell.Text = call["bp_sys1"].ToString() + "/" + call["bp_dia1"].ToString();
                        }
                        if ((int)call["bp_sys2"] != -1 && (int)call["bp_dia2"] != -1)
                        {
                            cell.Text += "<br/>" + call["bp_sys2"].ToString() + "/" + call["bp_dia2"].ToString();
                        }
                    }
                    else if (string.Compare("pulse1", key, true) == 0)
                    {
                        if ((int)call["pulse1"] != -1)
                        {
                            cell.Text = call["pulse1"].ToString();
                        }
                        if ((int)call["pulse2"] != -1)
                        {
                            cell.Text += "<br/>" + call["pulse2"].ToString();
                        }
                    }
                    else if (string.Compare("resp1", key, true) == 0)
                    {
                        
                        if ((int)call["resp1"] != -1)
                        {
                            cell.Text = call["resp1"].ToString();
                        }
                        if ((int)call["resp2"] != -1)
                        {
                            cell.Text += "<br/>" + call["resp2"].ToString();
                        }
                    }
                    else if (string.Compare("o2_sat1", key, true) == 0)
                    {
                        if ((int)call["o2_sat1"] != -1)
                        {
                            cell.Text = call["o2_sat1"].ToString();
                        }
                        if ((int)call["o2_sat2"] != -1)
                        {
                            cell.Text += "<br/>" + call["o2_sat2"].ToString();
                        }
                    }
                    else if (string.Compare("bgl1", key, true) == 0)
                    {
                        if ((int)call["bgl1"] != -1)
                        {
                            cell.Text = call["bgl1"].ToString();
                        }
                        if ((int)call["bgl2"] != -1)
                        {
                            cell.Text += "/";
                            cell.Text += call["bgl2"].ToString();
                        }

                    }
                    else if (string.Compare("loc", key, true) == 0)
                    {
                        if ((string)call["loc"] != "U")
                        {
                            cell.Text = call["loc"].ToString();
                        }
                    }
                    else if (string.Compare("gcs", key, true) == 0)
                    {
                        if ((int)call["gcs"] != -1)
                        {
                            cell.Text = call["gcs"].ToString();
                        }
                    }
                    else if (string.Compare("t_a", key, true) == 0)
                    {
                        if ((bool)call["t_a"] != false)
                        {
                            cell.Text = "Y";
                        }
                    }
                    else if (string.Compare("s_a", key, true) == 0)
                    {
                        if ((bool)call["s_a"] != false)
                        {
                            cell.Text = "Y";
                        }
                    }
                    else if (string.Compare("stemi", key, true) == 0)
                    {
                        if ((bool)call["stemi"] != false)
                        {
                            cell.Text = "Y";
                        }
                    }
                    else if (string.Compare("deptname", key, true) == 0)
                    {
                        if ((string)call["deptname"] != "N/A")
                        {
                            cell.Text = call["deptname"].ToString();
                        }
                    }
                    else if (string.Compare("level", key, true) == 0)
                    {
                        if ((string)call["level"] != "0")
                        {
                            cell.Text = call["level"].ToString();
                        }
                    }
                    else if (string.Compare("resus", key, true) == 0)
                    {
                        if ((bool)call["resus"] != false)
                        {
                            cell.Text = "Y";
                        }
                    }
                    else if (string.Compare("eta", key, true) == 0)
                    {
                        if ((int)call["eta"] != -1)
                        {
                            cell.Text = call["eta"].ToString();
                        }
                    }
                    else if (string.Compare("mult_pat", key, true) == 0)
                    {
                        if ((bool)call["mult_pat"] != false)
                        {
                            cell.Text = "Y";
                        }
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
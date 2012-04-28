using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.Security;
using RRDataLayer;

namespace RescueReceiving
{
    public partial class report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool bIsAdmin = Roles.IsUserInRole("Admin");

            btnDelete1.Visible = bIsAdmin;
            btnDelete2.Visible = bIsAdmin;

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

            string strUser = string.Empty;
            if (!(bIsAdmin ||
                Roles.IsUserInRole("Report")))
            {
                strUser = User.Identity.Name;
            }

            if (String.IsNullOrEmpty(start) && String.IsNullOrEmpty(stop))
            {
                myCalls = mgr.getRecordsForQuery(strUser);
            }
            else //if
            {

                if (!String.IsNullOrEmpty(start) && !String.IsNullOrEmpty(stop))
                {
                    myCalls = mgr.getRecordsForQuery(dtstart, dtstop, strUser);
                }
                else if (!String.IsNullOrEmpty(start))
                {
                    myCalls = mgr.getRecordsForQueryStart(dtstart, strUser);
                }
                else
                {
                    myCalls = mgr.getRecordsForQueryStop(dtstop, strUser);
                }
            }

            var row = new TableRow();
            row.Font.Bold = true;

            var headers = new Dictionary<string, string>();
            headers.Add("created_date_time", "Date");
            headers.Add("countyName", "County");
            headers.Add("unitname", "Unit");
            headers.Add("age", "Age");
            headers.Add("pc_color", "Ped Color");
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

            // Admins get selection column for delete
            //
            if (bIsAdmin)
            {
                var cell = new TableCell();
                cell.Text = "&nbsp;";
                row.Cells.Add(cell);
            }

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

                // Add check box for delete
                //
                if (bIsAdmin)
                {
                    var cell = new TableCell();
                    cell.HorizontalAlign = HorizontalAlign.Center;

                    var checkbox = new CheckBox();
                    checkbox.ID = "cbDelete" + call["id"].ToString();

                    cell.Controls.Add(checkbox);
                    row.Cells.Add(cell);
                }

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

                        cell.Text = "<a href=\"create.aspx?callid=" + call["id"].ToString() + "\">";
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
                        if (SafeToInt(call["age"]) != -1)
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
                        cell.Text = call["ccdescription"].ToString();
                        if (!string.IsNullOrEmpty(call["cc"].ToString()))
                        {
                            cell.Text += "<br/>" + call["cc"].ToString();
                        }
                    }
                    else if (string.Compare("bp_sys1", key, true) == 0)
                    {
                        if (SafeToInt(call["bp_sys1"]) != -1 && SafeToInt(call["bp_dia1"]) != -1)
                        {
                            cell.Text = call["bp_sys1"].ToString() + "/" + call["bp_dia1"].ToString();
                        }
                        if (SafeToInt(call["bp_sys2"]) != -1 && SafeToInt(call["bp_dia2"]) != -1)
                        {
                            cell.Text += "<br/>" + call["bp_sys2"].ToString() + "/" + call["bp_dia2"].ToString();
                        }
                    }
                    else if (string.Compare("pulse1", key, true) == 0)
                    {
                        if (SafeToInt(call["pulse1"]) != -1)
                        {
                            cell.Text = call["pulse1"].ToString();
                        }
                        if (SafeToInt(call["pulse2"]) != -1)
                        {
                            cell.Text += "<br/>" + call["pulse2"].ToString();
                        }
                    }
                    else if (string.Compare("resp1", key, true) == 0)
                    {
                        
                        if (SafeToInt(call["resp1"]) != -1)
                        {
                            cell.Text = call["resp1"].ToString();
                        }
                        if (SafeToInt(call["resp2"]) != -1)
                        {
                            cell.Text += "<br/>" + call["resp2"].ToString();
                        }
                    }
                    else if (string.Compare("o2_sat1", key, true) == 0)
                    {
                        if (SafeToInt(call["o2_sat1"]) != -1)
                        {
                            cell.Text = call["o2_sat1"].ToString();
                        }
                        if (SafeToInt(call["o2_sat2"]) != -1)
                        {
                            cell.Text += "<br/>" + call["o2_sat2"].ToString();
                        }
                    }
                    else if (string.Compare("bgl1", key, true) == 0)
                    {
                        if (SafeToInt(call["bgl1"]) != -1)
                        {
                            cell.Text = call["bgl1"].ToString();
                        }
                        if (SafeToInt(call["bgl2"]) != -1)
                        {
                            cell.Text += "/";
                            cell.Text += call["bgl2"].ToString();
                        }

                    }
                    else if (string.Compare("loc", key, true) == 0)
                    {
                        if (SafeToString(call["loc"]) != "U")
                        {
                            cell.Text = call["loc"].ToString();
                        }
                    }
                    else if (string.Compare("gcs", key, true) == 0)
                    {
                        if (SafeToInt(call["gcs"]) != -1)
                        {
                            cell.Text = call["gcs"].ToString();
                        }
                    }
                    else if (string.Compare("t_a", key, true) == 0)
                    {
                        if (SafeToBool(call["t_a"]) != false)
                        {
                            cell.Text = "Y";
                        }
                    }
                    else if (string.Compare("s_a", key, true) == 0)
                    {
                        if (SafeToBool(call["s_a"]) != false)
                        {
                            cell.Text = "Y";
                        }
                    }
                    else if (string.Compare("stemi", key, true) == 0)
                    {
                        if (SafeToBool(call["stemi"]) != false)
                        {
                            cell.Text = "Y";
                        }
                    }
                    else if (string.Compare("deptname", key, true) == 0)
                    {
                        if (SafeToString(call["deptname"]) != "N/A")
                        {
                            cell.Text = call["deptname"].ToString();
                        }
                    }
                    else if (string.Compare("level", key, true) == 0)
                    {
                        if (SafeToString(call["level"]) != "0")
                        {
                            cell.Text = call["level"].ToString();
                        }
                    }
                    else if (string.Compare("resus", key, true) == 0)
                    {
                        if (SafeToBool(call["resus"]) != false)
                        {
                            cell.Text = "Y";
                        }
                    }
                    else if (string.Compare("eta", key, true) == 0)
                    {
                        if (SafeToInt(call["eta"]) != -1)
                        {
                            cell.Text = call["eta"].ToString();
                        }
                    }
                    else if (string.Compare("mult_pat", key, true) == 0)
                    {
                        if (SafeToBool(call["mult_pat"]) != false)
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

        // Utility for converting a string to Int32
        //
        private int SafeToInt(string value)
        {
            int n = -1;     // failure
            try
            {
                n = Convert.ToInt32(value);
            }
            catch
            {
            }
            return n;
        }
            //Overload Method for SafeToInt
        private int SafeToInt(object value)
        {
            
            return SafeToInt(value.ToString());
        }

        // Utility for converting a string to string
        private string SafeToString(string value)
        {
            string n = "-1";
            try
            {
                n = value;
                if (value == null)
                {
                    n = "-1";
                }
            }
            catch
            {
            }
            return n;
        }
            //Overload Method for SafeToString
        private string SafeToString(object value)
        {
            return SafeToString(value.ToString());
        }

        private bool SafeToBool(bool value)
        {
            bool n = false;
            try
            {
                n = value;
            }
            catch
            {
            }
            return n;
        }

        private bool SafeToBool(object value)
        {
            try
            {
                return SafeToBool((bool)value);
            }
            catch
            {
            }

            return false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            deleteSelectedCalls(this);

            Response.Redirect(Request.RawUrl);
        }

        private void deleteSelectedCalls(Control parent)
        {
            var mgr = Application["RRDataManager"] as RRDataManager;

            if (parent == null)
            {
                return;
            }
            foreach (Control control in parent.Controls)
            {
                if (control is CheckBox)
                {
                    var checkBox = control as CheckBox;
                    var strName = checkBox.ID;
                    if (checkBox.Checked && strName.StartsWith("cbDelete"))
                    {
                        var strId = strName.Substring(8);
                        int nId = -1;
                        if (int.TryParse(strId, out nId))
                        {
                            mgr.deleteEmergencyCall(nId);
                        }
                    }
                }
                deleteSelectedCalls(control);
            }
        }
    }
}


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
    public partial class Export : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string attachment = "attachment; filename=EmergencyCalls.csv";
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            HttpContext.Current.Response.ContentType = "text/csv";
            HttpContext.Current.Response.AddHeader("Pragma", "public");

            bool bIsAdmin = Roles.IsUserInRole("Admin");

            List<RRDataObject> myCalls = null;
            
            var mgr = Application["RRDataManager"] as RRDataManager;
            string start = Request.QueryString["start"];
            string stop = Request.QueryString["stop"];
            
            Nullable<DateTime> dtstart = null;
            Nullable<DateTime> dtstop = null;
            
            if (!string.IsNullOrEmpty(start))
            {
                dtstart = DateTime.Parse(Server.UrlDecode(start));
            }
            if (!string.IsNullOrEmpty(stop))
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

            if (string.IsNullOrEmpty(start) && string.IsNullOrEmpty(stop))
            {
                myCalls = mgr.getRecordsForQuery(strUser);
            }
            else //if
            {
                if (!string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(stop))
                {
                    myCalls = mgr.getRecordsForQuery(dtstart, dtstop, strUser);
                }
                else if (!string.IsNullOrEmpty(start))
                {
                    myCalls = mgr.getRecordsForQueryStart(dtstart, strUser);
                }
                else
                {
                    myCalls = mgr.getRecordsForQueryStop(dtstop, strUser);
                }
            }

            var headers = new Dictionary<string, string>();
            headers.Add("created_date_time", "Date");
            headers.Add("countyName", "County");
            headers.Add("unitname", "Unit");
            headers.Add("age", "Age");
            headers.Add("pc_color", "Ped Color");
            headers.Add("sex", "Sex");
            headers.Add("categoryname", "Category");
            headers.Add("ccdescription", "Description");
            headers.Add("cc", "CC");
            headers.Add("bp_sys1", "BP 1");
            headers.Add("bp_sys2", "BP 2");
            headers.Add("pulse1", "Pulse 1");
            headers.Add("pulse2", "Pulse 2");
            headers.Add("resp1", "Resp 1");
            headers.Add("resp2", "Resp 2");
            headers.Add("o2_sat1", "O2 Sat 1");
            headers.Add("o2_sat2", "O2 Sat 2");
            headers.Add("bgl1", "BGL 1");
            headers.Add("bgl2", "BGL 2");
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

            bool bIsFirst = true;
            foreach (var entry in headers)
            {
                if (bIsFirst)
                {
                    bIsFirst = false;
                }
                else
                {
                    Response.Write(",");
                }
                Response.Write(entry.Value);
                if (string.Compare("created_date_time", entry.Key, true) == 0)
                {
                    Response.Write(",Time");
                }
            }
            Response.Write(Environment.NewLine);

            foreach (var call in myCalls)
            {
                foreach (var key in headers.Keys)
                {
                    if (!headers.ContainsKey(key))
                    {
                        continue;
                    }

                    if (string.Compare("created_date_time", key, true) == 0)
                    {
                        DateTime created = (DateTime) call[key];
                        var time = created.TimeOfDay;

                        Response.Write(created.ToShortDateString());
                        Response.Write("," + time.ToString("hhmm"));
                    }
                    else if (string.Compare("age", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToInt(call["age"]) != -1)
                        {
                            Response.Write(call["age"].ToString());
                            if (string.Compare(call["age_interval"].ToString(), "M", true) == 0)
                            {
                                Response.Write(" MOS");
                            }
                            else if (string.Compare(call["age_interval"].ToString(), "W", true) == 0)
                            {
                                Response.Write(" WKS");
                            }
                        }
                    }
                    else if (string.Compare("cc", key, true) == 0)
                    {
                        Response.Write(",");
                        string strCC = call["cc"].ToString();
                        if (!string.IsNullOrEmpty(strCC))
                        {
                            strCC = strCC.Replace("\"", "\"\"");
                            Response.Write("\"" + strCC + "\"");
                        }
                    }
                    else if (string.Compare("bp_sys1", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToInt(call["bp_sys1"]) != -1 && SafeToInt(call["bp_dia1"]) != -1)
                        {
                            Response.Write(call["bp_sys1"].ToString() + "/" + call["bp_dia1"].ToString());
                        }
                    }
                    else if (string.Compare("bp_sys2", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToInt(call["bp_sys2"]) != -1 && SafeToInt(call["bp_dia2"]) != -1)
                        {
                            Response.Write(call["bp_sys2"].ToString() + "/" + call["bp_dia2"].ToString());
                        }
                    }
                    else if (string.Compare("pulse1", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToInt(call["pulse1"]) != -1)
                        {
                            Response.Write(call["pulse1"].ToString());
                        }
                    }
                    else if (string.Compare("pulse2", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToInt(call["pulse2"]) != -1)
                        {
                            Response.Write(call["pulse2"].ToString());
                        }
                    }
                    else if (string.Compare("resp1", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToInt(call["resp1"]) != -1)
                        {
                            Response.Write(call["resp1"].ToString());
                        }
                    }
                    else if (string.Compare("resp2", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToInt(call["resp2"]) != -1)
                        {
                            Response.Write(call["resp2"].ToString());
                        }
                    }
                    else if (string.Compare("o2_sat1", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToInt(call["o2_sat1"]) != -1)
                        {
                            Response.Write(call["o2_sat1"].ToString());
                        }
                    }
                    else if (string.Compare("o2_sat2", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToInt(call["o2_sat2"]) != -1)
                        {
                            Response.Write(call["o2_sat2"].ToString());
                        }
                    }
                    else if (string.Compare("bgl1", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToInt(call["bgl1"]) != -1)
                        {
                            Response.Write(call["bgl1"].ToString());
                        }
                     }
                    else if (string.Compare("bgl2", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToInt(call["bgl2"]) != -1)
                        {
                            Response.Write(call["bgl2"].ToString());
                        }
                    }
                    else if (string.Compare("loc", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToString(call["loc"]) != "U")
                        {
                            Response.Write(call["loc"].ToString());
                        }
                    }
                    else if (string.Compare("gcs", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToInt(call["gcs"]) != -1)
                        {
                            Response.Write(call["gcs"].ToString());
                        }
                    }
                    else if (string.Compare("t_a", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToBool(call["t_a"]) != false)
                        {
                            Response.Write("Y");
                        }
                    }
                    else if (string.Compare("s_a", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToBool(call["s_a"]) != false)
                        {
                            Response.Write("Y");
                        }
                    }
                    else if (string.Compare("stemi", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToBool(call["stemi"]) != false)
                        {
                            Response.Write("Y");
                        }
                    }
                    else if (string.Compare("deptname", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToString(call["deptname"]) != "N/A")
                        {
                            Response.Write(call["deptname"].ToString());
                        }
                    }
                    else if (string.Compare("level", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToString(call["level"]) != "0")
                        {
                            Response.Write(call["level"].ToString());
                        }
                    }
                    else if (string.Compare("resus", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToBool(call["resus"]) != false)
                        {
                            Response.Write("Y");
                        }
                    }
                    else if (string.Compare("eta", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToInt(call["eta"]) != -1)
                        {
                            Response.Write(call["eta"].ToString());
                        }
                    }
                    else if (string.Compare("mult_pat", key, true) == 0)
                    {
                        Response.Write(",");
                        if (SafeToBool(call["mult_pat"]) != false)
                        {
                            Response.Write("Y");
                        }
                    }
                    else
                    {
                        Response.Write(",");
                        Response.Write(call[key].ToString());
                    }
                }

                Response.Write(Environment.NewLine); ;
            }

            HttpContext.Current.Response.End();
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
    }
}


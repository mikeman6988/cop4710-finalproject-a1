using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;

using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb; //This namespace is mainly used for dealing with 
//Excel sheet data
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using RRDataLayer;

namespace RescueReceiving
{
    public partial class import : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private int FindUnitId(string unitName, List<RRUnit> units)
        {
            int id = -1;
            unitName = "R-" + unitName;
            foreach (var unit in units)
            {
                if (string.Compare(unit.Name, unitName, true) == 0)
                {
                    id = unit.Id;
                    break;
                }
            }
            return id;
        }

        private int FindCategoryId(string categoryName, List<RRCategory> categories)
        {
            int id = -1;
            foreach (var category in categories)
            {
                if (string.Compare(category.Name, categoryName, true) == 0)
                {
                    id = category.Id;
                    break;
                }
            }
            return id;
        }

        private int FindComplaintId(string complaintName, List<RRChiefComplaint> complaints)
        {
            int id = -1;
            foreach (var complaint in complaints)
            {
                if (string.Compare(complaint.Name, complaintName, true) == 0)
                {
                    id = complaint.Id;
                    break;
                }
            }
            return id;
        }

        private int FindDeptId(string deptName, List<RRDepartment> depts)
        {
            int id = -1;
            foreach (var dept in depts)
            {
                if (string.Compare(dept.Name, deptName, true) == 0)
                {
                    id = dept.Id;
                    break;
                }
            }
            return id;
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            RRDataManager mgr = (RRDataManager)Application["RRDataManager"];
            DataTable dt = (DataTable)Application["dt"];

            List<RRUnit> units = mgr.getAllUnitItems();
            List<RRCategory> categories = mgr.getAllCategoryItems();
            List<RRChiefComplaint> complaints = mgr.getCCListItems();
            List<RRDepartment> depts = mgr.getAllDepartmentItems();

             //dictionary
            var headers = new Dictionary<string, string>();
            headers.Add("Date", "created_date_time");
            headers.Add("Unit", "unit");
            headers.Add("Age", "age");
            headers.Add("Sex", "sex");
            headers.Add("Category", "category");
            headers.Add("CC/Description", "ccid");
            headers.Add("BP", "bp_sys1");
            headers.Add("P", "pulse1");
            headers.Add("R", "resp1");
            headers.Add("O2 Sat", "o2_sat1");
            headers.Add("BGL#1/#2", "bgl1");
            headers.Add("LOC", "loc");
            headers.Add("GCS", "gcs");
            headers.Add("T/A", "t_a");
            headers.Add("S/A", "s_a");
            headers.Add("Stemi", "stemi");
            headers.Add("TC/ER/Peds", "receiving_dept");
            headers.Add("Level 1,2,3,T, Resus", "level");
            headers.Add("ETA", "eta");

            //String fileName = "~\\tmp\\" + Path.GetRandomFileName();
            //FileUpload1.SaveAs(Server.MapPath(fileName));
            //OleDbConnection oconn = new OleDbConnection
            //(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
           // Server.MapPath(fileName) + ";" +
           // "Extended Properties=Excel 8.0");//OledbConnection and 
            // connectionstring to connect to the Excel Sheet
            try
            {
                //oconn.Open(); 
                //OleDbDataAdapter da = new OleDbDataAdapter("select * from [Sheet1$]", oconn);
                //DataTable dt = new DataTable();
                
                //da.Fill(dt);
                //After connecting to the Excel sheet here we are selecting the data 
                //using select statement from the Excel sheet
                //OleDbCommand ocmd = new OleDbCommand("select * from [Sheet1$]", oconn);
                //oconn.Open();  //Here [Sheet1$] is the name of the sheet 
                //in the Excel file where the data is present
                //OleDbDataReader odr = ocmd.ExecuteReader();
                //DataTable dt = GridView1.DataSource as DataTable;
                //DataTable tdt = this.gridTable;
                DataTableReader odr = dt.CreateDataReader();
                //while(dt.CreateDataReader
                while (odr.Read())
                {

                    RRDataObject daOb = new RRDataObject();
                    for (int i = 0; i < odr.FieldCount;i++)
                    {
                        String keyName = odr.GetName(i);
                        if (!headers.ContainsKey(keyName))
                        {
                            continue;   // skip to next column
                        }

                        string field = headers[keyName];
                        if (string.Compare(field, "created_date_time", true) == 0)
                        {
                            CultureInfo enUS = new CultureInfo("en-US");
                            string strDate = odr[i].ToString();
                            if (string.IsNullOrEmpty(strDate))
                            {
                                try
                                {
                                    DateTime date = odr.GetDateTime(i);
                                    strDate = date.ToShortDateString();
                                }
                                catch
                                {
                                }
                            }
                            string strTime = odr[i + 1].ToString();

                            try
                            {
                                var time = DateTime.ParseExact(strDate + " " + strTime, "MM/dd/yy hhmm", enUS, DateTimeStyles.None);
                                daOb[field] = time;
                            }
                            catch
                            {
                                daOb[field] = DateTime.Now;
                            }
                        }
                        else if (string.Compare(field, "unit", true) == 0)
                        {
                            daOb[field] = FindUnitId(odr[i].ToString(), units);
                        }
                        else if (string.Compare(field, "age", true) == 0)
                        {
                            string strAge = odr[i].ToString();
                            if (strAge.IndexOf("MOS") != -1)
                            {
                                daOb["age_interval"] = "M";
                            }
                            else if (strAge.IndexOf("WKS") != -1)
                            {
                                daOb["age_interval"] = "W";
                            }
                            else
                            {
                                daOb["age_interval"] = "Y";
                            }

                            int nAge = -1;
                            if (!int.TryParse(strAge, out nAge))
                            {
                                nAge = -1;
                            }

                            daOb[field] = nAge;
                        }
                        else if (string.Compare(field, "sex", true) == 0)
                        {
                            string strSex = odr[i].ToString();
                            if (strSex.Length > 1)
                            {
                                strSex = strSex.Substring(0, 1);
                            }
                            daOb[field] = strSex;
                        }
                        else if (string.Compare(field, "category", true) == 0)
                        {
                            daOb[field] = FindCategoryId(odr[i].ToString(), categories);
                        }
                        else if (string.Compare(field, "ccid", true) == 0)
                        {
                            int id = FindComplaintId(odr[i].ToString(), complaints);
                            daOb[field] = id;
                            if (id == -1)
                            {
                                daOb["cc"] = odr[i].ToString();
                            }
                        }
                        else if (string.Compare(field, "bp_sys1", true) == 0)
                        {
                            string strBP = odr[i].ToString();
                            string[] bps = strBP.Split('/');
                            if (bps.Length == 2)
                            {
                                int sys1 = -1;
                                if (!int.TryParse(bps[0], out sys1))
                                {
                                    sys1 = -1;
                                }

                                int dia1 = -1;
                                if (!int.TryParse(bps[1], out dia1))
                                {
                                    dia1 = -1;
                                }

                                daOb["bp_sys1"] = sys1;
                                daOb["bp_dia1"] = dia1;
                            }
                        }
                        else if (string.Compare(field, "pulse1", true) == 0)
                        {
                            int pulse = -1;
                            if (!int.TryParse(odr[i].ToString(), out pulse))
                            {
                                pulse = -1;
                            }
                            daOb[field] = pulse;
                        }
                        else if (string.Compare(field, "resp1", true) == 0)
                        {
                            int resp = -1;
                            if (!int.TryParse(odr[i].ToString(), out resp))
                            {
                                resp = -1;
                            }
                            daOb[field] = resp;
                        }
                        else if (string.Compare(field, "o2_sat1", true) == 0)
                        {
                            int o2sat = -1;
                            if (!int.TryParse(odr[i].ToString(), out o2sat))
                            {
                                o2sat = -1;
                            }
                            daOb[field] = o2sat;
                        }
                        else if (string.Compare(field, "bgl1", true) == 0)
                        {
                            string strBGL = odr[i].ToString();
                            string[] bgls = strBGL.Split('/');
                            int j = 1;
                            foreach (var bgl in bgls)
                            {
                                int val = -1;
                                if (!int.TryParse(bgl, out val))
                                {
                                    val = -1;
                                }

                                daOb["bgl" + j] = val;
                                ++j;

                                if (j > 2)
                                {
                                    break;
                                }
                            }
                        }
                        else if (string.Compare(field, "loc", true) == 0)
                        {
                            string strLoc = odr[i].ToString();

                            if (string.IsNullOrEmpty(strLoc))
                            {
                                strLoc = "U";
                            }

                            if (!(string.Compare(strLoc, "Y", true) == 0 ||
                                  string.Compare(strLoc, "N", true) == 0 ||
                                  string.Compare(strLoc, "U", true) == 0))
                            {
                                strLoc = "U";
                            }

                            daOb[field] = strLoc;
                        }
                        else if (string.Compare(field, "gcs", true) == 0)
                        {
                            string strGcs = odr[i].ToString();
                            int gcs = -1;
                            if (string.IsNullOrEmpty(strGcs))
                            {
                                gcs = -1;
                            }
                            daOb[field] = gcs;
                        }
                        else if (string.Compare(field, "t_a", true) == 0)
                        {
                            string strTA = odr[i].ToString();
                            if (string.Compare(strTA, "Y", true) == 0)
                            {
                                daOb[field] = true;
                            }
                        }
                        else if (string.Compare(field, "s_a", true) == 0)
                        {
                            string strSA = odr[i].ToString();
                            if (string.Compare(strSA, "Y", true) == 0)
                            {
                                daOb[field] = true;
                            }
                        }
                        else if (string.Compare(field, "stemi", true) == 0)
                        {
                            string strStemi = odr[i].ToString();
                            if (string.Compare(strStemi, "Y", true) == 0)
                            {
                                daOb[field] = true;
                            }
                        }
                        else if (string.Compare(field, "receiving_dept", true) == 0)
                        {
                            daOb[field] = FindDeptId(odr[i].ToString(), depts);
                        }
                        else if (string.Compare(field, "level", true) == 0)
                        {
                            string strLevel = odr[i].ToString();
                            if (string.Compare(strLevel, "RESUS", true) == 0)
                            {
                                strLevel = "0";
                                daOb["resus"] = true;
                            }
                            if (string.IsNullOrEmpty(strLevel))
                            {
                                strLevel = "0";
                            }
                            daOb[field] = strLevel;
                        }
                        else if (string.Compare(field, "eta", true) == 0)
                        {
                            int eta = -1;
                            if (!int.TryParse(odr[i].ToString(), out eta))
                            {
                                eta = -1;
                            }
                            daOb[field] = eta;
                        }
                    }
                    mgr.createTableRow("EmergencyCall", daOb);
                }
                
                //oconn.Close();
            }
            catch (DataException ee)
            {
                
            }
            finally
            {
                
            }
            btnImport.Visible = false;
            btnView.Visible = true;

            Response.Write("<p>Finished importing!</p>");
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
             String fileName = "~\\tmp\\" + Path.GetRandomFileName();
            FileUpload1.SaveAs(Server.MapPath(fileName));
            OleDbConnection oconn = new OleDbConnection
            (@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
            Server.MapPath(fileName) + ";" +
            "Extended Properties=Excel 8.0");//OledbConnection and 
            // connectionstring to connect to the Excel Sheet
            try
            {
                oconn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from [Sheet1$]", oconn);
                //DataTable dt = new DataTable();
                Application["dt"] = new DataTable();
                DataTable dt = (DataTable)Application["dt"];

                //dt.Columns.Add("Date", typeof(DateTime));
                //dt.Columns.Add("Time", typeof(TimeSpan));
                //dt.Columns.Add("Unit", typeof(string));
                //dt.Columns.Add("Age", typeof(string));
                //dt.Columns.Add("Sex", typeof(string));
                //dt.Columns.Add("Category", typeof(string));
                //dt.Columns.Add("CC/Description", typeof(string));
                //dt.Columns.Add("BP", typeof(string));
                //dt.Columns.Add("P", typeof(int));
                //dt.Columns.Add("R", typeof(int));
               // dt.Columns.Add("O2 Sat", typeof(int));
                //dt.Columns.Add("BGL#1/#2", typeof(int));
                //dt.Columns.Add("LOC", typeof(string));
                //dt.Columns.Add("GCS", typeof(string));
               // dt.Columns.Add("T/A", typeof(string));
               // dt.Columns.Add("S/A", typeof(string));
                //dt.Columns.Add("Stemi", typeof(string));
                dt.Columns.Add("Level 1,2,3,T, Resus", typeof(String));
                //dt.Columns.Add("ACS", typeof(string));
                dt.Columns.Add("ETA", typeof(String));
                
               
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                
                oconn.Close();
                this.btnImport.Visible = true;
                this.btnView.Visible = false;
                //this.tbFilename.Text = fileName;
                
            }
            catch(Exception ex)
            {

            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            this.GridView1.DataSource = null;
            GridView1.DataBind();
            btnView.Visible = true;
            btnImport.Visible = false;
        } 
    }
}
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

        protected void btnImport_Click(object sender, EventArgs e)
        {
            RRDataManager mgr = (RRDataManager)Application["RRDataManager"];

            List<RRUnit> units = mgr.getAllUnitItems();
            List<RRCategory> categories = mgr.getAllCategoryItems();
            List<RRChiefComplaint> complaints = mgr.getCCListItems();

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
            headers.Add("TC/ER/Peds", "deptname");
            headers.Add("Level 1,2,3,T, Resus", "level");
            headers.Add("ETA", "eta");

            String fileName = "~\\tmp\\" + Path.GetRandomFileName();
            FileUpload1.SaveAs(Server.MapPath(fileName));
            OleDbConnection oconn = new OleDbConnection
            (@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
            Server.MapPath(fileName) + ";" +
            "Extended Properties=Excel 8.0");//OledbConnection and 
            // connectionstring to connect to the Excel Sheet
            try
            {
                //After connecting to the Excel sheet here we are selecting the data 
                //using select statement from the Excel sheet
                OleDbCommand ocmd = new OleDbCommand("select * from [Sheet1$]", oconn);
                oconn.Open();  //Here [Sheet1$] is the name of the sheet 
                //in the Excel file where the data is present
                OleDbDataReader odr = ocmd.ExecuteReader();
                List<RRDataObject> daObs = new List<RRDataObject>();

                while (odr.Read())
                {
                    RRDataObject daOb = new RRDataObject();
                    for (int i = 0; i < odr.FieldCount;i++)
                    {
                        String keyName = odr.GetName(i);
                        if (headers.ContainsKey(keyName))
                        {
                            continue;   // skip to next column
                        }

                        string field = headers[keyName];
                        if (string.Compare(field, "created_date_time", true) == 0)
                        {
                            CultureInfo enUS = new CultureInfo("en-US");
                            string strDate = odr[i].ToString();
                            string strTime = odr[i + 1].ToString();
                            
                            var time = DateTime.ParseExact(strDate + " " + strTime, "MM/dd/yy hhmm", enUS, DateTimeStyles.None);
                            daOb[field] = time;
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
                            int.TryParse(strAge, out nAge);

                            daOb[field] = nAge;
                        }
                        else if (string.Compare(field, "sex", true) == 0)
                        {
                            daOb[field] = odr[i].ToString();
                        }
                        else if (string.Compare(field, "category", true) == 0)
                        {
                            int id = FindCategoryId(odr[i].ToString(), categories);
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
                                int.TryParse(bps[0], out sys1);

                                int dia1 = -1;
                                int.TryParse(bps[1], out dia1);

                                daOb["bp_sys1"] = sys1;
                                daOb["bp_dia1"] = sys1;
                            }
                        }
                        else if (string.Compare(field, "pulse1", true) == 0)
                        {
                            int pulse = -1;
                            int.TryParse(odr[i].ToString(), out pulse);
                            daOb[field] = pulse;
                        }
                        else if (string.Compare(field, "resp1", true) == 0)
                        {
                            int resp = -1;
                            int.TryParse(odr[i].ToString(), out resp);
                            daOb[field] = resp;
                        }
                        else if (string.Compare(field, "o2_sat1", true) == 0)
                        {
                            int o2sat = -1;
                            int.TryParse(odr[i].ToString(), out o2sat);
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
                                int.TryParse(bgl, out val);

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
                        }


                    }
                    daObs.Add(daOb);
                    
                }
                
                oconn.Close();
            }
            catch (DataException ee)
            {
                
            }
            finally
            {
                
            }

        } 
    }
}
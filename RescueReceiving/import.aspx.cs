using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

namespace RescueReceiving
{
    public partial class import : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

         protected void Button1_Click(object sender, EventArgs e)
        {
            String x = this.FileUpload1.FileName;
            OleDbConnection oconn = new OleDbConnection
            (@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
            //Server.MapPath(this.FileUpload1.) + ";" +
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
                /*string fname = "";
                string lname = "";
                string mobnum = "";
                string city = "";
                string state = "";
                string zip = "";
                while (odr.Read())
                {
                    fname = valid(odr, 0);//Here we are calling the valid method
                    lname = valid(odr, 1);
                    mobnum = valid(odr, 2);
                    city = valid(odr, 3);
                    state = valid(odr, 4);
                    zip = valid(odr, 5);
                    //Here using this method we are inserting the data into the database
	           insertdataintosql(fname, lname, mobnum, city, state, zip);
                }*/
                oconn.Close();
            }
            catch (DataException ee)
            {
                /* lblmsg.Text = ee.Message;
                 lblmsg.ForeColor = System.Drawing.Color.Red;*/
            }
            finally
            {
                /*
                lblmsg.Text = "Data Inserted Sucessfully";
                lblmsg.ForeColor = System.Drawing.Color.Green;*/
            }

        } 
    }
}
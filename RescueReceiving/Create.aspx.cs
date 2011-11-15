using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRDataLayer;

namespace RescueReceiving
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var call = new EmergencyCall();
            call["test"] = "hello world";
            call["int"] = 5;
            call["bool"] = true;

            foreach (var key in call.Keys)
            {
                object curr = call[key];
            }
        }
    }
}
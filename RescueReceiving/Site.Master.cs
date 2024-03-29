﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace RescueReceiving
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                if (Roles.IsUserInRole("Admin"))
                {
                    var adminMenuItem = new MenuItem();
                    adminMenuItem.Text = "Admin";
                    adminMenuItem.NavigateUrl = "~/Admin.aspx";
                    NavigationMenu.Items.AddAt(1, adminMenuItem);
                }

                var reportMenuItem = new MenuItem();
                reportMenuItem.Text = "Reports";
                reportMenuItem.NavigateUrl = "~/Reporting.aspx";
                NavigationMenu.Items.AddAt(1, reportMenuItem);

                var createMenuItem = new MenuItem();
                createMenuItem.Text = "Create";
                createMenuItem.NavigateUrl = "~/Create.aspx";
                NavigationMenu.Items.AddAt(1, createMenuItem);

                var profileMenuItem = new MenuItem();
                profileMenuItem.Text = "Profile";
                profileMenuItem.NavigateUrl = "~/Profile.aspx";
                NavigationMenu.Items.Add(profileMenuItem);
            }
        }
    }
}

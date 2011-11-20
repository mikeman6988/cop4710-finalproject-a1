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
            initNew();

            // If we have an emergency call then use it to fill
            // the form with its data.
            //
            //initWithData();
        }

        // Used to fill form with drop down lists and other data
        // driven UI controls
        //
        private void initNew()
        {
            // Set the date and time
            //
            tbDate.Text = DateTime.Now.Date.ToShortDateString();
            tbTime.Text = DateTime.Now.Date.ToShortTimeString();

            // Get the county list
            //
            List<RRCounty> counties = GetCounties();
            foreach (var county in counties)
            {
                var item = new ListItem(county.Name, 
                                        county.Id.ToString()); 
                ddlCounty.Items.Add(item);
            }

            // Get the unit list
            //
            List <RRUnit> units = GetUnits();
            foreach (var unit in units)
            {
                var item = new ListItem(unit.Name,
                                        unit.Id.ToString());
                ddlUnit.Items.Add(item);
            }

            // Get the category list
            //
            List<RRCategory> categories = GetCategories();
            foreach (var category in categories)
            {
                var item = new ListItem(category.Name,
                                        category.Id.ToString());
                ddlCategory.Items.Add(item);
            }


        }

        //
        // Helpers
        //

        private List<RRCounty> GetCounties()
        {
            var counties = new List<RRCounty>();

            // TODO: replace with database query
            //
            var county = new RRCounty();
            county["countyid"] = 1;
            county["countyName"] = "Duval";

            counties.Add(county);

            county = new RRCounty();
            county["countyid"] = 2;
            county["countyName"] = "St. Johns";

            counties.Add(county);

            return counties;
        }

        private List<RRUnit> GetUnits()
        {
            var units = new List<RRUnit>();

            // TODO: replace with database query
            //
            var unit = new RRUnit();
            unit["unitid"] = 1;
            unit["unitname"] = "A1";

            units.Add(unit);

            unit = new RRUnit();
            unit["unitid"] = 2;
            unit["unitname"] = "A2";

            units.Add(unit);

            return units;
        }

        private List<RRCategory> GetCategories()
        {
            var categories = new List<RRCategory>();

            // TODO: replace with database query
            //
            var category = new RRCategory();
            category["catid"] = 1;
            category["categoryname"] = "FALL";

            categories.Add(category);

            category = new RRCategory();
            category["catid"] = 2;
            category["categoryname"] = "MEDICAL";

            categories.Add(category);

            return categories;
        }
    }
}
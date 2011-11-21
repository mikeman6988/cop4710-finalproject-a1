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
            // Get the data manager from the application
            //
            RRDataManager mgr = (RRDataManager) Application["RRDataManager"];

            // Set the date and time
            //
            tbDate.Text = DateTime.Now.Date.ToShortDateString();
            tbTime.Text = DateTime.Now.Date.ToShortTimeString();

            // Get the county list
            //
            List<RRCounty> counties = mgr.getAllCountyItems();
            foreach (var county in counties)
            {
                var item = new ListItem(county.Name, 
                                        county.Id.ToString()); 
                ddlCounty.Items.Add(item);
            }

            // Get the unit list
            //
            List <RRUnit> units = mgr.getAllUnitItems();
            foreach (var unit in units)
            {
                var item = new ListItem(unit.Name,
                                        unit.Id.ToString());
                ddlUnit.Items.Add(item);
            }

            // Get the category list
            //
            List<RRCategory> categories = mgr.getAllCategoryItems();
            foreach (var category in categories)
            {
                var item = new ListItem(category.Name,
                                        category.Id.ToString());
                ddlCategory.Items.Add(item);
            }

            // Get the destination department
            //
            List<RRDepartment> departments = mgr.getAllDepartmentItems();
            foreach (var department in departments)
            {
                var item = new ListItem(department.Name,
                                        department.Id.ToString());
                ddlDestination.Items.Add(item);
            }

            // Get the history list
            //
            List<RRHistory> histories = mgr.getAllHistoryItems();
            foreach (var history in histories)
            {
                var item = new ListItem(history.Name,
                                        history.Id.ToString());
                cblHistory.Items.Add(item);
            }

            // Get the treatment list
            //
            List<RRTreatment> treatments = mgr.getAllTreatmentItems();
            foreach (var treatment in treatments)
            {
                var item = new ListItem(treatment.Name,
                                        treatment.Id.ToString());
                cblTreatment.Items.Add(item);
            }

            // Get the medication list
            //
            List<RRMedication> medications = mgr.getAllMedicationItems();
            foreach (var medication in medications)
            {
                var item = new ListItem(medication.Name,
                                        medication.Id.ToString());
                ddlMedication.Items.Add(item);
            }

            // Get the doctor list
            //
            List<RRDoctor> doctors = mgr.getAllDoctorItems();
            foreach (var doctor in doctors)
            {
                var item = new ListItem(doctor.Name,
                                        doctor.Id.ToString());
                ddlDoctor.Items.Add(item);
            }
        }
    }
}
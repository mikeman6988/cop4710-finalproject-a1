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
        private DateTime m_now;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initNew();
            }
            else
            {
                // Re-establish "now" from text boxes
                //
                m_now = DateTime.Parse(tbDate.Text + " " + tbTime.Text);
            }

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
            m_now = DateTime.Now;
            tbDate.Text = m_now.ToShortDateString();
            tbTime.Text = m_now.ToLongTimeString();

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

            // Get chief complaints
            //
            List<RRChiefComplaint> complaints = mgr.getCCListItems();
            foreach (var complaint in complaints)
            {
                var item = new ListItem(complaint.Name,
                                        complaint.Id.ToString());
                ddlChiefComplaint.Items.Add(item);
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var ec = new RREmergencyCall();

            ec.CreatedDateTime = m_now;
            ec.CountyId = SafeToInt(ddlCounty.SelectedValue);
            ec.UnitId = SafeToInt(ddlUnit.SelectedValue);
            ec.Age = SafeToInt(tbAge.Text);
            ec.AgeType = GetAgeType();
            ec.Sex = GetSex();
            ec.AlertAndOriented = SafeToInt(ddlAlertOriented.SelectedItem.Text);
            ec.MultiplePatient = cbMultiplePatient.Checked;
            ec.Systolic1 = SafeToInt(tbBPS1.Text);
            ec.Diastolic1 = SafeToInt(tbBPD1.Text);
            ec.Systolic2 = SafeToInt(tbBPS2.Text);
            ec.Diastolic2 = SafeToInt(tbBPD2.Text);
            ec.Pulse1 = SafeToInt(tbPulse1.Text);
            ec.Pulse2 = SafeToInt(tbPulse2.Text);
            ec.Respiration1 = SafeToInt(tbResp1.Text);
            ec.Respiration2 = SafeToInt(tbResp2.Text);
            ec.OxygenSaturation1 = SafeToInt(tbO2SAT1.Text);
            ec.OxygenSaturation2 = SafeToInt(tbO2SAT2.Text);
            ec.LossOfConsciousness = ddlLOC.SelectedValue;
            ec.GlasgowComaScale = SafeToInt(ddlGCS.SelectedItem.Text);
            ec.BloodGlucoseLevel1 = SafeToInt(tbBGL1.Text);
            ec.BloodGlucoseLevel2 = SafeToInt(tbBGL2.Text);
            ec.CategoryId = SafeToInt(ddlCategory.SelectedValue);
            ec.ChiefComplaintId = SafeToInt(ddlChiefComplaint.SelectedValue);
            ec.ChiefComplaint = tbChiefComplaint.Text;

            // Get the data manager from the application
            //
            RRDataManager mgr = (RRDataManager)Application["RRDataManager"];
            mgr.createEmergencyCall(ec);
        }

        // Utility to determine the active age type
        //
        private string GetAgeType()
        {
            string ageType = string.Empty;
            if (rbYears.Checked)
            {
                ageType = "Y";
            }
            else if (rbMonths.Checked)
            {
                ageType = "M";
            }
            else if (rbWeeks.Checked)
            {
                ageType = "W";
            }
            else
            {
                // this should never happen
            }
            return ageType;
        }

        // Utility to determine the active sex type
        //
        private string GetSex()
        {
            string sexType = string.Empty;
            if (rbMale.Checked)
            {
                sexType = "M";
            }
            else if (rbFemale.Checked)
            {
                sexType = "F";
            }
            else
            {
                // this should never happen
            }
            return sexType;
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RRDataLayer;
using System.Web.Security;

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
                string callid = Request.QueryString["callid"];
                if (callid != null)
                {
                    // If we have an emergency call then use it to fill
                    // the form with its data.
                    //
                    initUsing(callid);
                }
            }
            else
            {
                // Re-establish "now" from text boxes
                //
                m_now = DateTime.Parse(tbDate.Text + " " + tbTime.Text);
            }
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

            tbDispatcher.Text = User.Identity.Name;

            var notApplicableItem = new ListItem("N/A", "-1");

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

            // Set the ETA drop down
            //
            ddlETA.Items.Add(notApplicableItem);
            for (int i = 0; i <= 60; ++i)
            {
                var item = new ListItem(i.ToString(), i.ToString());
                ddlETA.Items.Add(item);
            }
        }

        private void initUsing(string callid)
        {
            // Get the data manager from the application
            //
            RRDataManager mgr = (RRDataManager)Application["RRDataManager"];

            int id = -1;
            int.TryParse(callid, out id);

            var calls = mgr.getEmergencyCallByPrimaryKey(id);
            var ec = calls[0];    // TODO: ok check

            // Set form fields
            //
            m_now = ec.CreatedDateTime;
            lblEcId.Text = id.ToString();
            tbDate.Text = m_now.ToShortDateString();
            tbTime.Text = m_now.ToLongTimeString();

            ddlCounty.SelectedValue = ec.CountyId.ToString();
            ddlUnit.SelectedValue = ec.UnitId.ToString();
            tbAge.Text = TextBoxToString(ec.Age);
            SetAgeType(ec.AgeType);
            SetSex(ec.Sex);
            ddlAlertOriented.SelectedValue = ec.AlertAndOriented.ToString();
            cbMultiplePatient.Checked = ec.MultiplePatient;
            tbBPS1.Text = TextBoxToString(ec.Systolic1);
            tbBPD1.Text = TextBoxToString(ec.Diastolic1);
            tbBPS2.Text = TextBoxToString(ec.Systolic2);
            tbBPD2.Text = TextBoxToString(ec.Diastolic2);
            tbPulse1.Text = TextBoxToString(ec.Pulse1);
            tbPulse2.Text = TextBoxToString(ec.Pulse2);
            tbResp1.Text = TextBoxToString(ec.Respiration1);
            tbResp2.Text = TextBoxToString(ec.Respiration2);
            tbO2SAT1.Text = TextBoxToString(ec.OxygenSaturation1);
            tbO2SAT2.Text = TextBoxToString(ec.OxygenSaturation2);
            ddlLOC.SelectedValue = ec.LossOfConsciousness.ToString();
            ddlGCS.SelectedValue = ec.GlasgowComaScale.ToString();
            tbBGL1.Text = TextBoxToString(ec.BloodGlucoseLevel1);
            tbBGL2.Text = TextBoxToString(ec.BloodGlucoseLevel2);
            ddlCategory.SelectedValue = ec.CategoryId.ToString();
            ddlChiefComplaint.SelectedValue = ec.ChiefComplaintId.ToString();
            tbChiefComplaint.Text = ec.ChiefComplaint;
            tbSpeed.Text = TextBoxToString(ec.Speed);
            ddlDriver.SelectedValue = ec.DriverRestrained.ToString();
            ddlPassenger.SelectedValue = ec.PassengerRestrain.ToString();
            cbEjected.Checked = ec.Ejected;
            cbEntrapped.Checked = ec.Entrapped;
            cbRollover.Checked = ec.Rollover;
            cbAirbag.Checked = ec.Airbag;
            cbPackaged.Checked = ec.Packaged;
            cbHelmet.Checked = ec.Helmet;
            tbMedicalDetail.Text = ec.MedicalDetail;
            ddlLevel.SelectedValue = ec.Level;
            ddlDestination.SelectedValue = ec.ReceivingDepartment.ToString();
            cbCardiacRed.Checked = ec.CardiacRed;
            cbStrokeAlert.Checked = ec.StrokeAlert;
            cbStemi.Checked = ec.STEMI;
            cbTraumaAlert.Checked = ec.TraumaAlert;
            cbResusitation.Checked = ec.Resusitation;
            tbOnset.Text = ec.Onset.ToString();
            tbTimeIssued.Text = ec.RescueTime.ToString();
            cbNotified.Checked = ec.Notified;
            ddlETA.SelectedValue = ec.ETA.ToString();
            ddlMedication.SelectedValue = ec.Medication.ToString();
            ddlDoctor.SelectedValue = ec.Doctor.ToString();
            tbDEA.Text = ec.DEA_No;
            cbNarc.Checked = ec.Narc;
            tbDispatcher.Text = ec.Dispatcher;

            // Set the histories
            //
            var histories = mgr.getHistoryByPrimaryKey(id);
            foreach (var history in histories)
            {
                var item = cblHistory.Items.FindByValue(history.HistoryId.ToString());
                item.Selected = true;
            }

            // Set the treatments
            //
            var treatments = mgr.getTreatmentByPrimaryKey(id);
            foreach (var treatment in treatments)
            {
                var item = cblTreatment.Items.FindByValue(treatment.TreatmentId.ToString());
                item.Selected = true;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var ec = new RREmergencyCall();

            bool bIsEditing = false;
            int id = -1;
            if (!string.IsNullOrEmpty(lblEcId.Text))
            {
                id = int.Parse(lblEcId.Text);
                bIsEditing = true;
            }
            ec.CreatedDateTime = m_now;
            ec.CountyId = SafeToInt(ddlCounty.SelectedValue);
            ec.UnitId = SafeToInt(ddlUnit.SelectedValue);
            ec.Age = SafeToInt(tbAge.Text); 
            ec.AgeType = GetAgeType();
            ec.Sex = GetSex();
            ec.AlertAndOriented = SafeToInt(ddlAlertOriented.SelectedValue);
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
            ec.GlasgowComaScale = SafeToInt(ddlGCS.SelectedValue);
            ec.BloodGlucoseLevel1 = SafeToInt(tbBGL1.Text);
            ec.BloodGlucoseLevel2 = SafeToInt(tbBGL2.Text);
            ec.CategoryId = SafeToInt(ddlCategory.SelectedValue);
            ec.ChiefComplaintId = SafeToInt(ddlChiefComplaint.SelectedValue);
            ec.ChiefComplaint = tbChiefComplaint.Text;
            ec.Speed = SafeToInt(tbSpeed.Text);
            ec.DriverRestrained = SafeToInt(ddlDriver.SelectedValue);
            ec.PassengerRestrain = SafeToInt(ddlPassenger.SelectedValue);
            ec.Ejected = cbEjected.Checked;
            ec.Entrapped = cbEntrapped.Checked;
            ec.Rollover = cbRollover.Checked;
            ec.Airbag = cbAirbag.Checked;
            ec.Packaged = cbPackaged.Checked;
            ec.Helmet = cbHelmet.Checked;
            ec.MedicalDetail = tbMedicalDetail.Text;
            ec.Level = ddlLevel.SelectedValue;
            ec.ReceivingDepartment = SafeToInt(ddlDestination.SelectedValue);
            ec.CardiacRed = cbCardiacRed.Checked;
            ec.StrokeAlert = cbStrokeAlert.Checked;
            ec.STEMI = cbStemi.Checked;
            ec.TraumaAlert = cbTraumaAlert.Checked;
            ec.Resusitation = cbResusitation.Checked;
            ec.Onset = SafeToTimeSpan(tbOnset.Text);
            ec.RescueTime = SafeToTimeSpan(tbTimeIssued.Text);
            ec.Notified = cbNotified.Checked;
            ec.ETA = SafeToInt(ddlETA.SelectedValue);
            ec.Medication = SafeToInt(ddlMedication.SelectedValue);
            ec.Doctor = SafeToInt(ddlDoctor.SelectedValue);
            ec.DEA_No = tbDEA.Text;
            ec.Narc = cbNarc.Checked;
            ec.Dispatcher = tbDispatcher.Text;

            // Get the data manager from the application
            //
            RRDataManager mgr = (RRDataManager)Application["RRDataManager"];
            if (bIsEditing)
            {
                mgr.deleteEmergencyCall(id);
            }
            mgr.createEmergencyCall(ec);

            // History junction
            //
            foreach (ListItem item in cblHistory.Items)
            {
                if (item.Selected)
                {
                    var history = new RRHistoryJunction();
                    history.EmergencyCallId = id;
                    history.HistoryId = SafeToInt(item.Value);

                    mgr.createHistory(history);
                }
            }

            // Treatment junction
            //
            foreach (ListItem item in cblTreatment.Items)
            {
                if (item.Selected)
                {
                    var treatment = new RRTreatmentJunction();
                    treatment.EmergencyCallId = id;
                    treatment.TreatmentId = SafeToInt(item.Value);

                    mgr.createTreatment(treatment);
                }
            }

            // Relead the form
            //
            Response.Redirect("~/Default.aspx");
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

        // Utility to set the active age type
        //
        private void SetAgeType(string ageType)
        {
            if (string.Compare(ageType, "Y", true) == 0)
            {
                rbYears.Checked = true;
            }
            else if (string.Compare(ageType, "M", true) == 0)
            {
                rbMonths.Checked = true;
            }
            else if (string.Compare(ageType, "W", true) == 0)
            {
                rbWeeks.Checked = true;
            }
            else
            {
                // this should never happen
            }
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

        // Utility to set the active age type
        //
        private void SetSex(string sex)
        {
            if (string.Compare(sex, "M", true) == 0)
            {
                rbMale.Checked = true;
            }
            else if (string.Compare(sex, "F", true) == 0)
            {
                rbFemale.Checked = true;
            }
            else
            {
                // this should never happen
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

        // Utility for converting a string to TimeSpan
        //
        private TimeSpan SafeToTimeSpan(string value)
        {
            TimeSpan span = DateTime.Now.TimeOfDay;
            try
            {
                span = TimeSpan.Parse(value);
            }
            catch
            {
            }
            return span;
        }

        // Utility to convert an integer to string for text box
        // -1 means text box should be empty
        //
        private string TextBoxToString(int val)
        {
            string ret = string.Empty;
            if (val != -1)
            {
                ret = val.ToString();
            }
            return ret;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RRDataLayer
{
    public class RREmergencyCall : RRDataObject
    {
        private string SafeGetString(object obj)
        {
            string str = string.Empty;
            if (obj is string)
            {
                str = (string)obj;
            }
            return str;
        }

        private TimeSpan SafeGetTimeSpan(object obj)
        {
            TimeSpan time = TimeSpan.Zero;
            try
            {
                time = (TimeSpan)obj;
            }
            catch
            {
            }
            return time;
        }

        public int Id
        {
            get
            {
                return (int) this["id"];
            }
            set
            {
                this["id"] = value;
            }
        }

        public string CreatedBy
        {
            get
            {
                return SafeGetString(this["created_by"]);
            }
            set
            {
                this["created_by"] = value;
            }
        }

        public DateTime CreatedDateTime
        {
            get
            {
                return (DateTime) this["created_date_time"];
            }
            set
            {
                this["created_date_time"] = value;
            }
        }

        public int CountyId
        {
            get
            {
                return (int) this["county"];
            }
            set
            {
                this["county"] = value;
            }
        }

        public int UnitId
        {
            get
            {
                return (int)this["unit"];
            }
            set
            {
                this["unit"] = value;
            }
        }

        public int Age
        {
            get
            {
                return (int)this["age"];
            }
            set
            {
                this["age"] = value;
            }
        }

        public string AgeType
        {
            get
            {
                return (string) this["age_interval"];
            }
            set
            {
               this["age_interval"] = value;
            }
        }

        public string Sex
        {
            get
            {
                return SafeGetString(this["sex"]);
            }
            set
            {
                this["sex"] = value;
            }
        }

        public int AlertAndOriented
        {
            get
            {
                return (int)this["a_and_o"];
            }
            set
            {
                this["a_and_o"] = value;
            }
        }

        public bool MultiplePatient
        {
            get 
            {
                return (bool)this["mult_pat"];
            }
            set
            {
                this["mult_pat"] = value;
            }
        }

        public int Systolic1
        {
            get
            {
                return (int)this["bp_sys1"];
            }
            set
            {
                this["bp_sys1"] = value;
            }
        }

        public int Diastolic1
        {
            get
            {
                return (int)this["bp_dia1"];
            }
            set
            {
                this["bp_dia1"] = value;
            }
        }

        public int Systolic2
        {
            get
            {
                return (int)this["bp_sys2"];
            }
            set
            {
                this["bp_sys2"] = value;
            }
        }

        public int Diastolic2
        {
            get
            {
                return (int)this["bp_dia2"];
            }
            set
            {
                this["bp_dia2"] = value;
            }
        }

        public int Pulse1
        {
            get
            {
                return (int)this["pulse1"];
            }
            set
            {
                this["pulse1"] = value;
            }
        }

        public int Pulse2
        {
            get
            {
                return (int)this["pulse2"];
            }
            set
            {
                this["pulse2"] = value;
            }
        }

        public int Respiration1
        {
            get
            {
                return (int)this["resp1"];
            }
            set
            {
                this["resp1"] = value;
            }
        }

        public int Respiration2
        {
            get
            {
                return (int)this["resp2"];
            }
            set
            {
                this["resp2"] = value;
            }
        }

        public int OxygenSaturation1
        {
            get
            {
                return (int)this["o2_sat1"];
            }
            set
            {
                this["o2_sat1"] = value;
            }
        }

        public int OxygenSaturation2
        {
            get
            {
                return (int)this["o2_sat2"];
            }
            set
            {
                this["o2_sat2"] = value;
            }
        }

        public string LossOfConsciousness
        {
            get
            {
                return (string)this["loc"];
            }
            set
            {
                this["loc"] = value;
            }
        }

        public int GlasgowComaScale
        {
            get
            {
                return (int)this["gcs"];
            }
            set
            {
                this["gcs"] = value;
            }
        }

        public int BloodGlucoseLevel1
        {
            get
            {
                return (int) this["bgl1"];
            }
            set
            {
                this["bgl1"] = value;
            }
        }

        public int BloodGlucoseLevel2
        {
            get
            {
                return (int)this["bgl2"];
            }
            set
            {
                this["bgl2"] = value;
            }
        }

        public int CategoryId
        {
            get
            {
                return (int)this["category"];
            }
            set
            {
                this["category"] = value;
            }
        }

        public int ChiefComplaintId
        {
            get
            {
                return (int)this["ccid"];
            }
            set
            {
                this["ccid"] = value;
            }
        }

        public string ChiefComplaint
        {
            get
            {
                return SafeGetString(this["cc"]);
            }
            set
            {
                this["cc"] = value;
            }
        }

        public int Speed
        {
            get
            {
                return (int)this["speed"];
            }
            set
            {
                this["speed"] = value;
            }
        }

        public int DriverRestrained
        {
            get
            {
                return (int)this["driver_res"];
            }
            set
            {
                this["driver_res"] = value;
            }
        }

        public int PassengerRestrain
        {
            get
            {
                return (int)this["pass_res"];
            }
            set
            {
                this["pass_res"] = value;
            }
        }

        public bool Ejected
        {
            get
            {
                return (bool)this["eject"];
            }
            set
            {
                this["eject"] = value;
            }
        }

        public bool Entrapped
        {
            get
            {
                return (bool)this["entrap"];
            }
            set
            {
                this["entrap"] = value;
            }
        }

        public bool Rollover
        {
            get
            {
                return (bool)this["rollover"];
            }
            set
            {
                this["rollover"] = value;
            }
        }

        public bool Airbag
        {
            get
            {
                return (bool)this["airbag"];
            }
            set
            {
                this["airbag"] = value;
            }
        }

        public bool Packaged
        {
            get
            {
                return (bool)this["pkg"];
            }
            set
            {
                this["pkg"] = value;
            }
        }

        public bool Helmet
        {
            get
            {
                return (bool)this["helmet"];
            }
            set
            {
                this["helmet"] = value;
            }
        }

        public string MedicalDetail
        {
            get
            {
                return SafeGetString(this["medical_detail"]);
            }
            set
            {
                this["medical_detail"] = value;
            }
        }

        public string Level
        {
            get
            {
                return (string)this["level"];
            }
            set
            {
                this["level"] = value;
            }
        }

        public int ReceivingDepartment
        {
            get
            {
                return (int)this["receiving_dept"];
            }
            set
            {
                this["receiving_dept"] = value;
            }
        }

        public bool CardiacRed
        {
            get
            {
                return (bool)this["cardiacRed"];
            }
            set
            {
                this["cardiacRed"] = value;
            }
        }

        public bool StrokeAlert
        {
            get
            {
                return (bool)this["s_a"];
            }
            set
            {
                this["s_a"] = value;
            }
        }
        
        public bool STEMI
        {
            get
            {
                return (bool)this["stemi"];
            }
            set
            {
                this["stemi"] = value;
            }
        }
        
        public bool TraumaAlert
        {
            get
            {
                return (bool)this["t_a"];
            }
            set
            {
                this["t_a"] = value;
            }
        }

        public bool Resusitation
        {
            get
            {
                return (bool)this["resus"];
            }
            set
            {
                this["resus"] = value;
            }
        }

        public TimeSpan Onset
        {
            get
            {
                return SafeGetTimeSpan(this["onset"]);
            }
            set
            {
                this["onset"] = value;
            }
        }

        public TimeSpan RescueTime
        {
            get
            {
                return SafeGetTimeSpan(this["rescue_time"]); ;
            }
            set
            {
                this["rescue_time"] = value;
            }
        }

        public bool Notified
        {
            get
            {
                return (bool)this["notified"];
            }
            set
            {
                this["notified"] = value;
            }
        }

        public int ETA
        {
            get
            {
                return (int)this["eta"];
            }
            set
            {
                this["eta"] = value;
            }
        }

        public int Medication
        {
            get
            {
                return (int)this["meds"];
            }
            set
            {
                this["meds"] = value;
            }
        }

        public int Doctor
        {
            get
            {
                return (int)this["doc_sign"];
            }
            set
            {
                this["doc_sign"] = value;
            }
        }

        public string DEA_No
        {
            get
            {
                return SafeGetString(this["dea_num"]);
            }
            set
            {
                this["dea_num"] = value;
            }
        }

        public bool Narc
        {
            get
            {
                return (bool)this["narc"];
            }
            set
            {
                this["narc"] = value;
            }
        }

        public string Dispatcher
        {
            get
            {
                return SafeGetString(this["dispatcher"]);
            }
            set
            {
                this["dispatcher"] = value;
            }
        }
    }
}

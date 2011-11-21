using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RRDataLayer
{
    public class RREmergencyCall : RRDataObject
    {
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
                return (string)this["sex"];
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
                return (int) this["init_bgl"];
            }
            set
            {
                this["init_bgl"] = value;
            }
        }

        public int BloodGlucoseLevel2
        {
            get
            {
                return (int)this["sec_bgl"];
            }
            set
            {
                this["sec_bgl"] = value;
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
                return (string)this["cc"];
            }
            set
            {
                this["cc"] = value;
            }
        }
    
    }
}

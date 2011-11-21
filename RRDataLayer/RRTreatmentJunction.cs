using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RRDataLayer
{
    public class RRTreatmentJunction : RRDataObject
    {
        public RRTreatmentJunction()
        {
        }

        public DateTime EmergencyCallId
        {
            get
            {
                return (DateTime) this["date_time"];
            }
            set
            {
                this["date_time"] = value;
            }
        }

        public int TreatmentId
        {
            get
            {
                return (int)this["treatmentid"];
            }
            set
            {
                this["treatmentid"] = value;
            }
        }        
    }
}

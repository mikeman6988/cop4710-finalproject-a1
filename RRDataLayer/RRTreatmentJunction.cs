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

        public int EmergencyCallId
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

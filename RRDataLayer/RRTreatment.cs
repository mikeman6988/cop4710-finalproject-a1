using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RRDataLayer
{
    public class RRTreatment : RRDataObject
    {
        public RRTreatment()
        {
        }

        public string Name
        {
            get
            {
                return (string) this["tx_item"];
            }
            set
            {
                this["tx_item"] = value;
            }
        }

        public int Id
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

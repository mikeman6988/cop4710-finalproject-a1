using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RRDataLayer
{
    public class RRMedication : RRDataObject
    {
        public RRMedication()
        {
        }

        public string Name
        {
            get
            {
                return (string) this["medicationName"];
            }
            set
            {
                this["medicationName"] = value;
            }
        }

        public int Id
        {
            get
            {
                return (int)this["medid"];
            }
            set
            {
                this["medid"] = value;
            }
        }    
    }
}

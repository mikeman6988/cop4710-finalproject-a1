using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RRDataLayer
{
    public class RRDoctor : RRDataObject
    {
        public RRDoctor()
        {
        }

        public string Name
        {
            get
            {
                return (string) this["doctorName"];
            }
            set
            {
                this["doctorName"] = value;
            }
        }

        public int Id
        {
            get
            {
                return (int)this["doctorid"];
            }
            set
            {
                this["doctorid"] = value;
            }
        }        
    }
}

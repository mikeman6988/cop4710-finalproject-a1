using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RRDataLayer
{
    public class RRUnit : RRDataObject
    {
        public RRUnit()
        {
        }

        public string Name
        {
            get
            {
                return (string) this["unitname"];
            }
            set
            {
                this["unitname"] = value;
            }
        }

        public int Id
        {
            get
            {
                return (int)this["unitid"];
            }
            set
            {
                this["unitid"] = value;
            }
        }    
    }
}

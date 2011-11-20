using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RRDataLayer
{
    public class RRCounty : RRDataObject 
    {
        public RRCounty()
        {
        }

        public string Name
        {
            get
            {
                return (string) this["countyName"];
            }
            set
            {
                this["countyName"] = value;
            }
        }

        public int Id
        {
            get
            {
                return (int)this["countyid"];
            }
            set
            {
                this["countyid"] = value;
            }
        }
    }
}

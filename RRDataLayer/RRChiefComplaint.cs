using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RRDataLayer
{
    public class RRChiefComplaint : RRDataObject
    {
        public RRChiefComplaint()
        {
        }

        public string Name
        {
            get
            {
                return (string) this["ccDescription"];
            }
            set
            {
                this["ccDescription"] = value;
            }
        }

        public int Id
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RRDataLayer
{
    public class RRPediatricColor : RRDataObject
    {
        public RRPediatricColor()
        {
        }

        public string Color
        {
            get
            {
                return (string) this["pc_color"];
            }
            set
            {
                this["pc_color"] = value;
            }
        }

        public int Id
        {
            get
            {
                return (int)this["pc_id"];
            }
            set
            {
                this["pc_id"] = value;
            }
        }    
    }
}

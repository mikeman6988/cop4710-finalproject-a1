using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RRDataLayer
{
    public class RRHistoryJunction : RRDataObject
    {
        public RRHistoryJunction()
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

        public int HistoryId
        {
            get
            {
                return (int)this["hx"];
            }
            set
            {
                this["hx"] = value;
            }
        }        
    }
}

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

        public DateTime EmergencyCallId
        {
            get
            {
                return (DateTime) this["date"];
            }
            set
            {
                this["date"] = value;
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

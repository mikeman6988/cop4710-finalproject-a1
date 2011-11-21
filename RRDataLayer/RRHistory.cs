using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RRDataLayer
{
    public class RRHistory : RRDataObject
    {
        public RRHistory()
        {
        }

        public string Name
        {
            get
            {
                return (string) this["hxitem"];
            }
            set
            {
                this["hxitem"] = value;
            }
        }

        public int Id
        {
            get
            {
                return (int)this["hxid"];
            }
            set
            {
                this["hxid"] = value;
            }
        }    
    }
}

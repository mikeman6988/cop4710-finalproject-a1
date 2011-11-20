using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RRDataLayer
{
    public class RRCategory : RRDataObject
    {
        public RRCategory()
        {
        }

        public string Name
        {
            get
            {
                return (string) this["categoryname"];
            }
            set
            {
                this["categoryname"] = value;
            }
        }

        public int Id
        {
            get
            {
                return (int)this["catid"];
            }
            set
            {
                this["catid"] = value;
            }
        }
    }
}

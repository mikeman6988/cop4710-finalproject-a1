using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RRDataLayer
{
    public class RRDepartment : RRDataObject
    {
        public RRDepartment()
        {
        }

        public string Name
        {
            get
            {
                return (string) this["deptname"];
            }
            set
            {
                this["deptname"] = value;
            }
        }

        public int Id
        {
            get
            {
                return (int)this["deptid"];
            }
            set
            {
                this["deptid"] = value;
            }
        }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RRDataLayer
{
    public class RRDataObject
    {
        private Dictionary<string, object> m_props = new Dictionary<string,object>();

        public RRDataObject()
        {
        }

        public int Count
        {
            get
            {
                return m_props.Count;
            }
        }

        public object this[string key]
        {
            get
            {
                return m_props[key];
            }
            set
            {
                m_props[key] = value;
            }
        }

        public void Add(string key, object value)
        {
            m_props.Add(key, value);
        }

        public void Clear()
        {
            m_props.Clear();
        }

        public bool Has(string key)
        {
            return m_props.ContainsKey(key);
        }

        public string[] Keys
        {
            get
            {
                return m_props.Keys.ToArray<string>();
            }
        }

        public object[] Values
        {
            get
            {
                return m_props.Values.ToArray<object>();
            }
        }
    }
}

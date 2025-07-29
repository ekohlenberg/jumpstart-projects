using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace defarge
{
    public class BaseObject : Dictionary<string, object>
    {
        public BaseObject() { }

        public BaseObject( BaseObject t)
        {
            foreach( string k in t.Keys)
            {
                this[k] = t[k];
            }
        }

        public string domainName {get;  set;}
        public string tableName { get;  set; }
        public string tableBaseName{ get;  set; }
        public string auditTableName { get;  set;}
        protected List<string> rwk = new List<string>();

        public List<string> getRwk() { return rwk;  }
        public string getRwkString()
        {
            List<object> rwkValues = new();
            foreach(string c in rwk)
						{
							rwkValues.Add( this[c] );
						}
            return String.Join( " ", rwkValues);
        }

         // Override the indexer to keep dictionary & properties in sync
        public new object this[string key]
        {
            get => base[key];
            set
            {
                // 1) Check if the new value is different to avoid recursive writes
                if (!ContainsKey(key) || base[key] == null || !base[key].Equals(value))
                {
                    // 2) Update the dictionary
                    base[key] = value;
               
                }
            }
        }
       
        public override string ToString()
        {
            string s = string.Empty;

            foreach(string k in this.Keys)
            {
                s += k + " = " + this[k].ToString() + "\n";
            }

            return this.GetType().Name + "{\n" + s + "\n}";
        }
    }
}

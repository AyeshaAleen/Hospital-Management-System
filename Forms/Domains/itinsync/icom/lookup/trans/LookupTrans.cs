using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.icom.annotation;

namespace Domains.itinsync.icom.lookup.trans
{
    public class LookupTrans : System.Attribute, IDomain
    {

        public enum columns
        {
            code,value,lang
        }
        public enum primaryKey
        {
            lookupTransID
        }

        public int lookupTransID { get; set; }

        public string code { get; set; }

        public string value { get; set; }
        public string lang { get; set; }

        public object getKey()
        {
            return lookupTransID;
        }
        public void setTransID(object transID)
        {

        }
    }
}

using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            id
        }

        public int id { get; set; }

        public string code { get; set; }

        public string value { get; set; }
        public string lang { get; set; }

        public object getKey()
        {
            throw new NotImplementedException();
        }
        public void setTransID(object transID)
        {

        }
    }
}

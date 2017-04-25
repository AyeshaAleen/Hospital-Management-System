using Domains.itinsync.interfaces.domain;
using System;

namespace Domains.itinsync.icom.lookup.lookuptrans
{
    public class LookupTrans : System.Attribute, IDomain
    {
        public enum columns { code, value, lang }
        public enum primaryKey { lookupTransID }
        public Int32 lookupTransID { get; set; }
        public String code { get; set; }
        public String value { get; set; }
        public String lang { get; set; }
        public object getKey() { return lookupTransID; }

        public void setTransID(object transID)
        {
            
        }
    }
}
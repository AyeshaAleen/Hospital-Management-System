using Domains.itinsync.interfaces.domain;
using System;
using Domains.itinsync.icom.annotation;

namespace Domains.itinsync.icom.lookup
{
    public class LookUp : System.Attribute, IDomain
    {
        public enum columns { name, code, text, fr, sp, ud }
        public enum primaryKey { lookUpID }
        public enum forignKey { }
        public Int32 lookUpID { get; set; }
        
        public String name { get; set; }
        public String code { get; set; }
        public String text { get; set; }
        public String fr { get; set; }
        public String sp { get; set; }
        public String ud { get; set; }
        public object getKey() { return lookUpID; }

        public void setTransID(object transID)
        {

        }
    }
}
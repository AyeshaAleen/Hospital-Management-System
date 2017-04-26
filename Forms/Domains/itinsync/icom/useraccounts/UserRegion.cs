using Domains.itinsync.icom.annotation;
using Domains.itinsync.interfaces.domain;
using System;

namespace Domains.itinsync.useraccounts
{
    public class UserRegion : System.Attribute, IDomain
    {
        public enum columns { code, userID }
        public enum primaryKey { userRegionID }
        public Int32 userRegionID { get; set; }

        
        public String code { get; set; }
        public String codeText { get; set; }
        public Int32 userID { get; set; }
        public object getKey() { return userRegionID; }

        public void setTransID(object transID)
        {
         
        }
    }
}
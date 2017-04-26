using Domains.itinsync.interfaces.domain;
using System;

namespace Domains.itinsync.icom.userprofile
{
    public class UserProfile : System.Attribute, IDomain
    {
        public enum columns { userID, profileCode }
        public enum primaryKey { userprofileID }
        public Int32 userprofileID { get; set; }
        public Int32 userID { get; set; }
        public Int32 profileCode { get; set; }
        public object getKey() { return userprofileID; }
        public void setTransID(object transID) { }
    }
}
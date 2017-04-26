using Domains.itinsync.interfaces.domain;
using System;

namespace Domains.itinsync.icom.useraccounts
{
    public class UserRole : System.Attribute, IDomain
    {
        public enum columns { userID, roleID }
        public enum primaryKey { userRoleID }
        public Int32 userRoleID { get; set; }
        public Int32 userID { get; set; }
        public Int32 roleID { get; set; }
        public object getKey() { return userRoleID; }

        public void setTransID(object transID)
        {
            
        }
    }
}
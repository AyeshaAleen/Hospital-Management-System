using Domains.itinsync.interfaces.domain;
using System;

namespace Domains.itinsync.icom.useraccounts
{
    public class UserPermission : System.Attribute, IDomain
    {
        public enum columns { userID, code }
        public enum primaryKey { userPermissionID }
        public Int32 userPermissionID { get; set; }
        public Int32 userID { get; set; }
        public Int32 code { get; set; }
        public object getKey() { return userPermissionID; }
        public void setTransID(object transID) { }
    }
}
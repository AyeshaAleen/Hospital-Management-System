using Domains.itinsync.icom.annotation;
using Domains.itinsync.interfaces.domain;
using System;

namespace Domains.itinsync.icom.views
{
    public class UserPermissionView : IDomain
    {
        public enum columns { userID, firstName, role, lastName, code, text, pageID, permissionID, userPermissionID }
        public Int32 userID { get; set; }
        public string firstName { get; set; }
        [LookupAttribute(lookupName = "LKUserRole", relatedTag = "role_text")]
        public Int32 role { get; set; }
        public string role_text { get; set; }
        public string lastName { get; set; }
        public Int32 code { get; set; }
        public string text { get; set; }
        public Int32 pageID { get; set; }
        public Int32 permissionID { get; set; }
        public Int32 userPermissionID { get; set; }
        public void setTransID(object transID) { }
        public object getKey() { return userID; }
    }
}
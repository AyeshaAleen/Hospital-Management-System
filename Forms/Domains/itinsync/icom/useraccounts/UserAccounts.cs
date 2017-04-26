using Domains.itinsync.icom.annotation;
using Domains.itinsync.interfaces.domain;
using System;

namespace Domains.itinsync.icom.useraccounts
{
    public class UserAccounts : System.Attribute, IDomain
    {
        public enum columns
        { userName, password, role, loginCount, firstName, lastName,
          lastLogin, isLock,  userPhone, userEmail, transID, lang, timeZone, countryCode, vendorID, MobileProvider
        }
        public enum primaryKey { userID }
        public enum forignKey { transID }
        public Int32 userID { get; set; }
        public String userName { get; set; }
        public String password { get; set; }

        [LookupAttribute(lookupName = "LKUserRole", relatedTag = "role_text")]
        public Int32 role { get; set; }
        public String role_text { get; set; }
        public Int32 loginCount { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String lastLogin { get; set; }
        public String isLock { get; set; }
        public String isLock_text { get; set; }
        public String userPhone { get; set; }
        public String userEmail { get; set; }
        public Int32 transID { get; set; }

        [LookupAttribute(lookupName = "LKUserLang", relatedTag = "lang_Text")]
        public String lang { get; set; }
        public String lang_Text { get; set; }
        public String timeZone { get; set; }
        public String countryCode { get; set; }
        public Int32 vendorID { get; set; }
        public String MobileProvider { get; set; }
        public object getKey() { return userID; }
        public void setTransID(object transID)
        { this.transID = (Int32)transID; }
    }
}
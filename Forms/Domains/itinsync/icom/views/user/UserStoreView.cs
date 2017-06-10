using Domains.itinsync.icom.annotation;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.views.user
{
    public class UserStoreView : IDomain
    {
        public enum columns
        {
            userID,userName, password, role, loginCount, firstName, lastName,
            lastLogin, isLock, userPhone, userEmail, transID, lang, timeZone, countryCode, vendorID, MobileProvider,
            userRole, storeid, storename, zipCode, website, storelink, comments, walmart, fax, storeNo
        }
        public Int32 userID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        [LookupAttribute(lookupName = "LKUserRole", relatedTag = "role_text")]
        public Int32 role { get; set; }
        public string role_text { get; set; }
        public Int32 loginCount { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string lastLogin { get; set; }
        public string isLock { get; set; }
        public string isLock_text { get; set; }
        public string userPhone { get; set; }
        public string userEmail { get; set; }
        public Int32 transID { get; set; }

        [LookupAttribute(lookupName = "LKUserLang", relatedTag = "lang_Text")]
        public string lang { get; set; }
        public string lang_Text { get; set; }
        public string timeZone { get; set; }
        public string countryCode { get; set; }
        public Int32 vendorID { get; set; }
        public string MobileProvider { get; set; }

        public Int32 storeid { get; set; }
        public string storename { get; set; }
        public string zipCode { get; set; }
        public string website { get; set; }
        public string storelink { get; set; }
        public string comments { get; set; }
        public string walmart { get; set; }
        public string fax { get; set; }

        public string storeNo { get; set; }





        
        public object getKey() { return userID; }


        [LookupAttribute(lookupName = "LKUserRole", relatedTag = "userRole_text")]
        public Int32 userRole { get; set; }
        public String userRole_text { get; set; }

        public void setTransID(object transID)
        { this.transID = (Int32)transID; }
    }
}

using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.useraccounts
{
    public class UserAccounts : System.Attribute, IDomain
    {
        public enum columns
        {
            username, password, role, logincount, firstName, lastName,
            lastlogin, islock,  userPhone, useremail, transID, lang
        }

        public enum primaryKey { userid }
        public enum forignKey { transID }
        public string username { get; set; }
        public string lang { get; set; }
        public string langText { get; set; }

        public string password { get; set; }
        public int userid { get; set; }
        public int role { get; set; }
        public string userPhone { get; set; }
        public string useremail { get; set; }
        public string role_text { get; set; }
        public int logincount { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string lastlogin { get; set; }
        public string islock { get; set; }
        public string islock_text { get; set; }
        public string userstatus { get; set; }
        public string type { get; set; }
        public string typeText { get; set; }
        public int transID { get; set; }

        public object getKey()
        {
            return userid;
        }
    }
}

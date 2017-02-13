using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.useraccounts
{
    public class UserRole
    {
        public enum columns {  userid, roleid }
        public enum primaryKey { userRoleID }

        public int userRoleID { get; set; }
        public int userid { get; set; }
        public int roleid { get; set; }
    }
}

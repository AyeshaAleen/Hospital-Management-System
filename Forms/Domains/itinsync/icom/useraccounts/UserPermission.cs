using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.useraccounts
{
    public class UserPermission : System.Attribute, IDomain
    {
        public enum columns { userid, Code }
        public enum primaryKey { userpermissionid }

        public int userpermissionid { get; set; }
        public int userid { get; set; }
        public int Code { get; set; }

        public object getKey()
        {
            return userpermissionid;
        }
    }
}

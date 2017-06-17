using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.useraccounts
{
   public class UserStore : System.Attribute, IDomain
    {
        public enum columns { userid, storeid }
        public enum primaryKey { userstoreid }
        public Int32 userstoreid { get; set; }
        public Int32 userid { get; set; }
        public Int32 storeid { get; set; }
        public object getKey() { return userstoreid; }

        public void setTransID(object transID)
        {

        }
    }
}

using Entities.itinsync.vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.role
{
    public class Role
    {
        public enum columns { roleid, vendorid, parentref, agreementid, primaryRole }
        public int roleid { get; set; }
        public int vendorid { get; set; }
        public int agreementid { get; set; }
        public string parentref { get; set; }
        public string primaryRole { get; set; }
        public string primaryRoleText { get; set; }
        public Vendor vendor { get; set; }

    }
}

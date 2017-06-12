using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.interfaces.domain;
using Domains.itinsync.icom.annotation;

namespace Domains.itinsync.icom.views.emailroutingview
{
    public class EmailRouting : System.Attribute, IDomain
    {
        public enum columns { id, xdocumentdefinitionid, role, Users, storage, email }
        public Int64 id { get; set; }
        [LookupAttribute(lookupName = "LKEmailRouting", relatedTag = "role_Text")]
        public Int32 role { get; set; }

        public string role_Text { get; set; }
        public Int64 xdocumentdefinitionid { get; set; }
        public bool storage { get; set; }
        public bool email { get; set; }

        public string Users { get; set; }
        public object getKey()
        {
            return id;
        }

        public void setTransID(object transID)
        {

        }
    }
}

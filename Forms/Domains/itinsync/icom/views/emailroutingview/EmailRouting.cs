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
        public enum columns { id,route, storage, email }
        public string id { get; set; }
        [LookupAttribute(lookupName = "LKEmailRouting", relatedTag = "route_Text")]
        public Int32 route { get; set; }

        public string route_Text { get; set; }
        public Int32 xdocumentdefinitionid { get; set; }
        public bool storage { get; set; }
        public bool email { get; set; }
       
        public object getKey()
        {
            return id;
        }

        public void setTransID(object transID)
        {

        }
    }
}

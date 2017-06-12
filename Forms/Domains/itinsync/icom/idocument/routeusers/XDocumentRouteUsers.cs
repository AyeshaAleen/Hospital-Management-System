using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.icom.interfaces.document;
using Domains.itinsync.interfaces.domain;
using Domains.itinsync.icom.annotation;

namespace Domains.itinsync.icom.idocument.routeusers
{
    public class XDocumentRouteUsers : System.Attribute, IDomain
    {
        public enum columns { xdocumentdefinitionid, userid,role, users }
        public enum primaryKey { id }

        public Int32 id { get; set; }
        public Int32 xdocumentdefinitionid { get; set; }
       
        public Int32 userid { get; set; }
      


        public string users { get; set; }

        [LookupAttribute(lookupName = "LKEmailRouting", relatedTag = "role_Text")]

        public Int32 role { get; set; }
        public string role_Text { get; set; }
        public object getKey() { return id; }

        public void setTransID(object transID)
        {

        }
    }
}

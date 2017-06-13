using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.icom.interfaces.document;
using Domains.itinsync.interfaces.domain;
using Domains.itinsync.icom.annotation;

namespace Domains.itinsync.icom.idocument.route
{
    public class XDocumentRoute : System.Attribute, IDomain
    {
        public enum columns { xdocumentdefinitionid, role }
        public enum primaryKey { id }

        public Int32 id { get; set; }
        public Int32 xdocumentdefinitionid { get; set; }

        [LookupAttribute(lookupName = "LKEmailRouting", relatedTag = "role_Text")]
        public Int32 role { get; set; }

        public string role_Text { get; set; }
        public object getKey() { return id; }

        public void setTransID(object transID)
        {

        }
    }
}

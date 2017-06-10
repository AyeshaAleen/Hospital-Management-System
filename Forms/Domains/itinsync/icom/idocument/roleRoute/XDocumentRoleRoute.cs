using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.icom.interfaces.document;
using Domains.itinsync.interfaces.domain;
using Domains.itinsync.icom.annotation;

namespace Domains.itinsync.icom.idocument.roleRoute
{
    public class XDocumentRoleRoute : System.Attribute, IDomain, IDocument
    {
        public enum columns { xdocumentdefinitionid, role }
        public enum primaryKey { id }

        public Int32 id { get; set; }
        public Int32 xdocumentdefinitionid { get; set; }

        [LookupAttribute(lookupName = "LKEmailRouting", relatedTag = "routing_Text")]
        public Int32 role { get; set; }

        public string routing_Text { get; set; }
        public object getKey() { return id; }

        public void setTransID(object transID)
        {

        }
    }
}

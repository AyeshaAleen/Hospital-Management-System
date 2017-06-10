using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.icom.interfaces.document;
using Domains.itinsync.interfaces.domain;
using Domains.itinsync.icom.annotation;

namespace Domains.itinsync.icom.idocument.role
{
    public class XDocumentRole : System.Attribute, IDomain, IDocument
    {
        public enum columns { xdocumentdefinitionid, role }
        public enum primaryKey { xdocumentroleid }

        public Int32 xdocumentroleid { get; set; }
        public Int32 xdocumentdefinitionid { get; set; }
        [LookupAttribute(lookupName = "LKUserRole", relatedTag = "role_Text")]

        public Int32 role { get; set; }
        public string role_Text { get; set; }

        public object getKey() { return xdocumentroleid; }

        public void setTransID(object transID)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.icom.interfaces.document;
using Domains.itinsync.interfaces.domain;

namespace Domains.itinsync.icom.idocument.role
{
    public class XDocumentRole : System.Attribute, IDomain, IDocument
    {
        public enum columns { XDocumentDefinitionID, role }
        public enum primaryKey { xdocumentRoelID }

        public Int32 xdocumentRoelID { get; set; }
        public Int32 XDocumentDefinitionID { get; set; }
        public string role { get; set; }
        public object getKey() { return xdocumentRoelID; }

        public void setTransID(object transID)
        {

        }
    }
}

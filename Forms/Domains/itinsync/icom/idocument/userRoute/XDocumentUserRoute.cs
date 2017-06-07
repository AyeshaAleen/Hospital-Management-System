using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.icom.interfaces.document;
using Domains.itinsync.interfaces.domain;

namespace Domains.itinsync.icom.idocument.userRoute
{
    public class XDocumentUserRoute : System.Attribute, IDomain, IDocument
    {
        public enum columns { xDocumentDefinitionID, role }
        public enum primaryKey { id }

        public Int32 id { get; set; }
        public Int32 xDocumentDefinitionID { get; set; }
        public string role { get; set; }
        public object getKey() { return id; }

        public void setTransID(object transID)
        {

        }
    }
}

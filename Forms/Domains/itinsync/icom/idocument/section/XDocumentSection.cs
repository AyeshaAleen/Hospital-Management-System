using Domains.itinsync.icom.idocument.table;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.idocument.section
{
    public class XDocumentSection : System.Attribute, IDomain
    {
        public enum columns { name, pageID, flow, documentdefinitionid }
        public enum primaryKey { documentsectionid }
        public Int32 documentsectionid { get; set; }
        public String name { get; set; }
        public Int32 pageID { get; set; }
        public Int32 flow { get; set; }
        public Int32 documentdefinitionid { get; set; }
        public object getKey() { return documentsectionid; }

        public void setTransID(object transID)
        {

        }



        //*************Relational Mapping Objects*******************//////

        public List<XDocumentTable> documentTable = new List<XDocumentTable>();

        public int fieldcount { get; set; }
    }
}

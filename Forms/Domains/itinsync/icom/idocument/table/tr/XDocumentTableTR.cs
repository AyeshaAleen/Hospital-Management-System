using Domains.itinsync.icom.idocument.table.td;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.idocument.table.tr
{
    public class XDocumentTableTR : System.Attribute, IDomain
    {
        public enum columns
        { trControlID, cssClass, documentTableID }
        public enum primaryKey { trID }
        public Int32 trID { get; set; }
        public string trControlID { get; set; }
        public string cssClass { get; set; }
        public Int32 documentTableID { get; set; }
        public object getKey() { return trID; }
        public void setTransID(object transID)
        {

        }


        //*************Relational Mapping Objects*******************//////
        public List<XDocumentTableTD> tds = new List<XDocumentTableTD>();
    }
}

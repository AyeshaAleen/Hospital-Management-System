using Domains.itinsync.icom.idocument.table.tr;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.idocument.table
{
    public class XDocumentTable : System.Attribute, IDomain
    {
        public enum columns
        { dataToggle, tableControlID, cssClass, documentsectionid }
        public enum primaryKey { documentTableID }

        public Int32 documentsectionid { get; set; }
        
        public Int32 documentTableID { get; set; }
        public string dataToggle { get; set; }
        public string tableControlID { get; set; }
        public string cssClass { get; set; }
        public object getKey() { return documentTableID; }
        public void setTransID(object transID)
        {
            
        }


        //*************Relational Mapping Objects*******************//////
        public List<XDocumentTableTR> trs = new List<XDocumentTableTR>();
    }
}

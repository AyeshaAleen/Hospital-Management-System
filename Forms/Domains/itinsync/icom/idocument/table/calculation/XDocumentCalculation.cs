using Domains.itinsync.icom.idocument.table.content;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.idocument.table.calculation
{
    public class XDocumentCalculation : System.Attribute, IDomain
    {
        public enum columns
        { documentcontentID, operation, resultContentID }
        public enum primaryKey { xdocumentcalculationID }
        public Int32 xdocumentcalculationID { get; set; }
        public Int32 documentcontentID { get; set; }
        public string operation { get; set; }
        public Int32 resultContentID { get; set; }
      
        public object getKey() { return xdocumentcalculationID; }
        public void setTransID(object transID)
        {

        }

        //**************non DB fields**************///
        public XDocumentTableContent resultContent { get; set; }
        public List<XDocumentTableContent> resultOperationalContent = new List<XDocumentTableContent>();
        public XDocumentTableContent fieldContent { get; set; }
    }
}

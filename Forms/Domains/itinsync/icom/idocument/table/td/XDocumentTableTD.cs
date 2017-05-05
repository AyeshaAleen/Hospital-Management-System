using Domains.itinsync.icom.idocument.table.content;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.idocument.table.td
{
    public class XDocumentTableTD : System.Attribute, IDomain
    {
        public enum columns
        {  tdControlID, trID,cssClass, colSpan, tdType }
        public enum primaryKey { tdID }
        public Int32 tdID { get; set; }
        public string tdControlID { get; set; }
        public Int32 trID { get; set; }
        public string cssClass { get; set; }
        public string colSpan { get; set; }

        public string tdType { get; set; }
        public object getKey() { return tdID; }
        public void setTransID(object transID)
        {

        }


        //*************Relational Mapping Objects*******************//////
        public List<XDocumentTableContent> fields = new List<XDocumentTableContent>();
    }
}

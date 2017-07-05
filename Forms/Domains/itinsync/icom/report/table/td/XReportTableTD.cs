using Domains.itinsync.icom.report.table.content;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.report.table.td
{
    public class XReportTableTD : System.Attribute, IDomain
    {
        public enum columns
        { reportTRID, tdControlID, cssClass }
        public enum primaryKey { reportTDID }
        public Int32 reportTDID { get; set; }
        public Int32 reportTRID { get; set; }
        public string tdControlID { get; set; }
        public string cssClass { get; set; }
        public object getKey() { return reportTDID; }
        public void setTransID(object transID)
        {

        }

        //*************Relational Mapping Objects*******************//////
        public List<XReportTableContent> fields = new List<XReportTableContent>();
    }
}

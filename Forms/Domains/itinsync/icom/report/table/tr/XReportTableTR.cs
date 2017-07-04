using Domains.itinsync.icom.report.table.td;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.report.table.tr
{
    public class XReportTableTR : System.Attribute, IDomain
    {
        public enum columns
        { trControlID, cssClass, reporttableID }
        public enum primaryKey { reportTRID }
        public Int32 reportTRID { get; set; }
        public string trControlID { get; set; }
        public string cssClass { get; set; }
        public Int32 reporttableID { get; set; }
        public object getKey() { return reportTRID; }
        public void setTransID(object transID)
        {

        }

        //*************Relational Mapping Objects*******************//////
        public List<XReportTableTD> tds = new List<XReportTableTD>();
    }
}

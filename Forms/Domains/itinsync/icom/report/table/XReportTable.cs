using Domains.itinsync.icom.report.table.tr;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.report.table
{
    public class XReportTable : System.Attribute, IDomain
    {
        public enum columns
        { xreportdefinitionID, cssClass }
        public enum primaryKey { reporttableID }

        public Int32 reporttableID { get; set; }
        public Int32 xreportdefinitionID { get; set; }
        public string cssClass { get; set; }
        public object getKey() { return reporttableID; }
        public void setTransID(object transID)
        {

        }

        //*************Relational Mapping Objects*******************//////
        public List<XReportTableTR> trs = new List<XReportTableTR>();
    }
}

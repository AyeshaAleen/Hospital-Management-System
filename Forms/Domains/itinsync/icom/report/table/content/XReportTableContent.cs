using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.report.table.content
{
    public class XReportTableContent : System.Attribute, IDomain
    {
        public enum columns
        { documentControlID, height, width }
        public enum primaryKey { reportContentID }

        public Int32 reportContentID { get; set; }
        public string documentControlID { get; set; }
        public string height { get; set; }
        public string width { get; set; }
        public object getKey() { return reportContentID; }
        public void setTransID(object transID)
        {

        }
    }
}

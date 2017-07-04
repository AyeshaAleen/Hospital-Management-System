using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.report.definition
{
    public class XReportDefinition : System.Attribute, IDomain
    {
        public enum columns { documentDefinitionID, vendorID, name, status }
        public enum primaryKey { XReportDefinitionID }

        public Int32 XReportDefinitionID { get; set; }
        public Int32 documentDefinitionID { get; set; }
        public Int32 vendorID { get; set; }
        public String name { get; set; }
        public String status { get; set; }
        public object getKey() { return XReportDefinitionID; }

        public void setTransID(object transID)
        {

        }
    }
}

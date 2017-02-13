using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.vendor.associate
{
    public class VendorAssociation
    {
        public enum columns
        {
            id, customerid, vendorid, agreementid, activefrom, activeto,
            amount, trandate, trantime, transID
        }
        public int id { get; set; }
        public int customerid { get; set; }
        public int vendorid { get; set; }
        public int agreementid { get; set; }
        public string activefrom { get; set; }
        public string activeto { get; set; }
        public string amount { get; set; }
        public string trandate { get; set; }
        public string trantime { get; set; }
        public int transID { get; set; }

    }
}

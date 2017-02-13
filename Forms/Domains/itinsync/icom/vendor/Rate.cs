using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.vendor
{
    public class Rate
    {
        public enum columns
        {
            rateid, vendorID, agreementid, trandate, trantime, amount, userid,
            paymentmode, transID, GSTTaxrate, iholdTaxrate, sholdTaxrate
        }
        public int rateid { get; set; }
        public int vendorID { get; set; }
        public int agreementid { get; set; }
        public int trandate { get; set; }
        public int trantime { get; set; }
        public int amount { get; set; }
        public int userid { get; set; }
        public string paymentmode { get; set; }
        public string paymentmodeText { get; set; }
        public int transID { get; set; }
        public string GSTTaxrate { get; set; }
        public string iholdTaxrate { get; set; }
        public string sholdTaxrate { get; set; }
    }
}

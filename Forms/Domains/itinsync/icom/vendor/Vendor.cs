using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.vendor
{
    public class Vendor
    {
        public enum columns
        {
            vendorID, clientName, primaryrole, contactperson, additionalservice,
            Commodity, activefrom, activeto, trandate, trantime, transID, pfix
        }
        public int vendorID { get; set; }
        public string clientName { get; set; }
        public string primaryrole { get; set; }
        public string contactperson { get; set; }
        public string additionalservice { get; set; }
        public string Commodity { get; set; }
        public int activefrom { get; set; }
        public int activeto { get; set; }
        public int trandate { get; set; }
        public int trantime { get; set; }
        public string typeText { get; set; }
        public int transID { get; set; }
        public string pfix { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.vendor
{
    public class Address
    {
        public enum columns
        {
            addressid, addressLine1, addressLine2,
            city, country, postalCode, type, vendorID
        }
        public int addressid { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string postalCode { get; set; }
        public string type { get; set; }
        public string typeText { get; set; }
        public int vendorID { get; set; }
    }
}

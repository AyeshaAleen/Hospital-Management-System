using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.vendor
{
    public class Phones
    {
        public enum columns { phoneid, phone, type, vendorID };
        public int phoneid { get; set; }
        public string phone { get; set; }
        public string type { get; set; }
        public string typeText { get; set; }
        public int vendorID { get; set; }
    }
}

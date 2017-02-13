using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.vendor
{
    public class Emails
    {

        public enum columns { emailid, email, type, vendorID };
        public int emailid { get; set; }
        public string email { get; set; }
        public string type { get; set; }
        public string typeText { get; set; }
        public int vendorID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.invoice
{
   public class Invoice
    {
        public enum columns
        {
            invoiceid, invoiceType, statusCode, vendorID, agreementid, trandate, trantime,
            vehicleCode, amount, userid, referenceNo, comments, transID
        }
        public int invoiceid { get; set; }
        public string invoiceType { get; set; }
        public string statusCode { get; set; }
        public int vendorID { get; set; }
        public int agreementid { get; set; }
        public string trandate { get; set; }
        public string trantime { get; set; }
        public int vehicleCode { get; set; }
        public string amount { get; set; }
        public int userid { get; set; }
        public string referenceNo { get; set; }
        public string comments { get; set; }
        public int transID { get; set; }
    }
}


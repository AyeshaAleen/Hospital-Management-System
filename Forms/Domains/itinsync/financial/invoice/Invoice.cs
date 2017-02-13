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
            invoiceid, invoiceType, statusCode, vendorID, agreementid, trandate,
            trantime, vehicleCode, amount, userid, referenceNo, comments, transID
        }
        public Int32 invoiceid { get; set; }
        public String invoiceType { get; set; }
        public String statusCode { get; set; }
        public Int32 vendorID { get; set; }
        public Int32 agreementid { get; set; }
        public string trandate { get; set; }
        public string trantime { get; set; }
        public Int32 vehicleCode { get; set; }
        public string amount { get; set; }
        public Int32 userid { get; set; }
        public String referenceNo { get; set; }
        public String comments { get; set; }
        public Int32 transID { get; set; }
    }
}

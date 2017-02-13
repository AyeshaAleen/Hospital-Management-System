using Entities.itinsync.vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.payment
{
    public class Payment
    {
        public enum columns
        {
            paymentid, paytype, trantype, status, vendorid, amount, holeDate, bulkpayment,
            userid, taxamount, allocationdate, paysource, referencenumber, trandate,
            trantime, invoiceid, otheamount, parentref, receivedAmount, adjustAmount,
            agreementid, iholdtax, sholdtax, advanceamount, shortageAmount, paymentType
        }

        public int paymentid { get; set; }
        public string paytype { get; set; }
        public string trantype { get; set; }
        public string status { get; set; }
        public int vendorid { get; set; }
        public string amount { get; set; }
        public string holeDate { get; set; }
        public string bulkpayment { get; set; }
        public int userid { get; set; }
        public string taxamount { get; set; }
        public string allocationdate { get; set; }
        public string paysource { get; set; }
        public string referencenumber { get; set; }
        public string trandate { get; set; }
        public string trantime { get; set; }
        public int invoiceid { get; set; }
        public string otheamount { get; set; }
        public string parentref { get; set; }
        public string receivedAmount { get; set; }
        public string adjustAmount { get; set; }
        public int agreementid { get; set; }
        public string iholdtax { get; set; }
        public string sholdtax { get; set; }
        public string advanceAmount { get; set; }
        public string shortageAmount { get; set; }
        public string paymentType { get; set; }
    }
}

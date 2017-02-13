using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.gl.receipts.logreceipts
{
    public class Receipts
    {

        public enum columns
        {
            receiptid, vendorid, paymentGLID, amount, parentref,
            comments, allocationdate, allocationtime, referencenumber,
            transdate, transtime, userid, logreceiptid, refName, bankaccountid
        };
        public int receiptid { get; set; }
        public int vendorid { get; set; }
        public int paymentGLID { get; set; }
        public string amount { get; set; }
        public string parentref { get; set; }
        public string comments { get; set; }
        public string allocationdate { get; set; }
        public string allocationtime { get; set; }
        public string referencenumber { get; set; }
        public string transdate { get; set; }
        public string transtime { get; set; }
        public int userid { get; set; }
        public int logreceiptid { get; set; }
        public string refName { get; set; }
        public int bankaccountid { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.gl.receipts.logreceipts
{
    public class LogReceipt
    {

        public enum columns
        {
            logreceiptid, vendorid, logamount, transdate, transtime, allocationdate
        };
        public int logreceiptid { get; set; }
        public int vendorid { get; set; }
        public string logamount { get; set; }
        public string transdate { get; set; }
        public string transtime { get; set; }
        public string allocationdate { get; set; }
        ///*********extra*****//
        public string refName { get; set; }
    }
}

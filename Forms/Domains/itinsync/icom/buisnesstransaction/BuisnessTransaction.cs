using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.buisnesstransaction
{
    public enum columns
    {
        transid, transactionDate, transactionTime, userid, pageNo, previouspageNo
    }
    public class BuisnessTransaction
    {
        public int transid { get; set; }
        public string transactionDate { get; set; }
        public string transactionTime { get; set; }
        public int userid { get; set; }
        public int pageNo { get; set; }
        public int previouspageNo { get; set; }
    }
}

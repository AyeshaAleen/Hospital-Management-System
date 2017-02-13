using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.invoice
{
   public  class TDR
    {
        public enum columns
        {
            tdrid, TDRNO, invoiceid, status, userid, transid
        }
        public int tdrid { get; set; }
        public string TDRNO { get; set; }
        public int invoiceid { get; set; }
        public string status { get; set; }
        public string statustext { get; set; }
        public int userid { get; set; }
        public int transid { get; set; }
    }
}

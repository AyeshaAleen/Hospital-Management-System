using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.invoice
{
    public class TDRS
    {
        public enum columns
        {
            invoiceid, TDRNO, status, userid, transid
        }
        public Int32 tdrid { get; set; }
        public Int32 invoiceid { get; set; }
        public string TDRNO { get; set; }
        public string status { get; set; }
        public string statustext { get; set; }
        public Int32 userid { get; set; }
        public Int32 transid { get; set; }
    }
}

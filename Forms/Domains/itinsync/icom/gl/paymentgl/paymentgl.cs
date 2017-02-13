using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.gl.glpayment
{
    public class paymentgl
    {
        public enum columns
        {
            paymentGLID, vendorid, glamount, taxamount, trandate, trantime,
            comments, paymentid, authroizedate, authroizetime, trantype, userid,
            parentref, iholdtax, sholdtax, glstatus, bankaccountid, holdDate
        }
        public int paymentGLID { get; set; }
        public int vendorid { get; set; }
        public string glamount { get; set; }
        public string taxamount { get; set; }
        public string trandate { get; set; }
        public string trantime { get; set; }
        public string comments { get; set; }
        public Int32 paymentid { get; set; }
        public string authroizedate { get; set; }
        public string authroizetime { get; set; }
        public string trantype { get; set; }
        public Int32 userid { get; set; }
        public string parentref { get; set; }
        public string sholdtax { get; set; }
        public string iholdtax { get; set; }
        public string glstatus { get; set; }
        public string glstatusText { get; set; }
        public int bankaccountid { get; set; }
        public string holdDate { get; set; }
    }
}

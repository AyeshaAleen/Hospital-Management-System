using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.financial.bank
{
    public class BankAccount
    {
        public enum columns
        {
            accountid, account, bank, activefrom, activeto,
        }
        public int accountid { get; set; }
        public string account { get; set; }
        public string bank { get; set; }
        public string banktext { get; set; }
        public string activefrom { get; set; }
        public string activeto { get; set; }
        public string shortaccount { get; set; }
        public string text { get; set; }


    }
}

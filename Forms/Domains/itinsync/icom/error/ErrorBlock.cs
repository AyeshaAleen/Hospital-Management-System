using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.error
{
    public class ErrorBlock
    {
        public ErrorBlock()
        {
            this.ErrorCode = 0;
            this.WarningCode = 0;
        }
        public int ErrorCode { get; set; }
        public int WarningCode { get; set; }
        public string ErrorText { get; set; }
        public string WarningText { get; set; }
    }
}

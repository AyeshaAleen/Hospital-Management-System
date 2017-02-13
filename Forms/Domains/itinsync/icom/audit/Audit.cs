using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.audit
{
    public class Audit
    {
        public enum columns
        {
            ID, EventCode, Description, AdditionalDetails, userid,
            TranDate, TranTime, parentref, username
        }
        public int ID { get; set; }
        public int EventCode { get; set; }
        public string Description { get; set; }
        public string AdditionalDetails { get; set; }
        public int userid { get; set; }
        public string TranDate { get; set; }
        public string TranTime { get; set; }
        public string parentref { get; set; }
        public string username { get; set; }
        public string EventCodeText { get; set; }

    }
}

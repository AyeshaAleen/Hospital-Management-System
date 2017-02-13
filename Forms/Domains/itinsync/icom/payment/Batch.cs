using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.payment
{
    public class Batch
    {
        public enum columns { batchid, batchName, status, param, transdate, transtime }
        public int batchid { get; set; }
        public string batchName { get; set; }
        public string status { get; set; }
        public string param { get; set; }
        public string transdate { get; set; }
        public string transtime { get; set; }
    }
}

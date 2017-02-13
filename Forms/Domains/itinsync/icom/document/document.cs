using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.audit
{
    public class document
    {
        public enum columns
        {
            documentid, documentName, documentdefinitionid,
            transdate, transtime, status, data, filepath, parentref
        }
        public int documentid { get; set; }
        public string documentName { get; set; }
        public int documentdefinitionid { get; set; }
        public string transdate { get; set; }
        public string transtime { get; set; }
        public string status { get; set; }
        public string data { get; set; }
        public string filepath { get; set; }
        public string parentref { get; set; }

    }
}

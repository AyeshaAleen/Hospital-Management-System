using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.audit
{
    public class xdocumentdefination
    {
        public enum columns
        {
            id, name, rdlcpath, datatable, parameters
        }
        public int id { get; set; }
        public string name { get; set; }
        public string rdlcpath { get; set; }
        public string datatable { get; set; }
        public string parameters { get; set; }
    }
}

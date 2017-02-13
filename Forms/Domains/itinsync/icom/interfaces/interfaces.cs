using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.itinsync.audit
{
    public class interfaces
    {
        public enum columns
        {
            interfacesid, interfaceName, transdate, transtime
        }
        public int interfacesid { get; set; }
        public string interfaceName { get; set; }
        public string transdate { get; set; }
        public string transtime { get; set; }
    }
}

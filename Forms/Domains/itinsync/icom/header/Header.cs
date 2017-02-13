using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.header
{
    public class Header : IDomain
    {
        public Header()
        {
            this.currentPageNo = 0;

        }
        public int currentPageNo { get; set; }
        public int previousPageNo { get; set; }
        public int userid { get; set; }
        public string lang { get; set; }
        public int transID { get; set; }
        public object getKey()
        {
            throw new NotImplementedException();
        }
    }
}

using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.pages
{
    public class PageName : System.Attribute, IDomain
    {
        
        public enum primaryKey
        {
            pageid
        }

        public enum columns
        {
            pageid, pagename, webName
        }

        public int pageid { get; set; }
        public string pagename { get; set; }
        public string webName { get; set; }

        public object getKey()
        {
            return pageid;
        }
    }
}

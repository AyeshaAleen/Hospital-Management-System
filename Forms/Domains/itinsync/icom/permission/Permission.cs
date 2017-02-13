using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.permission
{
    public class Permission : System.Attribute, IDomain
    {
        public enum columns {  Code, text, pageID }
        public enum primaryKey { permissionid}

        public enum foreignKey { pageID }

        public int permissionid { get; set; }
        public int Code { get; set; }
        public string text { get; set; }
        public int pageID { get; set; }

        public object getKey()
        {
            return pageID;
        }
    }
}

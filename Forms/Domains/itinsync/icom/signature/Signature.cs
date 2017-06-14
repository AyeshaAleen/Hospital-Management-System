using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.interfaces.domain;
using Domains.itinsync.icom.annotation;

namespace Domains.itinsync.icom.signature
{
    public class Signature : System.Attribute, IDomain
    {
        public enum columns { documentid, signaturestring, trandate, trantime }
        public enum primaryKey { id }

        public Int32 id { get; set; }
        public Int32 documentid { get; set; }
        public string signaturestring { get; set; }
        public string trandate { get; set; }
        public string trantime { get; set; }

        public object getKey() { return id; }

        public void setTransID(object transID)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.interfaces.domain;

namespace Domains.itinsync.icom.views.emailroutingview
{
    public class EmailRouting : System.Attribute, IDomain
    {
        public enum columns { xDocumentDefinationID, storage, email, documentrolerouteid, role, documentuserrouteid, userid }
        public Int32 xDocumentDefinationID { get; set; }

        public bool storage { get; set; }
        public bool email { get; set; }
        public Int32 documentrolerouteid { get; set; }
        public Int32 role { get; set; }
        public Int32 documentuserrouteid { get; set; }
        public Int32 userid { get; set; }

        public object getKey()
        {
            return xDocumentDefinationID;
        }

        public void setTransID(object transID)
        {

        }
    }
}

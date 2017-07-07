using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.interfaces.domain;
using Domains.itinsync.icom.annotation;

namespace Domains.itinsync.icom.views.personalinbox
{
    public class PersonalInboxView : System.Attribute, IDomain
    {
        public enum columns { documentid, documentname, sectionname, transdate, transTime, status, userid, username }

        public Int64 documentid { get; set; }
        public string documentname { get; set; }
        public string sectionname { get; set; }
        public string transdate { get; set; }
        public string transTime { get; set; }

        [LookupAttribute(lookupName = "LKDocumentStatus", relatedTag = "status_Text")]
        public string status { get; set; }

        public string status_Text { get; set; }

        public Int32 userid { get; set; }
        public string username { get; set; }
        public object getKey()
        {
            return documentid;
        }

        public void setTransID(object transID)
        {

        }
    }
}

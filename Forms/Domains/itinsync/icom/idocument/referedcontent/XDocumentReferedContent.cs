using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.idocument.referedcontent
{
    public class XDocumentReferedContent : System.Attribute, IDomain
    {
        public enum columns { documentsectionID, controlID, translation, documentdefinitionID, documentcontentID }
        public enum primaryKey { referedContentID }
        public Int32 referedContentID { get; set; }
        public Int32 documentsectionID { get; set; }
        public string controlID { get; set; }
        public string translation { get; set; }

        public long documentdefinitionID { get; set; }

        public long documentcontentID { get; set; }
        public object getKey() { return referedContentID; }

        public void setTransID(object transID)
        {

        }
    }
}

using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.idocument.content
{
   public class XDocumentContent : System.Attribute, IDomain
    {
        public enum columns { documentsectionID, controlType, controlName, controlID, mask, isRequired, translation, cssClass, hight, width , sequence }
        public enum primaryKey { documentContentID }
        public Int32 documentContentID { get; set; }
        public Int32 documentsectionID { get; set; }
        public string controlType { get; set; }
        public string controlName { get; set; }
        public string controlID { get; set; }

        public string mask { get; set; }
        public string isRequired { get; set; }
        public string translation { get; set; }
        public string cssClass { get; set; }

        public string hight { get; set; }
        public string width { get; set; }
        public string sequence { get; set; }
        
        public object getKey() { return documentContentID; }

        public void setTransID(object transID)
        {

        }
    }
}

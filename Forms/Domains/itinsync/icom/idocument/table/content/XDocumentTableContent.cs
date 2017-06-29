using Domains.itinsync.icom.idocument.table.calculation;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.idocument.table.content
{
    public class XDocumentTableContent : System.Attribute, IDomain

    {
        public enum columns { tdID, controlType, controlName, controlID, mask, isRequired, translation, cssClass, hight, width,
            sequence , lookupName, colspan, defaultValue, points, isReadonly, formula, conditions
        }
        public enum primaryKey { documentTableContentID }
        public Int32 documentTableContentID { get; set; }
        public Int32 tdID { get; set; }
        public string controlType { get; set; }
        public string isReadonly { get; set; }
        public string controlName { get; set; }
        public string controlID { get; set; }
        public Int32 colspan { get; set; }
        public string mask { get; set; }
        public string points { get; set; }
        public string isRequired { get; set; }
        public string translation { get; set; }
        public string cssClass { get; set; }

        public string formula { get; set; }

        public string conditions { get; set; }

        public string hight { get; set; }
        public string width { get; set; }
        public string sequence { get; set; }
        public string lookupName { get; set; }
        public string tdType { get; set; }
        public string defaultValue { get; set; }
        
        public object getKey() { return documentTableContentID; }

        public void setTransID(object transID)
        {

        }
        //*************Relational Mapping Objects*******************//////
        public List<XDocumentCalculation> calculations = new List<XDocumentCalculation>();

        public List<XDocumentCalculation> fieldcalculations =new List<XDocumentCalculation>();
    }
}

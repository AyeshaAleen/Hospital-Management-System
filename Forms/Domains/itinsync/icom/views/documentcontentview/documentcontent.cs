using Domains.itinsync.interfaces.domain;
using System;
using Domains.itinsync.icom.idocument;

namespace Domains.itinsync.icom.document

{
    public class documentcontent : System.Attribute, IDomain
    {
        public enum columns { documentTableContentID, tdID, controlType, controlName, controlID, mask, isRequired, translation, cssClass, hight, width, sequence, lookupName, colspan, TRID, documentTableID, documentsectionid, documentdefinitionid }
        public Int32 documentTableContentID { get; set; }
        public Int32 tdID { get; set; }
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
        public string lookupName { get; set; }
        public Int32 colspan { get; set; }

        public Int32 TRID { get; set; }
        public Int32 documentTableID { get; set; }
        public Int32 documentsectionid { get; set; }
        public Int32 documentdefinitionid { get; set; }



        public object getKey()
        {
            return documentTableContentID;
        }

        public void setTransID(object transID)
        {

        }


    }
}
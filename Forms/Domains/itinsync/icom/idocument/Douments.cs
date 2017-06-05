using Domains.itinsync.icom.annotation;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.interfaces.document;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.idocument
{
    public class Douments : System.Attribute, IDomain, IDocument
    {
        public enum columns
        { documentName, documentDefinitionID, transDate, transTime, status, data, filePath, type, extension, storeid , Userid }
        public enum primaryKey { documentID }
        public Int32 documentID { get; set; }
        public string documentName { get; set; }
        public Int32 documentDefinitionID { get; set; }
        public string transDate { get; set; }
        [DateTimeAttribute(relatedTag = "transDate")]
        public string transTime { get; set; }
        public string status { get; set; }
        public String data { get; set; }
        public string filePath { get; set; }
        public string parentRef { get; set; }
        public Int32 vendorid { get; set; }
        public Int32 storeid { get; set; }
        public Int32 Userid { get; set; }
        public Int32 transID { get; set; }
        public string type { get; set; }
        public string extension { get; set; }
        public object getKey() { return documentID; }
        public void setTransID(object transID)
        {
            this.transID = (Int32)transID;
        }



        //*************Relational Mapping Objects*******************//////
        public XDocumentDefination xdocumentDefinition{get;set;}
    }
}

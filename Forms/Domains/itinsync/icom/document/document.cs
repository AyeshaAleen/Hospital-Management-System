using Domains.itinsync.icom.annotation;
using Domains.itinsync.interfaces.domain;
using System;

namespace Domain.itinsync.document
{
    public class Document : System.Attribute, IDomain
    {
        public enum columns
        { documentName, documentDefinitionID, transDate, transTime, status, data, filePath, parentRef, vendorid, type, extension }
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
        public Int32 transID { get; set; }
        public string type { get; set; }
        public string extension { get; set; }
        public object getKey() { return documentID; }
        public void setTransID(object transID)
        {
            this.transID = (Int32)transID;
        }
    }
}

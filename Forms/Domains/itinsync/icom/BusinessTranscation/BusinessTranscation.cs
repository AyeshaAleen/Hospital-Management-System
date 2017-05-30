using Domains.itinsync.icom.annotation;
using Domains.itinsync.interfaces.domain;
using System;

namespace domains.itinsync.businesstransaction
{
    public class BusinessTranscation : System.Attribute, IDomain
    {
        public enum columns
        {  transDate, transTime, userID, pageNo, previousPageNo }
        public enum primaryKey { transID }
        public Int32 transID { get; set; }
        public string transDate { get; set; }
        [DateTimeAttribute(relatedTag = "transDate")]
        public string transTime { get; set; }
        public Int32 userID { get; set; }
        public Int32 pageNo { get; set; }
        public Int32 previousPageNo { get; set; }
        public object getKey() { return transID; }

        public void setTransID(object transID)
        {
            //this.transID = (Int32)transID;
        }
    }
}
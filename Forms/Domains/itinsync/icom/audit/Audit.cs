using Domains.itinsync.icom.annotation;
using Domains.itinsync.interfaces.domain;
using System;

namespace domains.itinsync.audit
{
    public class Audit : System.Attribute, IDomain
    {
        public enum columns
        { eventCode, description, additionalDetails, userID, transDate, transTime, parentRef, userName, vendorid }
        public enum primaryKey { auditID }
        public Int32 auditID { get; set; }
        [LookupAttribute(lookupName = "LKAuditEvent", relatedTag = "eventCode_Text")]
        public Int32 eventCode { get; set; }
        public String eventCode_Text { get; set; }
        public String description { get; set; }
        public String additionalDetails { get; set; }
        public Int32 userID { get; set; }
        public String transDate { get; set; }

        [DateTimeAttribute(relatedTag = "transDate")]

        public String transTime { get; set; }
        public String parentRef { get; set; }
        public String userName { get; set; }
        public Int32 vendorid { get; set; }        
        public object getKey() { return auditID; }
        public void setTransID(object transID)
        {
            
        }
    }
}
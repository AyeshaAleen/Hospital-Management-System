using Domains.itinsync.icom.annotation;
using Domains.itinsync.interfaces.domain;
using System;

namespace Domains.itinsync.icom.team
{
    public class Team : System.Attribute, IDomain
    {
        public enum columns {  teamName, status }
        public enum primaryKey { teamID }
        public Int32 teamID { get; set; }
        public String teamName { get; set; }

        [LookupAttribute(lookupName = "LKTaskStatus", relatedTag = "statusText")]
        public String status { get; set; }
        public String statusText { get; set; }
        public object getKey() {  return teamID; }

        public void setTransID(object transID)
        {
            
        }
    }
}

using Domains.itinsync.icom.annotation;
using Domains.itinsync.interfaces.domain;
using System;

namespace Domains.itinsync.icom.views.user
{
    public class UserTeamView : IDomain
    {
        public enum columns { userTeamID, userID, teamName, teamID, status }
        public Int32 userTeamID { get; set; }
        public Int32 userID { get; set; }
        public String teamName { get; set; }
        public Int32 teamID { get; set; }
        [LookupAttribute(lookupName = "LKTaskStatus", relatedTag = "statusText")]
        public String status { get; set; }
        public String statusText { get; set; }
        public object getKey() { return userTeamID; }
        public void setTransID(object transID) { }
    }
}

using Domains.itinsync.interfaces.domain;
using System;

namespace domains.itinsync.useraccounts
{
    public class UserTeam : System.Attribute, IDomain
    {
        public enum columns { userID, teamID }
        public enum primaryKey { userTeamID }
        public Int32 userTeamID { get; set; }
        public Int32 userID { get; set; }
        public Int32 teamID { get; set; }
        public object getKey() { return userTeamID; }

        public void setTransID(object transID)
        {
            
        }
    }
}
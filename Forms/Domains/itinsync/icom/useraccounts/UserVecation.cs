using Domains.itinsync.interfaces.domain;
using System;

namespace DAO.itinsync.icom.useraccounts
{
    public class UserVecation : System.Attribute, IDomain
    {
        public enum columns { userName, startDate, endDate, timeZone, reasonCode, vecationCode }
        public enum primaryKey { vecationID }
        public Int32 vecationID { get; set; }
        public String userName { get; set; }
        public String startDate { get; set; }
        public String endDate { get; set; }
        public String timeZone { get; set; }
        public Int32 reasonCode { get; set; }
        public Int32 reasonCode_Text { get; set; }
        public Int32 vecationCode { get; set; }
        public Int32 vecationCode_Text { get; set; }
        public object getKey() { return vecationID; }

        public void setTransID(object transID)
        {
           
        }
    }
}
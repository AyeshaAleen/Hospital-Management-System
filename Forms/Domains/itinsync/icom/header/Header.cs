


using Domains.itinsync.icom.session.user;
using Domains.itinsync.interfaces.domain;
using System;

namespace Domains.itinsync.icom.header
{
    public class Header : System.Attribute, IDomain
    {
        public Header() { this.currentPageNo = 0; }
        public enum columns { previousPageNo, userid, lang, transID }
        public enum primaryKey { currentPageNo }
        public UserInformation userinformation = new UserInformation();
      



        public Int32 currentPageNo { get; set; }
        public Int32 previousPageNo { get; set; }
        public Int32 userID { get; set; }



        public String lang { get; set; }
        public Int32 transID { get; set; }
        public object getKey() { return currentPageNo; }

        public void setTransID(object transID)
        {
            this.transID = (Int32)transID;
        }
    }
}
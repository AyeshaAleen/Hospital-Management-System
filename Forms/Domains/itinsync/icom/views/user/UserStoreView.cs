using Domains.itinsync.icom.annotation;
using Domains.itinsync.interfaces.domain;
using System;

namespace Domains.itinsync.icom.views.user
{
    public class UserStoreView : IDomain
    {
        public enum columns { userstoreid, userid, storename, storeid }
        public Int32 userstoreid { get; set; }
        public Int32 userid { get; set; }
        public String storename { get; set; }
        public Int32 storeid { get; set; }
        

        public object getKey() { return userstoreid; }
        public void setTransID(object transID) { }
    }
}

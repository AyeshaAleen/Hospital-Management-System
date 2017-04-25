using Domains.itinsync.interfaces.domain;
using System;

namespace Domains.itinsync.icom.pages
{
    public class PageName : System.Attribute, IDomain
    {
        public enum columns { pageName, webName }
        public enum primaryKey { pageID }
        public Int32 pageID { get; set; }
        public String pageName { get; set; }
        public String webName { get; set; }
        public object getKey() { return pageID; }

        public void setTransID(object transID)
        {

        }
    }
}
using Domains.itinsync.icom.idocument.section;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.idocument.page
{
    public class pagename : System.Attribute, IDomain
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

        public override string ToString()
        {
            return pageName.ToString();
        }
        //*************Relational Mapping Objects*******************//////
        //public List<XDocumentSection> documentSections = new List<XDocumentSection>();
    }
}

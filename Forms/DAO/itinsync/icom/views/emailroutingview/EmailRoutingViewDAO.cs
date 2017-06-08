using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Domains.itinsync.icom.views.emailroutingview;

namespace DAO.itinsync.icom.views.emailroutingview
{
    public class EmailRoutingViewDAO : CRUDBase
    {
        string TABLENAME = " viewemailrouting ";
        public static EmailRoutingViewDAO getInstance(DBContext dbContext)
        {
            EmailRoutingViewDAO obj = new EmailRoutingViewDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            throw new NotImplementedException();
        }
        protected override IDomain setResult(DataTable dt, int i)
        {

            EmailRouting routing = new EmailRouting();
            routing.xDocumentDefinationID = Convert.ToInt32(dt.Rows[i][EmailRouting.columns.xDocumentDefinationID.ToString()]);

            setPropertiesValue(routing, dt, i, typeof(EmailRouting.columns));

           
            return routing;
        }
        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }
        private List<EmailRouting> wrap(List<IDomain> result)
        {
            List<EmailRouting> list = new List<EmailRouting>();
            foreach (IDomain domain in result)
                list.Add((EmailRouting)domain);
            return list;
        }
        public EmailRouting findbyDefinitionID(Int32 id)
        {
            string READ = string.Format("Select * from " + TABLENAME + " where xdocumentdefinationid = " + id);
            return (EmailRouting)processSingleResult(READ);
        }

        public List<EmailRouting> readyAll()
        {
            string READ = string.Format("Select * from " + TABLENAME);
            return wrap(processResults(READ));
        }
    }
}

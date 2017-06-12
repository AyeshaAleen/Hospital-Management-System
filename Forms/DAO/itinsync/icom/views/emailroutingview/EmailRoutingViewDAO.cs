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
    public class EmailRoutingDAO : CRUDBase
    {
        //string TABLENAME = " emailroutingview ";
        string TABLENAME = " EmailRoute ";
        public static EmailRoutingDAO getInstance(DBContext dbContext)
        {
            EmailRoutingDAO obj = new EmailRoutingDAO();
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
            routing.id = Convert.ToInt64(dt.Rows[i][EmailRouting.columns.id.ToString()]);

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
        public List<EmailRouting> findbyDefinitionID(Int64 xdocumentdefinitionid)
        {
            string READ = string.Format("Select * from " + TABLENAME + " where xdocumentdefinitionid = " + xdocumentdefinitionid);
            return wrap(processResults(READ));
            //return (EmailRouting)processSingleResult(READ);
        }

        public List<EmailRouting> readyAll()
        {
            string READ = string.Format("Select * from " + TABLENAME);
            return wrap(processResults(READ));
        }
    }
}

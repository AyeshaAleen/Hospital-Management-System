using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Domains.itinsync.icom.views.routeusers;

namespace DAO.itinsync.icom.views.routeusers
{
    public class XDocumentRouteUsersViewDAO : CRUDBase
    {
        string TABLENAME = " routeusersview ";
        public static XDocumentRouteUsersViewDAO getInstance(DBContext dbContext)
        {
            XDocumentRouteUsersViewDAO obj = new XDocumentRouteUsersViewDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            throw new NotImplementedException();
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            XDocumentRouteUsersView routeusers = new XDocumentRouteUsersView();
            routeusers.id = Convert.ToInt32(dt.Rows[i][XDocumentRouteUsersView.primaryKey.id.ToString()]);

            setPropertiesValue(routeusers, dt, i, typeof(XDocumentRouteUsersView.columns));

            return routeusers;
        }
        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }
        private List<XDocumentRouteUsersView> wrap(List<IDomain> result)
        {
            List<XDocumentRouteUsersView> list = new List<XDocumentRouteUsersView>();
            foreach (IDomain domain in result)
                list.Add((XDocumentRouteUsersView)domain);
            return list;
        }
        public List<XDocumentRouteUsersView> findbyDefinitionID(Int64 xdocumentdefinitionid)
        {
            string READ = string.Format("Select * from " + TABLENAME + " where xdocumentdefinitionid = " + xdocumentdefinitionid);
            return wrap(processResults(READ));
        }
    }
}

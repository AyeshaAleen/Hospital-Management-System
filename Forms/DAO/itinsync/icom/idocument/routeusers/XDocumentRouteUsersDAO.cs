using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Utils.itinsync.icom;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom.cache.document;
using Domains.itinsync.icom.idocument.routeusers;

namespace DAO.itinsync.icom.idocument.routeusers
{
    public class XDocumentRouteUsersDAO : CRUDBase
    {
        string TABLENAME = " xdocumentrouteusers ";
        string VIEWNAME = " routeusersview ";
        public static XDocumentRouteUsersDAO getInstance(DBContext dbContext)
        {
            XDocumentRouteUsersDAO obj = new XDocumentRouteUsersDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(XDocumentRouteUsers.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            XDocumentRouteUsers routeusers = new XDocumentRouteUsers();
            routeusers.id = Convert.ToInt32(dt.Rows[i][XDocumentRouteUsers.primaryKey.id.ToString()]);

            setPropertiesValue(routeusers, dt, i, typeof(XDocumentRouteUsers.columns));

            return routeusers;
        }
        protected override string updateQuery(object o, string where)
        {
            List<XDocumentRouteUsers> results = new List<XDocumentRouteUsers>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((XDocumentRouteUsers)o).id));
            foreach (XDocumentRouteUsers lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(XDocumentRouteUsers.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(XDocumentRouteUsers.primaryKey.id.ToString(), lk.id)));
            }
            return "";
        }
        private List<XDocumentRouteUsers> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<XDocumentRouteUsers> wrap(List<IDomain> result)
        {
            List<XDocumentRouteUsers> list = new List<XDocumentRouteUsers>();
            foreach (IDomain domain in result)
                list.Add((XDocumentRouteUsers)domain);
            return list;
        }
        public XDocumentRouteUsers findbyPrimaryKey(Int32 id)
        {
            if (DocumentManager.getDocumentRouteUsers(id) != null)
                return DocumentManager.getDocumentRouteUsers(id);

            string sql = "select * From " + TABLENAME + " where id = " + id;
            return (XDocumentRouteUsers)processSingleResult(sql);
        }

        public bool deleteByID(Int32 ID)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where id = {0}", ID);
            return delete(delSQL);
        }
        public List<XDocumentRouteUsers> findbyDefinitionID(Int64 xdocumentdefinitionid)
        {
            string READ = string.Format("Select * from " + VIEWNAME + " where xdocumentdefinitionid = " + xdocumentdefinitionid);
            return wrap(processResults(READ));
        }
    }
}

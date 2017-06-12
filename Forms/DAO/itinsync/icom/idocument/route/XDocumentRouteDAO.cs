using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.idocument.route;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Utils.itinsync.icom;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom.cache.document;

namespace DAO.itinsync.icom.idocument.route
{
    public class XDocumentRouteDAO : CRUDBase
    {
        string TABLENAME = " xdocumentroute ";
        public static XDocumentRouteDAO getInstance(DBContext dbContext)
        {
            XDocumentRouteDAO obj = new XDocumentRouteDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(XDocumentRoute.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            XDocumentRoute roleRoute = new XDocumentRoute();
            roleRoute.id = Convert.ToInt32(dt.Rows[i][XDocumentRoute.primaryKey.id.ToString()]);

            setPropertiesValue(roleRoute, dt, i, typeof(XDocumentRoute.columns));

            return roleRoute;
        }
        protected override string updateQuery(object o, string where)
        {
            List<XDocumentRoute> results = new List<XDocumentRoute>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((XDocumentRoute)o).id));
            foreach (XDocumentRoute lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(XDocumentRoute.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(XDocumentRoute.primaryKey.id.ToString(), lk.id)));
            }
            return "";
        }
        public XDocumentRoute findbyPrimaryKey(Int32 id)
        {
            if (DocumentManager.getDocumentRoute(id) != null)
                return DocumentManager.getDocumentRoute(id);

            string sql = "select * From " + TABLENAME + " where id = " + id;
            return (XDocumentRoute)processSingleResult(sql);
        }

        //public List<XDocumentRoute> readAll()
        //{
        //    string sql = "select * From " + TABLENAME;
        //    return wrap(processResults(sql));
        //}

        public List<XDocumentRoute> findbyDefinitionID(Int64 xdocumentdefinitionid)
        {
            string READ = string.Format("Select * from " + TABLENAME + " where xdocumentdefinitionid = " + xdocumentdefinitionid);
            return wrap(processResults(READ));
        }

        private List<XDocumentRoute> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<XDocumentRoute> wrap(List<IDomain> result)
        {
            List<XDocumentRoute> list = new List<XDocumentRoute>();
            foreach (IDomain domain in result)
                list.Add((XDocumentRoute)domain);
            return list;
        }

        public bool deleteByID(Int32 ID)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where id = {0}", ID);
            return delete(delSQL);
        }
    }
}

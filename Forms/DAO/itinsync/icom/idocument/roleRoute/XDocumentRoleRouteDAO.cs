using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.idocument.roleRoute;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Utils.itinsync.icom;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom.cache.document;

namespace DAO.itinsync.icom.idocument.roleRoute
{
    public class XDocumentRoleRouteDAO : CRUDBase
    {
        string TABLENAME = " xdocumentroleroute ";
        public static XDocumentRoleRouteDAO getInstance(DBContext dbContext)
        {
            XDocumentRoleRouteDAO obj = new XDocumentRoleRouteDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(XDocumentRoleRoute.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            XDocumentRoleRoute roleRoute = new XDocumentRoleRoute();
            roleRoute.id = Convert.ToInt32(dt.Rows[i][XDocumentRoleRoute.primaryKey.id.ToString()]);

            setPropertiesValue(roleRoute, dt, i, typeof(XDocumentRoleRoute.columns));

            return roleRoute;
        }
        protected override string updateQuery(object o, string where)
        {
            List<XDocumentRoleRoute> results = new List<XDocumentRoleRoute>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((XDocumentRoleRoute)o).id));
            foreach (XDocumentRoleRoute lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(XDocumentRoleRoute.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(XDocumentRoleRoute.primaryKey.id.ToString(), lk.id)));
            }
            return "";
        }
        public XDocumentRoleRoute findbyPrimaryKey(Int32 id)
        {
            if (DocumentManager.getDocumentRoleRoute(id) != null)
                return DocumentManager.getDocumentRoleRoute(id);

            string sql = "select * From " + TABLENAME + " where id = " + id;
            return (XDocumentRoleRoute)processSingleResult(sql);
        }

        public List<XDocumentRoleRoute> readAll()
        {
            string sql = "select * From " + TABLENAME;
            return wrap(processResults(sql));
        }

        private List<XDocumentRoleRoute> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<XDocumentRoleRoute> wrap(List<IDomain> result)
        {
            List<XDocumentRoleRoute> list = new List<XDocumentRoleRoute>();
            foreach (IDomain domain in result)
                list.Add((XDocumentRoleRoute)domain);
            return list;
        }

        public bool deleteByID(Int32 ID)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where id = {0}", ID);
            return delete(delSQL);
        }
        //public XDocumentDefination findbyDocumentName(string DocumentName)
        //{

        //    foreach (Int32 entry in GlobalStaticCache.documentDefinition.Keys)
        //    {
        //        XDocumentDefination documentDefinition = GlobalStaticCache.documentDefinition[entry];

        //        if (documentDefinition.name == DocumentName)
        //            return documentDefinition;
        //    }

        //    // if not found them reload complete definitions
        //    load();

        //    string sql = string.Format("select * From " + TABLENAME + "where name ='{0}'", DocumentName);
        //    return (XDocumentDefination)processSingleResult(sql);
        //}
    }
}

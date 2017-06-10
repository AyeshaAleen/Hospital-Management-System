using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.idocument.userRoute;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Utils.itinsync.icom;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom.cache.document;

namespace DAO.itinsync.icom.idocument.userRoute
{
    public class XDocumentUserRouteDAO : CRUDBase
    {
        string TABLENAME = " xdocumentuserroute ";
        public static XDocumentUserRouteDAO getInstance(DBContext dbContext)
        {
            XDocumentUserRouteDAO obj = new XDocumentUserRouteDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(XDocumentUserRoute.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            XDocumentUserRoute userRoute = new XDocumentUserRoute();
            userRoute.id = Convert.ToInt32(dt.Rows[i][XDocumentUserRoute.primaryKey.id.ToString()]);

            setPropertiesValue(userRoute, dt, i, typeof(XDocumentUserRoute.columns));

            return userRoute;
        }
        protected override string updateQuery(object o, string where)
        {
            List<XDocumentUserRoute> results = new List<XDocumentUserRoute>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((XDocumentUserRoute)o).id));
            foreach (XDocumentUserRoute lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(XDocumentUserRoute.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(XDocumentUserRoute.primaryKey.id.ToString(), lk.id)));
            }
            return "";
        }
        public XDocumentUserRoute findbyPrimaryKey(Int32 id)
        {
            if (DocumentManager.getDocumentUserRoute(id) != null)
                return DocumentManager.getDocumentUserRoute(id);

            string sql = "select * From " + TABLENAME + " where id = " + id;
            return (XDocumentUserRoute)processSingleResult(sql);
        }
        public List<XDocumentUserRoute> readAll()
        {
            string sql = "select * From " + TABLENAME;
            return wrap(processResults(sql));
        }

        public List<XDocumentUserRoute> findbyDocumentDefinitionID(Int32 documentDefinitionID)
        {
            
            string SQL = string.Format("Select * from " + TABLENAME + " where xdocumentdefinitionid =" + documentDefinitionID);
            return wrap(processResults(SQL));
        }


        private List<XDocumentUserRoute> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<XDocumentUserRoute> wrap(List<IDomain> result)
        {
            List<XDocumentUserRoute> list = new List<XDocumentUserRoute>();
            foreach (IDomain domain in result)
                list.Add((XDocumentUserRoute)domain);
            return list;
        }

        public bool deleteByID(Int32 ID)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where id = {0}", ID);
            return delete(delSQL);
        }
        //public XDocumentUserRoute findbyDocumentName(string DocumentName)
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

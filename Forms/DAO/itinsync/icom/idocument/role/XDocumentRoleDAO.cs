using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.idocument.role;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Utils.itinsync.icom;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom.cache.document;

namespace DAO.itinsync.icom.idocument.role
{
    public class XDocumentRoleDAO : CRUDBase
    {
        string TABLENAME = " xdocumentrole ";
        public static XDocumentRoleDAO getInstance(DBContext dbContext)
        {
            XDocumentRoleDAO obj = new XDocumentRoleDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(XDocumentRole.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            XDocumentRole role = new XDocumentRole();
            role.xdocumentRoelID = Convert.ToInt32(dt.Rows[i][XDocumentRole.primaryKey.xdocumentRoelID.ToString()]);

            setPropertiesValue(role, dt, i, typeof(XDocumentRole.columns));

            return role;
        }
        protected override string updateQuery(object o, string where)
        {
            List<XDocumentRole> results = new List<XDocumentRole>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((XDocumentRole)o).xdocumentRoelID));
            foreach (XDocumentRole lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(XDocumentRole.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(XDocumentRole.primaryKey.xdocumentRoelID.ToString(), lk.xdocumentRoelID)));
            }
            return "";
        }
        public XDocumentRole findbyPrimaryKey(Int32 xDocumentRoleID)
        {
            if (DocumentManager.getDocumentRole(xDocumentRoleID) != null)
                return DocumentManager.getDocumentRole(xDocumentRoleID);

            string sql = "select * From " + TABLENAME + " where xDocumentRoleID = " + xDocumentRoleID;
            return (XDocumentRole)processSingleResult(sql);
        }
        public List<XDocumentRole> readAll()
        {
            string sql = "select * From " + TABLENAME;
            return wrap(processResults(sql));
        }

        private List<XDocumentRole> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<XDocumentRole> wrap(List<IDomain> result)
        {
            List<XDocumentRole> list = new List<XDocumentRole>();
            foreach (IDomain domain in result)
                list.Add((XDocumentRole)domain);
            return list;
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

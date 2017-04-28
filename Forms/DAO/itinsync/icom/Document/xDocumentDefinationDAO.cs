using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.interfaces.domain;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom;
using domains.itinsync.document;

namespace DAO.itinsync.icom.document
{
    public class xDocumentDefinationDAO : CRUDBase
    {
        string TABLENAME = " xdocumentdefinition ";
        public static xDocumentDefinationDAO getInstance(DBContext dbContext)
        {
            xDocumentDefinationDAO obj = new xDocumentDefinationDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(xDocumentDefination.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            xDocumentDefination document = new xDocumentDefination();
            document.xDocumentDefinationID = Convert.ToInt32(dt.Rows[i][xDocumentDefination.primaryKey.xDocumentDefinationID.ToString()]);
            /* document.name = Convert.ToString(dt.Rows[i][xDocumentDefination.columns.name.ToString()]);
             document.rdlcPath = Convert.ToString(dt.Rows[i][xDocumentDefination.columns.rdlcPath.ToString()]);
             document.dataTable = Convert.ToString(dt.Rows[i][xDocumentDefination.columns.dataTable.ToString()]);
             document.parameters = Convert.ToString(dt.Rows[i][xDocumentDefination.columns.parameters.ToString()]);*/

            setPropertiesValue(document, dt, i, typeof(xDocumentDefination.columns));

            return document;
        }
        protected override string updateQuery(object o, string where)
        {
            List<xDocumentDefination> results = new List<xDocumentDefination>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((xDocumentDefination)o).xDocumentDefinationID));
            foreach (xDocumentDefination lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(xDocumentDefination.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(xDocumentDefination.primaryKey.xDocumentDefinationID.ToString(), lk.xDocumentDefinationID)));
            }
            return "";
        }
        public xDocumentDefination findbyPrimaryKey(int xDocumentDefinationID)
        {
            string sql = "select * From " + TABLENAME + "where xDocumentDefinationID = " + xDocumentDefinationID;
            return (xDocumentDefination)processSingleResult(sql);
        }
        public xDocumentDefination findbyDocumentName(string DocumentName)
        {
            string sql = string.Format("select * From " + TABLENAME + "where name ='{0}'" , DocumentName);
            return (xDocumentDefination)processSingleResult(sql);
        }

        public List<xDocumentDefination> readAll()
        {
            string sql = "select * From " + TABLENAME;
            return wrap(processResults(sql));
        }
        private List<xDocumentDefination> languageLookup()
        {
            string READBYLOOKUP = "select * from " + TABLENAME + " where name ='" + LookupsConstant.LKUserLang + "' order by name";
            return wrap(processResults(READBYLOOKUP));
        }
        private List<xDocumentDefination> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<xDocumentDefination> wrap(List<IDomain> result)
        {
            List<xDocumentDefination> list = new List<xDocumentDefination>();
            foreach (IDomain domain in result)
                list.Add((xDocumentDefination)domain);
            return list;
        }
    }
}
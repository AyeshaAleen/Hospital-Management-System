using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.interfaces.domain;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom;
using Domain.itinsync.document;

namespace DAO.itinsync.icom.document
{
    public class DocumentDAO : CRUDBase
    {
        string TABLENAME = " document ";
        public static DocumentDAO getInstance(DBContext dbContext)
        {
            DocumentDAO obj = new DocumentDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(Document.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            Document document = new Document();
            document.documentID = Convert.ToInt32(dt.Rows[i][Document.primaryKey.documentID.ToString()]);

            setPropertiesValue(document, dt, i, typeof(Document.columns));

            /*document.documentName = Convert.ToString(dt.Rows[i][Document.columns.documentName.ToString()]);
            document.documentDefinitionID = Convert.ToInt32(dt.Rows[i][Document.columns.documentDefinitionID.ToString()]);
            document.transDate = Convert.ToString(dt.Rows[i][Document.columns.transDate.ToString()]);
            document.transTime = Convert.ToString(dt.Rows[i][Document.columns.transTime.ToString()]);
            document.status = Convert.ToString(dt.Rows[i][Document.columns.data.ToString()]);
            document.filePath = Convert.ToString(dt.Rows[i][Document.columns.filePath.ToString()]);
            document.parentRef = Convert.ToString(dt.Rows[i][Document.columns.parentRef.ToString()]);*/
            return document;
        }
        protected override string updateQuery(object o, string where)
        {
            List<Document> results = new List<Document>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((Document)o).documentID));
            foreach (Document lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(Document.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(Document.primaryKey.documentID.ToString(), lk.documentID)));
            }
            return "";
        }
        public Document findbyPrimaryKey(int documentID)
        {
            string sql = "select * From " + TABLENAME + "where documentID = " + documentID;
            return (Document)processSingleResult(sql);
        }

        public Document readybyDocumentName(string documentName)
        {
            string sql = string.Format("select * From " + TABLENAME + "where documentName = '{0}'", documentName);
            return (Document)processSingleResult(sql);
        }

        public Document readybyParentref(string OrderNo)
        {
            string sql = string.Format("select * From " + TABLENAME + "where parentRef = '{0}'", OrderNo) ;
            return (Document)processSingleResult(sql);
        }

        public List<Document> readAll()
        {
            string sql = "select * From " + TABLENAME;
            return wrap(processResults(sql));
        }
        private List<Document> languageLookup()
        {
            string READBYLOOKUP = "select * from " + TABLENAME + " where name ='" + LookupsConstant.LKUserLang + "' order by name";
            return wrap(processResults(READBYLOOKUP));
        }
        private List<Document> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<Document> wrap(List<IDomain> result)
        {
            List<Document> list = new List<Document>();
            foreach (IDomain domain in result)
                list.Add((Document)domain);
            return list;
        }
    }
}
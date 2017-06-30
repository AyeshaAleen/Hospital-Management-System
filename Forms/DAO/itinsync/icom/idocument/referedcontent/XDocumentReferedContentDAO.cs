using System;
using System.Collections.Generic;
using System.Data;
using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.idocument.referedcontent;
using Domains.itinsync.interfaces.domain;
using Utils.itinsync.icom;
using Utils.itinsync.icom.exceptions;

namespace DAO.itinsync.icom.idocument.section
{
    public class XDocumentReferedContentDAO : CRUDBase
    {


        string TABLENAME = " xdocumentreferedcontent";

        public static XDocumentReferedContentDAO getInstance(DBContext dbContext)
        {
            XDocumentReferedContentDAO obj = new XDocumentReferedContentDAO();
            obj.init(dbContext);
            return obj;
        }

        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(XDocumentReferedContent.columns));
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            XDocumentReferedContent content = new XDocumentReferedContent();
            content.referedContentID = Convert.ToInt32(dt.Rows[i][XDocumentReferedContent.primaryKey.referedContentID.ToString()]);

            setPropertiesValue(content, dt, i, typeof(XDocumentReferedContent.columns));

            return content;
        }
     
        protected override string updateQuery(object o, string where)
        {
            List<XDocumentReferedContent> results = new List<XDocumentReferedContent>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((XDocumentReferedContent)o).referedContentID));
            foreach (XDocumentReferedContent lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(XDocumentReferedContent.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(XDocumentReferedContent.primaryKey.referedContentID.ToString(), lk.referedContentID)));
            }
            return "";
        }
        private List<XDocumentReferedContent> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        public XDocumentReferedContent findbyPrimaryKey(Int32 referedContentID)
        {
           
            string sql = "select * From " + TABLENAME + " where referedContentID = " + referedContentID;
            return (XDocumentReferedContent)processSingleResult(sql);
        }

        private List<XDocumentReferedContent> wrap(List<IDomain> result)
        {
            List<XDocumentReferedContent> list = new List<XDocumentReferedContent>();
            foreach (IDomain domain in result)
                list.Add((XDocumentReferedContent)domain);
            return list;
        }

     
        public bool DeleteByID(Int32 referedContentID)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where referedContentID = {0}", referedContentID);
            return delete(delSQL);
        }

        public List<XDocumentReferedContent> readbyFieldID(string fieldID)
        {
            string sql = string.Format("select * From " + TABLENAME + " where controlID = '{0}'",  fieldID);
            return wrap(processResults(sql));
        }

        public List<XDocumentReferedContent> readbyDefinitionID(Int32 documentDefinitionID)
        {
            string sql = string.Format("select * From " + TABLENAME + " where documentdefinitionID = '{0}'", documentDefinitionID);
            return wrap(processResults(sql));
        }

        public XDocumentReferedContent readbyDocumentContentID(Int32 fieldID)
        {
            string sql = string.Format("select * From " + TABLENAME + " where documentcontentID = '{0}'", fieldID);
            if (processSingleResult(sql) != null)
                return (XDocumentReferedContent)processSingleResult(sql);
            else
                return null;
        }


        public bool deleteByID(Int32 ID)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where referedContentID = {0}", ID);
            return delete(delSQL);
        }


    }
}

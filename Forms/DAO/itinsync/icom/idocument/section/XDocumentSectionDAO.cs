using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.idocument.section;
using Domains.itinsync.interfaces.domain;
using Utils.itinsync.icom.exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.itinsync.icom.document.documentdefinitionview;
using Utils.itinsync.icom.cache.global;
using Domains.itinsync.icom.idocument.definition;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom;
using Utils.itinsync.icom.cache.document;

namespace DAO.itinsync.icom.idocument.section
{
    public class XDocumentSectionDAO : CRUDBase
    {


        string TABLENAME = " xdocumentsection ";

        public static XDocumentSectionDAO getInstance(DBContext dbContext)
        {
            XDocumentSectionDAO obj = new XDocumentSectionDAO();
            obj.init(dbContext);
            return obj;
        }

        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(XDocumentSection.columns));
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            XDocumentSection content = new XDocumentSection();
            content.documentsectionid = Convert.ToInt32(dt.Rows[i][XDocumentSection.primaryKey.documentsectionid.ToString()]);

            setPropertiesValue(content, dt, i, typeof(XDocumentSection.columns));

            return content;
        }
        public List<XDocumentSection> readyByDocumentDefinitionID(Int64 documentDefinitionID)
        {
            if(DocumentManager.getDocumentSections(documentDefinitionID) !=null ) 
                return DocumentManager.getDocumentSections(documentDefinitionID);

            //if (GlobalStaticCache.documentDefinition.Count == 0)
            //{
            //    new DocumentContentViewDAO().load();
            //    return GlobalStaticCache.documentDefinition[documentDefinitionID.ToString()].tolist();
            //}


            //else
            //{
            //    return GlobalStaticCache.documentDefinition[documentDefinitionID.ToString()].tolist();
            //}

            string sql = "select * From " + TABLENAME + " where documentdefinitionid=" + documentDefinitionID;
            return wrap(processResults(sql));
        }
        protected override string updateQuery(object o, string where)
        {
            List<XDocumentSection> results = new List<XDocumentSection>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((XDocumentSection)o).documentsectionid));
            foreach (XDocumentSection lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(XDocumentSection.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(XDocumentSection.primaryKey.documentsectionid.ToString(), lk.documentsectionid)));
            }
            return "";
        }
        private List<XDocumentSection> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        public XDocumentSection findbyPrimaryKey(Int32 xDocumentSectionID)
        {
            if (DocumentManager.getDocumentSection(xDocumentSectionID) != null)
                return DocumentManager.getDocumentSection(xDocumentSectionID);

            string sql = "select * From " + TABLENAME + " where xDocumentSectionID = " + xDocumentSectionID;
            return (XDocumentSection)processSingleResult(sql);
        }

        private List<XDocumentSection> wrap(List<IDomain> result)
        {
            List<XDocumentSection> list = new List<XDocumentSection>();
            foreach (IDomain domain in result)
                list.Add((XDocumentSection)domain);
            return list;
        }

        public int LastFlowID(Int32 DefinationId)
        {
            string sql = "select max(flow) From " + TABLENAME + " where documentdefinitionid = "+ DefinationId;
            return MaxValue(sql);
            //return (XDocumentSection)processSingleResult(sql);
        }

        public bool DeleteByID(Int32 SectionId)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where documentsectionid = {0}", SectionId);
            return delete(delSQL);
        }
    }
}

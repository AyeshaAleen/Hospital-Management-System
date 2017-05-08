using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom.cache.global;
using DAO.itinsync.icom.document.documentdefinitionview;

namespace DAO.itinsync.icom.idocument.definition
{
    public class XDocumentDefinationDAO : CRUDBase
    {
        string TABLENAME = " xdocumentdefinition ";
        public static XDocumentDefinationDAO getInstance(DBContext dbContext)
        {
            XDocumentDefinationDAO obj = new XDocumentDefinationDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(XDocumentDefination.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            XDocumentDefination document = new XDocumentDefination();
            document.xDocumentDefinationID = Convert.ToInt32(dt.Rows[i][XDocumentDefination.primaryKey.xDocumentDefinationID.ToString()]);
           
            setPropertiesValue(document, dt, i, typeof(XDocumentDefination.columns));

            return document;
        }
        protected override string updateQuery(object o, string where)
        {
            List<XDocumentDefination> results = new List<XDocumentDefination>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((XDocumentDefination)o).xDocumentDefinationID));
            foreach (XDocumentDefination lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(XDocumentDefination.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(XDocumentDefination.primaryKey.xDocumentDefinationID.ToString(), lk.xDocumentDefinationID)));
            }
            return "";
        }
        public XDocumentDefination findbyPrimaryKey(int xDocumentDefinationID)
        {
            if (GlobalStaticCache.documentDefinition.Count == 0)
            {
                new DocumentContentViewDAO().load();
                return (XDocumentDefination)GlobalStaticCache.documentDefinition[xDocumentDefinationID.ToString()];
            }


            else
            {
                return (XDocumentDefination)GlobalStaticCache.documentDefinition[xDocumentDefinationID.ToString()];
            }


            //string sql = "select * From " + TABLENAME + "where xDocumentDefinationID = " + xDocumentDefinationID;
            //return (XDocumentDefination)processSingleResult(sql);
        }
        public XDocumentDefination findbyDocumentName(string DocumentName)
        {
            string sql = string.Format("select * From " + TABLENAME + "where name ='{0}'", DocumentName);
            return (XDocumentDefination)processSingleResult(sql);
        }

        public List<XDocumentDefination> readAll()
        {
            string sql = "select * From " + TABLENAME;
            return wrap(processResults(sql));
        }
        private List<XDocumentDefination> languageLookup()
        {
            string READBYLOOKUP = "select * from " + TABLENAME + " where name ='" + LookupsConstant.LKUserLang + "' order by name";
            return wrap(processResults(READBYLOOKUP));
        }
        private List<XDocumentDefination> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<XDocumentDefination> wrap(List<IDomain> result)
        {
            List<XDocumentDefination> list = new List<XDocumentDefination>();
            foreach (IDomain domain in result)
                list.Add((XDocumentDefination)domain);
            return list;
        }

        public List<XDocumentDefination> readyAll()
        {
            string READ = string.Format("Select * from " + TABLENAME);
            return wrap(processResults(READ));
        }

        public void load()
        {
            if (GlobalStaticCache.documentDefinition.Count == 0)
            {
                List<XDocumentDefination> documentlist = readyAll();
                foreach (XDocumentDefination td in documentlist)
                {
                    GlobalStaticCache.documentDefinition.Add(td.name,td);
                }
            }
        }
    }
}

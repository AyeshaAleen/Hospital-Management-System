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
using Domains.itinsync.icom.idocument.section;
using DAO.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table.tr;
using DAO.itinsync.icom.idocument.table.tr;
using DAO.itinsync.icom.idocument.table.td;
using DAO.itinsync.icom.idocument.table.content;
using Domains.itinsync.icom.idocument.table.td;
using Domains.itinsync.icom.idocument.table.content;
using DAO.itinsync.icom.idocument.table.calculation;
using Domains.itinsync.icom.idocument.table.calculation;
using DAO.itinsync.icom.idocument.section;
using System.Collections;
using Utils.itinsync.icom.cache.lookup;
using Domains.itinsync.icom.idocument.page;

namespace DAO.itinsync.icom.idocument.page
{
    public class pagenameDAO : CRUDBase
    {
        string TABLENAME = " pagename ";
        public static pagenameDAO getInstance(DBContext dbContext)
        {
            pagenameDAO obj = new pagenameDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(pagename.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            pagename pagename = new pagename();
            pagename.pageID = Convert.ToInt32(dt.Rows[i][pagename.primaryKey.pageID.ToString()]);
           
            setPropertiesValue(pagename, dt, i, typeof(pagename.columns));

            return pagename;
        }
        protected override string updateQuery(object o, string where)
        {
            List<pagename> results = new List<pagename>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((pagename)o).pageID));
            foreach (pagename lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(pagename.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(pagename.primaryKey.pageID.ToString(), lk.pageID)));
            }
            return "";
        }
        public pagename findbyPrimaryKey(Int32 pageID)
        {
            if (DocumentManager.getpageName(pageID) != null)
                return DocumentManager.getpageName(pageID);

            string sql = "select * From " + TABLENAME + " where pageID = " + pageID;
            return (pagename)processSingleResult(sql);
        }
        //public XDocumentDefination findbyDocumentName(string DocumentName)
        //{

        //    foreach (Int32 entry in GlobalStaticCache.documentDefinition.Keys)
        //    {
        //        XDocumentDefination documentDefinition= GlobalStaticCache.documentDefinition[entry];

        //        if (documentDefinition.name == DocumentName)
        //            return documentDefinition;
        //    }

        //    // if not found them reload complete definitions
        //    load();

        //    string sql = string.Format("select * From " + TABLENAME + "where name ='{0}'", DocumentName);
        //    return (pagename)processSingleResult(sql);
        //}

        public List<pagename> readAll()
        {
            string sql = "select * From " + TABLENAME;
            return wrap(processResults(sql));
        }
       
        private List<pagename> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<pagename> wrap(List<IDomain> result)
        {
            List<pagename> list = new List<pagename>();
            foreach (IDomain domain in result)
                list.Add((pagename)domain);
            return list;
        }
    }
}

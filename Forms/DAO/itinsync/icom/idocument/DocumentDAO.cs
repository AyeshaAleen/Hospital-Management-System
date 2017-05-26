using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.idocument;
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
using Domains.itinsync.icom.document;

namespace DAO.itinsync.icom.idocument
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
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(Douments.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            Douments document = new Douments();
            document.documentID = Convert.ToInt32(dt.Rows[i][Douments.primaryKey.documentID.ToString()]);

            setPropertiesValue(document, dt, i, typeof(Douments.columns));

           
            return document;
        }
        protected override string updateQuery(object o, string where)
        {
            List<Douments> results = new List<Douments>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((Douments)o).documentID));
            foreach (Douments lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(Douments.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(Douments.primaryKey.documentID.ToString(), lk.documentID)));
            }
            return "";
        }
        public Douments findbyPrimaryKey(int documentID)
        {
            string sql = "select * From " + TABLENAME + "where documentID = " + documentID;
            return (Douments)processSingleResult(sql);
        }
        public Douments readybyDocumentDefinitionID(Int32 documentDefinitionID,Int32 storeid)
        {



            string sql = string.Format("select * From " + TABLENAME + "where documentDefinitionID = {0} and storeid={1}", documentDefinitionID, storeid);
            return (Douments)processSingleResult(sql);
        }

        public Douments readybyDocumentName(string documentName)
        {



            string sql = string.Format("select * From " + TABLENAME + "where documentName = '{0}'", documentName);
            return (Douments)processSingleResult(sql);
        }

        public Douments readybyParentref(string OrderNo)
        {
            string sql = string.Format("select * From " + TABLENAME + "where parentRef = '{0}'", OrderNo);
            return (Douments)processSingleResult(sql);
        }

        public List<Douments> readAll()
        {
            string sql = "select * From " + TABLENAME;
            return wrap(processResults(sql));
        }
        
        private List<Douments> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<Douments> wrap(List<IDomain> result)
        {
            List<Douments> list = new List<Douments>();
            foreach (IDomain domain in result)
                list.Add((Douments)domain);
            return list;
        }
    }
}

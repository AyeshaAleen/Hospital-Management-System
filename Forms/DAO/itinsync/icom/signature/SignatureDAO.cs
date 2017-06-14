using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.signature;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Utils.itinsync.icom;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom.cache.document;

namespace DAO.itinsync.icom.signature
{
    public class SignatureDAO : CRUDBase
    {
        string TABLENAME = " signature ";
        public static SignatureDAO getInstance(DBContext dbContext)
        {
            SignatureDAO obj = new SignatureDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(Signature.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            Signature roleRoute = new Signature();
            roleRoute.id = Convert.ToInt32(dt.Rows[i][Signature.primaryKey.id.ToString()]);

            setPropertiesValue(roleRoute, dt, i, typeof(Signature.columns));

            return roleRoute;
        }
        protected override string updateQuery(object o, string where)
        {
            List<Signature> results = new List<Signature>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((Signature)o).id));
            foreach (Signature lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(Signature.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(Signature.primaryKey.id.ToString(), lk.id)));
            }
            return "";
        }
        public Signature findbyPrimaryKey(Int32 id)
        {
            //if (DocumentManager.getDocumentRoute(id) != null)
            //    return DocumentManager.getDocumentRoute(id);

            string sql = "select * From " + TABLENAME + " where id = " + id;
            return (Signature)processSingleResult(sql);
        }
        public List<Signature> findbyDocumentid(Int32 id)
        {
            string sql = "select * From " + TABLENAME + " where documentid = " + id;
            return wrap(processResults(sql));
        }
        public List<Signature> readAll()
        {
            string sql = "select * From " + TABLENAME;
            return wrap(processResults(sql));
        }

        private List<Signature> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<Signature> wrap(List<IDomain> result)
        {
            List<Signature> list = new List<Signature>();
            foreach (IDomain domain in result)
                list.Add((Signature)domain);
            return list;
        }

        public bool deleteByID(Int32 ID)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where id = {0}", ID);
            return delete(delSQL);
        }
    }
}

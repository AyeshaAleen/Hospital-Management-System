using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.icom.lookup.trans;
using Domains.itinsync.interfaces.domain;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Utils.itinsync.icom;
using Utils.itinsync.icom.exceptions;

namespace DAO.itinsync.icom.lookup.trans
{
    public class LookupTransDAO : CRUDBase
    {
        readonly string TABLENAME = " lookuptrans ";

        public static LookupTransDAO getInstance(DBContext dbContext)
        {
            LookupTransDAO obj = new LookupTransDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(LookupTrans.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            LookupTrans lookupTrans = new LookupTrans();
            lookupTrans.lookupTransID = Convert.ToInt32(dt.Rows[i][LookupTrans.primaryKey.lookupTransID.ToString()]);

            setPropertiesValue(lookupTrans, dt, i, typeof(LookupTrans.columns));

            return lookupTrans;
        }
        protected override string updateQuery(object o, string where)
        {
            List<LookupTrans> results = new List<LookupTrans>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((LookupTrans)o).lookupTransID));
            foreach (LookupTrans lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(LookupTrans.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(LookupTrans.primaryKey.lookupTransID.ToString(), lk.lookupTransID)));
            }
            return "";
        }

        private List<LookupTrans> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        public LookupTrans findbyPrimaryKey(Int32 id)
        {
            string sql = "select * From " + TABLENAME + " where lookupTransID = " + id;
            return (LookupTrans)processSingleResult(sql);
        }
        private List<LookupTrans> wrap(List<IDomain> result)
        {
            List<LookupTrans> list = new List<LookupTrans>();
            foreach (IDomain domain in result)
                list.Add((LookupTrans)domain);
            return list;
        }
        public List<LookupTrans> GetLookupTrans()
        {
            string READ = string.Format("Select * from " + TABLENAME );
            return wrap(processResults(READ));
        }
        public bool deleteByID(Int32 ID)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where lookupTransID = {0}", ID);
            return delete(delSQL);
        }
    }
}

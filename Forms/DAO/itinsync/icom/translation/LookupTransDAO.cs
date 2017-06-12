using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.lookup.lookuptrans;

namespace DAO.itinsync.icom.lookuptrans
{
    public class LookupTransDAO : CRUDBase
    {
        private string TABLENAME = " lookuptrans ";
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
            LookupTrans lookuptran = new LookupTrans();
            lookuptran.lookupTransID = Convert.ToInt32(dt.Rows[i][LookupTrans.primaryKey.lookupTransID.ToString()]);
            lookuptran.code = Convert.ToString(dt.Rows[i][LookupTrans.columns.code.ToString()]);
            lookuptran.value = Convert.ToString(dt.Rows[i][LookupTrans.columns.value.ToString()]);
            lookuptran.lang = Convert.ToString(dt.Rows[i][LookupTrans.columns.lang.ToString()]);
            return lookuptran;
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
        public LookupTrans findbyPrimaryKey(int lookupTransID)
        {
            string sql = "select * From " + TABLENAME + "where lookupTransID = " + lookupTransID;
            return (LookupTrans)processSingleResult(sql);
        }

        public bool translationExists(string trans,string lang)
        {
            string sql = string.Format("select count(*) as count From " + TABLENAME + "where value = '{0}' and lang='{1}'" , trans.Trim() ,lang);
            return executeCount(sql) > 0;
            
        }
        public LookupTrans findbyTranslcation(string value,string lang)
        {
            string sql = string.Format("select * From " + TABLENAME + "where value = '{0}' and lang='{1}'", value.Trim(), lang);
            return (LookupTrans)processSingleResult(sql);
        }
        public List<LookupTrans> readAll()
        {
            string sql = "select * From " + TABLENAME;
            return wrap(processResults(sql));
        }
      
        private List<LookupTrans> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<LookupTrans> wrap(List<IDomain> result)
        {
            List<LookupTrans> list = new List<LookupTrans>();
            foreach (IDomain domain in result)
                list.Add((LookupTrans)domain);
            return list;
        }


        public bool deleteBytrans(string trans)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where code = '{0}'", trans);
            return delete(delSQL);
        }
    }
}
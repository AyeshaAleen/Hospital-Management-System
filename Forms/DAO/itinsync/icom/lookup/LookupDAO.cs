using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using Domains.itinsync.interfaces.domain;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.lookup;
using Utils.itinsync.icom.constant.lookup;
using System.Collections;
using Utils.itinsync.icom.cache.global;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom;

namespace DAO.itinsync.icom.lookup
{
    public class LookUpDAO : CRUDBase
    {
        readonly string TABLENAME = " lookup ";
        public static LookUpDAO getInstance(DBContext dbContext)
        {
            LookUpDAO obj = new LookUpDAO();
            obj.init(dbContext);
            return obj;
        }

        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(LookUp.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            LookUp lookup = new LookUp();
            lookup.lookUpID = Convert.ToInt32(dt.Rows[i][LookUp.primaryKey.lookUpID.ToString()]);

            setPropertiesValue(lookup, dt, i, typeof(LookUp.columns));

            return lookup;
        }
        protected override string updateQuery(object o, string where)
        {
            List<LookUp> results = new List<LookUp>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((LookUp)o).lookUpID));
            foreach (LookUp lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(LookUp.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(LookUp.primaryKey.lookUpID.ToString(), lk.lookUpID)));
            }
            return "";
        }
        private List<LookUp> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        public LookUp findbyPrimaryKey(Int32 id)
        {
            string sql = "select * From " + TABLENAME + " where lookUpID = " + id;
            return (LookUp)processSingleResult(sql);
        }
        private List<LookUp> wrap(List<IDomain> result)
        {
            List<LookUp> list = new List<LookUp>();
            foreach (IDomain domain in result)
                list.Add((LookUp)domain);
            return list;
        }
        public List<LookUp> GetLookup()
        {
            string READ = string.Format("Select * from " + TABLENAME);
            return wrap(processResults(READ));
        }
        public bool deleteByID(Int32 ID)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where lookUpID = {0}", ID);
            return delete(delSQL);
        }
        private List<LookUp> languageLookUp()
        {
            List<LookUp> lkList = new List<LookUp>();
            DataTable dt = FillDataTable("select * from " + TABLENAME + " where name ='" + LookupsConstant.LKUserLang + "' order by name");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LookUp lk = new LookUp();
                lk.text = Convert.ToString(dt.Rows[i][LookUp.columns.text.ToString()]);
                lk.code = Convert.ToString(dt.Rows[i][LookUp.columns.code.ToString()]);
                lkList.Add(lk);
            }
            return lkList;
        }
        public void load()
        {            
            List<LookUp> lkList = languageLookUp();
            foreach (LookUp lk in lkList)
            {
                Dictionary<string, Hashtable> cacheMap = new Dictionary<string, Hashtable>();
                DataTable dt = FillDataTable("select * from " + TABLENAME + " order by name");
                string currentLookUpName = "";
                Hashtable hashtable = new Hashtable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)
                        currentLookUpName = Convert.ToString(dt.Rows[i][LookUp.columns.name.ToString()]);
                    if (currentLookUpName == Convert.ToString(dt.Rows[i][LookUp.columns.name.ToString()]))
                    {
                        hashtable[Convert.ToString(dt.Rows[i][LookUp.columns.code.ToString()])] = Convert.ToString(dt.Rows[i][lk.code == "en" ? "text" : lk.code]);
                    }
                    else if (currentLookUpName != Convert.ToString(dt.Rows[i][LookUp.columns.name.ToString()]))
                    {
                        cacheMap.Add(currentLookUpName, hashtable);
                        hashtable = new Hashtable();
                        currentLookUpName = Convert.ToString(dt.Rows[i][LookUp.columns.name.ToString()]);
                        hashtable[Convert.ToString(dt.Rows[i][LookUp.columns.code.ToString()])] = Convert.ToString(dt.Rows[i][lk.code == "en" ? "text" : lk.code]);
                    }
                }
                cacheMap.Add(currentLookUpName, hashtable);
                GlobalStaticCache.LKcacheMap.Add(lk.code, cacheMap);
            }
        }
    }
}
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
            throw new NotImplementedException();
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            throw new NotImplementedException();
        }
        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
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
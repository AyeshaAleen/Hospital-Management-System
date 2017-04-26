using System;
using System.Data;
using DAO.itinsync.icom.BaseAS.CRUDBase;
using Domains.itinsync.interfaces.domain;
using DAO.itinsync.icom.BaseAS.dbcontext;
using System.Collections.Generic;
using Utils.itinsync.icom;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.exceptions;
using System.Reflection;

namespace DAO.itinsync.icom.useraccounts
{
    class UserVecationDAO : CRUDBase
    {
        string TABLENAME = " uservecation ";
        public static UserVecationDAO getInstance(DBContext dbContext)
        {
            UserVecationDAO obj = new UserVecationDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(UserVecation.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            UserVecation uservecation = new UserVecation();
            uservecation.vecationID = Convert.ToInt32(dt.Rows[i][UserVecation.primaryKey.vecationID.ToString()]);

            setPropertiesValue(uservecation, dt, i, typeof(UserVecation.columns));

            /*uservecation.userName = Convert.ToString(dt.Rows[i][UserVecation.columns.userName.ToString()]);
            uservecation.startDate = Convert.ToString(dt.Rows[i][UserVecation.columns.startDate.ToString()]);
            uservecation.endDate = Convert.ToString(dt.Rows[i][UserVecation.columns.endDate.ToString()]);
            uservecation.timeZone = Convert.ToString(dt.Rows[i][UserVecation.columns.timeZone.ToString()]);
            uservecation.reasonCode = Convert.ToInt32(dt.Rows[i][UserVecation.columns.reasonCode.ToString()]);
            uservecation.vecationCode = Convert.ToInt32(dt.Rows[i][UserVecation.columns.vecationCode.ToString()]);*/
            return uservecation;
        }
        protected override string updateQuery(object o, string where)
        {
            List<UserVecation> results = new List<UserVecation>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((UserVecation)o).vecationID));
            foreach (UserVecation lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(UserVecation.columns));
                if (whereClause.Contains("="))
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(UserVecation.primaryKey.vecationID.ToString(), lk.vecationID)));
            }
            return "";
        }
        public UserVecation findbyPrimaryKey(int vecationID)
        {
            string sql = "select * From " + TABLENAME + "where id = " + vecationID;
            return (UserVecation)processSingleResult(sql);
        }
        public List<UserVecation> readAll()
        {
            string sql = "select * From " + TABLENAME;
            return wrap(processResults(sql));
        }
        private List<UserVecation> languageLookup()
        {
            string READBYLOOKUP = "select * from " + TABLENAME + " where name ='" + LookupsConstant.LKUserLang + "' order by name";
            return wrap(processResults(READBYLOOKUP));
        }
        private List<UserVecation> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<UserVecation> wrap(List<IDomain> result)
        {
            List<UserVecation> list = new List<UserVecation>();
            foreach (IDomain domain in result)
                list.Add((UserVecation)domain);
            return list;
        }        
    }
}
using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.interfaces.domain;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom;
using domains.itinsync.audit;
using Domains.itinsync.useraccounts;
using System.Reflection;

namespace DAO.itinsync.icom.userregion
{
    public class UserRegionDAO : CRUDBase
    {
        string TABLENAME = " userregion ";
        public static UserRegionDAO getInstance(DBContext dbContext)
        {
            UserRegionDAO obj = new UserRegionDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(Audit.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            UserRegion userregion = new UserRegion();
            userregion.userRegionID = Convert.ToInt32(dt.Rows[i][UserRegion.primaryKey.userRegionID.ToString()]);

            setPropertiesValue(userregion, dt, i, typeof(UserRegion.columns));

            /*userregion.code = Convert.ToString(dt.Rows[i][UserRegion.columns.code.ToString()]);
            userregion.userID = Convert.ToInt32(dt.Rows[i][UserRegion.columns.userID.ToString()]);*/
            return userregion;
        }
        protected override string updateQuery(object o, string where)
        {
            List<UserRegion> results = new List<UserRegion>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((UserRegion)o).userRegionID));
            foreach (UserRegion lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(UserRegion.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(UserRegion.primaryKey.userRegionID.ToString(), lk.userRegionID)));
            }
            return "";
        }
        public UserRegion findbyPrimaryKey(int userRegionID)
        {
            return (UserRegion)processSingleResult("select * From " + TABLENAME + "where id = " + userRegionID);
        }
        public List<UserRegion> readAll()
        {
            return wrap(processResults("select * From " + TABLENAME));
        }
        private List<UserRegion> languageLookup()
        {
            string READBYLOOKUP = "select * from " + TABLENAME + " where name ='" + LookupsConstant.LKUserLang + "' order by name";
            return wrap(processResults(READBYLOOKUP));
        }
        private List<UserRegion> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            return wrap(processResults(string.Format("Select * from " + TABLENAME + where)));
        }
        private List<UserRegion> wrap(List<IDomain> result)
        {
            List<UserRegion> list = new List<UserRegion>();
            foreach (IDomain domain in result)
                list.Add((UserRegion)domain);
            return list;
        }
        public List<UserRegion> readByUserID(Int32 userID)
        {
            return wrap(processResults(string.Format("Select * from " + TABLENAME + " where userid = '{0}'", userID)));
        }
    }
}
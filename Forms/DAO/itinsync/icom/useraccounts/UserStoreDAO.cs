using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.interfaces.domain;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.useraccounts;
using Utils.itinsync.icom;
using Utils.itinsync.icom.exceptions;
using Domains.itinsync.useraccounts;

namespace DAO.itinsync.icom.useraccounts
{
    public class UserStoreDAO : CRUDBase
    {

        string TABLENAME = " userstore ";
        public static UserStoreDAO getInstance(DBContext dbContext)
        {
            UserStoreDAO obj = new UserStoreDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(UserStore.columns));
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            UserStore userstore = new UserStore();
            userstore .userstoreid= Convert.ToInt32(dt.Rows[i][UserStore.primaryKey.userstoreid.ToString()]);

            setPropertiesValue(userstore, dt, i, typeof(UserStore.columns));

            return userstore;
        }

        protected override string updateQuery(object o, string where)
        {
            List<UserStore> results = new List<UserStore>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((UserStore)o).userstoreid));
            foreach (UserStore lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(UserStore.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(UserStore.primaryKey.userstoreid.ToString(), lk.userstoreid)));
            }
            return "";
        }
        private List<UserStore> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        public UserStore findbyPrimaryKey(int userstoreid)
        {
            string sql = "select * From " + TABLENAME + "where userstoreid = " + userstoreid;
            return (UserStore)processSingleResult(sql);
        }


        private List<UserStore> wrap(List<IDomain> result)
        {
            List<UserStore> list = new List<UserStore>();
            foreach (IDomain domain in result)
                list.Add((UserStore)domain);
            return list;
        }

        public bool deleteByID(Int32 userStoreID)
        {
            UserStore us = new UserStore();
            string delSQL = string.Format("delete from " + TABLENAME + " where userstoreid = '{0}'", userStoreID);
            return delete(delSQL);
        }

        public bool storeExists(Int32 storeid, Int32 userID)
        {
            if (executeCount(string.Format("select count(*) as count from " + TABLENAME + " where storeid = '{0}' and userid = '{1}'", storeid, userID)) > 0)
                return true;
            else
                return false;
        }
    }
}

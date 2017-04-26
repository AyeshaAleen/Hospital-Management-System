using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.interfaces.domain;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom;
using Domains.itinsync.icom.useraccounts;
using System.Reflection;

namespace DAO.itinsync.icom.userrole
{
    public class UserRoleDAO : CRUDBase
    {
        string TABLENAME = " userrole ";
        public static UserRoleDAO getInstance(DBContext dbContext)
        {
            UserRoleDAO obj = new UserRoleDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(UserRole.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            UserRole userRole = new UserRole();
            userRole.userRoleID = Convert.ToInt32(dt.Rows[i][UserRole.primaryKey.userRoleID.ToString()]);

            setPropertiesValue(userRole, dt, i, typeof(UserRole.columns));

            /*audit.userID = Convert.ToInt32(dt.Rows[i][UserRole.columns.userID.ToString()]);
            audit.roleID = Convert.ToInt32(dt.Rows[i][UserRole.columns.roleID.ToString()]);*/
            return userRole;
        }
        protected override string updateQuery(object o, string where)
        {
            List<UserRole> results = new List<UserRole>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((UserRole)o).userRoleID));
            foreach (UserRole lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(UserRole.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(UserRole.primaryKey.userRoleID.ToString(), lk.userRoleID)));
            }
            return "";
        }
        public UserRole findbyPrimaryKey(int userRoleID)
        {
            string sql = "select * From " + TABLENAME + "where id = " + userRoleID;
            return (UserRole)processSingleResult(sql);
        }
        public List<UserRole> readAll()
        {
            string sql = "select * From " + TABLENAME;
            return wrap(processResults(sql));
        }
        private List<UserRole> languageLookup()
        {
            string READBYLOOKUP = "select * from " + TABLENAME + " where name ='" + LookupsConstant.LKUserLang + "' order by name";
            return wrap(processResults(READBYLOOKUP));
        }
        private List<UserRole> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<UserRole> wrap(List<IDomain> result)
        {
            List<UserRole> list = new List<UserRole>();
            foreach (IDomain domain in result)
                list.Add((UserRole)domain);
            return list;
        }
        public List<UserRole> readByUserID(Int32 userID)
        {
            return wrap(processResults(string.Format("Select * from " + TABLENAME + " where userid = '{0}'", userID)));
        }
    }
}
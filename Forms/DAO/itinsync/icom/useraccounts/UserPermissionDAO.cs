using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.interfaces.domain;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom;
using Domains.itinsync.icom.useraccounts;
using System.Reflection;

namespace DAO.itinsync.icom.useraccounts
{
    public class UserPermissionDAO : CRUDBase
    {
        string TABLENAME = " userpermission ";
        public static UserPermissionDAO getInstance(DBContext dbContext)
        {
            UserPermissionDAO obj = new UserPermissionDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(UserPermission.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            UserPermission useraccounts = new UserPermission();
            useraccounts.userPermissionID = Convert.ToInt32(dt.Rows[i][UserPermission.primaryKey.userPermissionID.ToString()]);

            setPropertiesValue(useraccounts, dt, i, typeof(UserPermission.columns));

            /*useraccounts.userID = Convert.ToInt32(dt.Rows[i][UserPermission.columns.userID.ToString()]);
            useraccounts.code = Convert.ToInt32(dt.Rows[i][UserPermission.columns.code.ToString()]);*/
            return useraccounts;
        }
        protected override string updateQuery(object o, string where)
        {
            List<UserPermission> results = new List<UserPermission>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((UserPermission)o).userPermissionID));
            foreach (UserPermission lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(UserPermission.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(UserPermission.primaryKey.userPermissionID.ToString(), lk.userPermissionID)));
            }
            return "";
        }
        public UserPermission findbyPrimaryKey(int userPermissionID)
        {
            return (UserPermission)processSingleResult("select * From " + TABLENAME + "where id = " + userPermissionID);
        }
        public List<UserPermission> readAll()
        {
            return wrap(processResults("select * From " + TABLENAME));
        }
        public bool deleteByID(Int32 userPermissionID)
        {
            UserPermission up = new UserPermission();
            string delSQL = string.Format("delete from " + TABLENAME + " where userPermissionID = '{0}'", userPermissionID);
            return delete(delSQL);
        }
        private List<UserPermission> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            return wrap(processResults(string.Format("Select * from " + TABLENAME + where)));
        }
        private List<UserPermission> wrap(List<IDomain> result)
        {
            List<UserPermission> list = new List<UserPermission>();
            foreach (IDomain domain in result)
                list.Add((UserPermission)domain);
            return list;
        }
        
        public List<UserPermission> findbyForeignKey(Int32 userID)
        {
            return wrap(processResults("select * From " + TABLENAME + " where userID = " + userID));
        }
        public List<UserPermission> readByUserID(Int32 userID)
        {
            return wrap(processResults(string.Format("Select * from " + TABLENAME + " where userID = '{0}'", userID)));
        }
        public bool permissionExists(Int32 code, Int32 userID )
        {
            if(executeCount(string.Format("select count(*) as count from " + TABLENAME + " where code = '{0}' and userID = '{1}'", code, userID)) > 0)
                 return true;
            else
                return false;
        }
    }
}
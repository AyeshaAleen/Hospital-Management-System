using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Domains.itinsync.icom.views;
using DAO.itinsync.icom.task.taskdefinition;
using Utils.itinsync.icom;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.constant.lookup;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Utils.itinsync.icom.exceptions;

namespace DAO.itinsync.icom.views
{
    public class UserPermissionViewDAO : CRUDBase
    {
        string TABLENAME = " userpermissionview ";
        public static UserPermissionViewDAO getInstance(DBContext dbContext)
        {
            UserPermissionViewDAO obj = new UserPermissionViewDAO();
            obj.init(dbContext);
            return obj;
        }
        public UserPermissionView readByUserName(string username)
        {
            return (UserPermissionView)processSingleResult(string.Format("Select * from " + TABLENAME + " where username = '{0}'", username));
        }

        public List<UserPermissionView> readbyuserID(Int32 userID)
        {
            return wrap(processResults("select * From " + TABLENAME + " where userID = " + userID));
        }

        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(UserPermissionView.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            UserPermissionView userpermissionview = new UserPermissionView();
            userpermissionview.userID = Convert.ToInt32(dt.Rows[i][UserPermissionView.columns.userID.ToString()]);

            setPropertiesValue(userpermissionview, dt, i, typeof(UserPermissionView.columns));

            //set code translation
            //userpermissionview.role_text = LookupManager.readTextByCode(LookupsConstant.LKUserRole, userpermissionview.role, getHeader().lang);
            return userpermissionview;
        }
        protected override string updateQuery(object o, string where)
        {
            List<UserPermissionView> results = new List<UserPermissionView>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findByPrimaryKey(((UserPermissionView)o).userID));
            foreach (UserPermissionView lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(UserPermissionView.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(UserPermissionView.columns.userID.ToString(), lk.userID)));
            }
            return "";
        }
        public UserPermissionView findByPrimaryKey(int userID)
        {
            return (UserPermissionView)processSingleResult("select * From " + TABLENAME + "where userID = " + userID);
        }
        public List<UserPermissionView> readAll()
        {
            return wrap(processResults("select * From " + TABLENAME));
        }        

        private List<UserPermissionView> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            return wrap(processResults(string.Format("Select * from " + TABLENAME + where)));
        }
        private List<UserPermissionView> wrap(List<IDomain> result)
        {
            List<UserPermissionView> list = new List<UserPermissionView>();
            foreach (IDomain domain in result)
                list.Add((UserPermissionView)domain);
            return list;
        }
    }
}
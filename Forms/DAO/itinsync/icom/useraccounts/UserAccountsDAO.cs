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
using Utils.itinsync.icom.cache.lookup;

namespace DAO.itinsync.icom.useraccounts
{
    public class UserAccountsDAO : CRUDBase
    {
        string TABLENAME = " useraccounts ";
        public static UserAccountsDAO getInstance(DBContext dbContext)
        {
            UserAccountsDAO obj = new UserAccountsDAO();
            obj.init(dbContext);
            return obj;
        }
        public UserAccounts readByUserName(string username)
        {            
            return (UserAccounts)processSingleResult(string.Format("Select * from " + TABLENAME + " where username = '{0}'", username));
        }

        public List<UserAccounts> readbyName(string name)
        {
            return wrap(processResults(string.Format("select * From " + TABLENAME + " where firstName like '{0}'", name + "%")));
        }

        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(UserAccounts.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            UserAccounts useraccounts = new UserAccounts();
            useraccounts.userID = Convert.ToInt32(dt.Rows[i][UserAccounts.primaryKey.userID.ToString()]);

            setPropertiesValue(useraccounts, dt, i, typeof(UserAccounts.columns));

            //set code translation
            //useraccounts.role_text = LookupManager.readTextByCode(LookupsConstant.LKUserRole, useraccounts.role, getHeader().lang);
            //useraccounts.lang_Text = LookupManager.readTextByCode(LookupsConstant.LKUserLang, useraccounts.lang, getHeader().lang);
            return useraccounts;
        }
        protected override string updateQuery(object o, string where)
        {
            List<UserAccounts> results = new List<UserAccounts>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findByPrimaryKey(((UserAccounts)o).userID));
            foreach (UserAccounts lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(UserAccounts.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(UserAccounts.primaryKey.userID.ToString(), lk.userID)));
            }
            return "";
        }
        public UserAccounts findByPrimaryKey(int userID)
        {
            return (UserAccounts)processSingleResult("select * From " + TABLENAME + "where userid = " + userID);
        }


        public int updateuserpassword(UserAccounts user)
        {
            string SQL = "update " + TABLENAME + " set password ='" + user.password + "' WHERE userID =" + user.userID;
            return update(SQL);
        }

        public List<UserAccounts> readAll()
        {
            return wrap(processResults("select * From " + TABLENAME));
        }
       
        private List<UserAccounts> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            return wrap(processResults(string.Format("Select * from " + TABLENAME + where)));
        }
        private List<UserAccounts> wrap(List<IDomain> result)
        {
            List<UserAccounts> list = new List<UserAccounts>();
            foreach (IDomain domain in result)
                list.Add((UserAccounts)domain);
            return list;
        }
    }
}
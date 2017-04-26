using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.interfaces.domain;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom;
using domains.itinsync.useraccounts;
using System.Reflection;

namespace DAO.itinsync.icom.userteam
{
    public class UserTeamDAO : CRUDBase
    {
        string TABLENAME = " userteam ";
        public static UserTeamDAO getInstance(DBContext dbContext)
        {
            UserTeamDAO obj = new UserTeamDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(UserTeam.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            UserTeam userteam = new UserTeam();
            userteam.userTeamID = Convert.ToInt32(dt.Rows[i][UserTeam.primaryKey.userTeamID.ToString()]);
            setPropertiesValue(userteam, dt, i, typeof(UserTeam.columns));
            userteam.userID = Convert.ToInt32(dt.Rows[i][UserTeam.columns.userID.ToString()]);
            userteam.teamID = Convert.ToInt32(dt.Rows[i][UserTeam.columns.teamID.ToString()]);
            return userteam;
        }
        protected override string updateQuery(object o, string where)
        {
            List<UserTeam> results = new List<UserTeam>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((UserTeam)o).userTeamID));
            foreach (UserTeam lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(UserTeam.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(UserTeam.primaryKey.userTeamID.ToString(), lk.userTeamID)));
            }
            return "";
        }
        public UserTeam findbyPrimaryKey(int userTeamID)
        {
            string sql = "select * From " + TABLENAME + "where id = " + userTeamID;
            return (UserTeam)processSingleResult(sql);
        }
        public List<UserTeam> readAll()
        {
            string sql = "select * From " + TABLENAME;
            return wrap(processResults(sql));
        }
        public bool deleteByID(Int32 userTeamID)
        {
            UserTeam ut = new UserTeam();
            string delSQL = string.Format("delete from " + TABLENAME + " where userTeamID = '{0}'", userTeamID);
            return delete(delSQL);
        }
        public bool teamExists(Int32 teamID, Int32 userID)
        {
            if (executeCount(string.Format("select count(*) as count from ars.userteam where teamID = '{0}' and userID = '{1}'", teamID, userID)) > 0)
                return true;
            else
                return false;
        }
        private List<UserTeam> languageLookup()
        {
            string READBYLOOKUP = "select * from " + TABLENAME + " where name ='" + LookupsConstant.LKUserLang + "' order by name";
            return wrap(processResults(READBYLOOKUP));
        }
        private List<UserTeam> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<UserTeam> wrap(List<IDomain> result)
        {
            List<UserTeam> list = new List<UserTeam>();
            foreach (IDomain domain in result)
                list.Add((UserTeam)domain);
            return list;
        }
    }
}
using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.interfaces.domain;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom;
using Domains.itinsync.icom.team;
using System.Reflection;

namespace DAO.itinsync.icom.team
{
    public class TeamDAO : CRUDBase
    {
        string TABLENAME = " team ";
        public static TeamDAO getInstance(DBContext dbContext)
        {
            TeamDAO obj = new TeamDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(Team.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            Team team = new Team();
            team.teamID = Convert.ToInt32(dt.Rows[i][Team.primaryKey.teamID.ToString()]);
            setPropertiesValue(team, dt, i, typeof(Team.columns));
            return team;
        }
        protected override string updateQuery(object o, string where)
        {
            List<Team> results = new List<Team>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((Team)o).teamID));
            foreach (Team lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(Team.columns));
                //update on the base of primary key column
                if (whereClause.Contains("="))
                    update(ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(Team.primaryKey.teamID.ToString(), lk.teamID)));
            }
            return "";
        }
        public List<Team> readbyName(string teamName)
        {
            return wrap(processResults(string.Format("select * From " + TABLENAME + " where teamName like '{0}'", teamName + "%")));
        }
        public Team findbyPrimaryKey(Int32 TeamID)
        {
            return (Team)processSingleResult("select * From " + TABLENAME + " where teamID = " + TeamID);
        }
        public List<Team> readAll()
        {
            return wrap(processResults("select * From " + TABLENAME));
        }
        private List<Team> languageLookup()
        {
            return wrap(processResults("select * from " + TABLENAME + " where teamName ='" + LookupsConstant.LKUserLang + "' order by name"));
        }
        private List<Team> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            return wrap(processResults(string.Format("Select * from " + TABLENAME + where)));
        }
        private List<Team> wrap(List<IDomain> result)
        {
            List<Team> list = new List<Team>();
            foreach (IDomain domain in result)
                list.Add((Team)domain);
            return list;
        }
    }
}
using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Data;
using Domains.itinsync.interfaces.domain;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.views.user;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.constant.lookup;

namespace DAO.itinsync.icom.views
{
    public class UserTeamViewDAO : CRUDBase
    {
        String TABLENAME = " userteamview ";
        public static UserTeamViewDAO getInstance()
        {
            return new UserTeamViewDAO();
        }
        public static UserTeamViewDAO getInstance(DBContext dbContext)
        {
            UserTeamViewDAO obj = new UserTeamViewDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            UserTeamView utv = new UserTeamView();

            utv.status = Convert.ToString(dt.Rows[i][UserTeamView.columns.status.ToString()]);
            //utv.statusText = LookupManager.readTextByCode(LookupsConstant.LKTeamStatus, utv.status.ToString());
            utv.teamID = Convert.ToInt32(dt.Rows[i][UserTeamView.columns.teamID.ToString()]);
            utv.teamName = Convert.ToString(dt.Rows[i][UserTeamView.columns.teamName.ToString()]);
            utv.userID = Convert.ToInt32(dt.Rows[i][UserTeamView.columns.userID.ToString()]);
            utv.userTeamID = Convert.ToInt32(dt.Rows[i][UserTeamView.columns.userTeamID.ToString()]);
            return utv;
        }
        public List<UserTeamView> readByUserID(Int32 userID)
        {
            string READSQL = string.Format("Select * from " + TABLENAME + " where userID = '{0}'", userID);
            return wrap(processResults(READSQL));
        }
        private List<UserTeamView> wrap(List<IDomain> result)
        {
            List<UserTeamView> list = new List<UserTeamView>();
            foreach (IDomain domain in result)
                list.Add((UserTeamView)domain);
            return list;
        }
        private List<UserTeamView> readClientsByWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new Utils.itinsync.icom.exceptions.ItinsyncException(new Exception());
           
            string UPDATECLIENTSQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(UPDATECLIENTSQL));
        }
        public List<UserTeamView> readbyuserID(Int32 userID)
        {
            return wrap(processResults("select * From " + TABLENAME + " where userID = " + userID));
        }
        protected override string createQuery(object o)
        {
            throw new NotImplementedException();
        }
        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }
    }
}
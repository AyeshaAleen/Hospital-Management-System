using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.interfaces.domain;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.views.user;

namespace DAO.itinsync.icom.views.user
{
    public class UserStoreViewDAO2 : CRUDBase
    {

        string TABLENAME = " userstoreview ";
        public static UserStoreViewDAO2 getInstance(DBContext dbContext)
        {
            UserStoreViewDAO2 obj = new UserStoreViewDAO2();
            obj.init(dbContext);
            return obj;
        }

        protected override string createQuery(object o)
        {
            throw new NotImplementedException();
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            UserStoreView2 userstore = new UserStoreView2();
          

            setPropertiesValue(userstore, dt, i, typeof(UserStoreView2.columns));

            return userstore;
        }

        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }


        public List<UserStoreView2> readRoleAndStoreNo(int role,int storeid)
        {
            string sql = string.Format("select * From " + TABLENAME + "where userRole = {0} and storeid = '{1}'",role, storeid);
            return wrap(processResults(sql));
        }

        public List<UserStoreView2> readRole(int role)
        {
            string sql = string.Format("select * From " + TABLENAME + "where userRole = {0} ", role);
            return wrap(processResults(sql));
        }

        private List<UserStoreView2> wrap(List<IDomain> result)
        {
            List<UserStoreView2> list = new List<UserStoreView2>();
            foreach (IDomain domain in result)
                list.Add((UserStoreView2)domain);
            return list;
        }
    }
}

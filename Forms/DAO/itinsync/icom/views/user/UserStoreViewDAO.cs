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
    public class UserStoreViewDAO : CRUDBase
    {

        string TABLENAME = " userstoreview ";
        public static UserStoreViewDAO getInstance(DBContext dbContext)
        {
            UserStoreViewDAO obj = new UserStoreViewDAO();
            obj.init(dbContext);
            return obj;
        }

        protected override string createQuery(object o)
        {
            throw new NotImplementedException();
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            UserStoreView userstore = new UserStoreView();

            userstore.storeid = Convert.ToInt32(dt.Rows[i][UserStoreView.columns.storeid.ToString()]);
            userstore.storename = Convert.ToString(dt.Rows[i][UserStoreView.columns.storename.ToString()]);
            userstore.userid = Convert.ToInt32(dt.Rows[i][UserStoreView.columns.userid.ToString()]);
            userstore.userstoreid = Convert.ToInt32(dt.Rows[i][UserStoreView.columns.userstoreid.ToString()]);

            //setPropertiesValue(userstore, dt, i, typeof(UserStoreView.columns));

            return userstore;
        }

        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }

        public List<UserStoreView> readbyuserID(Int32 userID)
        {
            return wrap(processResults("select * From " + TABLENAME + " where userid = " + userID));
        }

        private List<UserStoreView> wrap(List<IDomain> result)
        {
            List<UserStoreView> list = new List<UserStoreView>();
            foreach (IDomain domain in result)
                list.Add((UserStoreView)domain);
            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Domains.itinsync.icom.views.personalinbox;

namespace DAO.itinsync.icom.views
{
    public class PersonalInboxViewDAO : CRUDBase
    {
        string TABLENAME = " personalinboxview ";
        public static PersonalInboxViewDAO getInstance(DBContext dbContext)
        {
            PersonalInboxViewDAO obj = new PersonalInboxViewDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            throw new NotImplementedException();
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            PersonalInboxView personalinbox = new PersonalInboxView();
            personalinbox.documentid = Convert.ToInt64(dt.Rows[i][PersonalInboxView.columns.documentid.ToString()]);

            setPropertiesValue(personalinbox, dt, i, typeof(PersonalInboxView.columns));

            return personalinbox;
        }
        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }
        private List<PersonalInboxView> wrap(List<IDomain> result)
        {
            List<PersonalInboxView> list = new List<PersonalInboxView>();
            foreach (IDomain domain in result)
                list.Add((PersonalInboxView)domain);
            return list;
        }
        public List<PersonalInboxView> readByUseridWithStatus(int userID, string status)
        {
            string READ = string.Format("Select * from " + TABLENAME + " where userID = " + userID + " and status = '" + status+"'");
            return wrap(processResults(READ));
        }
    }
}

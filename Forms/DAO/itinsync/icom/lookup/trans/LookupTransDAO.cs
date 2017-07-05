using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.icom.lookup.trans;
using Domains.itinsync.interfaces.domain;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;

namespace DAO.itinsync.icom.lookup.trans
{
    public class LookupTransDAO : CRUDBase
    {
        readonly string TABLENAME = " lookuptrans ";

        public static LookupTransDAO getInstance(DBContext dbContext)
        {
            LookupTransDAO obj = new LookupTransDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(LookupTrans.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            LookupTrans lookupTrans = new LookupTrans();
            lookupTrans.lookupTransID = Convert.ToInt32(dt.Rows[i][LookupTrans.primaryKey.lookupTransID.ToString()]);

            setPropertiesValue(lookupTrans, dt, i, typeof(LookupTrans.columns));

            return lookupTrans;
        }
        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }
        private List<LookupTrans> wrap(List<IDomain> result)
        {
            List<LookupTrans> list = new List<LookupTrans>();
            foreach (IDomain domain in result)
                list.Add((LookupTrans)domain);
            return list;
        }
        public List<LookupTrans> GetLookupTrans()
        {
            string READ = string.Format("Select * from " + TABLENAME );
            return wrap(processResults(READ));
        }
        public bool deleteByID(Int32 ID)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where lookupTransID = {0}", ID);
            return delete(delSQL);
        }
    }
}

using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.interfaces.domain;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.store;
using Utils.itinsync.icom;
using Utils.itinsync.icom.exceptions;

namespace DAO.itinsync.icom.store
{
    public class StoreDAO : CRUDBase
    {

        string TABLENAME = " stores ";
        public static StoreDAO getInstance(DBContext dbContext)
        {
            StoreDAO obj = new StoreDAO();
            obj.init(dbContext);
            return obj;
        }

        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(Store.columns));
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            Store store = new Store();
            store.storeid= Convert.ToInt32(dt.Rows[i][Store.primaryKey.storeid.ToString()]);
            setPropertiesValue(store, dt, i, typeof(Store.columns));


            return store;
        }

        protected override string updateQuery(object o, string where)
        {
            List<Store> results = new List<Store>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((Store)o).storeid));
            foreach (Store lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(Store.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(Store.primaryKey.storeid.ToString(), lk.storeid)));
            }
            return "";
        }

        public Store findbyPrimaryKey(int storeid)
        {
            return (Store)processSingleResult("select * From " + TABLENAME + "where storeid = " + storeid);
        }

        private List<Store> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<Store> wrap(List<IDomain> result)
        {
            List<Store> list = new List<Store>();
            foreach (IDomain domain in result)
                list.Add((Store)domain);
            return list;
        }
    }
}

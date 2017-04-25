using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Domains.itinsync.icom.pages;
using DAO.itinsync.icom.BaseAS.dbcontext;

namespace DAO.itinsync.icom.pages
{
    public class PageNameDAO : CRUDBase
    {
        private string TABLENAME = " pageName ";
        public static PageNameDAO getInstance(DBContext dbContext)
        {
            PageNameDAO obj = new PageNameDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            throw new NotImplementedException();
        }
        public  PageName findbyPrimaryKey(Int32 primaryKey)
        {
            throw new NotImplementedException();
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            PageName pagename = new PageName();
            pagename.pageID = Convert.ToInt32(dt.Rows[i][PageName.primaryKey.pageID.ToString()]);

            setPropertiesValue(pagename, dt, i, typeof(PageName.columns));

            /*pagename.pageName = Convert.ToString(dt.Rows[i][PageName.columns.pageName.ToString()]);
            pagename.webName = Convert.ToString(dt.Rows[i][PageName.columns.webName.ToString()]);*/
            return pagename;
        }
        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }
        public List<PageName> readAll()
        {
            string sql = "select * from " +TABLENAME  ;

            return wrap(processResults(sql));
        }

        private List<PageName> wrap(List<IDomain> result)
        {
            List<PageName> list = new List<PageName>();
            foreach (IDomain domain in result)
                list.Add((PageName)domain);

            return list;
        }
    }
}
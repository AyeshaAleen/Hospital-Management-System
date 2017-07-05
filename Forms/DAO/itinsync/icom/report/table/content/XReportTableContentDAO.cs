using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.report.table.content;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom;
using Utils.itinsync.icom.exceptions;

namespace DAO.itinsync.icom.report.table.content
{
    public class XReportTableContentDAO : CRUDBase
    {
        string TABLENAME = " xreporttablecontent ";

        public static XReportTableContentDAO getInstance(DBContext dbContext)
        {
            XReportTableContentDAO obj = new XReportTableContentDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(XReportTableContent.columns));
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            XReportTableContent obj = new XReportTableContent();
            obj.reportContentID = Convert.ToInt32(dt.Rows[i][XReportTableContent.primaryKey.reportContentID.ToString()]);

            setPropertiesValue(obj, dt, i, typeof(XReportTableContent.columns));

            return obj;
        }

        protected override string updateQuery(object o, string where)
        {
            List<XReportTableContent> results = new List<XReportTableContent>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((XReportTableContent)o).reportContentID));
            foreach (XReportTableContent lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(XReportTableContent.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(XReportTableContent.primaryKey.reportContentID.ToString(), lk.reportContentID)));
            }
            return "";
        }
        private List<XReportTableContent> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        public XReportTableContent findbyPrimaryKey(int ID)
        {
            string sql = "select * From " + TABLENAME + "where reportContentID = " + ID;
            return (XReportTableContent)processSingleResult(sql);
        }
        private List<XReportTableContent> wrap(List<IDomain> result)
        {
            List<XReportTableContent> list = new List<XReportTableContent>();
            foreach (IDomain domain in result)
                list.Add((XReportTableContent)domain);
            return list;
        }
        public bool deleteByID(Int32 ID)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where reportContentID = {0}", ID);
            return delete(delSQL);
        }
    }
}

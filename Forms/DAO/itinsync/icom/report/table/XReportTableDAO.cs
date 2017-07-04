using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.report.table;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom;
using Utils.itinsync.icom.exceptions;

namespace DAO.itinsync.icom.report.table
{
    public class XReportTableDAO : CRUDBase
    {
        string TABLENAME = " xreporttable ";

        public static XReportTableDAO getInstance(DBContext dbContext)
        {
            XReportTableDAO obj = new XReportTableDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(XReportTable.columns));
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            XReportTable obj = new XReportTable();
            obj.reporttableID = Convert.ToInt32(dt.Rows[i][XReportTable.primaryKey.reporttableID.ToString()]);

            setPropertiesValue(obj, dt, i, typeof(XReportTable.columns));

            return obj;
        }

        protected override string updateQuery(object o, string where)
        {
            List<XReportTable> results = new List<XReportTable>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((XReportTable)o).reporttableID));
            foreach (XReportTable lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(XReportTable.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(XReportTable.primaryKey.reporttableID.ToString(), lk.reporttableID)));
            }
            return "";
        }
        private List<XReportTable> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        public XReportTable findbyPrimaryKey(int ID)
        {
            string sql = "select * From " + TABLENAME + "where reporttableID = " + ID;
            return (XReportTable)processSingleResult(sql);
        }
        private List<XReportTable> wrap(List<IDomain> result)
        {
            List<XReportTable> list = new List<XReportTable>();
            foreach (IDomain domain in result)
                list.Add((XReportTable)domain);
            return list;
        }
        public bool deleteByID(Int32 ID)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where reporttableID = {0}", ID);
            return delete(delSQL);
        }
    }
}

using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.report.table.td;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom;
using Utils.itinsync.icom.exceptions;

namespace DAO.itinsync.icom.report.table.td
{
    public class XReportTableTDDAO : CRUDBase
    {
        string TABLENAME = " xreporttabletd ";

        public static XReportTableTDDAO getInstance(DBContext dbContext)
        {
            XReportTableTDDAO obj = new XReportTableTDDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(XReportTableTD.columns));
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            XReportTableTD obj = new XReportTableTD();
            obj.reportTDID = Convert.ToInt32(dt.Rows[i][XReportTableTD.primaryKey.reportTDID.ToString()]);

            setPropertiesValue(obj, dt, i, typeof(XReportTableTD.columns));

            return obj;
        }

        protected override string updateQuery(object o, string where)
        {
            List<XReportTableTD> results = new List<XReportTableTD>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((XReportTableTD)o).reportTDID));
            foreach (XReportTableTD lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(XReportTableTD.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(XReportTableTD.primaryKey.reportTDID.ToString(), lk.reportTDID)));
            }
            return "";
        }
        private List<XReportTableTD> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        public XReportTableTD findbyPrimaryKey(int ID)
        {
            string sql = "select * From " + TABLENAME + "where reportTDID = " + ID;
            return (XReportTableTD)processSingleResult(sql);
        }
        private List<XReportTableTD> wrap(List<IDomain> result)
        {
            List<XReportTableTD> list = new List<XReportTableTD>();
            foreach (IDomain domain in result)
                list.Add((XReportTableTD)domain);
            return list;
        }
        public bool deleteByID(Int32 ID)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where reportTDID = {0}", ID);
            return delete(delSQL);
        }
    }
}

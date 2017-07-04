using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.report.table.tr;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom;
using Utils.itinsync.icom.exceptions;

namespace DAO.itinsync.icom.report.table.tr
{
    public class XReportTableTRDAO : CRUDBase
    {
        string TABLENAME = " xreporttabletr ";

        public static XReportTableTRDAO getInstance(DBContext dbContext)
        {
            XReportTableTRDAO obj = new XReportTableTRDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(XReportTableTR.columns));
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            XReportTableTR obj = new XReportTableTR();
            obj.reportTRID = Convert.ToInt32(dt.Rows[i][XReportTableTR.primaryKey.reportTRID.ToString()]);

            setPropertiesValue(obj, dt, i, typeof(XReportTableTR.columns));

            return obj;
        }

        protected override string updateQuery(object o, string where)
        {
            List<XReportTableTR> results = new List<XReportTableTR>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((XReportTableTR)o).reporttableID));
            foreach (XReportTableTR lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(XReportTableTR.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(XReportTableTR.primaryKey.reportTRID.ToString(), lk.reportTRID)));
            }
            return "";
        }
        private List<XReportTableTR> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        public XReportTableTR findbyPrimaryKey(int ID)
        {
            string sql = "select * From " + TABLENAME + "where reportTRID = " + ID;
            return (XReportTableTR)processSingleResult(sql);
        }
        private List<XReportTableTR> wrap(List<IDomain> result)
        {
            List<XReportTableTR> list = new List<XReportTableTR>();
            foreach (IDomain domain in result)
                list.Add((XReportTableTR)domain);
            return list;
        }
        public bool deleteByID(Int32 ID)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where reportTRID = {0}", ID);
            return delete(delSQL);
        }
    }
}

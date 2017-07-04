using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.report.definition;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom;
using Utils.itinsync.icom.exceptions;

namespace DAO.itinsync.icom.report.definition
{
    public class XReportDefinitionDAO : CRUDBase
    {
        string TABLENAME = " xreportdefinition ";

        public static XReportDefinitionDAO getInstance(DBContext dbContext)
        {
            XReportDefinitionDAO obj = new XReportDefinitionDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(XReportDefinition.columns));
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            XReportDefinition obj = new XReportDefinition();
            obj.XReportDefinitionID = Convert.ToInt32(dt.Rows[i][XReportDefinition.primaryKey.XReportDefinitionID.ToString()]);

            setPropertiesValue(obj, dt, i, typeof(XReportDefinition.columns));

            return obj;
        }

        protected override string updateQuery(object o, string where)
        {
            List<XReportDefinition> results = new List<XReportDefinition>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((XReportDefinition)o).XReportDefinitionID));
            foreach (XReportDefinition lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(XReportDefinition.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(XReportDefinition.primaryKey.XReportDefinitionID.ToString(), lk.XReportDefinitionID)));
            }
            return "";
        }
        private List<XReportDefinition> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        public XReportDefinition findbyPrimaryKey(int ID)
        {
            string sql = "select * From " + TABLENAME + "where XReportDefinitionID = " + ID;
            return (XReportDefinition)processSingleResult(sql);
        }
        private List<XReportDefinition> wrap(List<IDomain> result)
        {
            List<XReportDefinition> list = new List<XReportDefinition>();
            foreach (IDomain domain in result)
                list.Add((XReportDefinition)domain);
            return list;
        }
        public bool deleteByID(Int32 ID)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where XReportDefinitionID = {0}", ID);
            return delete(delSQL);
        }
    }
}

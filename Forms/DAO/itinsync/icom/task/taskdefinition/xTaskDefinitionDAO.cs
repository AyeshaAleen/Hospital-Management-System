using System;
using System.Data;
using DAO.itinsync.icom.BaseAS.CRUDBase;
using Domains.itinsync.interfaces.domain;
using DAO.itinsync.icom.BaseAS.dbcontext;
using System.Collections.Generic;
using Utils.itinsync.icom;
using Utils.itinsync.icom.constant.lookup;
using Domains.itinsync.icom.task.taskdedinition;
using System.Runtime.Serialization;
using Utils.itinsync.icom.exceptions;

namespace DAO.itinsync.icom.task.taskdefinition
{
    class xTaskDefinitionDAO : CRUDBase
    {
        string TABLENAME = " xtaskdefinition ";
        public static xTaskDefinitionDAO getInstance(DBContext dbContext)
        {
            xTaskDefinitionDAO obj = new xTaskDefinitionDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(TaskDefinition.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            xTaskDefinition xtaskdefinition = new xTaskDefinition();
            xtaskdefinition.xTaskDefinitionID = Convert.ToInt32(dt.Rows[i][xTaskDefinition.primaryKey.xTaskDefinitionID.ToString()]);
            xtaskdefinition.name = Convert.ToString(dt.Rows[i][xTaskDefinition.columns.name.ToString()]);
            xtaskdefinition.openService = Convert.ToString(dt.Rows[i][xTaskDefinition.columns.openService.ToString()]);
            xtaskdefinition.completeService = Convert.ToString(dt.Rows[i][xTaskDefinition.columns.completeService.ToString()]);
            xtaskdefinition.parameters = Convert.ToString(dt.Rows[i][xTaskDefinition.columns.parameters.ToString()]);
            xtaskdefinition.dueDays = Convert.ToString(dt.Rows[i][xTaskDefinition.columns.dueDays.ToString()]);
            xtaskdefinition.deadLineDays = Convert.ToString(dt.Rows[i][xTaskDefinition.columns.deadLineDays.ToString()]);
            xtaskdefinition.body = Convert.ToString(dt.Rows[i][xTaskDefinition.columns.body.ToString()]);
            xtaskdefinition.route = Convert.ToString(dt.Rows[i][xTaskDefinition.columns.route.ToString()]);
            return xtaskdefinition;
        }
        protected override string updateQuery(object o, string where)
        {
            List<xTaskDefinition> results = new List<xTaskDefinition>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((xTaskDefinition)o).xTaskDefinitionID));
            foreach (xTaskDefinition lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(xTaskDefinition.columns));
                if (whereClause.Contains("="))
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(xTaskDefinition.primaryKey.xTaskDefinitionID.ToString(), lk.xTaskDefinitionID)));
            }
            return "";
        }
        public xTaskDefinition findbyPrimaryKey(int xTaskDefinitionID)
        {
            string sql = "select * From " + TABLENAME + "where id = " + xTaskDefinitionID;
            return (xTaskDefinition)processSingleResult(sql);
        }
        public List<xTaskDefinition> readAll()
        {
            string sql = "select * From " + TABLENAME;
            return wrap(processResults(sql));
        }
        private List<xTaskDefinition> languageLookup()
        {
            string READBYLOOKUP = "select * from " + TABLENAME + " where name ='" + LookupsConstant.LKUserLang + "' order by name";
            return wrap(processResults(READBYLOOKUP));
        }
        private List<xTaskDefinition> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<xTaskDefinition> wrap(List<IDomain> result)
        {
            List<xTaskDefinition> list = new List<xTaskDefinition>();
            foreach (IDomain domain in result)
                list.Add((xTaskDefinition)domain);
            return list;
        }
    }

}
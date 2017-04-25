using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.interfaces.domain;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom;
using domains.itinsync.businesstransaction;

namespace DAO.itinsync.icom.businesstransaction
{
    public class BusinessTranscationDAO : CRUDBase
    {
        string TABLENAME = " businesstransaction ";
        public static BusinessTranscationDAO getInstance(DBContext dbContext)
        {
            BusinessTranscationDAO obj = new BusinessTranscationDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(BusinessTranscation.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            BusinessTranscation businesstransaction = new BusinessTranscation();
            businesstransaction.transID = Convert.ToInt32(dt.Rows[i][BusinessTranscation.primaryKey.transID.ToString()]);
            setPropertiesValue(businesstransaction, dt, i, typeof(BusinessTranscation.columns));

            // need to put logic to convert time respective rtime zone

            

            /*businesstransaction.transDate = Convert.ToString(dt.Rows[i][BusinessTranscation.columns.transDate.ToString()]);
            businesstransaction.transTime = Convert.ToString(dt.Rows[i][BusinessTranscation.columns.transTime.ToString()]);
            businesstransaction.userID = Convert.ToInt32(dt.Rows[i][BusinessTranscation.columns.userID.ToString()]);
            businesstransaction.pageNo = Convert.ToInt32(dt.Rows[i][BusinessTranscation.columns.pageNo.ToString()]);
            businesstransaction.previousPageNo = Convert.ToInt32(dt.Rows[i][BusinessTranscation.columns.previousPageNo.ToString()]);*/
            return businesstransaction;
        }
        protected override string updateQuery(object o, string where)
        {
            List<BusinessTranscation> results = new List<BusinessTranscation>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((BusinessTranscation)o).transID));
            foreach (BusinessTranscation lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(BusinessTranscation.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(BusinessTranscation.primaryKey.transID.ToString(), lk.transID)));
            }
            return "";
        }
        public BusinessTranscation findbyPrimaryKey(int transID)
        {
            string sql = "select * From " + TABLENAME + "where id = " + transID;
            return (BusinessTranscation)processSingleResult(sql);
        }
        public List<BusinessTranscation> readAll()
        {
            string sql = "select * From " + TABLENAME;
            return wrap(processResults(sql));
        }
        private List<BusinessTranscation> languageLookup()
        {
            string READBYLOOKUP = "select * from " + TABLENAME + " where name ='" + LookupsConstant.LKUserLang + "' order by name";
            return wrap(processResults(READBYLOOKUP));
        }
        private List<BusinessTranscation> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<BusinessTranscation> wrap(List<IDomain> result)
        {
            List<BusinessTranscation> list = new List<BusinessTranscation>();
            foreach (BusinessTranscation domain in result)
                list.Add((BusinessTranscation)domain);
            return list;
        }
    }
}
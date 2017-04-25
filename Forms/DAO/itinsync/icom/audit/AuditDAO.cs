using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;
using domains.itinsync.audit;
using Domains.itinsync.interfaces.domain;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom;
using Utils.itinsync.icom.cache.lookup;

namespace DAO.itinsync.icom.audit
{
    public class AuditDAO : CRUDBase
    {
        string TABLENAME = " audit ";
        public static AuditDAO getInstance(DBContext dbContext)
        {
            AuditDAO obj = new AuditDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(Audit.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            Audit audit = new Audit();
            audit.auditID = Convert.ToInt32(dt.Rows[i][Audit.primaryKey.auditID.ToString()]);

            setPropertiesValue(audit, dt, i, typeof(Audit.columns));

            //audit.eventCode_Text = LookupManager.readTextByCode(LookupsConstant.LKAuditEvent, audit.eventCode, getHeader().lang);

            /*audit.eventCode = Convert.ToInt32(dt.Rows[i][Audit.columns.eventCode.ToString()]);
            audit.description = Convert.ToString(dt.Rows[i][Audit.columns.description.ToString()]);
            audit.additionalDetails = Convert.ToString(dt.Rows[i][Audit.columns.additionalDetails.ToString()]);
            audit.userID = Convert.ToInt32(dt.Rows[i][Audit.columns.userID.ToString()]);
            audit.transDate = Convert.ToString(dt.Rows[i][Audit.columns.transDate.ToString()]);
            audit.transTime = Convert.ToString(dt.Rows[i][Audit.columns.transTime.ToString()]);
            audit.parentRef = Convert.ToString(dt.Rows[i][Audit.columns.parentRef.ToString()]);
            audit.userName = Convert.ToString(dt.Rows[i][Audit.columns.userName.ToString()]);*/
            return audit;
        }
        protected override string updateQuery(object o, string where)
        {
            List<Audit> results = new List<Audit>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((Audit)o).auditID));
            foreach (Audit lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(Audit.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(Audit.primaryKey.auditID.ToString(), lk.auditID)));
            }
            return "";
        }
        public Audit findbyPrimaryKey(int auditID)
        {
            string sql = "select * From " + TABLENAME + "where id = " + auditID;
            return (Audit)processSingleResult(sql);
        }
        public List<Audit> readAll()
        {
            string sql = "select * From " + TABLENAME;
            return wrap(processResults(sql));
        }

        public List<Audit> readbyOrderNoEventCode(string orderno, List<Int32>eventcode)
        {
            var IDS = string.Join(",", eventcode);
            string SQL = string.Format("select * from " + TABLENAME + " where parentRef = '{0}' and eventCode in({1})", orderno, IDS);

            return wrap(processResults(SQL));
        }
        public List<Audit> readbyOrderNo(string orderno)
        {
            string SQL = string.Format("select * from " + TABLENAME + " where parentRef = '{0}'", orderno);

            return wrap(processResults(SQL));
        }

        public List<Audit> readbyUserID(Int32 userid)
        {
            string SQL = string.Format("select * from " + TABLENAME + " where userID = {0}", userid);

            return wrap(processResults(SQL));
        }

        private List<Audit> languageLookup()
        {
            string READBYLOOKUP = "select * from " + TABLENAME + " where name ='" + LookupsConstant.LKUserLang + "' order by name";
            return wrap(processResults(READBYLOOKUP));
        }
        private List<Audit> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<Audit> wrap(List<IDomain> result)
        {
            List<Audit> list = new List<Audit>();
            foreach (IDomain domain in result)
                list.Add((Audit)domain);
            return list;
        }

      
    }
}
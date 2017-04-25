using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using Domains.itinsync.interfaces.domain;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;
using System.Collections.Generic;
using Domains.itinsync.icom.permission;
using Utils.itinsync.icom;
using Utils.itinsync.icom.constant.lookup;
using DAO.itinsync.icom.task.taskdefinition;
using Utils.itinsync.icom.cache.global;
using System.Collections;
using Utils.itinsync.icom.exceptions;

namespace DAO.itinsync.icom.permission
{
    public class PermissionDAO : CRUDBase
    {
        string TABLENAME = " permission ";
        public static PermissionDAO getInstance(DBContext dbContext)
        {
            PermissionDAO obj = new PermissionDAO();
            obj.init(dbContext);
            return obj;
        }

        public void load()
        {
            if (GlobalStaticCache.PermissionCacheMap.Count == 0)
            {
                DataTable dt = FillDataTable("select * from Permission order by pageID");
                string currentPageID = "";
                Hashtable hashtable = new Hashtable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)
                        currentPageID = Convert.ToString(dt.Rows[i]["pageID"]);
                    if (currentPageID == Convert.ToString(dt.Rows[i]["pageID"]))
                    {
                        hashtable[Convert.ToString(dt.Rows[i]["Code"])] = Convert.ToString(dt.Rows[i]["text"]);
                    }
                    else if (currentPageID != Convert.ToString(dt.Rows[i]["pageID"]))
                    {
                        GlobalStaticCache.PermissionCacheMap.Add(currentPageID, hashtable);
                        hashtable = new Hashtable();
                        currentPageID = Convert.ToString(dt.Rows[i]["pageID"]);
                        hashtable[Convert.ToString(dt.Rows[i]["code"])] = Convert.ToString(dt.Rows[i]["text"]);
                    }
                }
                GlobalStaticCache.PermissionCacheMap.Add(currentPageID, hashtable);
            }
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(Permission.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            Permission permission = new Permission();
            permission.permissionID = Convert.ToInt32(dt.Rows[i][Permission.primaryKey.permissionID.ToString()]);
            setPropertiesValue(permission, dt, i, typeof(Permission.columns));
            return permission;
        }
        protected override string updateQuery(object o, string where)
        {
            List<Permission> results = new List<Permission>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((Permission)o).permissionID));
            foreach (Permission lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(Permission.columns));
                //update on the base of primary key column
                if (whereClause.Contains("="))
                    update(ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(Permission.primaryKey.permissionID.ToString(), lk.permissionID)));
            }
            return "";
        }
        public List<Permission> readbyName(string name)
        {
            return wrap(processResults(string.Format("select * From " + TABLENAME + " where name like '{0}'", name + "%")));
        }
        public Permission findbyPrimaryKey(Int32 permissionID)
        {
            return (Permission)processSingleResult("select * From " + TABLENAME + " where permissionID = " + permissionID);
        }
        public List<Permission> readAll()
        {
            return wrap(processResults("select * From " + TABLENAME));
        }
        private List<Permission> languageLookup()
        {
            return wrap(processResults("select * from " + TABLENAME + " where name ='" + LookupsConstant.LKUserLang + "' order by name"));
        }
        private List<Permission> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            return wrap(processResults(string.Format("Select * from " + TABLENAME + where)));
        }
        private List<Permission> wrap(List<IDomain> result)
        {
            List<Permission> list = new List<Permission>();
            foreach (IDomain domain in result)
                list.Add((Permission)domain);
            return list;
        }
    }
}
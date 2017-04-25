using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.interfaces.domain;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom;
using domains.itinsync.task;
using System.Reflection;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.cache.lookup;

namespace DAO.itinsync.icom.task
{
    public class TaskDAO : CRUDBase
    {
        string TABLENAME = " task ";
        public static TaskDAO getInstance(DBContext dbContext)
        {
            TaskDAO obj = new TaskDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(Task.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            Task task = new Task();
            task.taskID = Convert.ToInt32(dt.Rows[i][Task.primaryKey.taskID.ToString()]);
            setPropertiesValue(task, dt, i, typeof(Task.columns));

            
            //task.status_Text = LookupManager.readTextByCode(LookupsConstant.LKTaskStatus,task.status,getHeader().lang);

            return task;
        }
        protected override string updateQuery(object o, string where)
        {
            List<Task> results = new List<Task>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((Task)o).taskID));
            foreach (Task lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(Task.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(Task.primaryKey.taskID.ToString(), lk.taskID)));
            }
            return "";
        }
        public Task findbyPrimaryKey(int taskID)
        {
            return (Task)processSingleResult("select * From " + TABLENAME + "where taskID = " + taskID);
        }
        public List<Task> readAll()
        {
            return wrap(processResults("select * From " + TABLENAME));
        }

        public List<Task> readyByUserid(Int32 userid)
        {
           
            string SQL = string.Format("select * from " + TABLENAME + " where userid = {0} and status!=({1})", userid, ApplicationCodes.TAKS_STATUS_COMPLETE);

            return wrap(processResults(SQL));
        }

        public List<Task> readybyTeamIDS(List<Int32> teamID)
        {
            var IDS = string.Join(",",teamID);
            string SQL = string.Format("select * from " + TABLENAME + " where teamid in ({0}) and status!=({1})", IDS,ApplicationCodes.TAKS_STATUS_COMPLETE);
            
            return wrap(processResults(SQL));
        }

        public Task readyBYSubjectIDAndParentRef(Int32 id, string parentref, string name)
        {

            string SQL = string.Format("Select * from " + TABLENAME + " where subjectid = {0} and parentref = '{1}' and name ='{2}' ",id, parentref, name);
            return (Task)processSingleResult(SQL);
        }

        public int completeTask(Task task)
        {
            string SQL = "update " + TABLENAME + " set status =" + ApplicationCodes.TAKS_STATUS_COMPLETE + " WHERE taskid =" + task.taskID;
            return update(SQL);
        }
        public int inProgressTask(Task task)
        {
            string SQL = "update " + TABLENAME + " set status =" + ApplicationCodes.TASK_STATUS_INPROGRESS + ", userID = "+getHeader().userID+"  WHERE taskid =" + task.taskID;
            return update(SQL);
        }

        public int updateDueDateDeadLine(Task task)
        {
            string SQL = "update " + TABLENAME + " set duedate =" + task.dueDate + " , deadlinedate =" + task.deadlineDate+ " WHERE taskid =" + task.taskID;
            return update(SQL);
        }

        private List<Task> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<Task> wrap(List<IDomain> result)
        {
            List<Task> list = new List<Task>();
            foreach (IDomain domain in result)
                list.Add((Task)domain);
            return list;
        }
    }
}
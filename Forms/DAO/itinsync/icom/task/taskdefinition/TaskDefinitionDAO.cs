using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Domains.itinsync.icom.task.taskdedinition;
using Utils.itinsync.icom.cache.global;
using System.Reflection;

namespace DAO.itinsync.icom.task.taskdefinition
{
    public class TaskDefinitionDAO : CRUDBase
    {
        string TABLENAME = " xtaskdefinition ";
        public static TaskDefinitionDAO getDefInstance(DBContext dbContext)
        {
            TaskDefinitionDAO obj = new TaskDefinitionDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            throw new NotImplementedException();
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            TaskDefinition task = new TaskDefinition();
            task.xTaskDefinitionID = Convert.ToInt32(dt.Rows[i][TaskDefinition.primaryKey.xTaskDefinitionID.ToString()]);

            setPropertiesValue(task, dt, i, typeof(TaskDefinition.columns));

            /*
            task.completeService = Convert.ToString(dt.Rows[i][TaskDefinition.columns.completeService.ToString()]);
            task.deadlinedays = Convert.ToString(dt.Rows[i][TaskDefinition.columns.deadlinedays.ToString()]);
            task.duedays = Convert.ToString(dt.Rows[i][TaskDefinition.columns.duedays.ToString()]);
            task.Name = Convert.ToString(dt.Rows[i][TaskDefinition.columns.Name.ToString()]);
            task.openService = Convert.ToString(dt.Rows[i][TaskDefinition.columns.openService.ToString()]);
            task.parameters = Convert.ToString(dt.Rows[i][TaskDefinition.columns.parameters.ToString()]);
            
            task.body = Convert.ToString(dt.Rows[i][TaskDefinition.columns.body.ToString()]);
            task.route = Convert.ToInt32(dt.Rows[i][TaskDefinition.columns.route.ToString()]);*/
            return task;
        }
        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }
        private List<TaskDefinition> wrap(List<IDomain> result)
        {
            List<TaskDefinition> list = new List<TaskDefinition>();
            foreach (IDomain domain in result)
                list.Add((TaskDefinition)domain);
            return list;
        }
        public TaskDefinition findbyPrimaryKey(Int32 id)
        {
            string READ = string.Format("Select * from " + TABLENAME + " where xTaskDefinitionID = " + id);
            return (TaskDefinition)processSingleResult(READ);
        }

        public List<TaskDefinition> readyAll()
        {
            string READ = string.Format("Select * from " + TABLENAME);
            return wrap(processResults(READ));
        }
        public void load()
        {
            if (GlobalStaticCache.TaskDefinitionCacheMap.Count == 0)
            {
                List<TaskDefinition> tasklist = readyAll();
                foreach (TaskDefinition td in tasklist)
                {
                    GlobalStaticCache.TaskDefinitionCacheMap.Add(td.Name, td);
                }
            }
        }
    }
}
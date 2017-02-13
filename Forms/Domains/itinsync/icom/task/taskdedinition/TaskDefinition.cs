using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.task.taskdedinition
{
    public class TaskDefinition : System.Attribute, IDomain
    {
        public enum primaryKey { taskDefinitionID }
        public enum columns
        {
            Name, openService, completeService, parameters,
            duedays, deadlinedays, body, route
        }

        public int taskDefinitionID { get; set; }
        public string Name { get; set; }
        public string openService { get; set; }
        public string completeService { get; set; }
        public string parameters { get; set; }
        public string duedays { get; set; }
        public string deadlinedays { get; set; }
        public string body { get; set; }
        public int route { get; set; }

        public object getKey()
        {
            return taskDefinitionID;
        }
    }
}

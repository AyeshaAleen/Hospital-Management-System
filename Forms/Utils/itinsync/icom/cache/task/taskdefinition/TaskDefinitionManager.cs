using Domains.itinsync.icom.task.taskdedinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom.cache.global;

namespace Utils.itinsync.icom.cache.task.taskdefinition
{
    public static class TaskDefinitionManager
    {
        public static TaskDefinition readbyName(string name)
        {
           

            return GlobalStaticCache.TaskDefinitionCacheMap[name];

        }
    }
}

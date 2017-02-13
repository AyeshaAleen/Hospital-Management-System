using Domains.itinsync.icom.pages;
using Domains.itinsync.icom.task.taskdedinition;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.itinsync.icom.cache.global
{
    public static class GlobalStaticCache
    {
        public static Dictionary<string, Dictionary<string, string>>        translationcacheMap         = new Dictionary<string, Dictionary<string, string>>();
        public static Dictionary<string, Dictionary<string, Hashtable>>     LKcacheMap                  = new Dictionary<string, Dictionary<string, Hashtable>>();
        public static Dictionary<string, Hashtable>                         PermissionCacheMap          = new Dictionary<string, Hashtable>();
        public static Dictionary<string, PageName>                          PageCacheMap                = new Dictionary<string, PageName>();
        public static Dictionary<string, TaskDefinition>                    TaskDefinitionCacheMap      = new Dictionary<string, TaskDefinition>();
        public static List<Int32>                                           PageIDCacheMap              = new List<Int32>();
    }
}

using Domains.itinsync.icom.pages;
using Domains.itinsync.icom.task.taskdedinition;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.document;
using Domains.itinsync.interfaces.domain;
using Domains.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table.tr;
using Domains.itinsync.icom.idocument.table.td;
using Domains.itinsync.icom.idocument.table.content;
using Domains.itinsync.icom.idocument.table.calculation;
using Domains.itinsync.icom.idocument.section;

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
        public static Dictionary<Int32, XDocumentDefination>                documentDefinition          = new Dictionary<Int32, XDocumentDefination>();
        public static Dictionary<Int32, XDocumentTable>                     documentTables              = new Dictionary<Int32, XDocumentTable>();
        public static Dictionary<Int32, XDocumentTableTR>                   documentTablesTR            = new Dictionary<Int32, XDocumentTableTR>();
        public static Dictionary<Int32, XDocumentTableTD>                   documentTablesTD            = new Dictionary<Int32, XDocumentTableTD>();
        public static Dictionary<Int32, XDocumentTableContent>              documentContent             = new Dictionary<Int32, XDocumentTableContent>();
        public static Dictionary<Int32, XDocumentCalculation>               documentCalculation         = new Dictionary<Int32, XDocumentCalculation>();
        public static Dictionary<Int32, XDocumentSection>                   documentSection             = new Dictionary<Int32, XDocumentSection>();

    }
}

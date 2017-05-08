using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Utils.itinsync.icom.cache.global;
using System.Reflection;
using Domains.itinsync.icom.document;

namespace DAO.itinsync.icom.document.documentdefinitionview
{
    public class DocumentContentViewDAO : CRUDBase
    {
        string TABLENAME = " xdocumentcontentview ";
        public static DocumentContentViewDAO getDefInstance(DBContext dbContext)
        {
            DocumentContentViewDAO obj = new DocumentContentViewDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            throw new NotImplementedException();
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            documentcontent document = new documentcontent();
            document.documentdefinitionid = Convert.ToInt32(dt.Rows[i][documentcontent.columns.documentdefinitionid.ToString()]);

            setPropertiesValue(document, dt, i, typeof(documentcontent.columns));

            /*
            task.completeService = Convert.ToString(dt.Rows[i][TaskDefinition.columns.completeService.ToString()]);
            task.deadlinedays = Convert.ToString(dt.Rows[i][TaskDefinition.columns.deadlinedays.ToString()]);
            task.duedays = Convert.ToString(dt.Rows[i][TaskDefinition.columns.duedays.ToString()]);
            task.Name = Convert.ToString(dt.Rows[i][TaskDefinition.columns.Name.ToString()]);
            task.openService = Convert.ToString(dt.Rows[i][TaskDefinition.columns.openService.ToString()]);
            task.parameters = Convert.ToString(dt.Rows[i][TaskDefinition.columns.parameters.ToString()]);
            
            task.body = Convert.ToString(dt.Rows[i][TaskDefinition.columns.body.ToString()]);
            task.route = Convert.ToInt32(dt.Rows[i][TaskDefinition.columns.route.ToString()]);*/
            return document;
        }
        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }
        private List<documentcontent> wrap(List<IDomain> result)
        {
            List<documentcontent> list = new List<documentcontent>();
            foreach (IDomain domain in result)
                list.Add((documentcontent)domain);
            return list;
        }
        public documentcontent findbyPrimaryKey(Int32 id)
        {
            string READ = string.Format("Select * from " + TABLENAME + " where xTaskDefinitionID = " + id);
            return (documentcontent)processSingleResult(READ);
        }

        public List<documentcontent> readyAll()
        {
            string READ = string.Format("Select * from " + TABLENAME);
            return wrap(processResults(READ));
        }
        public void load()
        {
            if (GlobalStaticCache.documentDefinition.Count == 0)
            {
                List<documentcontent> tasklist = readyAll();
                foreach (documentcontent td in tasklist)
                {
                    GlobalStaticCache.documentDefinition.Add(td.controlName, td);
                }
            }
        }
    }
}
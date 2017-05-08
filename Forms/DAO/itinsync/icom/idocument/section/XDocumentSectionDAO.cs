using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.idocument.section;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.itinsync.icom.document.documentdefinitionview;
using Utils.itinsync.icom.cache.global;

namespace DAO.itinsync.icom.idocument.section
{
    public class XDocumentSectionDAO : CRUDBase
    {


        string TABLENAME = " xdocumentsection ";

        public static XDocumentSectionDAO getInstance(DBContext dbContext)
        {
            XDocumentSectionDAO obj = new XDocumentSectionDAO();
            obj.init(dbContext);
            return obj;
        }

        protected override string createQuery(object o)
        {
            throw new NotImplementedException();
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            XDocumentSection content = new XDocumentSection();
            content.documentsectionid = Convert.ToInt32(dt.Rows[i][XDocumentSection.primaryKey.documentsectionid.ToString()]);

            setPropertiesValue(content, dt, i, typeof(XDocumentSection.columns));

            return content;
        }
        public List<XDocumentSection> readyByDocumentDefinitionID(Int32 documentDefinitionID)
        {
            //if (GlobalStaticCache.documentDefinition.Count == 0)
            //{
            //    new DocumentContentViewDAO().load();
            //    return GlobalStaticCache.documentDefinition[documentDefinitionID.ToString()].tolist();
            //}


            //else
            //{
            //    return GlobalStaticCache.documentDefinition[documentDefinitionID.ToString()].tolist();
            //}

            string sql = "select * From " + TABLENAME + " where documentdefinitionid=" + documentDefinitionID;
            return wrap(processResults(sql));
        }
        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }

        private List<XDocumentSection> wrap(List<IDomain> result)
        {
            List<XDocumentSection> list = new List<XDocumentSection>();
            foreach (IDomain domain in result)
                list.Add((XDocumentSection)domain);
            return list;
        }
    }
}

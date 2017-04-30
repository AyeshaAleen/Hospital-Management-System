using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Domains.itinsync.icom.idocument.content;
using DAO.itinsync.icom.BaseAS.dbcontext;

namespace DAO.itinsync.icom.idocument.content
{
    public class XDocumentContentDAO : CRUDBase
    {

        string TABLENAME = " xdocumentcontent ";

        public static XDocumentContentDAO getInstance(DBContext dbContext)
        {
            XDocumentContentDAO obj = new XDocumentContentDAO();
            obj.init(dbContext);
            return obj;
        }

        protected override string createQuery(object o)
        {
            throw new NotImplementedException();
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            XDocumentContent content = new XDocumentContent();
            content.documentContentID = Convert.ToInt32(dt.Rows[i][XDocumentContent.primaryKey.documentContentID.ToString()]);

            setPropertiesValue(content, dt, i, typeof(XDocumentContent.columns));

            return content;
        }
        public List<XDocumentContent> readBYSectionID(Int32 sectionID)
        {
            string sql = "select * From " + TABLENAME + " where documentsectionID="+ sectionID;
            return wrap(processResults(sql));
        }
        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }

        private List<XDocumentContent> wrap(List<IDomain> result)
        {
            List<XDocumentContent> list = new List<XDocumentContent>();
            foreach (IDomain domain in result)
                list.Add((XDocumentContent)domain);
            return list;
        }
    }
}

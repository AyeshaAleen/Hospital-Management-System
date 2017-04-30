using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Domains.itinsync.icom.idocument.table.content;
using DAO.itinsync.icom.BaseAS.dbcontext;

namespace DAO.itinsync.icom.idocument.table.content
{
    public class XDocumentTableContentDAO : CRUDBase
    {
        string TABLENAME = " xdocumenttablecontent  ";

        public static XDocumentTableContentDAO getInstance(DBContext dbContext)
        {
            XDocumentTableContentDAO obj = new XDocumentTableContentDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            throw new NotImplementedException();
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            XDocumentTableContent tr = new XDocumentTableContent();
            tr.documentTableContentID = Convert.ToInt32(dt.Rows[i][XDocumentTableContent.primaryKey.documentTableContentID.ToString()]);

            setPropertiesValue(tr, dt, i, typeof(XDocumentTableContent.columns));

            return tr;
        }

        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }

        public List<XDocumentTableContent> readbyTDID(Int32 tdID)
        {
            string sql = "select * From " + TABLENAME + " where tdID = " + tdID;
            return wrap(processResults(sql));
        }

        private List<XDocumentTableContent> wrap(List<IDomain> result)
        {
            List<XDocumentTableContent> list = new List<XDocumentTableContent>();
            foreach (IDomain domain in result)
                list.Add((XDocumentTableContent)domain);
            return list;
        }
    }
}

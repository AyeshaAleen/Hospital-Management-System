using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Domains.itinsync.icom.idocument.table.tr;
using DAO.itinsync.icom.BaseAS.dbcontext;

namespace DAO.itinsync.icom.idocument.table.tr
{
    public class XDocumentTableTRDAO : CRUDBase
    {
        string TABLENAME = " xdocumenttabletr  ";

        public static XDocumentTableTRDAO getInstance(DBContext dbContext)
        {
            XDocumentTableTRDAO obj = new XDocumentTableTRDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            throw new NotImplementedException();
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            XDocumentTableTR tr = new XDocumentTableTR();
            tr.trID = Convert.ToInt32(dt.Rows[i][XDocumentTableTR.primaryKey.trID.ToString()]);

            setPropertiesValue(tr, dt, i, typeof(XDocumentTableTR.columns));

            return tr;
        }

        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }

        public List<XDocumentTableTR> readbyTableID(Int32 tableID)
        {
            string sql = "select * From " + TABLENAME + " where documentTableID = " + tableID;
            return wrap(processResults(sql));
        }

        private List<XDocumentTableTR> wrap(List<IDomain> result)
        {
            List<XDocumentTableTR> list = new List<XDocumentTableTR>();
            foreach (IDomain domain in result)
                list.Add((XDocumentTableTR)domain);
            return list;
        }
    }
}

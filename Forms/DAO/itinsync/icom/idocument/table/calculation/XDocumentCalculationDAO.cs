using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.idocument.table.calculation;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.itinsync.icom.idocument.table.calculation
{
    public class XDocumentCalculationDAO : CRUDBase
    {
        string TABLENAME = " xdocumentcalculation  ";

        public static XDocumentCalculationDAO getInstance(DBContext dbContext)
        {
            XDocumentCalculationDAO obj = new XDocumentCalculationDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            throw new NotImplementedException();
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            XDocumentCalculation dc = new XDocumentCalculation();
            dc.xdocumentcalculationID = Convert.ToInt32(dt.Rows[i][XDocumentCalculation.primaryKey.xdocumentcalculationID.ToString()]);

            setPropertiesValue(dc, dt, i, typeof(XDocumentCalculation.columns));

            return dc;
        }

        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }
        public List<XDocumentCalculation> readbyResultantID(Int32 resultantID)
        {
            string sql = "select * From " + TABLENAME + " where resultContentID = " + resultantID;
            return wrap(processResults(sql));
        }
        public List<XDocumentCalculation> readbyContentID(Int32 ContentID)
        {
            string sql = "select * From " + TABLENAME + " where documentcontentID = " + ContentID;
            return wrap(processResults(sql));
        }

        private List<XDocumentCalculation> wrap(List<IDomain> result)
        {
            List<XDocumentCalculation> list = new List<XDocumentCalculation>();
            foreach (IDomain domain in result)
                list.Add((XDocumentCalculation)domain);
            return list;
        }
    }
}

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
using Utils.itinsync.icom.cache.global;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.idocument.section;
using Domains.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table.tr;
using Domains.itinsync.icom.idocument.table.td;
using Domains.itinsync.icom.idocument.table.content;

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
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(XDocumentCalculation.columns));
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


        public List<XDocumentCalculation> readbyFieldID(Int32 fieldID)
        {
            //foreach (Int32 entry in GlobalStaticCache.documentDefinition.Keys)
            //{
            //    XDocumentDefination documentDefinition = GlobalStaticCache.documentDefinition[entry];

            //    foreach (XDocumentSection section in documentDefinition.documentSections)
            //    {
            //        foreach (XDocumentTable table in section.documentTable)
            //        {
            //            foreach (XDocumentTableTR tr in table.trs)
            //            {
            //                foreach (XDocumentTableTD td in tr.tds)
            //                {
            //                    foreach (XDocumentTableContent field in td.fields)
            //                    {
            //                        if (field.documentTableContentID == fieldID)
            //                            //issue
            //                            return field.calculations;
            //                    }
                                   
            //                }

            //            }

            //        }

            //    }
            //}

            string sql = "select * From " + TABLENAME + " where documentcontentID = " + fieldID;
            return wrap(processResults(sql));
        }



        public bool deleteByID(Int32 ID)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where xdocumentcalculationID = {0}", ID);
            return delete(delSQL);
        }
    }
}

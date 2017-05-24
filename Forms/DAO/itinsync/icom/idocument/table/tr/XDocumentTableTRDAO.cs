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
using Domains.itinsync.icom.idocument.definition;
using Utils.itinsync.icom.cache.global;
using Domains.itinsync.icom.idocument.section;
using Domains.itinsync.icom.idocument.table;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom;
using Utils.itinsync.icom.exceptions;

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
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(XDocumentTableTR.columns));
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
            List<XDocumentTableTR> results = new List<XDocumentTableTR>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((XDocumentTableTR)o).documentTableID));
            foreach (XDocumentTableTR lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(XDocumentTableTR.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(XDocumentTableTR.primaryKey.trID.ToString(), lk.trID)));
            }
            return "";
        }
        private List<XDocumentTableTR> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        public XDocumentTableTR findbyPrimaryKey(int trID)
        {
            string sql = "select * From " + TABLENAME + "where trID = " + trID;
            return (XDocumentTableTR)processSingleResult(sql);
        }

        public List<XDocumentTableTR> readbyTableID(Int32 tableID)
        {

            XDocumentTable objdocumenttable = DocumentManager.getDocumentTableID(tableID);
            if (objdocumenttable != null)
            {
                XDocumentSection objdocumentsection = DocumentManager.getDocumentSectionID(objdocumenttable.documentsectionid);
                if (objdocumentsection != null)
                {
                    List<XDocumentTableTR> objdocumenttabletr = DocumentManager.getDocumentTablesTRS(objdocumenttable.documentTableID, objdocumenttable.documentsectionid, objdocumentsection.documentdefinitionid);
                    if (objdocumenttabletr != null)
                        return objdocumenttabletr;
                }
            }
            //foreach (Int32 entry in GlobalStaticCache.documentDefinition.Keys)
            //{
            //    XDocumentDefination documentDefinition = GlobalStaticCache.documentDefinition[entry];

            //    foreach (XDocumentSection section in documentDefinition.documentSections)
            //    {
            //        foreach (XDocumentTable table in section.documentTable)
            //        {
            //            if (table.documentTableID == tableID)
            //                return table.trs;
            //        }

            //    }
            //}
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

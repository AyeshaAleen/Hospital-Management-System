using DAO.itinsync.icom.BaseAS.CRUDBase;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.interfaces.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom.cache.global;
using DAO.itinsync.icom.document.documentdefinitionview;//
using Domains.itinsync.icom.idocument.section;
using DAO.itinsync.icom.idocument.table;//
using Domains.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table.tr;
using DAO.itinsync.icom.idocument.table.tr;//
using DAO.itinsync.icom.idocument.table.td;//
using DAO.itinsync.icom.idocument.table.content;//
using Domains.itinsync.icom.idocument.table.td;
using Domains.itinsync.icom.idocument.table.content;
using DAO.itinsync.icom.idocument.table.calculation;//
using Domains.itinsync.icom.idocument.table.calculation;
using DAO.itinsync.icom.idocument.section;//
using System.Collections;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.cache.document;

namespace DAO.itinsync.icom.idocument.definition
{
    public class XDocumentDefinationDAO : CRUDBase
    {
        string TABLENAME = " xdocumentdefinition ";
        public static XDocumentDefinationDAO getInstance(DBContext dbContext)
        {
            XDocumentDefinationDAO obj = new XDocumentDefinationDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(XDocumentDefination.columns));
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            XDocumentDefination document = new XDocumentDefination();
            document.xDocumentDefinationID = Convert.ToInt32(dt.Rows[i][XDocumentDefination.primaryKey.xDocumentDefinationID.ToString()]);
           
            setPropertiesValue(document, dt, i, typeof(XDocumentDefination.columns));

            return document;
        }
        protected override string updateQuery(object o, string where)
        {
            List<XDocumentDefination> results = new List<XDocumentDefination>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((XDocumentDefination)o).xDocumentDefinationID));
            foreach (XDocumentDefination lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(XDocumentDefination.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(XDocumentDefination.primaryKey.xDocumentDefinationID.ToString(), lk.xDocumentDefinationID.ToString())));
            }
            return "";
        }
        public XDocumentDefination findbyPrimaryKey(Int64 xDocumentDefinationID)
        {
            if (DocumentManager.getDocumentDefinition(xDocumentDefinationID) != null)
                return DocumentManager.getDocumentDefinition(xDocumentDefinationID);

            string sql = "select * From " + TABLENAME + " where xDocumentDefinationID = " + xDocumentDefinationID;
            return (XDocumentDefination)processSingleResult(sql);
        }
        public XDocumentDefination findbyDocumentName(string DocumentName)
        {

            foreach (Int32 entry in GlobalStaticCache.documentDefinition.Keys)
            {
                XDocumentDefination documentDefinition= GlobalStaticCache.documentDefinition[entry];

                if (documentDefinition.name == DocumentName)
                    return documentDefinition;
            }

            // if not found them reload complete definitions
            load();
              
            string sql = string.Format("select * From " + TABLENAME + "where name ='{0}'", DocumentName);
            return (XDocumentDefination)processSingleResult(sql);
        }

        public List<XDocumentDefination> readAll()
        {
            string sql = "select * From " + TABLENAME;
            return wrap(processResults(sql));
        }
       
        private List<XDocumentDefination> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        private List<XDocumentDefination> wrap(List<IDomain> result)
        {
            List<XDocumentDefination> list = new List<XDocumentDefination>();
            foreach (IDomain domain in result)
                list.Add((XDocumentDefination)domain);
            return list;
        }

       

        public void load()
        {
            GlobalStaticCache.documentCalculation = new Dictionary<Int32, XDocumentCalculation>();
            GlobalStaticCache.documentSection   =  new Dictionary<Int32, XDocumentSection>();
            GlobalStaticCache.documentTables = new Dictionary<Int32, XDocumentTable>();
            List<XDocumentDefination> documentsDefinitions = readAll();
            foreach (XDocumentDefination documentDefinition in documentsDefinitions)
            {
                documentDefinition.documentSections = XDocumentSectionDAO.getInstance(currentDBContext).readyByDocumentDefinitionID(documentDefinition.xDocumentDefinationID);

                foreach (XDocumentSection section in documentDefinition.documentSections)
                {
                    section.documentTable = XDocumentTableDAO.getInstance(currentDBContext).readbySectionID(section.documentsectionid);

                    foreach (XDocumentTable table in section.documentTable)
                    {
                        table.trs = XDocumentTableTRDAO.getInstance(currentDBContext).readbyTableID(table.documentTableID);

                        foreach (XDocumentTableTR tr in table.trs)
                        {
                            tr.tds = XDocumentTableTDDAO.getInstance(currentDBContext).readbyTRID(tr.trID);

                            foreach (XDocumentTableTD td in tr.tds)
                            {
                                td.fields = XDocumentTableContentDAO.getInstance(currentDBContext).readbyTDID(td.tdID);

                                foreach (XDocumentTableContent content in td.fields)
                                {
                                    content.calculations = XDocumentCalculationDAO.getInstance(currentDBContext).readbyResultantID(content.documentTableContentID);
                                    content.fieldcalculations = XDocumentCalculationDAO.getInstance(currentDBContext).readbyContentID(content.documentTableContentID);

                                    foreach (XDocumentCalculation calculation in content.calculations)
                                    {
                                        calculation.fieldContent = XDocumentTableContentDAO.getInstance(currentDBContext).findByPrimaryKey(calculation.documentcontentID);
                                        calculation.resultContent = XDocumentTableContentDAO.getInstance(currentDBContext).findByPrimaryKey(calculation.resultContentID);
                                        GlobalStaticCache.documentCalculation.Add(calculation.xdocumentcalculationID, calculation);
                                    }

                                    foreach (XDocumentCalculation fieldcalculation in content.fieldcalculations)
                                    {
                                        fieldcalculation.fieldContent = XDocumentTableContentDAO.getInstance(currentDBContext).findByPrimaryKey(fieldcalculation.documentcontentID);
                                        fieldcalculation.resultContent = XDocumentTableContentDAO.getInstance(currentDBContext).findByPrimaryKey(fieldcalculation.resultContentID);
                                       
                                    }

                                    if (GlobalStaticCache.documentContent.ContainsKey(content.documentTableContentID)==false)
                                    {
                                        GlobalStaticCache.documentContent.Add(content.documentTableContentID, content);
                                    }

                                }

                                if (GlobalStaticCache.documentTablesTD.ContainsKey(td.tdID) == false)
                                {
                                    GlobalStaticCache.documentTablesTD.Add(td.tdID, td);
                                }
                               
                            }
                            if (GlobalStaticCache.documentTablesTR.ContainsKey(tr.trID) == false)
                            {
                                GlobalStaticCache.documentTablesTR.Add(tr.trID, tr);
                            }
                        }
                        if (GlobalStaticCache.documentTables.ContainsKey(table.documentTableID) == false)
                        {
                            GlobalStaticCache.documentTables.Add(table.documentTableID, table);
                        }
                    }
                    if (GlobalStaticCache.documentSection.ContainsKey(section.documentsectionid) == false)
                    {
                        GlobalStaticCache.documentSection.Add(section.documentsectionid, section);
                    }
                }
                if (GlobalStaticCache.documentDefinition.ContainsKey(documentDefinition.xDocumentDefinationID) == false)
                {
                    GlobalStaticCache.documentDefinition.Add(documentDefinition.xDocumentDefinationID, documentDefinition);
                }

            }
        }

    }
}

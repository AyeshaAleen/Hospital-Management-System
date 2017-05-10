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
using Utils.itinsync.icom.cache.global;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.idocument.section;
using Domains.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table.tr;
using Domains.itinsync.icom.idocument.table.td;
using Utils.itinsync.icom.cache.lookup;

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


        
        public XDocumentTableContent findByPrimaryKey(Int32 ID)
        {
            if (DocumentManager.getDocumentTablesContentID(ID) != null)
                return DocumentManager.getDocumentTablesContentID(ID);
            /*
            foreach (Int32 entry in GlobalStaticCache.documentDefinition.Keys)
            {
                XDocumentDefination documentDefinition = GlobalStaticCache.documentDefinition[entry];

                foreach (XDocumentSection section in documentDefinition.documentSections)
                {
                    foreach (XDocumentTable table in section.documentTable)
                    {
                        foreach (XDocumentTableTR tr in table.trs)
                        {
                            foreach (XDocumentTableTD td in tr.tds)
                            {
                                foreach (XDocumentTableContent content in td.fields)
                                {
                                    if (content.documentTableContentID== ID)
                                        return content;
                                }
                                
                            }

                        }

                    }

                }
            }

            */
            string sql = "select * From " + TABLENAME + " where documentTableContentID = " + ID;
            return (XDocumentTableContent)processSingleResult(sql);
        }
        public List<XDocumentTableContent> readbyTDID(Int32 tdID)
        {
            foreach (Int32 entry in GlobalStaticCache.documentDefinition.Keys)
            {
                XDocumentDefination documentDefinition = GlobalStaticCache.documentDefinition[entry];

                foreach (XDocumentSection section in documentDefinition.documentSections)
                {
                    foreach (XDocumentTable table in section.documentTable)
                    {
                        foreach (XDocumentTableTR tr in table.trs)
                        {
                            foreach (XDocumentTableTD td in tr.tds)
                            {
                                if (td.trID == tdID)
                                    return td.fields;
                            }
                            
                        }

                    }

                }
            }

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

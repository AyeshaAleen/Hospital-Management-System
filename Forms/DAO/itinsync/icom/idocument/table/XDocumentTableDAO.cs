using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Domains.itinsync.icom.idocument.table;
using DAO.itinsync.icom.BaseAS.dbcontext;
using Utils.itinsync.icom.cache.global;
using DAO.itinsync.icom.document.documentdefinitionview;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.idocument.section;

namespace DAO.itinsync.icom.idocument.table
{
    public class XDocumentTableDAO : CRUDBase
    {

        string TABLENAME = " xdocumenttable ";

        public static XDocumentTableDAO getInstance(DBContext dbContext)
        {
            XDocumentTableDAO obj = new XDocumentTableDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            throw new NotImplementedException();
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            XDocumentTable table = new XDocumentTable();
            table.documentTableID= Convert.ToInt32(dt.Rows[i][XDocumentTable.primaryKey.documentTableID.ToString()]);

            setPropertiesValue(table, dt, i, typeof(XDocumentTable.columns));

            return table;
        }

        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }

        public List<XDocumentTable> readbySectionID(Int32 sectionID)
        {
            foreach (Int32 entry in GlobalStaticCache.documentDefinition.Keys)
            {
                XDocumentDefination documentDefinition = GlobalStaticCache.documentDefinition[entry];

                foreach (XDocumentSection section in documentDefinition.documentSections)
                {
                    if (section.documentsectionid == sectionID)
                        return section.documentTable;
                }
            }
            //if (GlobalStaticCache.documentDefinition.Count == 0)
            //{
            //    new DocumentContentViewDAO().load();
            //    return GlobalStaticCache.documentDefinition[sectionID.ToString()].tolist();
            //}


            //else
            //{
            //    return GlobalStaticCache.documentDefinition[sectionID.ToString()].tolist();
            //}

            string sql = "select * From " + TABLENAME + " where documentsectionid = " + sectionID;
            return wrap(processResults(sql));
        }

        private List<XDocumentTable> wrap(List<IDomain> result)
        {
            List<XDocumentTable> list = new List<XDocumentTable>();
            foreach (IDomain domain in result)
                list.Add((XDocumentTable)domain);
            return list;
        }
    }
}

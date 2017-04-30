﻿using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.interfaces.domain;
using System.Data;
using Domains.itinsync.icom.idocument.table.td;
using DAO.itinsync.icom.BaseAS.dbcontext;

namespace DAO.itinsync.icom.idocument.table.td
{
    public class XDocumentTableTDDAO : CRUDBase
    {

        string TABLENAME = " xdocumenttabletd  ";

        public static XDocumentTableTDDAO getInstance(DBContext dbContext)
        {
            XDocumentTableTDDAO obj = new XDocumentTableTDDAO();
            obj.init(dbContext);
            return obj;
        }
        protected override string createQuery(object o)
        {
            throw new NotImplementedException();
        }

        protected override IDomain setResult(DataTable dt, int i)
        {
            XDocumentTableTD td = new XDocumentTableTD();
            td.tdID = Convert.ToInt32(dt.Rows[i][XDocumentTableTD.primaryKey.tdID.ToString()]);

            setPropertiesValue(td, dt, i, typeof(XDocumentTableTD.columns));

            return td;
        }

        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }

        public List<XDocumentTableTD> readbyTRID(Int32 trID)
        {
            string sql = "select * From " + TABLENAME + " where trID = " + trID;
            return wrap(processResults(sql));
        }

        private List<XDocumentTableTD> wrap(List<IDomain> result)
        {
            List<XDocumentTableTD> list = new List<XDocumentTableTD>();
            foreach (IDomain domain in result)
                list.Add((XDocumentTableTD)domain);
            return list;
        }
    }
}

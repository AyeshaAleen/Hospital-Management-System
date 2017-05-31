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
using Utils.itinsync.icom.cache.global;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.idocument.section;
using Domains.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table.tr;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom;
using Utils.itinsync.icom.exceptions;

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
            return "INSERT INTO " + TABLENAME + preparedCreateQuery(o, typeof(XDocumentTableTD.columns));
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
            List<XDocumentTableTD> results = new List<XDocumentTableTD>();
            if (where.Length > 0)
                results = readWhere(where);
            else
                results.Add(findbyPrimaryKey(((XDocumentTableTD)o).tdID));
            foreach (XDocumentTableTD lk in results)
            {
                string whereClause = " update " + TABLENAME + " set ";
                whereClause = whereClause + preparedUpdateQuery(lk, o, typeof(XDocumentTableTD.columns));
                if (whereClause.Contains("="))//update on the base of primary key column
                    update(Utils.itinsync.icom.ServiceUtils.finilizedQuery(whereClause) + ServiceUtils.finilizedQueryWhere(ServiceUtils.appendQuotes(XDocumentTableTD.primaryKey.tdID.ToString(), lk.tdID)));
            }
            return "";
        }
        private List<XDocumentTableTD> readWhere(string where)
        {
            if (where == null || where.Length == 0)
                throw new ItinsyncException(new Exception());
            string SQL = string.Format("Select * from " + TABLENAME + where);
            return wrap(processResults(SQL));
        }
        public XDocumentTableTD findbyPrimaryKey(int tdID)
        {
            string sql = "select * From " + TABLENAME + "where tdID = " + tdID;
            return (XDocumentTableTD)processSingleResult(sql);
        }

        public List<XDocumentTableTD> readbyTRID(Int32 trID)
        {
            XDocumentTableTR objdocumenttabletr = DocumentManager.getDocumentTablesTRID(trID);
            if (objdocumenttabletr != null)
            {
                XDocumentTable objdocumenttable = DocumentManager.getDocumentTableID(objdocumenttabletr.documentTableID);
                if (objdocumenttable != null)
                {
                    XDocumentSection objdocumentsection = DocumentManager.getDocumentSectionID(objdocumenttable.documentsectionid);
                    if (objdocumentsection != null)
                    {
                        List<XDocumentTableTD> objdocumenttabletd = DocumentManager.getDocumentTablesTDS(objdocumenttabletr.trID,objdocumenttable.documentTableID, objdocumenttable.documentsectionid, objdocumentsection.documentdefinitionid);
                        if (objdocumenttabletd != null)
                            return objdocumenttabletd;
                    }
                }
            }

            //foreach (Int32 entry in GlobalStaticCache.documentDefinition.Keys)
            //{
            //    XDocumentDefination documentDefinition = GlobalStaticCache.documentDefinition[entry];

            //    foreach (XDocumentSection section in documentDefinition.documentSections)
            //    {
            //        foreach (XDocumentTable table in section.documentTable)
            //        {
            //            foreach (XDocumentTableTR tr in table.trs)
            //            {
            //                if (tr.trID == trID)
            //                    return tr.tds;
            //            }

            //        }

            //    }
            //}


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


        public bool deleteByID(Int32 ID)
        {
            string delSQL = string.Format("delete from " + TABLENAME + " where tdID = {0}", ID);
            return delete(delSQL);
        }

    }
}

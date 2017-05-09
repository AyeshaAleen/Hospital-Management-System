using DAO.itinsync.icom.BaseAS.CRUDBase;
using System;
using System.Collections.Generic;
using Domains.itinsync.interfaces.domain;
using System.Data;
using DAO.itinsync.icom.BaseAS.dbcontext;

using Utils.itinsync.icom.constant.lookup;
using System.Collections;
using Utils.itinsync.icom.cache.global;
using Domains.itinsync.icom.document;

namespace DAO.itinsync.icom.document
{
    public class DocumentDAO : CRUDBase
    {
        readonly string TABLENAME = " xdocumentcontentview ";
        public static DocumentDAO getInstance(DBContext dbContext)
        {
            DocumentDAO obj = new DocumentDAO();
            obj.init(dbContext);
            return obj;
        }

        protected override string createQuery(object o)
        {
            throw new NotImplementedException();
        }
        protected override IDomain setResult(DataTable dt, int i)
        {
            throw new NotImplementedException();
        }
        protected override string updateQuery(object o, string where)
        {
            throw new NotImplementedException();
        }
        //private List<LookUp> languageLookUp()
        //{
        //    List<LookUp> lkList = new List<LookUp>();
        //    DataTable dt = FillDataTable("select * from " + TABLENAME + " where name ='" + LookupsConstant.LKUserLang + "' order by name");
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        LookUp lk = new LookUp();
        //        lk.text = Convert.ToString(dt.Rows[i][LookUp.columns.text.ToString()]);
        //        lk.code = Convert.ToString(dt.Rows[i][LookUp.columns.code.ToString()]);
        //        lkList.Add(lk);
        //    }
        //    return lkList;
        //}
       
    }
}
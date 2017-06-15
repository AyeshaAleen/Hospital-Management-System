using Domains.itinsync.icom.interfaces.request;
using Domains.itinsync.icom.interfaces.response;
using System.Collections.Generic;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.error;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.idocument;
using Domains.itinsync.icom.document;
using Domains.itinsync.icom.idocument.section;
using Domains.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table.tr;
using Domains.itinsync.icom.idocument.table.td;
using Domains.itinsync.icom.idocument.table.content;
using Domains.itinsync.icom.idocument.table.calculation;
using System;
using Domains.itinsync.icom.lookup.lookuptrans;

namespace Services.itinsync.icom.tablecontent.dto
{
    public class tablecontentDTO : IRequestHandler, IResponseHandler
    {
        public string READBY { get; set; }
        public string documentdefinitionName { get; set; }

        public Int64 documentdefinitionID { get; set; }

        public int sectionnID { get; set; }

        public XDocumentTable documentTable = new XDocumentTable();

        public XDocumentTable documentTableParse = new XDocumentTable();

        public XDocumentCalculation documentCalculation = new XDocumentCalculation();

        public List<XDocumentCalculation> documentCalculationlist = new List<XDocumentCalculation>();

        public LookupTrans lookupTrans = new LookupTrans();


        public List<XDocumentTable> documentTablelist = new List<XDocumentTable>();

        public ErrorBlock errorBlock = new ErrorBlock();
        public Header header = new Header();
        public ErrorBlock getErrorBlock() { return errorBlock; }
        public Header getHeader() { return header; }
        public object getResponseMessage() { return this; }
    }
}
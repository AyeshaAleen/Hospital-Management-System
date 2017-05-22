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

namespace Services.itinsync.icom.tablecontent.dto
{
    public class tablecontentDTO : IRequestHandler, IResponseHandler
    {
        public string READBY { get; set; }
        public string documentdefinitionName { get; set; }

        public int documentdefinitionID { get; set; }

        public XDocumentTable documentTable = new XDocumentTable();
        

        public ErrorBlock errorBlock = new ErrorBlock();
        public Header header = new Header();
        public ErrorBlock getErrorBlock() { return errorBlock; }
        public Header getHeader() { return header; }
        public object getResponseMessage() { return this; }
    }
}
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

namespace Services.itinsync.icom.tablecontent.dto
{
    public class tablecontentDTO : IRequestHandler, IResponseHandler
    {
        public string READBY { get; set; }

        public string UPDATEBY { get; set; }
        public XDocumentDefination documentDefination = new XDocumentDefination();
        public Douments document = new Douments();
        public XDocumentSection documentSection = new XDocumentSection();
        public XDocumentTable documentTable = new XDocumentTable();
        public List<XDocumentTableTR> documentTableTRlist = new List<XDocumentTableTR>();
        public XDocumentTableTR documentTableTR = new XDocumentTableTR();

        public List<XDocumentTableTD> documentTableTDlist = new List<XDocumentTableTD>();
        public XDocumentTableTD documentTableTD = new XDocumentTableTD();

        public List<XDocumentTableContent> documentTableContentlist = new List<XDocumentTableContent>();
        public XDocumentTableContent documentTableContent = new XDocumentTableContent();

        public List<XDocumentCalculation> documentTableCalculationlist = new List<XDocumentCalculation>();

        public documentcontent documentcontentview = new documentcontent();



        public List<Douments> documentList = new List<Douments>();
        public ErrorBlock errorBlock = new ErrorBlock();
        public Header header = new Header();
        public ErrorBlock getErrorBlock() { return errorBlock; }
        public Header getHeader() { return header; }
        public object getResponseMessage() { return this; }
    }
}
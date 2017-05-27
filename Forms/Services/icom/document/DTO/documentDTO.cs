using Domains.itinsync.icom.interfaces.request;
using Domains.itinsync.icom.interfaces.response;
using System.Collections.Generic;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.error;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.idocument;
using Domains.itinsync.icom.document;
using Domains.itinsync.icom.idocument.section;

namespace Services.itinsync.icom.documents.dto
{
    public class DocumentDTO : IRequestHandler, IResponseHandler
    {
        public string READBY { get; set; }

        public string UPDATEBY { get; set; }
        public XDocumentDefination documentDefination = new XDocumentDefination();
        public List<XDocumentDefination> documentDefinationlist = new List<XDocumentDefination>();

        public Douments document = new Douments();

        public List<XDocumentSection> documentSectionlist = new List<XDocumentSection>();
        public XDocumentSection documentSection = new XDocumentSection();

        public documentcontent documentcontentview = new documentcontent();

        public List<>

        public List<Douments> documentList = new List<Douments>();
        public ErrorBlock errorBlock = new ErrorBlock();
        public Header header = new Header();
        public ErrorBlock getErrorBlock() { return errorBlock; }
        public Header getHeader() { return header; }
        public object getResponseMessage() { return this; }
    }
}
using Domains.itinsync.icom.interfaces.request;
using Domains.itinsync.icom.interfaces.response;
using System.Collections.Generic;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.error;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.idocument;
using Domains.itinsync.icom.document;
using Domains.itinsync.icom.idocument.section;
using Domains.itinsync.icom.idocument.role;
using Domains.itinsync.icom.idocument.route;
using Domains.itinsync.icom.idocument.routeusers;
using Domains.itinsync.icom.signature;

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

        public XDocumentRole documentRole = new XDocumentRole();
        public List<XDocumentRole> documentRolelist = new List<XDocumentRole>();

        public XDocumentRoute documentRoute = new XDocumentRoute();
        public List<XDocumentRoute> documentRoutelist = new List<XDocumentRoute>();

        public XDocumentRouteUsers documentRouteUsers = new XDocumentRouteUsers();
        public List<XDocumentRouteUsers> documentRouteUserslist = new List<XDocumentRouteUsers>();

        public Signature signature = new Signature();
        public List<Signature> signaturelist = new List<Signature>();

        public List<Douments> documentList = new List<Douments>();
        public ErrorBlock errorBlock = new ErrorBlock();
        public Header header = new Header();
        public ErrorBlock getErrorBlock() { return errorBlock; }
        public Header getHeader() { return header; }
        public object getResponseMessage() { return this; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.icom.interfaces.request;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.error;
using Domains.itinsync.icom.views.routeusers;


namespace Services.icom.views.routeusers.dto
{
    public class DocumentRouteUsersDTO : IRequestHandler, IResponseHandler
    {
        public XDocumentRouteUsersView xdocumentRouteUsers = new XDocumentRouteUsersView();
        public List<XDocumentRouteUsersView> xdocumentRouteUserslist = new List<XDocumentRouteUsersView>();

        public ErrorBlock errorBlock = new ErrorBlock();
        public Header header = new Header();
        public ErrorBlock getErrorBlock() { return errorBlock; }
        public Header getHeader() { return header; }
        public object getResponseMessage() { return this; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domains.itinsync.icom.interfaces.request;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.error;
using Domains.itinsync.icom.views.emailroutingview;

namespace Services.icom.emailroutingview.dto
{
    public class EmailRoutingDTO : IRequestHandler, IResponseHandler
    {
        public string READBY { get; set; }
        public string UPDATEBY { get; set; }

        public EmailRouting emailRouting = new EmailRouting();
        public List<EmailRouting> emailRoutinglist = new List<EmailRouting>();

        public ErrorBlock errorBlock = new ErrorBlock();
        public Header header = new Header();
        public ErrorBlock getErrorBlock() { return errorBlock; }
        public Header getHeader() { return header; }
        public object getResponseMessage() { return this; }
    }
}

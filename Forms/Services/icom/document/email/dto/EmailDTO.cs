using Domains.itinsync.icom.interfaces.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.interfaces.email;
using Domains.itinsync.icom.interfaces.document;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.error;

namespace Services.icom.document.email.dto
{
    public class EmailDTO : IRequestHandler,IResponseHandler, IEmail
    {
        public Header header { get; set; }
        public IDocument document { get; set; }
        public ErrorBlock errorBlock { get; set; }
        public Header getHeader()
        {
            return header;
        }

        public IDocument getParentref()
        {
            return document;
        }

        public ErrorBlock getErrorBlock()
        {
            return errorBlock;
        }

        public object getResponseMessage()
        {
            return this;
        }
    }
}

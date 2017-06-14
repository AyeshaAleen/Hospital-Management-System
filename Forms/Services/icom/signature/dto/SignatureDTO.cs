using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domains.itinsync.icom.interfaces.request;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.error;
using Domains.itinsync.icom.signature;

namespace Services.icom.signature.dto
{
    public class SignatureDTO : IRequestHandler, IResponseHandler
    {
        public Signature signature = new Signature();
        public List<Signature> signaturelist = new List<Signature>();

        public ErrorBlock errorBlock = new ErrorBlock();
        public Header header = new Header();
        public ErrorBlock getErrorBlock() { return errorBlock; }
        public Header getHeader() { return header; }
        public object getResponseMessage() { return this; }
    }
}

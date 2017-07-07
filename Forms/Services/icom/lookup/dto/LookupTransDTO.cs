using Domains.itinsync.icom.error;
using Domains.itinsync.icom.header;
using Domains.itinsync.icom.interfaces.request;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.lookup.trans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.icom.lookup.dto
{
    public class LookupTransDTO : IRequestHandler, IResponseHandler
    {
        public LookupTrans lookupTrans = new LookupTrans();
        public List<LookupTrans> lookupTranslist = new List<LookupTrans>();

        public ErrorBlock errorBlock = new ErrorBlock();
        public Header header = new Header();
        public ErrorBlock getErrorBlock() { return errorBlock; }
        public Header getHeader() { return header; }
        public object getResponseMessage() { return this; }
    }
}

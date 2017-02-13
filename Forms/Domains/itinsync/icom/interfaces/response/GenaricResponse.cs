using Domains.itinsync.icom.error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.interfaces.response
{
    public class GenaricResponse : IResponseHandler
    {
        public ErrorBlock errorBlock = new ErrorBlock();
        public Object message;
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

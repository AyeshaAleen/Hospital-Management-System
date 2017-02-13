using Domains.itinsync.icom.error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.interfaces.response
{
    public interface IResponseHandler
    {
        ErrorBlock getErrorBlock();
        Object getResponseMessage();
    }
}

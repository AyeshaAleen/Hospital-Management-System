using Domains.itinsync.icom.header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.interfaces.request
{
    public interface IRequestHandler
    {
        Header getHeader();

    }
}

using Domains.itinsync.icom.interfaces.document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.itinsync.icom.interfaces.email
{
    public interface IEmail
    {
         IDocument getParentref();
    }
}

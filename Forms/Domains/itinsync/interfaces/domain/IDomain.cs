using System.Collections.Generic;
using Domains.itinsync.icom.idocument.section;

namespace Domains.itinsync.interfaces.domain
{
    public interface IDomain
    {
        object getKey();
        void setTransID(object transID);
        
    }


}
using DAO.itinsync.icom.BaseAS.frame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.itinsync.icom.interfaces.response;
using Services.itinsync.icom.cache;

namespace Services.icom.cache.frame
{
    public abstract class FrameASCache : FrameAS
    {
        protected override IResponseHandler executeBody(object o)
        {
            throw new NotImplementedException();
        }

        protected override void finalizer(bool status)
        {
            //reload document cache service as we have made content changes
            new CacheManagmentService().executeAsPrimary(null);
        }
    }
}

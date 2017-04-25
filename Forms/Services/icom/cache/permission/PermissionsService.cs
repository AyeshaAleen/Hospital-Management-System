using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.permission;
using Domains.itinsync.icom.interfaces.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.itinsync.icom.cache.permission
{
    public class PermissionsService : FrameAS
    {
        protected override IResponseHandler executeBody(object o)
        {
            IResponseHandler responseHandler = new GenaricResponse();
            PermissionDAO.getInstance(dbContext).load();
            return responseHandler;
        }
    }
}

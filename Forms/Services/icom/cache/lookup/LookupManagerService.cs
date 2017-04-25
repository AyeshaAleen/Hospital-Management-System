using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.lookup;
using Domains.itinsync.icom.interfaces.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom.constant.application;

namespace Services.itinsync.icom.cache.lookup
{
    public class LookupManagerService : FrameAS
    {
        protected override IResponseHandler executeBody(object o)
        {

            IResponseHandler responseHandler = new GenaricResponse();
            string language = ApplicationCodes.DEFAULT_USER_LANG;
            if (o != null && typeof(string).IsAssignableFrom(o.GetType()))
                language = (string)o;

            //LookupDAO.getInstance(dbContext).load();
            LookUpDAO.getInstance(dbContext).load();

            return responseHandler;
        }
    }
}

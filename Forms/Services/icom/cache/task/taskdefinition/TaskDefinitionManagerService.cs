using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.task.taskdefinition;
using Domains.itinsync.icom.interfaces.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.itinsync.icom.cache.task.taskdefinition
{
    public class TaskDefinitionManagerService : FrameAS
    {
        protected override IResponseHandler executeBody(object o)
        {
            IResponseHandler responseHandler = new GenaricResponse();


            TaskDefinitionDAO.getDefInstance(dbContext).load();
            return responseHandler;
        }
    }
}

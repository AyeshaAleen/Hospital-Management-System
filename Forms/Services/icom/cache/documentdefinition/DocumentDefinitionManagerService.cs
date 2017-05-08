using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.task.taskdefinition;
using Domains.itinsync.icom.interfaces.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.itinsync.icom.idocument.definition;
using DAO.itinsync.icom.document.documentdefinitionview;

namespace Services.itinsync.icom.cache.task.taskdefinition
{
    public class DocumentDefinitionManagerService : FrameAS
    {
        protected override IResponseHandler executeBody(object o)
        {
            IResponseHandler responseHandler = new GenaricResponse();


            DocumentContentViewDAO.getDefInstance(dbContext).load();
            return responseHandler;
        }
    }
}

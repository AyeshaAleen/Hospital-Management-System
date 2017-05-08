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
using Domains.itinsync.icom.idocument.section;
using DAO.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table.tr;
using DAO.itinsync.icom.idocument.table.tr;
using DAO.itinsync.icom.idocument.table.td;
using DAO.itinsync.icom.idocument.table.content;
using Domains.itinsync.icom.idocument.table.td;
using Domains.itinsync.icom.idocument.table.content;
using DAO.itinsync.icom.idocument.table.calculation;
using Domains.itinsync.icom.idocument.table.calculation;
using Domains.itinsync.icom.idocument.definition;
using DAO.itinsync.icom.idocument.section;
using Utils.itinsync.icom.cache.global;

namespace Services.itinsync.icom.cache.task.taskdefinition
{
    public class DocumentDefinitionManagerService : FrameAS
    {
        protected override IResponseHandler executeBody(object o)
        {
            IResponseHandler responseHandler = new GenaricResponse();

            XDocumentDefinationDAO.getInstance(dbContext).load();
            
          


            return responseHandler;
        }
    }
}

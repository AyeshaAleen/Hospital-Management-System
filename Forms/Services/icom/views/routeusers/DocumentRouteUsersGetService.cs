using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.views.routeusers;
using Domains.itinsync.icom.interfaces.response;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;
using Services.icom.views.routeusers.dto;

namespace Services.icom.views.routeusers
{
    public class DocumentRouteUsersGetService : FrameAS
    {
        DocumentRouteUsersDTO dto = null;

        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (DocumentRouteUsersDTO)o;

                dto.xdocumentRouteUserslist = XDocumentRouteUsersViewDAO.getInstance(dbContext).findbyDefinitionID(dto.xdocumentRouteUsers.xdocumentdefinitionid);
            }
            catch (Exception ex)
            {
                dto.getErrorBlock().ErrorCode = ApplicationCodes.ERROR;
                dto.getErrorBlock().ErrorText = ApplicationCodes.ERROR_TEXT;
                throw new ItinsyncException(ex, dto.getErrorBlock().ErrorText, dto.getErrorBlock().ErrorCode);
            }
            return dto;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.views.emailroutingview;
using Domains.itinsync.icom.interfaces.response;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;
using Services.icom.emailroutingview.dto;

namespace Services.icom.emailroutingview
{
    public class EmailRoutingGetService:FrameAS
    {
        EmailRoutingDTO dto = null;

        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (EmailRoutingDTO)o;
                if (dto.emailRouting.xdocumentdefinitionid > 0)
                {
                    dto.emailRoutinglist = EmailRoutingDAO.getInstance(dbContext).findbyDefinitionID(dto.emailRouting.xdocumentdefinitionid);
                }

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

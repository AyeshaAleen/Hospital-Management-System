using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.idocument.userRoute;
using Domains.itinsync.icom.interfaces.response;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;
using Services.itinsync.icom.documents.dto;

namespace Services.icom.document
{
    public class DocumentUserRouteSaveService : FrameAS
    {
        DocumentDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (DocumentDTO)o;
                if (dto.documentUserRoute.id > 0)
                {
                    XDocumentUserRouteDAO.getInstance(dbContext).update(dto.documentUserRoute, "");
                }
                else
                {
                    XDocumentUserRouteDAO.getInstance(dbContext).create(dto.documentUserRoute);
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

using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.store;
using DAO.itinsync.icom.views.user;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.views.user;
using Services.icom.document.store.dto;
using Services.icom.views.userstoreview.dto;
using System;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;

namespace Services.icom.views.userstoreview
{
    public class UserStoreViewGetService : FrameAS
    {
        UserStoreViewDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (dto.UserStoreViewDTO)o;
                dto.userStoreViewList = UserStoreViewDAO.getInstance(dbContext).readbyuserID(dto.userstoreview.userid);
                    
                    if (dto.userStoreViewList.Count == 0 && dto.userstoreview.userid == 0)
                    {
                        dto.getErrorBlock().ErrorCode = ApplicationCodes.ERROR;
                        dto.getErrorBlock().ErrorText = ApplicationCodes.ERROR_TEXT + "{USER.STORE.NOT.EXIST}";
                        throw new ItinsyncException(new System.Exception(), dto.getErrorBlock().ErrorText, dto.getErrorBlock().ErrorCode);
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

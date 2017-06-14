using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.useraccounts;
using Domains.itinsync.icom.interfaces.response;
using System;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;

namespace Services.itinsync.icom.useraccounts
{
    public class UserPermissionViewSaveService : FrameAS
    {
        dto.UserPermissionViewDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (dto.UserPermissionViewDTO)o;
                if (dto.userpermissionview.userID > 0)
                {
                    UserPermissionDAO.getInstance(dbContext).update(dto.userpermissionview, "");
                }
                else
                {
                    UserPermissionDAO.getInstance(dbContext).create(dto.userpermissionview);
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
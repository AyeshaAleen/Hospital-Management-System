using DAO.itinsync.icom.BaseAS.frame;
using System;
using Domains.itinsync.icom.interfaces.response;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom.constant.application;
using DAO.itinsync.icom.useraccounts;

namespace Services.itinsync.icom.useraccounts
{
    public class UserPermissionDeleteService : FrameAS
    {
        dto.UserPermissionDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (dto.UserPermissionDTO)o;
                Int32 userPermissionID = dto.userpermission.userPermissionID;
                dto.delete = UserPermissionDAO.getInstance(dbContext).deleteByID(dto.userpermission.userPermissionID);
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
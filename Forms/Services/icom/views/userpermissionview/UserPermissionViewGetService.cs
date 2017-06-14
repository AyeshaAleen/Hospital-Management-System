using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.views;
using Domains.itinsync.icom.interfaces.response;
using System;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;

namespace Services.itinsync.icom.useraccounts
{
    public class UserPermissionViewGetService : FrameAS
    {
        dto.UserPermissionViewDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (dto.UserPermissionViewDTO)o;
                dto.userpermissionviewList = UserPermissionViewDAO.getInstance(dbContext).readbyuserID(dto.userpermissionview.userID);

                if (dto.userpermissionviewList.Count == 0 && dto.userpermissionview.userID == 0)
                    if (dto.userpermissionviewList.Count == 0 && dto.userpermissionview.userID == 0)
                {
                    dto.getErrorBlock().ErrorCode = ApplicationCodes.ERROR;
                    dto.getErrorBlock().ErrorText = ApplicationCodes.ERROR_TEXT + "No such UserPermission exist";
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
using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.permission;
using Domains.itinsync.icom.interfaces.response;
using Services.icom.permission.dto;
using System;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;

namespace Services.icom.permission
{
    public class PermissionGetService : FrameAS
    {
        PermissionDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (PermissionDTO)o;
                if (dto.READBY == ReadByConstant.READBYNAME)
                    dto.permissionList = PermissionDAO.getInstance(dbContext).readbyName(dto.permission.text);
                else if (dto.READBY == ReadByConstant.READBYID)
                    dto.permission = PermissionDAO.getInstance(dbContext).findbyPrimaryKey(dto.permission.permissionID);
                else if (dto.READBY == ReadByConstant.READBYALL)
                    dto.permissionList = PermissionDAO.getInstance(dbContext).readAll();
                if (dto.permissionList.Count == 0 && dto.permission == null)
                {
                    dto.getErrorBlock().ErrorCode = ApplicationCodes.ERROR;
                    dto.getErrorBlock().ErrorText = ApplicationCodes.ERROR_TEXT + "No such permission exist";
                    throw new ItinsyncException(new Exception(), dto.getErrorBlock().ErrorText, dto.getErrorBlock().ErrorCode);
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
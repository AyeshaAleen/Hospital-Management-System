using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.useraccounts;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.useraccounts;
using Services.itinsync.icom.useraccounts.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;

namespace Services.itinsync.icom.useraccounts
{
    public class UserPermissionSaveService : FrameAS
    {
        UserPermissionDTO dto = null;   
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                UserPermission userpermission = new UserPermission();
                dto = (UserPermissionDTO)o;
                UserPermission up = dto.userpermission;
                if (!UserPermissionDAO.getInstance(dbContext).permissionExists(dto.userpermission.code, dto.userpermission.userID))
                    UserPermissionDAO.getInstance(dbContext).create(up);
                else
                {
                    dto.getErrorBlock().ErrorCode = ApplicationCodes.ERROR;
                    dto.getErrorBlock().ErrorText = ApplicationCodes.ERROR_TEXT + "{USER.PERMISSION.ALREADY.EXIST}";
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
using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.useraccounts;
using Domains.itinsync.icom.interfaces.response;
using Services.itinsync.icom.useraccounts.dto;
using System;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;

namespace Services.itinsync.icom.useraccounts
{
    public class UserAccountsSaveService : FrameAS
    {
        UserAccountsDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (UserAccountsDTO)o;
                if (dto.useraccounts.userID > 0)
                {
                    UserAccountsDAO.getInstance(dbContext).update(dto.useraccounts, "");
                }
                else
                {
                    UserAccountsDAO.getInstance(dbContext).create(dto.useraccounts);
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
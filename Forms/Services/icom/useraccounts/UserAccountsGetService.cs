using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.useraccounts;
using Domains.itinsync.icom.interfaces.response;
using Services.itinsync.icom.useraccounts.dto;
using System;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;

namespace Services.itinsync.icom.useraccounts
{
    public class UserAccountsGetService : FrameAS
    {
        UserAccountsDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (UserAccountsDTO)o;
                if (dto.READBY == ReadByConstant.READBYUSERNAME)
                    dto.userAccountsList.Add(UserAccountsDAO.getInstance(dbContext).readByUserName(dto.useraccounts.userName));
                else if (dto.READBY == ReadByConstant.READBYID)
                    dto.useraccounts = UserAccountsDAO.getInstance(dbContext).findByPrimaryKey(dto.useraccounts.userID);
                else
                    dto.userAccountsList = UserAccountsDAO.getInstance(dbContext).readAll() ;
                if (dto.userAccountsList.Count == 0 && dto.useraccounts.userID ==0)
                {
                    dto.getErrorBlock().ErrorCode = ApplicationCodes.ERROR;
                    dto.getErrorBlock().ErrorText = ApplicationCodes.ERROR_TEXT + "{USER.ACCOUNT.NOT.EXIST}";
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
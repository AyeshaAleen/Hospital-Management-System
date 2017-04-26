
using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.useraccounts;
using Domains.itinsync.icom.interfaces.response;
using Services.itinsync.icom.useraccounts.dto;
using System;
using System.Threading;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.exceptions;

namespace Services.itinsync.icom.useraccounts
{
    public class UserAccountSaveService : FrameAS
    {
        UserAccountsDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (UserAccountsDTO)o;

                if(dto.UPDATEBY==ReadByConstant.READBYUSERID)
                {
                    UserAccountsDAO.getInstance(dbContext).updateuserpassword(dto.useraccounts);
                }
                if (dto.useraccounts.userID > 0 && dto.UPDATEBY != ReadByConstant.READBYUSERID)
                {
                    UserAccountsDAO.getInstance(dbContext).update(dto.useraccounts, "");
                }
                else if(dto.useraccounts.userID==0)
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
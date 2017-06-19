using DAO.itinsync.icom.BaseAS.frame;
using domains.itinsync.useraccounts;
using Domains.itinsync.useraccounts;
using Domains.itinsync.icom.interfaces.response;
using Services.itinsync.icom.useraccounts.dto;
using System;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;
using Services.icom.useraccounts.DTO;
using DAO.itinsync.icom.useraccounts;

namespace Services.icom.useraccounts
{
    public class UserStoreSaveService : FrameAS
    {
        UserStoreDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                //UserStore userstore = new UserStore();
                dto = (UserStoreDTO)o;

                //UserTeam up = dto.userteam;
                if (!UserStoreDAO.getInstance(dbContext).storeExists(dto.userstore.storeid, dto.userstore.userid))
                    UserStoreDAO.getInstance(dbContext).create(dto.userstore);
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

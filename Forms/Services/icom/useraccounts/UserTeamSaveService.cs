using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.userteam;
using domains.itinsync.useraccounts;
using Domains.itinsync.icom.interfaces.response;

using Services.itinsync.icom.useraccounts.dto;
using System;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;

namespace Services.itinsync.icom.useraccounts
{
    public class UserTeamSaveService : FrameAS
    {
        UserTeamDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                UserTeam userteam = new UserTeam();
                dto = (UserTeamDTO)o;
                UserTeam up = dto.userteam;
                if (!UserTeamDAO.getInstance(dbContext).teamExists(dto.userteam.teamID, dto.userteam.userID))
                    UserTeamDAO.getInstance(dbContext).create(up);
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
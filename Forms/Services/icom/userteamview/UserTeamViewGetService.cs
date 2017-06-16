using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.team;
using DAO.itinsync.icom.views;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.views.user;
using Services.itinsync.icom.team.dto;
using Services.itinsync.icom.userteamview.dto;
using System;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;

namespace Services.itinsync.icom.userteamview
{
    public class UserTeamViewGetService : FrameAS
    {
        dto.UserTeamViewDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (dto.UserTeamViewDTO)o;
                dto.userTeamViewList = UserTeamViewDAO.getInstance(dbContext).readbyuserID(dto.userteamview.userID);

                if (dto.userTeamViewList.Count == 0 && dto.userteamview.userID == 0)
                    if (dto.userTeamViewList.Count == 0 && dto.userteamview.userID == 0)
                    {
                        dto.getErrorBlock().ErrorCode = ApplicationCodes.ERROR;
                        dto.getErrorBlock().ErrorText = ApplicationCodes.ERROR_TEXT + "{USER.TEAM.NOT.EXIST}";
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
using System;
using Domains.itinsync.icom.interfaces.response;
using Services.itinsync.icom.team.dto;
using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.team;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;

//Created By Qundeel Ch

namespace Services.itinsync.icom.team
{
    public class TeamSaveService : FrameAS
    {
        TeamDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (TeamDTO) o;
                if (dto.team.teamID > 0)
                {
                    TeamDAO.getInstance(dbContext).update(dto.team, "");
                }
                else
                {
                    TeamDAO.getInstance(dbContext).create(dto.team);
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
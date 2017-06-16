using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.team;
//using DAO.itinsync.icom.vendor;
using Domains.itinsync.icom.interfaces.response;
using Services.itinsync.icom.team.dto;
//using Services.itinsync.icom.vendor.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;

//Created By Qundeel Ch

namespace Services.itinsync.icom.team
{
    public class TeamGetService : FrameAS
    {
        TeamDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (TeamDTO)o;
                if (dto.READBY == ReadByConstant.READBYNAME)
                    dto.teamList = TeamDAO.getInstance(dbContext).readbyName(dto.team.teamName);
                else if (dto.READBY == ReadByConstant.READBYID)
                    dto.team = TeamDAO.getInstance(dbContext).findbyPrimaryKey(dto.team.teamID);
                else if (dto.READBY == ReadByConstant.READBYALL)
                    dto.teamList = TeamDAO.getInstance(dbContext).readAll();
                if (dto.teamList.Count == 0 && dto.team == null)
                {
                    dto.getErrorBlock().ErrorCode = ApplicationCodes.ERROR;
                    dto.getErrorBlock().ErrorText = ApplicationCodes.ERROR_TEXT + "{TEAM.NOT.EXIST}";
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
using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.userteam;
using Domains.itinsync.icom.interfaces.response;
using Services.itinsync.icom.useraccounts.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;

namespace Services.itinsync.icom.userteam
{
    public class UserTeamGetService : FrameAS
    {
        UserTeamDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (UserTeamDTO)o;
               /* if (dto.READBY == ReadByConstant.READBYUSERNAME)
                    dto.userTeamList.Add(UserTeamDAO.getInstance(dbContext).readByTeamName(dto.userTeam.teamName));
                else if (dto.READBY == ReadByConstant.READBYID)
                    dto.userteam = UserTeamDAO.getInstance(dbContext).findByPrimaryKey(dto.userteam.userID);*/
                if (dto.userTeamList.Count == 0 && dto.userteam.userID == 0)
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
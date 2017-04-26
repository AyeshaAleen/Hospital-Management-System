using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.useraccounts;
using DAO.itinsync.icom.userteam;
using Domains.itinsync.icom.interfaces.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;

namespace Services.itinsync.icom.useraccounts
{
    public class UserTeamDeleteService : FrameAS
    {
        dto.UserTeamDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (dto.UserTeamDTO)o;
                Int32 userTeamID = dto.userteam.userTeamID;
                dto.delete = UserTeamDAO.getInstance(dbContext).deleteByID(dto.userteam.userTeamID);
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
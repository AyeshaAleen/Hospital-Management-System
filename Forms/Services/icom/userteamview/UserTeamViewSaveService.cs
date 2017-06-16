using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.views;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.views.user;
using Services.itinsync.icom.userteamview.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;

namespace Services.itinsync.icom.userteamview
{
    public class UserTeamViewSaveService : FrameAS
    {
        UserTeamViewDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                UserTeamView userteamview = new UserTeamView();
                dto = (UserTeamViewDTO)o;
                UserTeamView up = dto.userteamview;
                UserTeamViewDAO.getInstance(dbContext).create(up);
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
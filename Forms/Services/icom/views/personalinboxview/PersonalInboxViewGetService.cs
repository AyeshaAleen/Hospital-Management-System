using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.views;
using Domains.itinsync.icom.interfaces.response;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;
using Services.icom.views.personalinboxview.dto;

namespace Services.icom.views.personalinboxview
{
    public class PersonalInboxViewGetService : FrameAS
    {
        PersonalInboxViewDTO dto = null;

        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (PersonalInboxViewDTO)o;
                dto.personalinboxviewList = PersonalInboxViewDAO.getInstance(dbContext).readByUseridWithStatus(dto.personalinboxview.userid, dto.personalinboxview.status);

                if (dto.personalinboxviewList.Count==0)
                    {
                        dto.getErrorBlock().ErrorCode = ApplicationCodes.ERROR;
                        dto.getErrorBlock().ErrorText = ApplicationCodes.ERROR_TEXT + "No such Document exist";
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

﻿using DAO.itinsync.icom.BaseAS.frame;
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
using Services.icom.useraccounts.DTO;

namespace Services.icom.useraccounts
{
    public class UserStoreDeleteService : FrameAS
    {
        UserStoreDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (UserStoreDTO)o;
                //Int32 userTeamID = dto.userteam.userTeamID;
                UserStoreDAO.getInstance(dbContext).deleteByID(dto.userstore.userstoreid);
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
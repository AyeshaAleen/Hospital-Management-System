﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.idocument.routeusers;
using Domains.itinsync.icom.interfaces.response;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;
using Services.itinsync.icom.documents.dto;

namespace Services.itinsync.icom.document.dynamic.routeusers
{
    public class DocumentRouteUsersGetService : FrameAS
    {
        DocumentDTO dto = null;

        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (DocumentDTO)o;

                dto.documentRouteUserslist = XDocumentRouteUsersDAO.getInstance(dbContext).findbyDefinitionID(dto.documentRouteUsers.xdocumentdefinitionid);
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
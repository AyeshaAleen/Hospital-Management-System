﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.signature;
using Domains.itinsync.icom.interfaces.response;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;
using Services.icom.signature.dto;

namespace Services.icom.signature
{
    public class SignatureGetService : FrameAS
    {
        SignatureDTO dto = null;

        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (SignatureDTO)o;
                dto.signaturelist = SignatureDAO.getInstance(dbContext).findbyDocumentid(dto.signature.documentid);
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

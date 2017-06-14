using DAO.itinsync.icom.BaseAS.frame;
using System;
using System.Collections.Generic;
using Domains.itinsync.icom.interfaces.response;
using Services.icom.document.store.dto;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;
using DAO.itinsync.icom.store;

namespace Services.icom.document.email
{
    
   public class StoreGetService : FrameAS
    {
        private StoreDTO dto=null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (StoreDTO)o;
                    dto.storelist = StoreDAO.getInstance(dbContext).readAll();

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

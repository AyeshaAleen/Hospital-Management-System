using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.store;
using Domains.itinsync.icom.interfaces.response;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;
using Services.icom.document.store.dto;

namespace Services.icom.document.store
{
    public class StoreDeleteService : FrameAS
    {
        StoreDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (StoreDTO)o;
                if (dto.store.storeid > 0)
                    StoreDAO.getInstance(dbContext).deleteByID(dto.store.storeid);
                
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

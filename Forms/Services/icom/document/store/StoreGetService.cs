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
    public class StoreGetService : FrameAS
    {
        StoreDTO dto = null;

        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (StoreDTO)o;
                if (dto.store.storeid > 0)
                    dto.store = StoreDAO.getInstance(dbContext).findbyPrimaryKey(dto.store.storeid);

                else if (dto.READBY == ReadByConstant.READBYUSERNAME)
                    dto.store = StoreDAO.getInstance(dbContext).findbyName(dto.store.name);

                else if(dto.READBY==ReadByConstant.READBYALL)
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

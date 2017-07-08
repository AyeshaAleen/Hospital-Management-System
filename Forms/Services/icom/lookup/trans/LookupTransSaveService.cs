using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.icom.lookup.dto;
using Domains.itinsync.icom.interfaces.response;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;
using DAO.itinsync.icom.lookup.trans;
using DAO.itinsync.icom.BaseAS.frame;

namespace Services.icom.lookup.trans
{
    public class LookupTransSaveService : FrameAS
    {
        LookupTransDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (LookupTransDTO)o;
                if (dto.lookupTrans.lookupTransID > 0)
                {
                    LookupTransDAO.getInstance(dbContext).update(dto.lookupTrans, "");
                }
                else
                {
                    LookupTransDAO.getInstance(dbContext).create(dto.lookupTrans);
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

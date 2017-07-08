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
using DAO.itinsync.icom.lookup;

namespace Services.icom.lookup.trans
{
    public class LookupSaveService : FrameAS
    {
        LookupDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (LookupDTO)o;
                if (dto.lookup.lookUpID > 0)
                {
                    LookUpDAO.getInstance(dbContext).update(dto.lookup, "");
                }
                else
                {
                    LookUpDAO.getInstance(dbContext).create(dto.lookup);
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

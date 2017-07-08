
using DAO.itinsync.icom.BaseAS.frame;
using DAO.itinsync.icom.useraccounts;
using Domains.itinsync.icom.interfaces.response;
using Services.itinsync.icom.useraccounts.dto;
using System;
using System.Threading;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.exceptions;
using Services.itinsync.icom.documents.dto;
using DAO.itinsync.icom.idocument;
using DAO.itinsync.icom.idocument.section;
using Services.itinsync.icom.cache;
using Services.icom.cache.frame;
using DAO.itinsync.icom.pages;
using Services.itinsync.icom.document.dynamic.section;

namespace Services.itinsync.icom.document.dynamic.page
{
    public class DocumentPageSaveService : FrameASCache
    {
        DocumentDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (DocumentDTO)o;
                if (dto.page.pageID > 0)
                {

                    PageNameDAO.getInstance(dbContext).update(dto.page, "");
                }
                else
                {

                   dto.documentSection.pageID= PageNameDAO.getInstance(dbContext).create(dto.page);
                }

                new DocumentSectionSaveService().executeAsSecondary(dto, dbContext);

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
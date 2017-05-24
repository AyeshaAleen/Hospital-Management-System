
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
using DAO.itinsync.icom.idocument.definition;

namespace Services.itinsync.icom.documents
{
    public class documentSaveService : FrameAS
    {
        DocumentDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (DocumentDTO)o;
                if (dto.document.documentID > 0)
                {
                    DocumentDAO.getInstance(dbContext).update(dto.document, "");
                }
                else
                {
                    dto.documentDefination.name = dto.document.documentName;
                    dto.document.documentDefinitionID = XDocumentDefinationDAO.getInstance(dbContext).findbyDocumentName(dto.document.documentName).xDocumentDefinationID;

                    dto.document.documentID = DocumentDAO.getInstance(dbContext).create(dto.document);
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
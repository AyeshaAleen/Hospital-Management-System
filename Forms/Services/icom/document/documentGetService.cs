using DAO.itinsync.icom.BaseAS.frame;

using Domains.itinsync.icom.interfaces.response;
using System;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;
using Services.itinsync.icom.documents.dto;
using DAO.itinsync.icom.idocument;
using DAO.itinsync.icom.idocument.definition;



//Created By Qundeel Ch

namespace Services.itinsync.icom.documents
{
    public class DocumentGetService : FrameAS
    {
        DocumentDTO dto = null;

        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (DocumentDTO)o;
                if (dto.document.storeid > 0)
                {
                    dto.document = DocumentDAO.getInstance(dbContext).readybyDocumentDefinitionID(dto.document.documentDefinitionID, dto.document.storeid);
                    dto.document.xdocumentDefinition = XDocumentDefinationDAO.getInstance(dbContext).findbyPrimaryKey(dto.document.documentDefinitionID);
                }
                dto.documentList = DocumentDAO.getInstance(dbContext).readAll();
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
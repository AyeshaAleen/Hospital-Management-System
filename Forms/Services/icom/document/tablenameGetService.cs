using DAO.itinsync.icom.BaseAS.frame;

using Domains.itinsync.icom.interfaces.response;
using System;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom.constant.audit;
using Services.itinsync.icom.documents.dto;


//Created By Qundeel Ch

namespace Services.itinsync.icom.documents
{
    public class tablenameGetService : FrameAS
    {
        DocumentDTO dto = null;

        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (DocumentDTO)o;
               // dto.pagenamelist = pagenameDAO.getInstance(dbContext).readAll();
                //dto.document = DocumentDAO.getInstance(dbContext).readybyDocumentName(dto.document.documentName);
                //dto.document.xdocumentDefinition = XDocumentDefinationDAO.getInstance(dbContext).findbyPrimaryKey(dto.document.documentDefinitionID);
               
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
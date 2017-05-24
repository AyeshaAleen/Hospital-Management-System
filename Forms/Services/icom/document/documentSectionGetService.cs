using DAO.itinsync.icom.BaseAS.frame;

using Domains.itinsync.icom.interfaces.response;
using System;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;
using Services.itinsync.icom.documents.dto;

using DAO.itinsync.icom.idocument.section;


//Created By Qundeel Ch

namespace Services.itinsync.icom.documents
{
    public class documentSectionGetService : FrameAS
    {
        DocumentDTO dto = null;

        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (DocumentDTO)o;

                dto.documentDefination.documentSections = XDocumentSectionDAO.getInstance(dbContext).readyByDocumentDefinitionID(dto.documentDefination.xDocumentDefinationID);




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
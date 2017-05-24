using DAO.itinsync.icom.BaseAS.frame;

using Domains.itinsync.icom.interfaces.response;
using System;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;
using Utils.itinsync.icom.constant.audit;
using Services.itinsync.icom.documents.dto;
using DAO.itinsync.icom.idocument;
using DAO.itinsync.icom.idocument.definition;
using DAO.itinsync.icom.idocument.section;
using Domains.itinsync.icom.idocument.section;
using DAO.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table;
using DAO.itinsync.icom.idocument.table.tr;
using Domains.itinsync.icom.idocument.table.tr;
using DAO.itinsync.icom.idocument.table.td;
using Domains.itinsync.icom.idocument.table.td;
using DAO.itinsync.icom.idocument.table.content;
using Domains.itinsync.icom.idocument.table.content;
using DAO.itinsync.icom.idocument.table.calculation;
using Domains.itinsync.icom.idocument.table.calculation;


//Created By Qundeel Ch

namespace Services.itinsync.icom.documents
{
    public class documentDefinitionGetService : FrameAS
    {
        DocumentDTO dto = null;

        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (DocumentDTO)o;

                //dto.document = DocumentDAO.getInstance(dbContext).readybyDocumentName(dto.document.documentName);
                dto.documentDefinationlist = XDocumentDefinationDAO.getInstance(dbContext).readAll();
               
                

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
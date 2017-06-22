using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domains.itinsync.icom.idocument;
using Domains.itinsync.icom.interfaces.response;
using Forms.itinsync.src.session;
using Services.itinsync.icom.documents;
using Services.itinsync.icom.documents.dto;
using Utils.itinsync.icom.date;

namespace Forms.itinsync.src.session
{
    public class DocumentBasePage:BasePage
    {
        public IResponseHandler saveDocument(string xml, int documentid, int DocumentFlow,string status)
        {
            //need to move below code in genaric class as we need to call it from various point with same information
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document.documentDefinitionID = ((Douments)getParentRef()).xdocumentDefinition.xDocumentDefinationID;
            dto.document.transDate = DateFunctions.getCurrentDateAsString();
            dto.document.transTime = DateFunctions.getCurrentTimeInMillis();
            dto.document.data = xml;
            dto.document.Userid = getHeader().userID;
            dto.document.status = status;
            dto.document.storeid = ((Douments)getParentRef()).storeid;
            dto.document.documentID = documentid;
            dto.document.flow = DocumentFlow;
            IResponseHandler response = new DocumentSaveService().executeAsPrimary(dto);
            return response;

        }
    }
}
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
using Domains.itinsync.icom.idocument.section;
using static Forms.itinsync.src.session.Session;
using Utils.itinsync.icom.constant.application;
using Domains.itinsync.icom.idocument.definition;
using Utils.itinsync.icom.cache.document;

namespace Forms.itinsync.src.session
{
    public class DocumentBasePage:BasePage
    {
        public IResponseHandler saveDocument(string xml, int documentid, int documentFlow,string status)
        {
            //need to move below code in genaric class as we need to call it from various point with same information
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document.documentDefinitionID = ((Douments)getParentRef()).xdocumentDefinition.xDocumentDefinationID;
            dto.document.xdocumentDefinition = DocumentManager.getDocumentDefinition(dto.document.documentDefinitionID);
            dto.document.transDate = DateFunctions.getCurrentDateAsString();
            dto.document.transTime = DateFunctions.getCurrentTimeInMillis();
            dto.document.data = xml;
            dto.document.Userid = getHeader().userID;
            dto.document.status = status;
            dto.document.storeid = ((Douments)getParentRef()).storeid;
            dto.document.documentID = documentid;
            dto.document.flow = documentFlow;
            dto.document.documentName = ((Douments)getParentRef()).documentName;
           IResponseHandler response = new DocumentSaveService().executeAsPrimary(dto);
            // update parentref in each section so that session data will update with latest one
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                setParentRef(dto.document);
                XDocumentDefination documentDefinition = ((Douments)getParentRef()).xdocumentDefinition;


                //getParentRef().prvis.grade
                for(int i=1;i<= documentDefinition.documentSections.Count;i++)
                {
                XDocumentSection section = documentDefinition.documentSections.Where(c => c.flow.Equals(getSection().flow + i)).SingleOrDefault();
                    if(section.status==ApplicationCodes.DOCUMENT_STATUS_ACTIVE)
                    {
                        setSection(section);
                        break;
                    }
                }
                

                //setSection(documentDefinition.documentSections.Where(c => c.flow.Equals(getSection().flow + 1)).SingleOrDefault());

            }
            return response;

        }

        public XDocumentSection getSection()
        {
            return (XDocumentSection)Sessions.getSession().Get(SessionKey.SECTION);
        }

        public void setSection(XDocumentSection section)
        {
            Sessions.getSession().Set(SessionKey.SECTION, section);
        }


    }
}
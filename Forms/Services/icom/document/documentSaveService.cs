
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
using System.Xml;

namespace Services.itinsync.icom.documents
{
    public class DocumentSaveService : FrameAS
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
                  
                    dto.document.documentName = XDocumentDefinationDAO.getInstance(dbContext).findbyPrimaryKey(dto.document.documentDefinitionID).name;


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


        private void SetDocumentData(string Data)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Data);

            XmlDocument docFinal = new XmlDocument();
            docFinal.LoadXml(dto.document.data);
            XmlNodeList elemListfinal = docFinal.GetElementsByTagName("GeneralSIO");

            XmlNodeList elemList = doc.GetElementsByTagName("GeneralSIO");
            if (elemList != null)
            {
                XmlNode mynode = elemList.Item(0);
                XmlNode mynodechild = elemListfinal.Item(0);

                foreach (XmlNode parentnode in mynode.ChildNodes)
                {
                    
                    // setControlValues(parent, childnode.Name, childnode.InnerText);

                   
                }

                
              
            }
        }



    }
}
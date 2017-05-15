
using DAO.itinsync.icom.BaseAS.frame;
using Domains.itinsync.icom.interfaces.response;
using System;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.exceptions;
using DAO.itinsync.icom.idocument;
using DAO.itinsync.icom.idocument.definition;
using Services.itinsync.icom.tablecontent.dto;
using DAO.itinsync.icom.idocument.section;
using Domains.itinsync.icom.idocument.table;
using DAO.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table.tr;
using Domains.itinsync.icom.idocument.table.td;
using Domains.itinsync.icom.idocument.table.content;
using DAO.itinsync.icom.idocument.table.tr;
using DAO.itinsync.icom.idocument.table.td;
using DAO.itinsync.icom.idocument.table.content;

namespace Services.itinsync.icom.tablecontent
{
    public class tablecontentSaveService : FrameAS
    {
        tablecontentDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (tablecontentDTO)o;

                dto.documentDefination.name = dto.document.documentName;
                dto.document.documentDefinitionID = XDocumentDefinationDAO.getInstance(dbContext).findbyDocumentName(dto.document.documentName).xDocumentDefinationID;

               
                    DocumentDAO.getInstance(dbContext).create(dto.document);
                


                #region Create Table

                if (dto.documentTable != null)
                {
                   // dto.documentTable.documentsectionid = dto.documentSection.documentsectionid;
                    dto.documentTable.documentTableID = XDocumentTableDAO.getInstance(dbContext).create(dto.documentTable);
                }

                #endregion

                #region Create Other Data

                if (dto.documentTableTRlist != null && dto.documentTableTRlist.Count > 0)
                {
                    foreach (XDocumentTableTR obj_DocumentTableTR in dto.documentTableTRlist)
                    {
                        #region Create Table TR

                        obj_DocumentTableTR.documentTableID = dto.documentTable.documentTableID;
                        dto.documentTableTR.trID = XDocumentTableTRDAO.getInstance(dbContext).create(obj_DocumentTableTR);

                        #endregion

                        if (dto.documentTableTDlist != null && dto.documentTableTDlist.Count > 0)
                        {
                            foreach (XDocumentTableTD obj_DocumentTableTD in dto.documentTableTDlist)
                            {
                                #region Create Table TD

                                obj_DocumentTableTD.trID = dto.documentTableTR.trID;
                                dto.documentTableTD.tdID = XDocumentTableTDDAO.getInstance(dbContext).create(obj_DocumentTableTD);

                                #endregion

                                #region Create Table TD Content

                                if (dto.documentTableContentlist != null && dto.documentTableContentlist.Count > 0)
                                {
                                    foreach (XDocumentTableContent obj_DocumentTableContent in dto.documentTableContentlist)
                                    {
                                        obj_DocumentTableContent.tdID = dto.documentTableTD.tdID;
                                        dto.documentTableContent.documentTableContentID = XDocumentTableContentDAO.getInstance(dbContext).create(obj_DocumentTableContent);
                                    }
                                }

                                #endregion
                            }
                        }


                    }
                }
                #endregion





                if (dto.document.documentID > 0)
                {
                    DocumentDAO.getInstance(dbContext).update(dto.document, "");
                }
                else
                {

                    DocumentDAO.getInstance(dbContext).create(dto.document);
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

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
using Domains.itinsync.icom.idocument.definition;

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

                
               // XDocumentDefination documentDefinition = XDocumentDefinationDAO.getInstance(dbContext).findbyDocumentName(dto.documentdefinitionName);

                #region check is document exist

                #endregion
                

                #region Create Table

                if (dto.documentTable != null)
                {
                    dto.documentTable.documentTableID = XDocumentTableDAO.getInstance(dbContext).create(dto.documentTable);
                }

                #endregion

                #region Create Other Data

                if (dto.documentTable.trs != null && dto.documentTable.trs.Count > 0)
                {
                    foreach (XDocumentTableTR tr in dto.documentTable.trs)
                    {
                        #region Create Table TR

                        tr.documentTableID = dto.documentTable.documentTableID;
                        tr.trID = XDocumentTableTRDAO.getInstance(dbContext).create(tr);

                        #endregion

                        if (tr.tds != null && tr.tds.Count > 0)
                        {
                            foreach (XDocumentTableTD td in tr.tds)
                            {
                                #region Create Table TD

                                td.trID = tr.trID;
                                td.tdID = XDocumentTableTDDAO.getInstance(dbContext).create(td);

                                #endregion

                                #region Create Table TD Content

                                if (td.fields != null)
                                {
                                    if (td.fields.Count > 0)
                                    {
                                        foreach (XDocumentTableContent field in td.fields)
                                        {
                                            field.tdID = td.tdID;
                                            field.documentTableContentID = XDocumentTableContentDAO.getInstance(dbContext).create(field);
                                        }
                                    }
                                }

                                #endregion
                            }
                        }


                    }
                }
                #endregion





                
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
﻿using DAO.itinsync.icom.BaseAS.frame;

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
    public class DocumentGetService : FrameAS
    {
        DocumentDTO dto = null;

        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (DocumentDTO)o;

                dto.document = DocumentDAO.getInstance(dbContext).readybyDocumentName(dto.document.documentName);
                dto.document.xdocumentDefinition = XDocumentDefinationDAO.getInstance(dbContext).findbyPrimaryKey(dto.document.documentDefinitionID);
                dto.document.xdocumentDefinition.documentSections = XDocumentSectionDAO.getInstance(dbContext).readyByDocumentDefinitionID(dto.document.documentDefinitionID);

                foreach (XDocumentSection section in dto.document.xdocumentDefinition.documentSections)
                {
                    section.documentTable = XDocumentTableDAO.getInstance(dbContext).readbySectionID(section.documentsectionid);

                    foreach (XDocumentTable table in section.documentTable)
                    {
                        table.trs = XDocumentTableTRDAO.getInstance(dbContext).readbyTableID(table.documentTableID);

                        foreach (XDocumentTableTR tr in table.trs)
                        {
                            tr.tds = XDocumentTableTDDAO.getInstance(dbContext).readbyTRID(tr.trID);

                            foreach (XDocumentTableTD td in tr.tds)
                            {
                                td.fields = XDocumentTableContentDAO.getInstance(dbContext).readbyTDID(td.tdID);

                                foreach (XDocumentTableContent content in td.fields)
                                {
                                    content.calculations = XDocumentCalculationDAO.getInstance(dbContext).readbyContentID(content.documentTableContentID);

                                    foreach (XDocumentCalculation calculation in content.calculations)
                                    {
                                        calculation.fieldContent = content;
                                        calculation.resultContent = XDocumentTableContentDAO.getInstance(dbContext).findByPrimaryKey(calculation.resultContentID);
                                    }
                                }


                            }

                        }
                    }

                }

                //dto.document = DocumentDAO.getInstance(dbContext).readybyDocumentName(dto.document.documentName);
                //dto.document.xdocumentDefinition = XDocumentDefinationDAO.getInstance(dbContext).findbyPrimaryKey(dto.document.documentDefinitionID);
                //dto.document.xdocumentDefinition.documentSections =XDocumentSectionDAO.getInstance(dbContext).readyByDocumentDefinitionID(dto.document.documentDefinitionID);

                //foreach (XDocumentSection section in dto.document.xdocumentDefinition.documentSections )
                //{
                //    section.documentTable = XDocumentTableDAO.getInstance(dbContext).readbySectionID(section.documentsectionid);

                //    foreach (XDocumentTable table in section.documentTable)
                //    {
                //        table.trs = XDocumentTableTRDAO.getInstance(dbContext).readbyTableID(table.documentTableID);

                //        foreach (XDocumentTableTR tr in table.trs)
                //        {
                //            tr.tds = XDocumentTableTDDAO.getInstance(dbContext).readbyTRID(tr.trID);

                //            foreach (XDocumentTableTD td in tr.tds)
                //            {
                //                td.fields = XDocumentTableContentDAO.getInstance(dbContext).readbyTDID(td.tdID);

                //                foreach (XDocumentTableContent content in td.fields)
                //                {
                //                    content.calculations = XDocumentCalculationDAO.getInstance(dbContext).readbyContentID(content.documentTableContentID);

                //                    foreach (XDocumentCalculation calculation in content.calculations)
                //                    {
                //                        calculation.fieldContent = content;
                //                        calculation.resultContent = XDocumentTableContentDAO.getInstance(dbContext).findByPrimaryKey(calculation.resultContentID);
                //                    }
                //                }


                //            }

                //        }
                //    }

                //}



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
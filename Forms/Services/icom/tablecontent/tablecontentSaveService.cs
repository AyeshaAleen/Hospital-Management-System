﻿
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
using DAO.itinsync.icom.lookuptrans;
using Domains.itinsync.icom.idocument.table.calculation;
using DAO.itinsync.icom.idocument.table.calculation;

namespace Services.itinsync.icom.tablecontent
{
    public class TableContentSaveService : FrameAS
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

                if (dto.documentTableParse != null)
                {
                    dto.documentTableParse.documentTableID = XDocumentTableDAO.getInstance(dbContext).create(dto.documentTableParse);
                }

                #endregion

                #region Create Other Data

                if (dto.documentTableParse.trs != null && dto.documentTableParse.trs.Count > 0)
                {
                    foreach (XDocumentTableTR tr in dto.documentTableParse.trs)
                    {
                        #region Create Table TR

                        tr.documentTableID = dto.documentTableParse.documentTableID;
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

                                            dto.lookupTrans.code = field.translation;
                                            dto.lookupTrans.value = field.defaultValue;
                                            dto.lookupTrans.lang = "en";

                                            LookupTransDAO.getInstance(dbContext).create(dto.lookupTrans);

                                            if(field.calculations!=null)
                                            {
                                                if(field.calculations.Count>0)
                                                {
                                                    foreach (XDocumentCalculation calculation in field.calculations)
                                                    {
                                                        if (field.controlID == calculation.resultContentAttribute)
                                                            calculation.resultContentID = field.documentTableContentID;
                                                        else
                                                        calculation.documentcontentID = field.documentTableContentID;

                                                        calculation.xdocumentcalculationID= XDocumentCalculationDAO.getInstance(dbContext).create(calculation);
                                                    }
                                                    }
                                            }


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
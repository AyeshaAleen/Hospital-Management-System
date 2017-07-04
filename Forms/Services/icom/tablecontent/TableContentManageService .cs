
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
using Domains.itinsync.icom.idocument.table.calculation;
using DAO.itinsync.icom.idocument.table.calculation;
using DAO.itinsync.icom.lookuptrans;
using Services.itinsync.icom.cache.task.taskdefinition;
using Services.itinsync.icom.cache;
using Services.icom.cache.frame;
using Domains.itinsync.icom.idocument.referedcontent;

namespace Services.itinsync.icom.tablecontent
{
    public class TableContentManageService : FrameASCache
    {
        tablecontentDTO dto = null;
        protected override IResponseHandler executeBody(object o)
        {
            try
            {
                dto = (tablecontentDTO)o;


                #region Delete Table

                dto.documentTablelist = XDocumentTableDAO.getInstance(dbContext).readbySectionID(dto.sectionnID);

                #endregion

                #region Delete Other Data
                if (dto.documentTablelist != null && dto.documentTablelist.Count>0)
                {
                    foreach (XDocumentTable table in dto.documentTablelist)
                    {

                        XDocumentTableDAO.getInstance(dbContext).deleteByID(table.documentTableID);

                        dto.documentTable.trs = XDocumentTableTRDAO.getInstance(dbContext).readbyTableID(table.documentTableID);

                        foreach (XDocumentTableTR tr in dto.documentTable.trs)
                        {
                            XDocumentTableTRDAO.getInstance(dbContext).deleteByID(tr.trID);


                            tr.tds = XDocumentTableTDDAO.getInstance(dbContext).readbyTRID(tr.trID);
                            foreach (XDocumentTableTD td in tr.tds)
                            {
                                XDocumentTableTDDAO.getInstance(dbContext).deleteByID(td.tdID);

                                td.fields = XDocumentTableContentDAO.getInstance(dbContext).readbyTDID(td.tdID);
                                foreach (XDocumentTableContent field in td.fields)
                                {
                                    XDocumentTableContentDAO.getInstance(dbContext).deleteByID(field.documentTableContentID);
                                    //LookupTransDAO.getInstance(dbContext).deleteBytrans(field.translation);

                                    //field.calculations = XDocumentCalculationDAO.getInstance(dbContext).readbyFieldID(field.documentTableContentID);
                                    //foreach (XDocumentCalculation calculation in field.calculations)
                                    //{
                                    //    XDocumentCalculationDAO.getInstance(dbContext).deleteByID(calculation.xdocumentcalculationID);

                                    //}

                                    field.ReferredContent = XDocumentReferedContentDAO.getInstance(dbContext).readbyDocumentContentID(field.documentTableContentID);
                                    
                                    if(field.ReferredContent!=null && field.ReferredContent.referedContentID>0)
                                        XDocumentReferedContentDAO.getInstance(dbContext).deleteByID(field.ReferredContent.referedContentID);

           



                                }
                               

                            }
                          

                        }
                       
                    }

                    #endregion
                }



                new TableContentSaveService().executeAsSecondary(dto,dbContext);


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
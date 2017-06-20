
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
using Domains.itinsync.icom.lookup.lookuptrans;
using System.Collections.Generic;

namespace Services.itinsync.icom.tablecontent
{
    public class TableContentSaveService : FrameAS
    {
        tablecontentDTO dto = null;
		Dictionary<Int32, List<XDocumentCalculation>>  calculationMap =new Dictionary<Int32, List<XDocumentCalculation>>();
		Dictionary<string, XDocumentTableContent>  fieldMap =new Dictionary<string, XDocumentTableContent>();
            
        protected override IResponseHandler executeBody(object o)
        {
            try
            {

                dto = (tablecontentDTO)o;
                
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
                              
                              #region Create Table TD Content
                              if (td.fields != null && td.fields.Count > 0)
                              {

                                    td.trID = tr.trID;
                                    td.tdID = XDocumentTableTDDAO.getInstance(dbContext).create(td);
                                    
                                    foreach (XDocumentTableContent field in td.fields)
                                    {
                                        translation(field);
                                        field.tdID = td.tdID;
                                        field.documentTableContentID = XDocumentTableContentDAO.getInstance(dbContext).create(field);
										
                                       
										calculationMap.Add(field.documentTableContentID,field.calculations);
										fieldMap.Add(field.controlID,field);
                                        
                                           
                                    }
                              }
                                #endregion
                            }
                        }
                    }
                }
                #endregion
				
				//docalculation();
            }
            catch (Exception ex)
            {
                dto.getErrorBlock().ErrorCode = ApplicationCodes.ERROR;
                dto.getErrorBlock().ErrorText = ApplicationCodes.ERROR_TEXT;
                throw new ItinsyncException(ex, dto.getErrorBlock().ErrorText, dto.getErrorBlock().ErrorCode);
            }
            return dto;
        }

        private void translation(XDocumentTableContent field)
        {
            if (!string.IsNullOrEmpty(field.translation))
            {
                dto.lookupTrans.code = field.translation;
                dto.lookupTrans.value = field.defaultValue;
                dto.lookupTrans.lang = "en";
                if (LookupTransDAO.getInstance(dbContext).translationExists(field.defaultValue, "en"))
                {
                    LookupTrans trans = LookupTransDAO.getInstance(dbContext).findbyTranslcation(field.defaultValue, "en");
                    field.translation = trans.code;
                    field.defaultValue = trans.value;
                }
                else
                    LookupTransDAO.getInstance(dbContext).create(dto.lookupTrans);
            }
        }

        private void docalculation()
        {

          
		  foreach(Int32 documentTableContentID in calculationMap.Keys)
		  {
			 foreach (XDocumentCalculation calculation in calculationMap[documentTableContentID])
			 {
					//here you find resultant ID
					calculation.resultContentID = fieldMap[calculation.resultContentAttribute].documentTableContentID;

                    calculation.documentcontentID = documentTableContentID;
                    //now write code for Create calculation object here

                    XDocumentCalculationDAO.getInstance(dbContext).create(calculation);
                }
		  }
               
            
        }

    }
}
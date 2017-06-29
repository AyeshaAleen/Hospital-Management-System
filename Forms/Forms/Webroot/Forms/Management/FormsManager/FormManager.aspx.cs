using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table.content;
using Domains.itinsync.icom.idocument.table.td;
using Domains.itinsync.icom.idocument.table.tr;
using Domains.itinsync.icom.interfaces.response;
using Forms.itinsync.src.session;
using HtmlAgilityPack;
using Services.itinsync.icom.documents;
using Services.itinsync.icom.documents.dto;
using Services.itinsync.icom.tablecontent;
using Services.itinsync.icom.tablecontent.dto;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.date;
using Utils.itinsync.icom.xml;
using Utils.itinsync.icom;
using Utils.itinsync.icom.html;
using Utils.itinsync.icom.cache.document;

namespace Forms.Webroot.Forms.Management.FormsManager
{
    public partial class FormsManager : BasePage
    {



        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                loadDropDown();
                FormName.Value = ((XDocumentDefination)getParentRef()).name;
                SectionName.Value = DocumentManager.getDocumentSection(Convert.ToInt32(getSubjectID())).name;
                string test = (DocumentManager.getDocumentSectionFieldCount(Convert.ToInt32(getSubjectID()), ((XDocumentDefination)getParentRef()).xDocumentDefinationID)).ToString();
                ControlCount.Value = (Convert.ToInt32(DocumentManager.getDocumentSectionFieldCount(Convert.ToInt32(getSubjectID()), ((XDocumentDefination)getParentRef()).xDocumentDefinationID).ToString())+1).ToString();
                sectionID.Value = getSubjectID();
            }
        }
        private void loadDropDown()
        {
            ddlMask.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKMask, getHeader().lang);
            ddlMask.DataBind();

            ddlOperation.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKOperation, getHeader().lang);
            ddlOperation.DataBind();


            ddlConditionOperation.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKCondition, getHeader().lang);
            ddlConditionOperation.DataBind();


            ddlLookupName.DataSource = LookupManager.readLookups(getHeader().lang);
            ddlLookupName.DataBind();


        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {

            tableOuterHtml.Value = HTMLUtils.HTMLTable((XDocumentDefination)getParentRef(), Convert.ToInt32(getSubjectID()), getHeader().lang);

        }

        protected void savedocument_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(getSubjectID()))
            {
                string source = tableOuterHtml.Value;
                

                source = XMLUtils.DecodedFinalXML(source);

                tablecontentDTO dto = new tablecontentDTO();
                dto.sectionnID = Convert.ToInt32(getSubjectID());

                //Delete existing record if any
                dto.documentdefinitionID = ((XDocumentDefination)getParentRef()).xDocumentDefinationID;
                dto.documentTableParse = HTMLUtils.HtmlParse(source, Convert.ToInt32(getSubjectID()), ((XDocumentDefination)getParentRef()).name);
                dto.documentTable.documentsectionid = Convert.ToInt32(getSubjectID());

                IResponseHandler response = new TableContentManageService().executeAsPrimary(dto);
                if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                {
                    setParentRef(DocumentManager.getDocumentDefinition(Convert.ToInt32(((XDocumentDefination)getParentRef()).xDocumentDefinationID)));
                    tableOuterHtml.Value = HTMLUtils.HTMLTable((XDocumentDefination)getParentRef(), Convert.ToInt32(getSubjectID()), getHeader().lang);
                    showSuccessMessage(response);
                }
                else
                {
                    showErrorMessage(response);
                }
            }
            else
            {
                showErrorMessage("Sessions Expire");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
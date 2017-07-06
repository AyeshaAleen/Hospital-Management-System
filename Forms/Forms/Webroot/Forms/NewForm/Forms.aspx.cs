using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.interfaces.document;
using Domains.itinsync.icom.interfaces.response;
using Forms.itinsync.src.session;
using Services.icom.document.email;
using Services.icom.document.store.dto;
using Utils.itinsync.icom.cache.document;
using Utils.itinsync.icom.constant.application;
using Services.itinsync.icom.documents.dto;
using Utils.itinsync.icom.date;
using Services.itinsync.icom.documents;
using Domains.itinsync.icom.pages;
using Utils.itinsync.icom.cache.pages;
using Services.icom.document.store;
using Domains.itinsync.icom.idocument.section;
using Utils.itinsync.icom.xml;
using Utils.itinsync.icom;
using Domains.itinsync.icom.idocument;

namespace Forms.Webroot.Forms.NewForm
{
    //Work by Qundeel Ch
    public partial class Forms : DocumentBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getDocument_Store();
            }

        }
        private void getDocument_Store()
        {
            ddlForms.DataSource = DocumentManager.getDefinitions();
            ddlForms.DataBind();
            StoreDTO dto = new StoreDTO();
            dto.header = getHeader();
            dto.READBY = ReadByConstant.READBYALL;
            IResponseHandler response = new StoreGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (StoreDTO)response;
                ddlStore.DataSource = dto.storelist;
                ddlStore.DataBind();
            }
        }

        protected void getDocumentDetail(object sender, EventArgs e)
        {

            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document.documentDefinitionID = Convert.ToInt32(ddlForms.SelectedValue);
            dto.document.xdocumentDefinition = DocumentManager.getDocumentDefinition(dto.document.documentDefinitionID);
            if(!string.IsNullOrEmpty(txtFormDate.Value))
            dto.document.transDate = DateFunctions.formatDateAsString(txtFormDate.Value);
            else
                dto.document.transDate = DateFunctions.getCurrentDateAsString();
            dto.document.transTime = DateFunctions.getCurrentTimeInMillis();

            foreach (XDocumentSection section in DocumentManager.getDocumentDefinition(dto.document.documentDefinitionID).documentSections)
            {
                if(section.status==ApplicationCodes.DOCUMENT_STATUS_ACTIVE)
                dto.document.data += XMLUtils.appendTag(ServiceUtils.trimWhiteSpaces(section.name), "");

            }
            dto.document.documentName = dto.document.xdocumentDefinition.name;

            dto.document.data = XMLUtils.appendTag(dto.document.documentName, dto.document.data);


            dto.document.Userid = getHeader().userID;
            dto.document.storeid = Convert.ToInt32(ddlStore.SelectedValue);
            dto.document.flow = 1;
            dto.document.status = ApplicationCodes.DOCUMENT_STATUS_START;
            dto.document.documentName = dto.document.xdocumentDefinition.name;

            IResponseHandler response = new DocumentSaveService().executeAsPrimary(dto);


            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (DocumentDTO)response;
                setParentRef(dto.document);
                setSection(((Douments)getParentRef()).xdocumentDefinition.documentSections.Where(c => c.flow.Equals(1)).SingleOrDefault());

                PageName getPageDetail = PageManager.readbyPageID(getSection().pageID);

                ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.parent.location.href = '"+ getPageDetail.webName + "'; </script>");
                //Response.Redirect(getPageDetail.webName);
            }
        }
    }
}
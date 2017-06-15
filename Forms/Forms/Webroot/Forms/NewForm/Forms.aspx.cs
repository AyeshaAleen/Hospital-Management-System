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

namespace Forms.Webroot.Forms.NewForm
{
    //Work by Qundeel Ch
    public partial class Forms : BasePage
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
            ddlForms.DataSource= DocumentManager.getDefinitions();
            ddlForms.DataBind();
            StoreDTO dto = new StoreDTO();
            dto.header = getHeader();
            IResponseHandler response = new StoreGetService().executeAsPrimary(dto);
            if(response.getErrorBlock().ErrorCode==ApplicationCodes.ERROR_NO)
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
            dto.document.transDate = DateFunctions.getCurrentDateAsString();
            dto.document.transTime = DateFunctions.getCurrentTimeInMillis();
            dto.document.data = "<"+dto.document.xdocumentDefinition.name + "></" + dto.document.xdocumentDefinition.name + ">";
            dto.document.Userid = getHeader().userID;
            dto.document.storeid = Convert.ToInt32(ddlStore.SelectedValue);
            dto.document.flow = 1;
            dto.document.documentName = dto.document.xdocumentDefinition.name;

            IResponseHandler response = new DocumentSaveService().executeAsPrimary(dto);

            
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (DocumentDTO)response;
                setParentRef(dto.document);
                PageName getPageDetail = PageManager.readbyPageID(dto.document.xdocumentDefinition.documentSections.First().pageID);
                Response.Redirect(getPageDetail.webName);
            }
            

            
        }
    }
}
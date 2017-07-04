using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domains.itinsync.icom.interfaces.response;
using Forms.itinsync.src.session;
using Services.itinsync.icom.documents;
using Services.itinsync.icom.documents.dto;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.constant.page;
using Utils.itinsync.icom.cache.document;
using Services.itinsync.icom.document.dynamic.definition;
using Domains.itinsync.icom.idocument.definition;

namespace Forms.Webroot.Forms.Management
{
    public partial class AddForms : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadForm();
            }
        }
        private void LoadForm()
        {
            tblDocument.DataSource = DocumentManager.getDefinitions();
            tblDocument.DataBind();
            
        }

        protected void tbl_sectionDetails(object sender, CommandEventArgs e)
        {
            
            setParentRef(DocumentManager.getDocumentDefinition(Convert.ToInt32(e.CommandArgument)));
            //setSubjectID(Convert.ToInt32(e.CommandArgument));
            //popupmodal.Style.Value = "display:block";
           
            Response.Redirect(PageConstant.PAGE_DocumentSection);
        }
        
        
        protected void btnSaveDocument_Click(object sender, EventArgs e)
        {
            IResponseHandler response= DbOperation();
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                LoadForm();
                showSuccessMessage(response);
             
            }
            else
                showErrorMessage(response);
        }
        DocumentDTO dto;
        IResponseHandler DbOperation()
        {
            dto = new DocumentDTO();
            dto.header = getHeader();
            //if (documentID > 0) dto.header = getHeader(); else getHeader();
            if (!string.IsNullOrEmpty(TxtEditDocumentId.Value))
                dto.documentDefination.xDocumentDefinationID = Convert.ToInt32(TxtEditDocumentId.Value);
            dto.documentDefination.name = TxtDocumentName.Value;

            IResponseHandler response = new DocumentDefinitionSaveService().executeAsPrimary(dto);
            
            return response;
        }
    }
}
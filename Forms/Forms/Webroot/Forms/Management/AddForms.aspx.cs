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

            //popupmodal.Style.Value = "display:block";
           
            Response.Redirect(PageConstant.PAGE_DocumentSection);
        }
        
        int DDID = 0;
        protected void btnSaveDocument_Click(object sender, EventArgs e)
        {
           
            DbOperation();
            LoadForm();
        }
        DocumentDTO dto;
        IResponseHandler DbOperation()
        {
            dto = new DocumentDTO();
            dto.header = getHeader();
            //if (documentID > 0) dto.header = getHeader(); else getHeader();
            dto.documentDefination.xDocumentDefinationID = DDID;
            dto.documentDefination.name = field.Value;

            IResponseHandler response = new documentDefinitionSaveService().executeAsPrimary(dto);
            return response;
        }
    }
}
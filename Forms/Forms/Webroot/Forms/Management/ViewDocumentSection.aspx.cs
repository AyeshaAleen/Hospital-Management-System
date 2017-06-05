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

namespace Forms.Webroot.Forms.Management
{
    public partial class ViewDocumentSection : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //setBreadCrumb("");
                LoadForm();
            }
        }

        void LoadDDown()
        {
            DropDownList1.Items.Add("Male");
            DropDownList1.Items.Add("Female");
        }
        private void LoadForm()
        {
            try
            {
                if (!string.IsNullOrEmpty(getSubjectID()))
                {
                    DocumentDTO dto = new DocumentDTO();
                    dto.header = getHeader();
                    dto.documentDefination.xDocumentDefinationID = Convert.ToInt32(getSubjectID());
                    IResponseHandler response = new documentSectionGetService().executeAsPrimary(dto);
                    if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                    {
                        dto = (DocumentDTO)response;
                        tblDocument.DataSource = dto.documentDefination.documentSections;
                        tblDocument.DataBind();
                    }
                    else
                        showErrorMessage(response);
                }
            }
            catch (Exception)
            {

            }
        }
        protected void btnViewDocument_Command(object sender, CommandEventArgs e)
        {
            setSectionID(e.CommandArgument.ToString());
            Response.Redirect(PageConstant.PAGE_DocumentSectiondynamicForm);
        }
        int DSID = 0;
        protected void btnSaveSection_Click(object sender, EventArgs e)
        {
            if (ClickedId.Value.Length > 0)
                for (int i = 0; i < tblDocument.Controls.Count; i++)
                    if ((tblDocument.Controls[i].FindControl("btnEditDocument") as LinkButton).ClientID == ClickedId.Value)
                    {
                        DSID = Convert.ToInt32((tblDocument.Controls[i].FindControl("btnEditDocument") as LinkButton).CommandArgument);
                        break;
                    }
            DbOperation();
            LoadForm();
        }
        DocumentDTO dto;
        IResponseHandler DbOperation()
        {
            dto = new DocumentDTO();
            dto.header = getHeader();
            //if (documentID > 0) dto.header = getHeader(); else getHeader();

            dto.documentSection.documentsectionid = DSID;
            dto.documentSection.name = field.Value;
            dto.documentSection.pageID = 0;
            dto.documentSection.flow = (tblDocument.Controls.Count + 1).ToString();
            dto.documentSection.documentdefinitionid = Convert.ToInt32(getSubjectID());

            IResponseHandler response = new documentSectionSaveService().executeAsPrimary(dto);
            return response;
        }
    }
}
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
            LoadForm();
            if (!IsPostBack)
            {
                LoadDDown();
            }
        }

        void LoadDDown()
        {
            dto = new DocumentDTO();
            dto.header = getHeader();
            IResponseHandler response = new tablenameGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (DocumentDTO)response;
                //DropDownList1.DataSource = dto.pagenamelist;
                DropDownList1.DataBind();
            }
        }
        DocumentDTO dto;
        private void LoadForm()
        {
            try
            {
                if (!string.IsNullOrEmpty(getSubjectID()))
                {
                    dto = new DocumentDTO();
                    dto.header = getHeader();
                    dto.documentDefination.xDocumentDefinationID = Convert.ToInt32(getSubjectID());
                    IResponseHandler response = new documentSectionGetService().executeAsPrimary(dto);
                    if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                    {
                        dto = (DocumentDTO)response;
                        tblDocument.DataSource = null;
                        tblDocument.DataSource = dto.documentDefination.documentSections;
                        tblDocument.DataBind();
                        setSubjectID(dto.documentDefination.xDocumentDefinationID);
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
            setSubjectID(Convert.ToString(e.CommandArgument));
            Response.Redirect(PageConstant.PAGE_DocumentSectiondynamicForm);
        }

        protected void btnSaveSection_Click(object sender, EventArgs e)
        {
            DocumentDTO dtoIn = new DocumentDTO();
            dtoIn.header = getHeader();

            dtoIn.documentSection.name = field.Value;
            dtoIn.documentSection.pageID = Convert.ToInt32(DropDownList1.SelectedValue); // ok
            dtoIn.documentSection.flow = (tblDocument.Controls.Count + 1).ToString();
            dtoIn.documentSection.documentdefinitionid = Convert.ToInt32(getSubjectID());

            if (ClickedId.Value.Length > 0)
                for (int i = 0; i < tblDocument.Controls.Count; i++)
                    if ((tblDocument.Controls[i].FindControl("btnEditDocument") as LinkButton).ClientID == ClickedId.Value)
                    {
                        dtoIn.documentSection.documentsectionid = Convert.ToInt32((tblDocument.Controls[i].FindControl("btnEditDocument") as LinkButton).CommandArgument);

                        dtoIn.documentSection.pageID = dto.documentDefination.documentSections.FirstOrDefault(x => x.documentsectionid
                        == dtoIn.documentSection.documentsectionid).pageID;

                        dtoIn.documentSection.flow = dto.documentDefination.documentSections.FirstOrDefault(x => x.documentsectionid
                        == dtoIn.documentSection.documentsectionid).flow;
                        break;
                    }

            IResponseHandler response = new documentSectionSaveService().executeAsPrimary(dtoIn);
            LoadForm();
        }
    }
}
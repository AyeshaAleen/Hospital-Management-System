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
            if(!IsPostBack)
            {
                LoadForm();
            }
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
            catch(Exception)
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

        }
    }
}
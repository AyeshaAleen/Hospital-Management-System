using Domains.itinsync.icom.interfaces.response;
using Forms.itinsync.src.session;
using Services.icom.views.personalinboxview;
using Services.icom.views.personalinboxview.dto;
using Services.itinsync.icom.documents;
using Services.itinsync.icom.documents.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.itinsync.icom.cache.document;
using Utils.itinsync.icom.constant.application;

namespace Forms.Webroot
{
    public partial class CommonMaster : MasterBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PersonalInboxViewDTO dto = new PersonalInboxViewDTO();
                dto.header = dto.getHeader();
                dto.personalinboxview.userid = getUserID();
                dto.personalinboxview.status = ApplicationCodes.DOCUMENT_STATUS_INPROGRESS;

                IResponseHandler response = new PersonalInboxViewGetService().executeAsPrimary(dto);
                if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                {
                    tblDocument.DataSource = dto.personalinboxviewList;
                    lblNew.Text = dto.personalinboxviewList.Count.ToString();
                    tblDocument.DataBind();
                }
            }
        }

        protected void btndocumentlink_Click(object sender, EventArgs e)
        {
          
        }
        protected void btnchangepassword_Click(object sender, EventArgs e)
        {
            setSubjectID("0");
            Response.Redirect(ResolveClientUrl("Users/ChangePassword.aspx"));
        }

        protected void btnViewDocument_Command(object sender, CommandEventArgs e)
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();

            dto.document.documentID = Convert.ToInt32(e.CommandArgument);

            IResponseHandler response = new DocumentGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (DocumentDTO)response;
                //setSubjectID(Convert.ToString(e.CommandArgument));
                dto.document.xdocumentDefinition = DocumentManager.getDocumentDefinition(dto.document.documentDefinitionID);
                Response.Redirect(getWebPageName(dto.documentSection.pageID));
            }
        }
    }
}
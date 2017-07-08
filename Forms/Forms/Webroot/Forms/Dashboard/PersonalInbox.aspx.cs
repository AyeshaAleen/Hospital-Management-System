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
using Utils.itinsync.icom.cache.pages;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.constant.lookup;

using Services.icom.views.personalinboxview.dto;
using Services.icom.views.personalinboxview;

using System.Data;
using Utils.itinsync.icom.cache.document;
using Domains.itinsync.icom.views.personalinbox;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.idocument.section;

namespace Forms.Webroot.Forms.Dashboard
{
    public partial class PersonalInbox : DocumentBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PersonalInboxViewDTO dto = new PersonalInboxViewDTO();
                dto.header = getHeader();
                dto.personalinboxview.userid = getUserID();
                dto.personalinboxview.status = ApplicationCodes.DOCUMENT_STATUS_INPROGRESS;

                IResponseHandler response = new PersonalInboxViewGetService().executeAsPrimary(dto);
                if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                {
                    tblDocument.DataSource = dto.personalinboxviewList.OrderByDescending(u=>u.transTime);
                    tblDocument.DataBind();
                }
            }
        }

        protected void btnViewDocument_Command(object sender, CommandEventArgs e)
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();

            dto.document.documentID = Convert.ToInt32(e.CommandArgument);
            dto.READBY = ReadByConstant.READBYID;
            IResponseHandler response = new DocumentGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (DocumentDTO)response;
                dto.document.xdocumentDefinition = DocumentManager.getDocumentDefinition(dto.document.documentDefinitionID);

                XDocumentSection section = dto.document.xdocumentDefinition.documentSections.Where(u => u.documentdefinitionid == dto.document.xdocumentDefinition.xDocumentDefinationID && Convert.ToInt32(u.flow) == dto.document.flow+1).SingleOrDefault();

                setParentRef(dto.document);
                setSection(section);
                Response.Redirect(getWebPageName(section.pageID));
            }
            else
                showErrorMessage(response);
        }
    }
}
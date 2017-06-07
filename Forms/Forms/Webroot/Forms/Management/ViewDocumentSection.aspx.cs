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
using Domains.itinsync.icom.idocument.definition;

namespace Forms.Webroot.Forms.Management
{
    public partial class ViewDocumentSection : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
             doLoad();
            
        }

        private void doLoad()
        {
            ddlsectionPagesName.DataSource = PageManager.getPages();
            ddlsectionPagesName.DataBind();
            if (getParentRef()!=null)
            {
                tblDocument.DataSource = ((XDocumentDefination)getParentRef()).documentSections;
                tblDocument.DataBind();
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
            dtoIn.documentSection.pageID = Convert.ToInt32(ddlsectionPagesName.SelectedValue); // ok
            dtoIn.documentSection.flow = (tblDocument.Controls.Count + 1).ToString();
            dtoIn.documentSection.documentdefinitionid = Convert.ToInt32(getSubjectID());

            IResponseHandler response = new documentSectionSaveService().executeAsPrimary(dtoIn);
            doLoad();
        }
    }
}
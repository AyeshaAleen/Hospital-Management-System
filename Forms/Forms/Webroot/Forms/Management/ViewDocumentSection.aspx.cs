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
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.constant.lookup;
using Services.icom.document;

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
            ddlUserRole.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKUserRole, getHeader().lang);
            ddlUserRole.DataBind();

            ddlEmailRouting.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKEmailRouting, getHeader().lang);
            ddlEmailRouting.DataBind();
            
            LoadUserRoleTbl();
        }
        void LoadUserRoleTbl()
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            IResponseHandler response = new DocumentRoleGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (DocumentDTO)response;
                tblUserRole.DataSource = dto.documentRolelist;
                tblUserRole.DataBind();
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

        protected void btnAddUserRole_Click(object sender, EventArgs e)
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();

            dto.documentRole.xdocumentdefinitionid = Convert.ToInt32(getSubjectID());
            dto.documentRole.role = Convert.ToInt32(ddlUserRole.SelectedValue);

            IResponseHandler response = new DocumentRoleSaveService().executeAsPrimary(dto);

            LoadUserRoleTbl();
        }

        protected void btnEditUserRole_Command(object sender, CommandEventArgs e)
        {
            //DocumentDTO dto = new DocumentDTO();
            //dto.header = getHeader();

            //dto.documentRole.xdocumentroleid = Convert.ToInt32(e.CommandArgument);
            //ddlOperation.SelectedValue = Convert.ToString(e.CommandArgument);
            //dto.documentRole.xdocumentdefinitionid = Convert.ToInt32(getSubjectID());
            //dto.documentRole.role = Convert.ToInt32(ddlOperation.SelectedValue);
        }

        protected void btnDeleteUserRole_Command(object sender, CommandEventArgs e)
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.documentRole.xdocumentroleid = Convert.ToInt32(e.CommandArgument);

            IResponseHandler response = new DocumentRoleDeleteService().executeAsPrimary(dto);

            LoadUserRoleTbl();
        }
    }
}
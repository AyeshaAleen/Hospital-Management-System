using Forms.itinsync.src.session;
using Domains.itinsync.icom.interfaces.response;
using Services.itinsync.icom.useraccounts;
using Services.itinsync.icom.useraccounts.dto;
using System;
using System.Web.UI.WebControls;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.constant.page;

namespace Forms.Webroot.Users
{
    public partial class UserSearch : BasePage
    {
        private Int32 PAGEID = 1022;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { if (hasPermission(PAGEID)) { } } 
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.PAGE_ADD_USER);
           // Redirect(PageConstant.PAGE_ADD_USER);
        }
        protected void btnClearForm_Click(object sender, EventArgs e) { }
        protected void btnSearchUser_Click(object sender, EventArgs e)
        {
            UserAccountsDTO dto = new UserAccountsDTO();
            dto.header = getHeader();
            dto.useraccounts.userName = txtUserName.Value;
            dto.READBY = ReadByConstant.READBYUSERNAME;
            IResponseHandler response = new UserAccountsGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (UserAccountsDTO)response;
                repeaterUsers.DataSource = dto.userAccountsList;
                repeaterUsers.DataBind();
            }
            else
                showErrorMessage(response);
        }
        protected void tblEditUser_RowClick(object sender, CommandEventArgs e)
        {
            setSubjectID(Convert.ToString(e.CommandArgument));
            Response.Redirect(PageConstant.PAGE_ADD_USER);
            // Redirect(PageConstant.PAGE_ADD_USER);
        }
        protected void tblEditPermission_RowClick(object sender, CommandEventArgs e)
        {
            setSubjectID(Convert.ToString(e.CommandArgument));
            Response.Redirect(PageConstant.PAGE_EDIT_PERMISSION);
            //Redirect(PageConstant.PAGE_EDIT_PERMISSION);
        }
        protected void tblEditTeam_RowClick(object sender, CommandEventArgs e)
        {
            setSubjectID(Convert.ToString(e.CommandArgument));
           // Redirect(PageConstant.PAGE_EDIT_TEAM);
        }
    }
}
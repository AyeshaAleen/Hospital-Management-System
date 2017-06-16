using Forms.itinsync.src.session;
using Domains.itinsync.icom.interfaces.response;
using Services.itinsync.icom.useraccounts;
using Services.itinsync.icom.useraccounts.dto;
using System;
using System.Web.UI.WebControls;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.constant.page;
using Utils.itinsync.icom.SecurityManager;

namespace ARS.Webroot.Desktop.Users
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
            Redirect(PageConstant.PAGE_ADD_USER);
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
            Redirect(PageConstant.PAGE_ADD_USER);
        }
        protected void tblEditPermission_RowClick(object sender, CommandEventArgs e)
        {
            setSubjectID(Convert.ToString(e.CommandArgument));
            Redirect(PageConstant.PAGE_EDIT_PERMISSION);
        }
        protected void tblEditTeam_RowClick(object sender, CommandEventArgs e)
        {
            setSubjectID(Convert.ToString(e.CommandArgument));
            Redirect(PageConstant.PAGE_EDIT_TEAM);
        }

        protected void btnResetPassword_Command(object sender, CommandEventArgs e)
        {
            UserAccountsDTO dto = new UserAccountsDTO();
            dto.header = getHeader();
            dto.useraccounts.userID = Convert.ToInt32(e.CommandArgument);
            dto.READBY = ReadByConstant.READBYID;
            IResponseHandler responseget = new UserAccountsGetService().executeAsPrimary(dto);
            if (responseget.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (UserAccountsDTO)responseget;
                dto.useraccounts.userEmail = dto.useraccounts.userEmail;
                dto.useraccounts.password = SecurityManager.RandomNumber(10);
                dto.UPDATEBY = ReadByConstant.READBYUSERID;
                IResponseHandler response = new UserAccountSaveService().executeAsPrimary(dto);

                if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                {

                    showSuccessMessage(response);
                }
                else
                    showErrorMessage(response);
            }
            else
                showErrorMessage(responseget);
        }
    }
}
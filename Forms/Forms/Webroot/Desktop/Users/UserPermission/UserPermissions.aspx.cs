using Forms.itinsync.src.session;
using Domains.itinsync.icom.interfaces.response;
using Services.icom.permission;
using Services.icom.permission.dto;
using Services.itinsync.icom.useraccounts;
using Services.itinsync.icom.useraccounts.dto;
using System;
using Utils.itinsync.icom.constant.application;
using System.Web.UI.WebControls;

namespace Forms.Webroot.Desktop.Users.UserPermission
{
    public partial class UserPermissions : BasePage
    {
        private int PAGEID = 1028;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (hasPermission(PAGEID))
                {
                    getUserName();
                    getUserPermissions();
                    getPages();
                }
            }            
        }

        private void getUserName()
        {
            UserAccountsDTO dto = new UserAccountsDTO();
            if (getSubjectID() != null && getSubjectID().Length > 0)
                dto.useraccounts.userID = Convert.ToInt32(getSubjectID());
            dto.READBY = ReadByConstant.READBYID;
            IResponseHandler response = new UserAccountsGetService().executeAsPrimary(dto);
            lblname.InnerText = dto.useraccounts.firstName + " " + dto.useraccounts.lastName;
        }

        private void getUserPermissions()
        {
            if (getSubjectID() != null && getSubjectID().Length > 0)
            {
                UserPermissionViewDTO dto = new UserPermissionViewDTO();
                dto.header = getHeader();
                dto.userpermissionview.userID = Convert.ToInt32(getSubjectID());
                IResponseHandler response = new UserPermissionViewGetService().executeAsPrimary(dto);
                if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                {
                    dto = (UserPermissionViewDTO)response;
                    tblUserPermissions.DataSource = dto.userpermissionviewList;
                    tblUserPermissions.DataBind();
                }
                else
                    showErrorMessage(response);
            }
        }
        private void getPages()
        {
            PermissionDTO dto = new PermissionDTO();
            dto.header = getHeader();
            dto.READBY = ReadByConstant.READBYALL;
            IResponseHandler response = new PermissionGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (PermissionDTO)response;
                ddlPermission.DataSource = dto.permissionList;
                ddlPermission.DataBind();
            }
            else
                showErrorMessage(response);
        }
        protected void tbl_Delete_Click(object sender, CommandEventArgs e)
        {
            Int32 upid = Convert.ToInt32(e.CommandArgument);
            deletePermission(upid);
            PermissionDTO dto = new PermissionDTO();
            IResponseHandler response = new PermissionGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                getUserPermissions();
            else
                showErrorMessage(response);
        }

        private IResponseHandler deletePermission(Int32 upid)
        {
            UserPermissionDTO dto = new UserPermissionDTO();
            dto.header = getHeader();
            if (getSubjectID() != null && getSubjectID().Length > 0)
            {
                dto.userpermission.userPermissionID = upid;
            }
            return new UserPermissionDeleteService().executeAsPrimary(dto);
        }         

        protected void btnAddPermission_Click(object sender, EventArgs e)
        {
            addPermision();
            PermissionDTO dto = new PermissionDTO();
            dto.READBY = ReadByConstant.READBYALL;
            IResponseHandler response = new PermissionGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                getUserPermissions();
            else
                showErrorMessage(response);
        }

        private IResponseHandler addPermision()
        {
            UserPermissionDTO dto = new UserPermissionDTO();
            dto.header = getHeader();
            if (getSubjectID() != null && getSubjectID().Length > 0)
                dto.userpermission.userID = Convert.ToInt32(getSubjectID());
            dto.userpermission.code = Convert.ToInt32(ddlPermission.SelectedValue);
            return new UserPermissionSaveService().executeAsPrimary(dto);
        }
    }
}
using System;
using Services.itinsync.icom.useraccounts.dto;
using Domains.itinsync.icom.interfaces.response;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.constant.lookup;
using Services.itinsync.icom.useraccounts;
using Forms.itinsync.src.session;
using Utils.itinsync.icom.constant.application;
//using Services.icom.vendor;
//using Services.itinsync.icom.vendor.dto;
//using Services.itinsync.icom.team.dto;
//using Services.itinsync.icom.team;

namespace Forms.Webroot.Users
{
    public partial class AddUser : BasePage
    {
        private Int32 PAGEID = 260;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (hasPermission(PAGEID))
                {
                    lookup();
                    //getVendor();
                    searchUser();
                }
            }
        }
        
        private void lookup()
        {
            ddlCountryCode.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKCountryCode, getHeader().lang);
            ddlCountryCode.DataBind();

            ddlUserRole.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKUserRole, getHeader().lang);
            ddlUserRole.DataBind();

            ddlLang.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKUserLang, getHeader().lang);
            ddlLang.DataBind();
        }
        //private void getVendor()
        //{
        //    VendorDTO dto = new VendorDTO();
        //    dto.header = getHeader();            
        //    dto.READBY = ReadByConstant.READBYALL;
        //    IResponseHandler response = new VendorGetService().executeAsPrimary(dto);
        //    if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
        //    {
        //        dto = (VendorDTO)response;
        //        ddlvendor.DataSource = dto.vendorList;
        //        ddlvendor.DataBind();
        //    }
        //    else
        //        showErrorMessage(response);
        //}
        
        private void searchUser()
        {
            if (getSubjectID() != null && getSubjectID().Length > 0)
            {
                UserAccountsDTO dto = new UserAccountsDTO();
                dto.header = getHeader();
                dto.useraccounts.userID = Convert.ToInt32(getSubjectID());
                dto.READBY = ReadByConstant.READBYID;
                IResponseHandler response = new UserAccountsGetService().executeAsPrimary(dto);
                if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                {
                    dto = (UserAccountsDTO)response;
                    txtFirstName.Value = dto.useraccounts.firstName;
                    txtLastName.Value = dto.useraccounts.lastName;
                    txtUserName.Value = dto.useraccounts.userName;
                    txtUserEmail.Value = dto.useraccounts.userEmail;
                    txtPassword.Value = dto.useraccounts.password;
                    txtConfirmPassword.Value = dto.useraccounts.password;
                    ddlCountryCode.SelectedValue = dto.useraccounts.countryCode;
                    txtContact.Value = dto.useraccounts.userPhone;
                    ddlUserRole.SelectedValue = Convert.ToString(dto.useraccounts.role);
                    ddlLang.SelectedValue = dto.useraccounts.lang;
                }
                else
                    showErrorMessage(response);
            }
        }

        private IResponseHandler saveUsers()
        {
            UserAccountsDTO dto = new UserAccountsDTO();
            dto.header = getHeader();
            if (getSubjectID() != null && getSubjectID().Length > 0)
                dto.useraccounts.userID = Convert.ToInt32(getSubjectID());
            dto.useraccounts.firstName = txtFirstName.Value;
            dto.useraccounts.lastName = txtLastName.Value;
            dto.useraccounts.userName = txtUserName.Value;
            dto.useraccounts.userEmail = txtUserEmail.Value;
            dto.useraccounts.password = txtPassword.Value;
            dto.useraccounts.password = txtConfirmPassword.Value;
            dto.useraccounts.countryCode = ddlCountryCode.SelectedValue;
            dto.useraccounts.userPhone = txtContact.Value;
            dto.useraccounts.role = Convert.ToInt32(ddlUserRole.SelectedValue);
            dto.useraccounts.lang = ddlLang.SelectedValue;
           // dto.useraccounts.vendorID = Convert.ToInt32(ddlvendor.SelectedValue);
            return new UserAccountSaveService().executeAsPrimary(dto);
        }

        private void addUser()
        {
            IResponseHandler response = saveUsers();
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                showSuccessMessage(response);
                UserAccountsDTO dto = (UserAccountsDTO)response;
                setSubjectID(dto.useraccounts.userID.ToString());
            }
            else
                showErrorMessage(response);
        }
        
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            addUser();
        }
    }
}
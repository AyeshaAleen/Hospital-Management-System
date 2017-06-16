using System;
using Services.itinsync.icom.useraccounts.dto;
using Domains.itinsync.icom.interfaces.response;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.constant.lookup;
using Services.itinsync.icom.useraccounts;
using Forms.itinsync.src.session;
using Utils.itinsync.icom.constant.application;
//using Services.itinsync.icom.vendor;
//using Services.itinsync.icom.vendor.dto;
using Services.itinsync.icom.team.dto;
using Services.itinsync.icom.team;
using Utils.itinsync.icom.SecurityManager;
using System.Collections.Generic;

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
                    searchUser();
                    //getVendor();

                }
            }
        }
        
        private void lookup()
        {
            ddlCarrier.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKMobileProvider, getHeader().lang);
            ddlCarrier.DataBind();


            ddlCountryCode.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKCountryCode, getHeader().lang);
            ddlCountryCode.DataBind();

            ddlUserRole.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKUserRole, getHeader().lang);
            ddlUserRole.DataBind();

            ddlLang.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKUserLang, getHeader().lang);
            ddlLang.DataBind();
       
            ddlTimeZone.DataSource = TimeZoneInfo.GetSystemTimeZones();
            ddlTimeZone.DataBind();

            //VendorDTO dto = new VendorDTO();
            //dto.header = getHeader();
            //dto.READBY = ReadByConstant.READBYALL;
            //IResponseHandler response = new VendorGetService().executeAsPrimary(dto);
            //if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            //{
            //    dto = (VendorDTO)response;

            //    ddlvendor.DataSource = dto.vendorList;
            //    ddlvendor.DataBind();
            //}

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


                    //txtPassword.Value = SecurityManager.DecodeString(dto.useraccounts.password);
                    //txtConfirmPassword.Value =  SecurityManager.DecodeString(dto.useraccounts.password);
                    txtPassword.Visible = false;
                    txtConfirmPassword.Visible = false;
                    lblPassword.Visible = false;
                    lblConfirmPassword.Visible = false;

                    ddlCountryCode.SelectedValue = dto.useraccounts.countryCode;
                    ddlCarrier.SelectedValue = dto.useraccounts.MobileProvider;
                    txtContact.Value = dto.useraccounts.userPhone;
                    ddlUserRole.SelectedValue = Convert.ToString(dto.useraccounts.role);
                    ddlLang.SelectedValue = dto.useraccounts.lang;
                    ddlTimeZone.SelectedValue = dto.useraccounts.timeZone;
                    //showSuccessMessage(response);
                    // clearForm();
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
            dto.useraccounts.password =  SecurityManager.EncodeString(txtConfirmPassword.Value);
            dto.useraccounts.countryCode = ddlCountryCode.SelectedValue;
            if(ddlCarrier.SelectedValue!="0")
            dto.useraccounts.MobileProvider = ddlCarrier.SelectedValue;
            dto.useraccounts.userPhone = txtContact.Value;
            dto.useraccounts.role = Convert.ToInt32(ddlUserRole.SelectedValue);
            dto.useraccounts.lang = ddlLang.SelectedValue;
            dto.useraccounts.vendorID = Convert.ToInt32(ddlvendor.SelectedValue);
            dto.useraccounts.timeZone = ddlTimeZone.SelectedValue;
            return new UserAccountSaveService().executeAsPrimary(dto);
        }

        private void addUser()
        {
            IResponseHandler response = saveUsers();
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                
                showSuccessMessage(response);
                //clearForm();
                //UserAccountsDTO dto = (UserAccountsDTO)response;
                //setSubjectID(dto.useraccounts.userID.ToString());

          
            }
            else
                showErrorMessage(response);
        }
        
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            addUser();
        }

        protected void btnResetPassword_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
           

           
        }
    }
}
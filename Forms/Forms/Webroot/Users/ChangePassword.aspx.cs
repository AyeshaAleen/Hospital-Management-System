using Forms.itinsync.src.session;
using Domains.itinsync.icom.interfaces.response;
using Services.itinsync.icom.useraccounts;
using Services.itinsync.icom.useraccounts.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.SecurityManager;

using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.constant.lookup;
using Services.itinsync.icom.team.dto;
using Services.itinsync.icom.team;

namespace Forms.Webroot.Users
{
    public partial class ChangePassword : BasePage
    {
        private Int32 PAGEID = 1052;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (hasPermission(PAGEID))
                {

                }
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Value == getHeader().userinformation.userAccount.password)
            {
                UserAccountsDTO dto = new UserAccountsDTO();
                dto.header = getHeader();
                dto.useraccounts.userID = getHeader().userID;
                dto.useraccounts.userEmail = getHeader().userinformation.userAccount.userEmail;
                dto.useraccounts.password = SecurityManager.EncodeString(txtPassword.Value);
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
                showErrorMessage("Password.Not.Match");
        }
    }
}
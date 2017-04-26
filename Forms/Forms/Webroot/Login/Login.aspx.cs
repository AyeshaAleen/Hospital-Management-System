using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.session.user;
using Forms.itinsync.src.session;
using Services.itinsync.icom.useraccounts.DTO;
using Services.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.itinsync.icom.constant.application;

namespace Forms.Webroot.Login
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logOut();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserInformationServiceGet userinfoservice = new UserInformationServiceGet();
            UserInformationInDTO dto = new UserInformationInDTO();
            dto.userName = txtUsername.Value;
            dto.password = txtPassword.Value;
            IResponseHandler response = userinfoservice.executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                IResponseHandler rh = (UserInformation)response.getResponseMessage();
                InjectSession((UserInformation)rh.getResponseMessage());
            }
            else
            {
                alertFailure.Visible = true;
                alertFailure.InnerHtml = ApplicationCodes.ERROR_TEXT + trasnlation(response.getErrorBlock().ErrorText);
            }
        }
    }
}
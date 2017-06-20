using Forms.itinsync.src.session;
using Domains.itinsync.icom.interfaces.response;
using Services.icom.views.userstoreview;
using Services.icom.views.userstoreview.dto;
using Services.itinsync.icom.useraccounts;
using Services.itinsync.icom.useraccounts.dto;
using Services.icom.document.store;
using Services.icom.document.store.dto;
using System;
using System.Web.UI.WebControls;
using Utils.itinsync.icom.constant.application;
using Services.icom.useraccounts.DTO;
using Services.icom.useraccounts;

namespace Forms.Webroot.Store
{
    public partial class AssignStore : BasePage
    {
        private int PAGEID = 1045;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (hasPermission(PAGEID))
                {
                    getUserName();
                    getUserStores();
                    getStores();
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

        private void getUserStores()
        {
            if (getSubjectID() != null && getSubjectID().Length > 0)
            {
                UserStoreViewDTO dto = new UserStoreViewDTO();
                dto.header = getHeader();
                dto.userstoreview.userid = Convert.ToInt32(getSubjectID());
                IResponseHandler response = new UserStoreViewGetService().executeAsPrimary(dto);
                if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                {
                    dto = (UserStoreViewDTO)response;
                    tblUserStores.DataSource = dto.userStoreViewList;
                    tblUserStores.DataBind();
                }
                else
                    showErrorMessage(response);
            }
        }

        private void getStores()
        {
            StoreDTO dto = new StoreDTO();
            dto.header = getHeader();
            dto.READBY = ReadByConstant.READBYALL;
            IResponseHandler response = new StoreGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (StoreDTO)response;
                ddlStores.DataSource = dto.storelist;
                ddlStores.DataBind();
            }
            else
                showErrorMessage(response);
        }

        protected void tbl_Delete_Click(object sender, CommandEventArgs e)
        {
            UserStoreDTO dto = new UserStoreDTO();
            dto.header = getHeader();

            dto.userstore.userstoreid = Convert.ToInt32(e.CommandArgument);
            IResponseHandler response = new UserStoreDeleteService().executeAsPrimary(dto);

            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                getUserStores();
            else
                showErrorMessage(response);
        }

        protected void btnAddStore_Click(object sender, EventArgs e)
        {
            UserStoreDTO dto = new UserStoreDTO();
            dto.header = getHeader();
            if (getSubjectID() != null && getSubjectID().Length > 0)
                dto.userstore.userid = Convert.ToInt32(getSubjectID());

            dto.userstore.storeid = Convert.ToInt32(ddlStores.SelectedValue);
            IResponseHandler response = new UserStoreSaveService().executeAsPrimary(dto);
           
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                getUserStores();
            else
                showErrorMessage(response);
        }
        
    }
}
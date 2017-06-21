using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Forms.itinsync.src.session;
using Domains.itinsync.icom.interfaces.response;
using Services.icom.document.store;
using Services.icom.document.store.dto;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.constant.page;
using Utils.itinsync.icom.SecurityManager;
using Domains.itinsync.icom.store;

namespace Forms.Webroot.Store
{
    public partial class SearchStore : BasePage
    {
        private Int32 PAGEID = 1046;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { if (hasPermission(PAGEID)) { } }
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            // Redirect(PageConstant.PAGE_ADD_USER);
            setSubjectID(0);
           Response.Redirect(PageConstant.PAGE_ADD_STORE);
        }
        protected void btnClearForm_Click(object sender, EventArgs e) { }
        protected void btnSearchStore_Click(object sender, EventArgs e)
        {
            SearchUser();
        }
        protected void tblEditStore_RowClick(object sender, CommandEventArgs e)
        {
            //int i = ((Domains.itinsync.icom.store.Store)getParentRef()).storeid;
            setSubjectID(Convert.ToString(e.CommandArgument));
            Response.Redirect(PageConstant.PAGE_ADD_STORE);
           
        }
        protected void tblDeleteStore_RowClick(object sender, CommandEventArgs e)
        {
            StoreDTO dto = new StoreDTO();
            dto.header = getHeader();
            dto.store.storeid = Convert.ToInt32(e.CommandArgument);
            IResponseHandler response = new StoreDeleteService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                SearchUser();
                showSuccessMessage(response);
            }
            else
                showErrorMessage(response);
        }

        void SearchUser()
        {
            StoreDTO dto = new StoreDTO();
            dto.header = getHeader();
            dto.store.name = txtStoreName.Value;
            //dto.READBY = ReadByConstant.READBYUSERNAME;

            dto.READBY = (txtStoreName.Value.Length < 1) ? ReadByConstant.READBYALL: ReadByConstant.READBYUSERNAME;

            IResponseHandler response = new StoreGetService().executeAsPrimary(dto); 
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (StoreDTO)response;
                repeaterStores.DataSource = dto.storelist;
                repeaterStores.DataBind();
            }
            else
                showErrorMessage(response);
        }
    }
}
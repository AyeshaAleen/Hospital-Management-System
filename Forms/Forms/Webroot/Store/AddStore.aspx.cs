using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utils.itinsync.icom.SecurityManager;
using Services.icom.document.store.dto;
using Domains.itinsync.icom.interfaces.response;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.constant.lookup;
using Services.icom.document.store;
using Forms.itinsync.src.session;
using Utils.itinsync.icom.constant.application;

namespace Forms.Webroot.Store
{
    public partial class AddStore : BasePage
    {
        private Int32 PAGEID = 1044;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (hasPermission(PAGEID))
                {
                    getStores();
                }
            }
        }
        protected void btnAddStore_Click(object sender, EventArgs e)
        {
            StoreDTO dto = new StoreDTO();
            dto.header = getHeader();

            if (getSubjectID() != null && getSubjectID().Length > 0)
                dto.store.storeid = Convert.ToInt32(getSubjectID());

            // dto.store.storeid = ((Domains.itinsync.icom.store.Store)getParentRef()).storeid;

            dto.store.name = txtStoreName.Value;
            dto.store.zipCode = txtZipCode.Value;
            dto.store.website = txtWebSite.Value;
            dto.store.storelink = txtStoreLink.Value;
            dto.store.comments = txtComments.Value;
            dto.store.walmart = txtWalmart.Value;
            dto.store.fax = txtFax.Value;
            dto.store.storeNo = txtStoreNo.Value;

            IResponseHandler response = new StoreSaveService().executeAsPrimary(dto);

            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                showSuccessMessage(response);
            }
            else
                showErrorMessage(response);
        }
        
        void getStores()
        {
            if (getSubjectID() != null && getSubjectID().Length > 0)
            {
                StoreDTO dto = new StoreDTO();
                dto.header = getHeader();
             dto.store.storeid = Convert.ToInt32(getSubjectID());
            //dto.store.storeid = ((Domains.itinsync.icom.store.Store)getParentRef()).storeid;


            IResponseHandler response = new StoreGetService().executeAsPrimary(dto);
                if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                {
                    dto = (StoreDTO)response;

                    txtStoreName.Value = dto.store.name;
                    txtZipCode.Value = dto.store.zipCode;
                    txtWebSite.Value = dto.store.website;
                    txtStoreLink.Value = dto.store.storelink;
                    txtComments.Value = dto.store.comments;
                    txtWalmart.Value = dto.store.walmart;
                    txtFax.Value = dto.store.fax;
                    txtStoreNo.Value = dto.store.storeNo;
                   
                    
                }
                else
                    showErrorMessage(response);
            }
        }
    }
}
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
        private Int32 PAGEID = 260;
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!Page.IsPostBack)
            {
                getStores();
            }
        }
        protected void btnAddStore_Click(object sender, EventArgs e)
        {

        }
        
        void getStores()
        {

        }
    }
}
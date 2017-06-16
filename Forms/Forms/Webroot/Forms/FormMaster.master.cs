using Forms.itinsync.src.session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domains.itinsync.icom.interfaces.response;
using Services.itinsync.icom.cache.pages;
using Utils.itinsync.icom.cache.global;

namespace Forms.Webroot.Forms
{
    public partial class FormMaster : MasterBasePage
    {
        BasePage bp = new BasePage();
        protected void Page_Load(object sender, EventArgs e)
        {
            loadPageCache();
            //string test = getLastURL();

        }
        private void loadPageCache()
        {

            //if (GlobalStaticCache.PageCacheMap.ContainsKey(doumentDefinitionID))
            //    return GlobalStaticCache.documentDefinition[doumentDefinitionID];


            //IResponseHandler response = new PageManagerService().executeAsPrimary();
        }
        //public string translation(string key)
        //{
        //   return bp.trasnlation(key);
        //}

    }
}
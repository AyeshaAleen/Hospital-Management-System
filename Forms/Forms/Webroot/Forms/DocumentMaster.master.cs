using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Domains.itinsync.icom.idocument.definition;
using Forms.itinsync.src.session;
using Utils.itinsync.icom.cache.pages;

namespace Forms.Webroot.Forms
{
    public partial class DocumentMaster : MasterBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (getParentRef() != null)
            { 
                DataTable dt_PageDetail = new DataTable();
                dt_PageDetail.Columns.Add("name");
                dt_PageDetail.Columns.Add("Webname");
                foreach (var section in ((XDocumentDefination)getParentRef()).documentSections)
                {
                    dt_PageDetail.Rows.Add(section.name, PageManager.readbyPageID(section.pageID).webName);
                }

                tblSectionTab.DataSource = dt_PageDetail;
                tblSectionTab.DataBind();

                //PageTabs.


            }
        }
    }
}
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
using Domains.itinsync.icom.idocument;
using Domains.itinsync.icom.idocument.section;
using static Forms.itinsync.src.session.Session;
using Utils.itinsync.icom.constant.application;

namespace Forms.Webroot.Forms
{
    public partial class DocumentMaster : MasterBasePage
    {
        public static string DocumentName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (getParentRef() != null)
            {
               var DocumentName = getParentRef().getParentrefName();
                DataTable dt_PageDetail = new DataTable();
                dt_PageDetail.Columns.Add("name");
                dt_PageDetail.Columns.Add("Webname");
                foreach (var section in ((Douments)getParentRef()).xdocumentDefinition.documentSections)
                {
                    if(section.status==ApplicationCodes.DOCUMENT_STATUS_ACTIVE)
                    dt_PageDetail.Rows.Add(section.name, PageManager.readbyPageID(section.pageID).webName);
                }

                tblSectionTab.DataSource = dt_PageDetail;
                tblSectionTab.DataBind();

                //PageTabs.


            }
        }

        public XDocumentSection getSection()
        {
            return (XDocumentSection)Sessions.getSession().Get(SessionKey.SECTION);
        }
    }
}
using Domains.itinsync.icom.idocument;
using Domains.itinsync.icom.idocument.section;
using Domains.itinsync.icom.interfaces.response;
using Domains.itinsync.icom.pages;
using Forms.itinsync.src.session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.itinsync.icom.cache.pages;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.xml;
using Domains.itinsync.icom.idocument.definition;

namespace Forms.Webroot.Forms.section
{
    public partial class Section :  DocumentBasePage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sectionHeading.InnerText = getSection().name;
                createControl();
                getSectionContentData();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //getSectionContentData();
        }
        private void getSectionContentData()
        {
            if (!string.IsNullOrEmpty(((Douments)getParentRef()).data))
            {
                XMLUtils.processXML(this, ((Douments)getParentRef()).data, getSection().name);
            }
        }
        private void createControl()
        {
            processDynamicContent(tableDynamic, ((Douments)getParentRef()), getSection().documentsectionid);
            tableDynamic.EnableViewState = true;
            ViewState["tableDynamic"] = true;

            processForwardedFields(hiddenFieldDiv, ((Douments)getParentRef()));
        }

        protected override void LoadViewState(object savedState)
        {
            createControl();
            base.LoadViewState(savedState);
           
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Douments document = ((Douments)getParentRef());
            string sectionXML = XMLUtils.getDynamicXML(getSection().name, document.data, this);

            IResponseHandler response = saveDocument(sectionXML, document.documentID, getSection().flow, ApplicationCodes.DOCUMENT_STATUS_INPROGRESS);

            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                PageName getPageDetail = PageManager.readbyPageID(getSection().pageID);

                Response.Redirect(getPageDetail.webName);
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            XDocumentDefination documentDefinition = ((Douments)getParentRef()).xdocumentDefinition;

            for (int i = 1; i <= documentDefinition.documentSections.Count; i++)
            {
                XDocumentSection section = documentDefinition.documentSections.Where(c => c.flow.Equals(getSection().flow - i)).SingleOrDefault();
                if (section.status == ApplicationCodes.DOCUMENT_STATUS_ACTIVE)
                {
                    setSection(section);
                    break;
                }
            }

            PageName getPageDetail = PageManager.readbyPageID(getSection().pageID);

            Response.Redirect(getPageDetail.webName);

        }
    }
}
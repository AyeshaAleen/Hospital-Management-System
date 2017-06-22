using Domains.itinsync.icom.interfaces.response;
using Forms.itinsync.src.session;
using Services.itinsync.icom.documents;
using Services.itinsync.icom.documents.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.date;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;
using Utils.itinsync.icom.xml;
using System.Xml;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.idocument.section;
using Domains.itinsync.icom.idocument;


namespace Forms.Webroot.Forms.SIO
{
    [Serializable()]
    public partial class Cleanliness :DocumentBasePage
    {

        private static string dbxml = "";
        private static string xml = "";
        private static int documentid = 0;
        private static int DocumentFlow = 0;
        private static string CurrentFileName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CurrentFileName = Path.GetFileName(Request.Path);
                CreateControl();
                loaddata();
            }
        }

        private void loaddata()
        {
            if (!string.IsNullOrEmpty(dbxml))
            {
                XMLUtils.processXML(this, dbxml, CurrentFileName);
            }
        }

        private void CreateControl()
        {
            XDocumentSection Section = ((Douments)getParentRef()).xdocumentDefinition.documentSections.Where(c => c.name.Equals(CurrentFileName)).SingleOrDefault();
            dbxml = ((Douments)getParentRef()).data;
            documentid = ((Douments)getParentRef()).documentID;
            DocumentFlow = Convert.ToInt32(Section.flow);

            if (Section != null)
            {
                Table obj_Table = processDynamicContent(tableDynamic, ((Douments)getParentRef()), Section.documentsectionid);
                tableDynamic.EnableViewState = true;
                ViewState["tableDynamic"] = true;
            }
        }

    

        protected override void LoadViewState(object savedState)
        {
            CreateControl();
            base.LoadViewState(savedState);

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {

            string CurrentFileName = Path.GetFileName(Request.Path);

            xml = XMLUtils.getDynamicXML(CurrentFileName, dbxml, this);

            IResponseHandler response =saveDocument(xml, documentid, DocumentFlow, ApplicationCodes.DOCUMENT_STATUS_INPROGRESS);

            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                Response.Redirect("BasicInfo.aspx");
            }

        }
       
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("Quality.aspx"); 
        }
    }
}
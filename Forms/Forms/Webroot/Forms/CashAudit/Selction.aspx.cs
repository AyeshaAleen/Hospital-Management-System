using Domains.itinsync.icom.idocument;
using Domains.itinsync.icom.idocument.section;
using Forms.itinsync.src.session;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.itinsync.icom.xml;

namespace Forms.Webroot.Forms.CashAudit
{
    public partial class Selction : BasePage
    {
        private int PAGENO = 1044;
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
                createControl();
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

        private void createControl()
        {
            XDocumentSection Section = ((Douments)getParentRef()).xdocumentDefinition.documentSections.Where(c => c.name.Equals("Selction")).SingleOrDefault();
            dbxml = ((Douments)getParentRef()).data;
            documentid = ((Douments)getParentRef()).documentID;
            DocumentFlow = Section.flow;

            if (Section != null)
            {
                Table obj_Table = processDynamicContent(tableDynamic, ((Douments)getParentRef()), Section.documentsectionid);
                tableDynamic.EnableViewState = true;
                ViewState["tableDynamic"] = true;
            }

        }

        protected override void LoadViewState(object savedState)
        {
            createControl();
            base.LoadViewState(savedState);

        }
        protected void btnNext_Click(object sender, EventArgs e)
        {

            
        }
    }
}
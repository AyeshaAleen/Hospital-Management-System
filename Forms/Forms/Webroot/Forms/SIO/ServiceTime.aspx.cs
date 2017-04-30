using Domains.itinsync.icom.idocument;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.idocument.section;
using Domains.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table.content;
using Domains.itinsync.icom.idocument.table.td;
using Domains.itinsync.icom.idocument.table.tr;
using Domains.itinsync.icom.interfaces.response;
using Forms.itinsync.src.session;
using Services.itinsync.icom.documents;
using Services.itinsync.icom.documents.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.date;

namespace Forms.Webroot.Forms.SIO
{
    public partial class ServiceTime : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //loaddata();
            }
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            loaddata();
            processDynamicContent(tableDynamic,getDocument());
        }

        private Douments getDocument()
        {
            Douments documents = new Douments();

            XDocumentDefination xdocumentDefinition = new XDocumentDefination();
            xdocumentDefinition.xDocumentDefinationID = 1001;
            xdocumentDefinition.name = "SIO";
            documents.xdocumentDefinition = xdocumentDefinition;


            //**********Section part***//
            XDocumentSection section = new XDocumentSection();
            section.documentdefinitionid = 1001;
            section.documentsectionid = 2;
            section.name = "serviceTime";
            section.flow = "1";
            documents.xdocumentDefinition.documentSections.Add(section);

            //**********Table***//
            XDocumentTable tables = new XDocumentTable();
            tables.documentTableID = 1;
            tables.documentsectionid = 2;
            tables.tableControlID = "tableDynamic";
            section.documentTable.Add(tables);


            //**********TR part***//
            XDocumentTableTR tr = new XDocumentTableTR();
            tr.trID = 1;
            tr.documentTableID = 1;
            tables.trs.Add(tr);


            //**********TD part***//

            XDocumentTableTD td = new XDocumentTableTD();
            td.trID = 1;
            td.tdID = 1;
            tr.tds.Add(td);

            //**********TD part***//
            XDocumentTableContent content = new XDocumentTableContent();
            content.tdID = 1;
            content.controlName = "dynamic123";
            content.controlID= "dynamic123";
            content.controlType = ApplicationCodes.FORMS_CONTROL_TAXTBOX;
            content.documentTableContentID = 1;
            content.isRequired = "1";
            content.mask = "numaric";
            content.tdID = 1;
            td.fields.Add(content);

            XDocumentTableContent content2 = new XDocumentTableContent();
            content2.tdID = 1;
            content2.controlName = "dynamic1234";
            content2.controlID = "dynamic1234";
            content2.controlType = ApplicationCodes.FORMS_CONTROL_TAXTBOX;
            content2.documentTableContentID = 1;
            content2.isRequired = "1";
            content2.mask = "numaric";
            content2.tdID = 1;
            td.fields.Add(content2);

            return documents;
        }

        private void loaddata()
        {
            if(!string.IsNullOrEmpty(getXMLSession()))
            {
                processXML(processDynamicDiv, getXMLSession(), "ServiceTime");
            }   
        }
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("GeneralSIO.aspx");
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            GeneralSIO.xml += "<ServiceTime>" + xmlConversion(this, "") + "</ServiceTime>";
            Response.Redirect("Service.aspx");
        }
    }
}
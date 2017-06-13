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

namespace Forms.Webroot.Forms.SIO
{
    [Serializable()]
    public partial class GeneralSIO : BasePage
    {

        private static string dbxml = "";
        public static string xml = "<SIO></SIO>";
        public static int documentid = 0;
        public static int DocumentFlow = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Manage_documents();

                getDocument();
                
            }
        }

        private void Manage_documents()
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document.storeid = Convert.ToInt32(getSubjectID());
            dto.document.documentDefinitionID = Convert.ToInt32(((XDocumentDefination)getParentRef()).xDocumentDefinationID);

            IResponseHandler response = new DocumentGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR)
            {
                save_data();
            }
        }

        private void getDocument()
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document.documentDefinitionID = Convert.ToInt32(((XDocumentDefination)getParentRef()).xDocumentDefinationID);
            dto.document.storeid = Convert.ToInt32(getSubjectID());
            IResponseHandler response = new DocumentGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                CreateControl(response);
            }
            }

        private void CreateControl(IResponseHandler response)
        {
            XDocumentSection Section = ((XDocumentDefination)getParentRef()).documentSections.Where(c=>c.name.Equals("GeneralSIO")).SingleOrDefault();
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                setResponseHandler(response);
                DocumentDTO dto = (DocumentDTO)response;
                dbxml = dto.document.data;
                documentid = dto.document.documentID;
                if(Section != null)
                {
                    Table obj_Table = processDynamicContent(tableDynamic, dto.document, Section.documentsectionid);
                    tableDynamic.EnableViewState = true;
                    ViewState["tableDynamic"] = true;
                }
            }
        }

        private void save_data()
        {

            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document.documentDefinitionID = Convert.ToInt32(((XDocumentDefination)getParentRef()).xDocumentDefinationID);
            dto.document.transDate = DateFunctions.getCurrentDateAsString();
            dto.document.transTime = DateFunctions.getCurrentTimeInMillis();
            dto.document.data = xml;
            dto.document.Userid = getHeader().userID;
            dto.document.storeid = Convert.ToInt32(getSubjectID());
            dto.document.documentID = documentid;
            dto.document.flow = DocumentFlow;
            IResponseHandler response = new DocumentSaveService().executeAsPrimary(dto);
           
        }


       

        protected override void LoadViewState(object savedState)
        {
            CreateControl(getResponseHandler());
            base.LoadViewState(savedState);
            
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
          

            xml = "<SIO>" + "<GeneralSIO>" + xmlConversion(this, "") + "</GeneralSIO>" + "</SIO>";

            string db_xml = dbxml;
            XMLParser xmlparser = new XMLParser(db_xml);
            db_xml = xmlparser.getTagXML("GeneralSIO");


            XMLParser xmlparser_In = new XMLParser(xml);
           

            string invalue = xmlparser_In.getTagXML("GeneralSIO");

            

            xmlparser.setTagXML("GeneralSIO", invalue.ToString());

            xml = xmlparser.getRootTagXML("GeneralSIO");

            save_data();
         
            Response.Redirect("ServiceTime.aspx");
        }

    }
}
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
using Utils.itinsync.icom.cache.document;

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
                createControl();
                
            }
        }
        
        private void createControl()
        {
            XDocumentSection Section = ((Douments)getParentRef()).xdocumentDefinition.documentSections.Where(c=>c.name.Equals("GeneralSIO")).SingleOrDefault();
            dbxml = ((Douments)getParentRef()).data;
            documentid = ((Douments)getParentRef()).documentID;
            if(Section != null)
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
          

            xml = "<SIO>" + "<GeneralSIO>" + xmlConversion(this, "") + "</GeneralSIO>" + "</SIO>";

            string db_xml = dbxml;
            XMLParser xmlparser = new XMLParser(db_xml);
            db_xml = xmlparser.getTagXML("GeneralSIO");


            XMLParser xmlparser_In = new XMLParser(xml);
           

            string invalue = xmlparser_In.getTagXML("GeneralSIO");

            

            xmlparser.setTagXML("GeneralSIO", invalue.ToString());

            xml = xmlparser.getRootTagXML("GeneralSIO");

             save_data();
            
         
            
        }

        private void save_data()
        {

            //need to move below code in genaric class as we need to call it from various point with same information
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document =(Douments) getParentRef();
            dto.document.data = xml;
            dto.document.flow = 2;
            IResponseHandler response = new DocumentSaveService().executeAsPrimary(dto);

            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (DocumentDTO)response;
                setParentRef(dto.document);
                Response.Redirect("ServiceTime.aspx");
            }

        }

    }
}
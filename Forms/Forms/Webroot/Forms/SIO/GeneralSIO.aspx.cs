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

namespace Forms.Webroot.Forms.SIO
{
    [Serializable()]
    public partial class GeneralSIO : BasePage
    {
        private static int section_id = 1;
        private static int documentDefinitionID = 1001;
        private static string dbxml = "";
        public static string xml = "";
        public static int documentid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                doLoad();

        }
        private void doLoad()
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document.documentDefinitionID = 1001;
            dto.document.storeid = 1;
            IResponseHandler response = new DocumentGetService().executeAsPrimary(dto);

            CreateControl(response);
        }
      
        private void CreateControl(IResponseHandler response)
        {
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                setResponseHandler(response);
                DocumentDTO dto = (DocumentDTO)response;
                dbxml = dto.document.data;
                documentid = dto.document.documentID;
                Table obj_Table = processDynamicContent(tableDynamic, dto.document, section_id);


                tableDynamic.EnableViewState = true;
                ViewState["tableDynamic"] = true;

            }
        }

        private void save_data()
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document.documentDefinitionID = documentDefinitionID;
            dto.document.transDate = DateFunctions.getCurrentDateAsString();
            dto.document.transTime = DateFunctions.getCurrentTimeInMillis();
            dto.document.data = xml;
            dto.document.Userid = getHeader().userID;
            dto.document.storeid = 1;

            
            dto.document.documentID = documentid;

            IResponseHandler response = new DocumentSaveService().executeAsPrimary(dto);
            //if(response.getErrorBlock().ErrorCode==ApplicationCodes.ERROR_NO)
            //{

            //}
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
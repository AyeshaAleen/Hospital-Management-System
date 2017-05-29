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

namespace Forms.Webroot.Forms.SIO
{
    public partial class GeneralSIO : BasePage
    {
        private static int section_id = 1;
        private static int documentDefinitionID = 1001;

        public static string xml = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
                this.CreateControl();


            string xml = @"<SIO><GeneralSIO><GSIORadioYes1>True</GSIORadioYes1><GSIORadioNo1>False</GSIORadioNo1><GSIORadioN_A1>False</GSIORadioN_A1><GSIORadioYes2>True</GSIORadioYes2><GSIORadioNo2>False</GSIORadioNo2><GSIORadioN_A2>False</GSIORadioN_A2><GSIORadioYes3>True</GSIORadioYes3><GSIORadioNo3>False</GSIORadioNo3><GSIORadioN_A3>False</GSIORadioN_A3><GSIORadioYes4>True</GSIORadioYes4><GSIORadioNo4>False</GSIORadioNo4><GSIORadioN_A4>False</GSIORadioN_A4><GSIORadioYes5>True</GSIORadioYes5><GSIORadioNo5>False</GSIORadioNo5><GSIORadioN_A5>False</GSIORadioN_A5><GSIORadioYes6>True</GSIORadioYes6><GSIORadioNo6>False</GSIORadioNo6><GSIORadioN_A6>False</GSIORadioN_A6><GSIORadioYes7>True</GSIORadioYes7><GSIORadioNo7>False</GSIORadioNo7><GSIORadioN_A7>False</GSIORadioN_A7><GSIORadioYes8>True</GSIORadioYes8><GSIORadioNo8>False</GSIORadioNo8><GSIORadioN_A8>False</GSIORadioN_A8><GSIORadioYes9>True</GSIORadioYes9><GSIORadioNo9>False</GSIORadioNo9><GSIORadioN_A9>False</GSIORadioN_A9><GSIORadioYes10>True</GSIORadioYes10><GSIORadioNo10>False</GSIORadioNo10><GSIORadioN_A10>False</GSIORadioN_A10><GSIORadioYes11>True</GSIORadioYes11><GSIORadioNo11>False</GSIORadioNo11><GSIORadioN_A11>False</GSIORadioN_A11><GSIORadioYes12>True</GSIORadioYes12><GSIORadioNo12>False</GSIORadioNo12><GSIORadioN_A12>False</GSIORadioN_A12><GSIORadioYes13>True</GSIORadioYes13><GSIORadioNo13>False</GSIORadioNo13><GSIORadioN_A13>False</GSIORadioN_A13><txtTotal>1.4861111111111114</txtTotal><txtResult></txtResult></GeneralSIO></SIO>";
            XMLParser xmlparser = new XMLParser(xml);
            xml = xmlparser.getTagXML( "GeneralSIO");

            string invalue = @"<GSIORadioYes1>True</GSIORadioYes1><GSIORadioNo1>False</GSIORadioNo1>";

            xmlparser.setTagXML("GeneralSIO", invalue); 

            xml = xmlparser.getTagXML("GeneralSIO");



        }
      
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
           // CreateControl();

        }
        private void CreateControl()
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document.documentDefinitionID = 1001;
            IResponseHandler response = new DocumentGetService().executeAsPrimary(dto);

            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (DocumentDTO)response;
                Table obj_Table = processDynamicContent(tableDynamic, dto.document, section_id);
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

            dto.document.documentID = 51;

            IResponseHandler response = new documentSaveService().executeAsPrimary(dto);
            //if(response.getErrorBlock().ErrorCode==ApplicationCodes.ERROR_NO)
            //{

            //}
        }


        

        protected void btnNext_Click(object sender, EventArgs e)
        {

            xml = "<SIO>" + "<GeneralSIO>" + xmlConversion(this, "") + "</GeneralSIO>" + "</SIO>";

            save_data();
         
            Response.Redirect("ServiceTime.aspx");
        }

    }
}
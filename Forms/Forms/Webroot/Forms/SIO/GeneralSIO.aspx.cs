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
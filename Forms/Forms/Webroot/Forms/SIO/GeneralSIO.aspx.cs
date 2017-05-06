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

namespace Forms.Webroot.Forms.SIO
{
    public partial class GeneralSIO : BasePage
    {
        private static int section_id = 1;

        public static string xml = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //loaddata();
            }
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {


            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document.documentName = "SIO";
            IResponseHandler response = new DocumentGetService().executeAsPrimary(dto);

            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (DocumentDTO)response;
                processDynamicContent(tableDynamic, dto.document, section_id);
            }

        }



        private void loaddata()
        {
            if (!string.IsNullOrEmpty(getXMLSession()))
            {
                processXML(validate, getXMLSession(), "ServiceTime");
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            xml = "<SIO>" + "<GeneralSIO>" + xmlConversion(this, "") + "</GeneralSIO>";
         
            Response.Redirect("ServiceTime.aspx");
        }
    }
}
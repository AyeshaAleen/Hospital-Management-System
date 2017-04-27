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
        public static string xml = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //loaddata();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            loaddata();
        }

        private void loaddata()
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document.documentName = "SIO";
            IResponseHandler response = new DocumentGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (DocumentDTO)response;
                if (dto.document == null)
                    return;
                else
                {
                    setXMLSession(dto.document.data);

                    processXML(this, dto.document.data, "GeneralSIO");
                }
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            xml = "<GeneralSIO>" + xmlConversion(this, "") + "</GeneralSIO>";
         
            Response.Redirect("ServiceTime.aspx");
        }
    }
}
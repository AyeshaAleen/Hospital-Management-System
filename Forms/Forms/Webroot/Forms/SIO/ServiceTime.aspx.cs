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

            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document.documentName = "SIO";
            IResponseHandler response = new DocumentGetService().executeAsPrimary(dto);

            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (DocumentDTO)response;
                processDynamicContent(tableDynamic, dto.document,2);
            }
            
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
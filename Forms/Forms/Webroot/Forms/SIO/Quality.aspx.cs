﻿using Domains.itinsync.icom.interfaces.response;
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
    public partial class Quality : BasePage
    {
        private static int section_id = 4;

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
                processXML(this, getXMLSession(), "Quality");
            }
        }
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("Service.aspx");
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            GeneralSIO.xml += "<Quality>" + xmlConversion(this, "") + "</Quality>";
            Response.Redirect("Cleanliness.aspx");
        }
    }
}
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
    public partial class Service : BasePage
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
        }
        private void loaddata()
        {
            if (!string.IsNullOrEmpty(getXMLSession()))
            {
                processXML(this, getXMLSession(), "Service");
            }
        }
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiceTime.aspx");
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            GeneralSIO.xml += "<Service>" + xmlConversion(this, "") + "</Service>";
            Response.Redirect("Quality.aspx");
        }
    }
}
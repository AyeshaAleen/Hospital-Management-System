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
    public partial class BasicInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
              //  loaddata();
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
                processXML(this, getXMLSession(), "BasicInfo");
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cleanliness.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GeneralSIO.xml += "<BasicInfo>" + xmlConversion(this, "") + "</BasicInfo>" + "</SIO>";
            DocumentDTO dto = new DocumentDTO();
            if (getSubjectIDInt() > 0)
                dto.document.documentID = getSubjectIDInt();
            dto.document.documentName = "SIO";
            dto.document.transDate = DateFunctions.getCurrentDateAsString();
            dto.document.transTime = DateFunctions.getCurrentTimeInMillis();
            dto.document.data = GeneralSIO.xml;
            IResponseHandler response = new documentSaveService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                showSuccessMessage(response);
            }
            else
            {
                showErrorMessage(response);
            }
        }
    }
}
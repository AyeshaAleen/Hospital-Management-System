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
using Services.icom.signature.dto;
using Services.icom.signature;
using Services.icom.document;

namespace Forms.Webroot.Forms.SIO
{
    [Serializable()]
    public partial class BasicInfo : BasePage
    {
  
        public static string xml = "";
        public static int documentid = 0;
        public static int DocumentFlow = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loaddata();
            }
        }
        private void loaddata()
        {
            if (!string.IsNullOrEmpty(getXMLSession()))
            {
               XMLUtils.processXML(this, getXMLSession(), "BasicInfo");
            }
        }

        private void save_data()
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document.documentDefinitionID = ((Douments)getParentRef()).xdocumentDefinition.xDocumentDefinationID;
            dto.document.transDate = DateFunctions.getCurrentDateAsString();
            dto.document.transTime = DateFunctions.getCurrentTimeInMillis();
            dto.document.data = xml;
            dto.document.Userid = getHeader().userID;
            dto.document.storeid = ((Douments)getParentRef()).storeid;
            dto.document.documentID = documentid;
            dto.document.flow = DocumentFlow;

            dto.signature.documentid = documentid;

            dto.signature.trandate = DateFunctions.getCurrentDateAsString();
            dto.signature.trantime = DateFunctions.getCurrentTimeInMillis();

            dto.signature.signaturestring = signature1.Value.Replace("data:image/png;base64,", "");
            dto.signature.signaturetype = ApplicationCodes.FORMS_SIGNATURE_TYPE_MANAGER;
            dto.signaturelist.Add(dto.signature);

            dto.signature.signaturestring = signature2.Value.Replace("data:image/png;base64,", "");
            dto.signature.signaturetype = ApplicationCodes.FORMS_SIGNATURE_TYPE_COMPLETEDBY;
            dto.signaturelist.Add(dto.signature);

            IResponseHandler response = new DocumentCompletionService().executeAsPrimary(dto);

            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                showSuccessMessage(response);
            }
            else
                showErrorMessage(response);
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            

        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            save_data();
        }
    }
}
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

namespace Forms.Webroot.Forms.SIO
{
    [Serializable()]
    public partial class BasicInfo : BasePage
    {
        private static string dbxml = "";
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
            IResponseHandler response = new DocumentSaveService().executeAsPrimary(dto);

            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                SaveSignature(signature1.Value,"");
                SaveSignature(signature2.Value, "");

                showSuccessMessage(response);
            }
            else
                showErrorMessage(response);
        }
        
        IResponseHandler SaveSignature(string signaturestring, string signaturetype)
        {
            SignatureDTO dto = new SignatureDTO();
            dto.header = getHeader();

            dto.signature.documentid = documentid;
            dto.signature.signaturestring = signaturestring.Replace("data:image/png;base64,", "");
            dto.signature.signaturetype = signaturetype;
            dto.signature.trandate= DateFunctions.getCurrentDateAsString();
            dto.signature.trantime= DateFunctions.getCurrentTimeInMillis();

            return new SignatureSaveService().executeAsPrimary(dto);
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            

        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveSignature(signature1.Value, "");
            SaveSignature(signature2.Value, "");
        }
    }
}
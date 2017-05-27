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
using Domains.itinsync.icom.idocument.section;

namespace Forms.Webroot.Forms.SIO
{
    public partial class GeneralSIO : BasePage
    {
        static int documentDefID = 1001, documentSecID = 0, documentID = 0, flowID = 0;
        int CompleteSecs = 0, TotalSecs = 0;
        static string SecPageName = "", nextPageURL = "", prevPageURL = "", rootPageName = "SIO";

        DocumentDTO dto;
        static string xml = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["documentID"] != null) documentID = (int)Session["documentID"];

                //if (documentID == 0) // It will be first page
                //{
                //    xml = "<" + rootPageName + "></" + rootPageName + ">";

                //    documentID = ((DocumentDTO)DbOperation()).document.documentID;
                //}
                documentID = 61;
                GetXml();
            }
        }


        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document.documentName = rootPageName;
            IResponseHandler response = new DocumentGetService().executeAsPrimary(dto);

            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (DocumentDTO)response;
                processDynamicContent(tableDynamic, dto.document, documentSecID);
            }
        }

        private void save_data()
        {
            //Control parent = tableDynamic;
            //Control tableControl = parent.FindControl("tableDynamic");
            //Table parentTable = ((Table)(tableControl));


            //for (int i = 0; i < parentTable.Rows.Count; i++)
            //{
            //    for (int j = 0; j < tableDynamic.Rows[i].Cells.Count; j++)
            //    {


            //        string cellValue = tableDynamic.Rows[i].Cells[j].Text;

            //    }
            //}
        }

        //private void loaddata()
        //{
        //    if (!string.IsNullOrEmpty(getXMLSession()))
        //    {
        //        processXML(validate, getXMLSession(), "ServiceTime");
        //    }
        //}

        void GetXml()
        {
            dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document.documentID = documentID;

            IResponseHandler response = new dynamicdocumenttableget().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (DocumentDTO)response;
                PrepareXml();
            }
        }
        void PrepareXml()
        {
            SecPageName = new FileInfo(Request.Url.AbsolutePath).Name.Replace(".aspx", "");

            xml = dto.document.data;
            int SIndex = 0, EIndex = 0;

            // Remove root ending tag for updation
            xml = xml.Replace("</" + rootPageName + ">", "");

            TotalSecs = dto.documentSectionlist.Count;
            CompleteSecs = 0;

            flowID = Convert.ToInt16((dto.documentSectionlist.FirstOrDefault(x => x.documentdefinitionid == documentDefID && x.name.Trim() == SecPageName).flow));
            documentSecID = Convert.ToInt16((dto.documentSectionlist.FirstOrDefault(x => x.documentdefinitionid == documentDefID && x.name.Trim()
            == SecPageName).documentsectionid));

            prevPageURL = (flowID > 1) ? dto.documentSectionlist.FirstOrDefault(x => x.flow == (flowID - 1).ToString()).name.Trim() : SecPageName;

            nextPageURL = dto.documentSectionlist.FirstOrDefault(x => x.flow == (flowID + 1).ToString()).name.Trim();
            nextPageURL = (nextPageURL.Length > 0) ? nextPageURL : SecPageName;

            foreach (XDocumentSection dSec in dto.documentSectionlist) CompleteSecs = (xml.Contains("<" + dSec.name.Trim() + ">")) ? CompleteSecs + 1 : CompleteSecs;

            decimal Perc = Math.Round(Convert.ToDecimal(CompleteSecs) / Convert.ToDecimal(TotalSecs) * 100);

            if (xml.Contains("<" + SecPageName + ">"))
            {
                SIndex = xml.IndexOf("<" + SecPageName + ">") + SecPageName.Length + 2;
                EIndex = xml.IndexOf("</" + SecPageName + ">");
                xml = (EIndex - SIndex > 0) ? xml.Replace(xml.Substring(SIndex, EIndex - SIndex), "") : xml;
            }
            else xml += "<" + SecPageName + ">" + "</" + SecPageName + ">";
        }
        int Pending = 0;
        void FinalizeXml()
        {
            if (flowID > TotalSecs)
            {
                string Tag = "<" + SecPageName + ">" + "</" + SecPageName + ">"; // Start and End Tags

                // If Start and End Tags existing, then it will place html between them
                if (xml.Contains(Tag)) xml = xml.Replace(Tag, "<" + SecPageName + ">" + Tages.Value + "</" + SecPageName + ">");

                // If Start and End Tags not existing, then it will concatenate html with tags
                else xml += "<" + SecPageName + ">" + Tages.Value + "</" + SecPageName + ">";

                xml += "</" + rootPageName + ">";
                Session["documentID"] = documentID;

                //  when there is last page 
                if (flowID == TotalSecs) { flowID++; Session["documentID"] = null; }

                // Update existing document
                DbOperation();
                if (Pending > 0) nextPageURL = "";
                Response.Redirect(nextPageURL + ".aspx");
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
           // FinalizeXml();
        }

        protected void btnPending_Click(object sender, EventArgs e)
        {
            Pending = 1;
            FinalizeXml();
        }
        protected void btnPrev_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPageURL + ".aspx");
        }
        IResponseHandler DbOperation()
        {
            dto = new DocumentDTO();
            dto.header = getHeader();
            //if (documentID > 0) dto.header = getHeader(); else getHeader();
            dto.document.documentID = documentID;

            dto.document.documentDefinitionID = documentDefID;
            dto.document.documentName = rootPageName;
            dto.document.transDate = DateFunctions.getCurrentDateAsString();
            dto.document.transTime = DateFunctions.getCurrentTimeInMillis();
            dto.document.data = xml;
            IResponseHandler response = new documentSaveService().executeAsPrimary(dto);
            return response;
        }
    }
}
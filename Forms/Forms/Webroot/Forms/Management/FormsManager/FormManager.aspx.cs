using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table.content;
using Domains.itinsync.icom.idocument.table.td;
using Domains.itinsync.icom.idocument.table.tr;
using Domains.itinsync.icom.interfaces.response;
using Forms.itinsync.src.session;
using HtmlAgilityPack;
using Services.itinsync.icom.documents;
using Services.itinsync.icom.documents.dto;
using Services.itinsync.icom.tablecontent;
using Services.itinsync.icom.tablecontent.dto;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.date;
using Utils.itinsync.icom.xml;

namespace Forms.Webroot.Forms.Management.FormsManager
{
    public partial class FormsManager : BasePage
    {
        private static int section_id = 8;
        private static int DDID = 1003;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDeopDown();
            }
        }
        private void loadDeopDown()
        {
            ddlLookupName.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKControlType, getHeader().lang);
            ddlLookupName.DataBind();

            ddlMask.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKMask, getHeader().lang);
            ddlMask.DataBind();
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.document.documentDefinitionID = DDID;
            IResponseHandler response = new DocumentGetService().executeAsPrimary(dto);

            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (DocumentDTO)response;
                Table table = new Table();
                processDynamicContentform(table, dto.document, section_id);

                
              
                StringWriter sw = new StringWriter();
                table.RenderControl(new HtmlTextWriter(sw));

                string html = sw.ToString();
                tableOuterHtml.Value = html;
            }

        }
    
        protected void savedocument_Click(object sender, EventArgs e)
        {


            string source = tableOuterHtml.Value;
            source = XMLUtils.DecodeXML(source);

            tablecontentDTO dto = new tablecontentDTO();
            dto.documentdefinitionID = DDID;
            dto.documentTable = HtmlParse(source, section_id);
            dto.documentTable.documentsectionid = section_id;

            IResponseHandler response = new tablecontentSaveService().executeAsPrimary(dto);
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
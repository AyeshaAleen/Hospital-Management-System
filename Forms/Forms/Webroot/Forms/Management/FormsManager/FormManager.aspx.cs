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
using Utils.itinsync.icom;
using Utils.itinsync.icom.html;

namespace Forms.Webroot.Forms.Management.FormsManager
{
    public partial class FormsManager : BasePage
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDropDown();
            }
        }
        private void loadDropDown()
        {
           // string m = Enum.GetName(typeof(LookupsConstant)value);

     

            //ddlLookupName.DataSource = LookupsConstant;
            //ddlLookupName.DataBind();
            ddlMask.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKMask, getHeader().lang);
            ddlMask.DataBind();
            ddlOperation.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKOperation, getHeader().lang);
            ddlOperation.DataBind();


            ddlLookupName.DataSource = LookupManager.readLookups(getHeader().lang);
            ddlLookupName.DataBind();

            
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            
            tableOuterHtml.Value = HTMLUtils.HTMLTable((XDocumentDefination)getParentRef(), Convert.ToInt32(getSubjectID()),getHeader().lang);

        }
    
        protected void savedocument_Click(object sender, EventArgs e)
        {


            string source = tableOuterHtml.Value;
            source = XMLUtils.DecodeXML(source);

            tablecontentDTO dto = new tablecontentDTO();
            dto.sectionnID = Convert.ToInt32(getSubjectID());

            //Delete existing record if any
            IResponseHandler responseDelete = new tablecontentDeleteService().executeAsPrimary(dto);
            if (responseDelete.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = new tablecontentDTO();

                dto.documentdefinitionID = ((XDocumentDefination)getParentRef()).xDocumentDefinationID;
                dto.documentTable =HTMLUtils.HtmlParse(source, Convert.ToInt32(getSubjectID()));
                dto.documentTable.documentsectionid = Convert.ToInt32(getSubjectID());





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
}
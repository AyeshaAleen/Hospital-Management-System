using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.interfaces.document;
using Domains.itinsync.icom.interfaces.response;
using Forms.itinsync.src.session;
using Services.icom.document.email;
using Services.icom.document.store.dto;
using Utils.itinsync.icom.cache.document;
using Utils.itinsync.icom.constant.application;

namespace Forms.Webroot.Forms.NewForm
{
    //Work by Qundeel Ch
    public partial class Forms : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
              
                getDocument_Store();
            }
                
        }
        private void getDocument_Store()
        {
            ddlForms.DataSource= DocumentManager.getDefinitions();
            ddlForms.DataBind();
            StoreDTO dto = new StoreDTO();
            dto.header = getHeader();
            IResponseHandler response = new StoreGetService().executeAsPrimary(dto);
            if(response.getErrorBlock().ErrorCode==ApplicationCodes.ERROR_NO)
            {
                dto = (StoreDTO)response;
                ddlStore.DataSource = dto.storelist;
                ddlStore.DataBind();
            }
        }

        protected void getDocumentDetail(object sender, EventArgs e)
        {
            XDocumentDefination DocumentDefinition = DocumentManager.getDocumentDefinition(Convert.ToInt32(ddlForms.SelectedValue));
            setParentRef(DocumentDefinition);
            //For Storing Store
            setSubjectID(ddlStore.SelectedValue);
            

            Response.Redirect("/Webroot/Forms/" +ddlForms.SelectedItem +"/"+ DocumentDefinition .documentSections.First().name+ ".aspx");
        }
    }
}
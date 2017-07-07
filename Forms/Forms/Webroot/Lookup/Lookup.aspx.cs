using Domains.itinsync.icom.interfaces.response;
using Forms.itinsync.src.session;
using Services.icom.lookup.dto;
using Services.icom.lookup.trans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.itinsync.icom.constant.application;

namespace Forms.Webroot.Lookup
{
    public partial class Lookup : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                getLookups();
        }

        protected void btnAddLookup_Click(object sender, EventArgs e)
        {
            saveLookupTrans();
        }
        protected void tblLookupDelete_RowClick(object sender, CommandEventArgs e)
        {
            LookupDTO dto = new LookupDTO();
            dto.header = getHeader();
            dto.lookup.lookUpID = Convert.ToInt32(e.CommandArgument);

            IResponseHandler response = new LookupDeleteService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (LookupDTO)response;
                getLookups();
                showSuccessMessage(response);
            }
            else
                showErrorMessage(response);
        }
        void getLookups()
        {
            LookupDTO dto = new LookupDTO();
            dto.header = getHeader();

            IResponseHandler response = new LookupGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (LookupDTO)response;
                repeaterLookup.DataSource = dto.lookuplist;
                repeaterLookup.DataBind();
            }
            else
                showErrorMessage(response);
        }
        void saveLookupTrans()
        {
            LookupDTO dto = new LookupDTO();
            dto.header = getHeader();
            dto.lookup.lookUpID = Convert.ToInt32(txtLookupsID.Value);
            
            dto.lookup.name = txtLookupName.Value;
            dto.lookup.code = txtLookupCode.Value;
            dto.lookup.text = txtLookupText.Value;

            dto.lookup.fr = txtFrench.Value;
            dto.lookup.sp = txtSpanish.Value;
            dto.lookup.ud = txtUrdu.Value;

            IResponseHandler response = new LookupSaveService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (LookupDTO)response;
                getLookups();
                txtLookupName.Value = txtLookupCode.Value = txtLookupText.Value 
                    = txtFrench.Value = txtSpanish.Value = txtUrdu.Value = "";
                showSuccessMessage(response);
            }
            else
                showErrorMessage(response);
        }
    }
}
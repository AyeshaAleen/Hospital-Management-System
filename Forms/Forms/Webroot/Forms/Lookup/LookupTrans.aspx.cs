using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Forms.itinsync.src.session;
using Domains.itinsync.icom.interfaces.response;

using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.constant.page;
using Services.itinsync.icom;
using DAO.itinsync.icom.lookup.trans;
using Services.icom.lookuptrans.dto;
using Services.icom.lookuptrans;
using System.IO;

namespace Forms.Webroot.Forms.Lookup
{
    public partial class LookupTrans : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                getLookupTrans();
        }

        protected void btnAddLookup_Click(object sender, EventArgs e)
        {
            LookupTransDTO dto = new LookupTransDTO();
            dto.header = getHeader();
            dto.lookupTrans.lang = dto.header.lang;
            dto.lookupTrans.value = txtLookupName.Value;
            dto.lookupTrans.code = dto.lookupTrans.value.Replace(" ", ".");

            IResponseHandler response = new LookupTransSaveService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (LookupTransDTO)response;
                getLookupTrans();
                showSuccessMessage(response);
            }
            else
                showErrorMessage(response);
        }
        protected void tblLookup_RowClick(object sender, CommandEventArgs e)
        {
            LookupTransDTO dto = new LookupTransDTO();
            dto.header = getHeader();
            dto.lookupTrans.lookupTransID = Convert.ToInt32(e.CommandArgument);

            IResponseHandler response = new LookupTransDeleteService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (LookupTransDTO)response;
                getLookupTrans();
                showSuccessMessage(response);
            }
            else
                showErrorMessage(response);
        }

        void getLookupTrans()
        {
            LookupTransDTO dto = new LookupTransDTO();
            dto.header = getHeader();
            
            IResponseHandler response = new LookupTransGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (LookupTransDTO)response;
                repeaterLookupTrans.DataSource = dto.lookupTranslist;
                repeaterLookupTrans.DataBind();
            }
            else
                showErrorMessage(response);
        }
    }
}
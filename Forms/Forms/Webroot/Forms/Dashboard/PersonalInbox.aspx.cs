using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domains.itinsync.icom.interfaces.response;
using Forms.itinsync.src.session;
using Services.itinsync.icom.documents;
using Services.itinsync.icom.documents.dto;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.constant.page;
using Utils.itinsync.icom.cache.pages;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.constant.lookup;

using Services.itinsync.icom.useraccounts.dto;
using Services.itinsync.icom.useraccounts;

using System.Data;
using Utils.itinsync.icom.cache.document;
using Domains.itinsync.icom.idocument;

namespace Forms.Webroot.Forms.Dashboard
{
    public partial class PersonalInbox : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DocumentDTO dtoDoc = new DocumentDTO();
                dtoDoc.header = getHeader();
                dtoDoc.READBY = ReadByConstant.READBYALL;

                IResponseHandler responseDoc = new DocumentGetService().executeAsPrimary(dtoDoc);
                if (responseDoc.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                {
                     dtoDoc.documentList = ((DocumentDTO)responseDoc).documentList.Where(x => x.status == ApplicationCodes.DOCUMENT_STATUS_INPROGRESS).ToList();
                }

                if (dtoDoc.documentList.Count > 0)
                {
                    UserAccountsDTO dtoUsers = new UserAccountsDTO();
                    dtoUsers.header = getHeader();

                    IResponseHandler responseUsers = new UserAccountsGetService().executeAsPrimary(dtoUsers);
                    if (responseUsers.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                    {
                        dtoUsers = (UserAccountsDTO)responseUsers;

                        foreach (Douments document in dtoDoc.documentList)
                            document.Users = dtoUsers.userAccountsList.Where(x => x.userID.Equals(document.Userid)).SingleOrDefault().userName;

                        tblDocument.DataSource = dtoDoc.documentList;
                        tblDocument.DataBind();
                    }
                }
            }
        }
        protected void btnViewDocument_Command(object sender, CommandEventArgs e)
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            
            dto.document.documentID= Convert.ToInt32(e.CommandArgument);

            IResponseHandler response = new DocumentGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (DocumentDTO)response;

                Response.Redirect(getWebPageName(dto.document.xdocumentSection.pageID));
            }

        }
    }
}
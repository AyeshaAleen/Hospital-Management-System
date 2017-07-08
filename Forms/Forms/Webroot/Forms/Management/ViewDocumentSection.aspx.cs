﻿using System;
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
using Domains.itinsync.icom.idocument.definition;
using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.constant.lookup;

using Services.itinsync.icom.useraccounts.dto;
using Services.itinsync.icom.useraccounts;
using Services.itinsync.icom.document.dynamic.role;
using Services.itinsync.icom.document.dynamic.route;
using Services.itinsync.icom.document.dynamic.routeusers;
using Services.itinsync.icom.document.dynamic.section;
using Services.itinsync.icom.document.dynamic.definition;
using System.Data;
using Utils.itinsync.icom.cache.document;
using Domains.itinsync.icom.idocument.section;
using System.Web.Services;
using Services.itinsync.icom.document.dynamic.page;

namespace Forms.Webroot.Forms.Management
{
    public partial class ViewDocumentSection : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                doLoad();
               // setSubjectID()
            }
                
        }

        private void doLoad()
        {
            //ddlsectionPagesName.DataSource = PageManager.getPages();
            //ddlsectionPagesName.DataBind();
            if (getParentRef() != null)
            {
                tblDocument.DataSource = ((XDocumentDefination)getParentRef()).documentSections;
                tblDocument.DataBind();
            }
            ddlUserRole.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKUserRole, getHeader().lang);
            ddlUserRole.DataBind();

            ddlEmailRouting.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKEmailRouting, getHeader().lang);
            ddlEmailRouting.DataBind();

            ddlUserRouting.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKUserEmailRouting, getHeader().lang);
            ddlUserRouting.DataBind();

            LoadUsers();//getUsers()
            LoadUserRoleTbl();//getRoles
            LoadEmailRoutingTbl();//getEmailRoutes
        }
        void LoadUsers()
        {
            UserAccountsDTO dto = new UserAccountsDTO();
            dto.header = getHeader();

            IResponseHandler response = new UserAccountsGetService().executeAsPrimary(dto);
            if(response.getErrorBlock().ErrorCode==ApplicationCodes.ERROR_NO)
            {
                ddlUsers.DataSource = ((UserAccountsDTO)response).userAccountsList;
                ddlUsers.DataBind();
            }
           
        }
        void LoadUserRoleTbl()
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            IResponseHandler response = new DocumentRoleGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (DocumentDTO)response;
                tblUserRole.DataSource = dto.documentRolelist;
                tblUserRole.DataBind();
                //loadUsersUpdatePanel.Update();
            }
        }

        void LoadEmailRoutingTbl()
        {
            tblRoute.DataSource = DocumentManager.getDefinitionRoute(getParentRef().getParentrefKey());
            tblRoute.DataBind();

            tblRouteUsers.DataSource = DocumentManager.getDefinitionRouteUsers(getParentRef().getParentrefKey());
            tblRouteUsers.DataBind();

            chkEmail.Checked = DocumentManager.getDocumentDefinition(getParentRef().getParentrefKey()).email== "0" ? true : false;
            chkStorage.Checked = DocumentManager.getDocumentDefinition(getParentRef().getParentrefKey()).storage == "0" ? true : false;

        }

        protected void btnViewDocument_Command(object sender, CommandEventArgs e)
        {
            setSubjectID(Convert.ToString(e.CommandArgument));
            Response.Redirect(PageConstant.PAGE_DocumentSectiondynamicForm);
        }

        protected void btnDeleteDocument_Command(object sender, CommandEventArgs e)
        {
            DocumentDTO dtoIn = new DocumentDTO();
            dtoIn.header = getHeader();

            dtoIn.documentSection.documentsectionid = Convert.ToInt32(e.CommandArgument);

            XDocumentSection getSectionStatus = DocumentManager.getDocumentSection(Convert.ToInt32(e.CommandArgument));
            dtoIn.documentSection.pageID = getSectionStatus.pageID;
            dtoIn.documentSection.flow = getSectionStatus.flow;
            dtoIn.documentSection.documentdefinitionid = ((XDocumentDefination)getParentRef()).xDocumentDefinationID;

            if (getSectionStatus.status == ApplicationCodes.DOCUMENT_STATUS_ACTIVE)
            {

                dtoIn.documentSection.status = ApplicationCodes.DOCUMENT_STATUS_DEACTIVE;
            }
            else
                dtoIn.documentSection.status=ApplicationCodes.DOCUMENT_STATUS_ACTIVE;

            IResponseHandler response = new DocumentSectionSaveService().executeAsPrimary(dtoIn);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                setParentRef(dtoIn.documentDefination);
                showSuccessMessage(response);
                doLoad();
            }
            else
                showErrorMessage(response);
        }

       
        protected void btnSaveSection_Click(object sender, EventArgs e)
        {
            DocumentDTO dtoIn = new DocumentDTO();
            dtoIn.header = getHeader();

            dtoIn.documentSection.name = field.Value;
            dtoIn.documentSection.flow = tblDocument.Controls.Count + 1;
            dtoIn.documentSection.documentdefinitionid = ((XDocumentDefination)getParentRef()).xDocumentDefinationID;
            dtoIn.documentSection.status = ApplicationCodes.DOCUMENT_STATUS_ACTIVE;

            dtoIn.page.pageName = field.Value;
            dtoIn.page.webName = PageConstant.PAGE_DOCUMENT_SECTION;

            IResponseHandler response = new DocumentPageSaveService().executeAsPrimary(dtoIn);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dtoIn = (DocumentDTO)response;

                setParentRef(DocumentManager.getDocumentDefinition(Convert.ToInt32(dtoIn.documentSection.documentdefinitionid)));
                showSuccessMessage(response);
                doLoad();
            }
            else
                showErrorMessage(response);
          
        }

        protected void btnAddUserRole_Click(object sender, EventArgs e)
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();

            dto.documentRole.xdocumentdefinitionid = getParentRef().getParentrefKey();
            dto.documentRole.role = Convert.ToInt32(ddlUserRole.SelectedValue);

            IResponseHandler response = new DocumentRoleSaveService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                showSuccessMessage(response);
                LoadUserRoleTbl();
            }
            else
                showErrorMessage(response);
           
        }

        //protected void btnEditUserRole_Command(object sender, CommandEventArgs e)
        //{
        //    //DocumentDTO dto = new DocumentDTO();
        //    //dto.header = getHeader();

        //    //dto.documentRole.xdocumentroleid = Convert.ToInt32(e.CommandArgument);
        //    //ddlOperation.SelectedValue = Convert.ToString(e.CommandArgument);
        //    //dto.documentRole.xdocumentdefinitionid = Convert.ToInt32(getSubjectID());
        //    //dto.documentRole.role = Convert.ToInt32(ddlOperation.SelectedValue);
        //}

        protected void btnDeleteUserRole_Command(object sender, CommandEventArgs e)
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
            dto.documentRole.xdocumentroleid = Convert.ToInt32(e.CommandArgument);

            IResponseHandler response = new DocumentRoleDeleteService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                showSuccessMessage(response);
                LoadUserRoleTbl();
            }
            else
                showErrorMessage(response);
           
        }
        protected void btnAddUserEmailRouting_Click(object sender, EventArgs e)
        {
            DocumentDTO dto = new DocumentDTO();
            dto.documentRouteUsers.xdocumentdefinitionid = getParentRef().getParentrefKey();
            dto.documentRouteUsers.role = Convert.ToInt32(ddlUserRouting.SelectedValue);
            dto.documentRouteUsers.userid = Convert.ToInt32(ddlUsers.SelectedValue);
            dto.documentRouteUsers.useremail = txtUserEmail.Value;

            IResponseHandler response = new DocumentRouteUsersSaveService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                showSuccessMessage(response);
                LoadEmailRoutingTbl();
            }
            else
                showErrorMessage(response);
        }
        protected void btnAddEmailRouting_Click(object sender, EventArgs e)
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();
                dto.documentRoute.xdocumentdefinitionid = getParentRef().getParentrefKey();
                dto.documentRoute.role = Convert.ToInt32(ddlEmailRouting.SelectedValue);

                IResponseHandler response = new DocumentRouteSaveService().executeAsPrimary(dto);
                if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                {
                showSuccessMessage(response);
                LoadEmailRoutingTbl();
                }
                else
                    showErrorMessage(response);
           
        }
        protected void btnDeleteRoute_Command(object sender, CommandEventArgs e)
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();

            dto.documentRoute.id = Convert.ToInt32(e.CommandArgument);
            IResponseHandler response = new DocumentRouteDeleteService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                showSuccessMessage(response);
                LoadEmailRoutingTbl();
            }
            else
                showErrorMessage(response);
          
        }
        protected void btnDeleteRouteUsers_Command(object sender, CommandEventArgs e)
        {
            DocumentDTO dto = new DocumentDTO();
            dto.header = getHeader();

            dto.documentRouteUsers.id = Convert.ToInt32(e.CommandArgument);
            IResponseHandler response = new DocumentRouteUsersDeleteService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                showSuccessMessage(response);
                LoadEmailRoutingTbl();
            }
            else
                showErrorMessage(response);
           
        }
    }
}
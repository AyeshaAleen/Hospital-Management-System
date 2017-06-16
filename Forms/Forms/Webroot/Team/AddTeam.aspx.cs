using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Forms.itinsync.src.session;
using Domains.itinsync.icom.interfaces.response;
using Services.itinsync.icom.team.dto;
using Services.itinsync.icom.team;

using Utils.itinsync.icom.cache.lookup;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.constant.lookup;
using Utils.itinsync.icom.date;
using Utils.itinsync.icom.constant.page;

using DAO.itinsync.icom.team;
//Created By Qundeel Ch

namespace Forms.Webroot.Team
{
    public partial class AddTeam : BasePage
    {
        private Int32 PAGEID = 1024;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (hasPermission(PAGEID))
                {
                    LoadlookUp();

                    searchTeam();
                  

                        //vendorDisplay(getSubjectID());

                }
            }
        }

        private void LoadlookUp()
        {
            ddlStatus.DataSource = LookupManager.readbyLookupName(LookupsConstant.LKUserStatus, getHeader().lang);
            ddlStatus.DataBind();
        }
        

        private void searchTeam()
        {
            if (getSubjectID() != null && getSubjectID().Length > 0)
            {
                TeamDTO dto = new TeamDTO();
                dto.header = getHeader();
                dto.team.teamID = Convert.ToInt32(getSubjectID());
                dto.READBY = ReadByConstant.READBYID;
                IResponseHandler response = new TeamGetService().executeAsPrimary(dto);
                if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                {
                    dto = (TeamDTO)response;
                    txtTeamName.Value = dto.team.teamName;
                    ddlStatus.SelectedValue =dto.team.status;

                    showSuccessMessage(response);
                }
                else
                    showErrorMessage(response);
            }
        }



        private IResponseHandler saveTeamDetails()
        {
            TeamDTO dto = new TeamDTO();
            dto.header = getHeader();
            if (getSubjectID() != null && getSubjectID().Length > 0)
                dto.team.teamID = Convert.ToInt32(getSubjectID());
            dto.team.teamName = txtTeamName.Value;
            dto.team.status = ddlStatus.SelectedValue;
          
        

            return new TeamSaveService().executeAsPrimary(dto);
        }

        protected void btnClearForm_Click(object sender, EventArgs e)
        {
        }
        protected void btnUpdateTeam_Click(object sender, EventArgs e)
        {
            IResponseHandler response = saveTeamDetails();
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                showSuccessMessage(response);

                TeamDTO dto = (TeamDTO)response;
                setSubjectID(dto.team.teamID.ToString());

               
                txtTeamName.Value = "";
               // ddlStatus.SelectedValue = 0;

               // Redirect(PageConstant.PAGE_ManageTeam);
            }
            else
                showErrorMessage(response);
        }


    }
}
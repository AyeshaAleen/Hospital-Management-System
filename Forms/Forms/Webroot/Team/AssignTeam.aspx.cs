using ARS.itinsync.src.session;
using Domains.itinsync.icom.interfaces.response;
using Services.itinsync.icom.team;
using Services.itinsync.icom.team.dto;
using Services.itinsync.icom.useraccounts;
using Services.itinsync.icom.useraccounts.dto;
using Services.itinsync.icom.userteamview;
using Services.itinsync.icom.userteamview.dto;
using System;
using System.Web.UI.WebControls;
using Utils.itinsync.icom.constant.application;

namespace ARS.Webroot.Desktop.Team
{
    public partial class AssignTeam : BasePage
    {
        private int PAGEID = 1029;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (hasPermission(PAGEID))
                {
                    getUserName();
                    getUserTeams();
                    getTeams();
                }
            }
        }

        private void getUserName()
        {
            UserAccountsDTO dto = new UserAccountsDTO();
            if (getSubjectID() != null && getSubjectID().Length > 0)
                dto.useraccounts.userID = Convert.ToInt32(getSubjectID());
            dto.READBY = ReadByConstant.READBYID;
            IResponseHandler response = new UserAccountsGetService().executeAsPrimary(dto);
            lblname.InnerText = dto.useraccounts.firstName + " " + dto.useraccounts.lastName;
        }

        private void getUserTeams()
        {
            if (getSubjectID() != null && getSubjectID().Length > 0)
            {
                UserTeamViewDTO dto = new UserTeamViewDTO();
                dto.header = getHeader();
                dto.userteamview.userID = Convert.ToInt32(getSubjectID());
                IResponseHandler response = new UserTeamViewGetService().executeAsPrimary(dto);
                if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                {
                    dto = (UserTeamViewDTO)response;
                    tblUserTeams.DataSource = dto.userTeamViewList;
                    tblUserTeams.DataBind();
                }
                else
                    showErrorMessage(response);
            }
        }
        private void getTeams()
        {
            TeamDTO dto = new TeamDTO();
            dto.header = getHeader();
            dto.READBY = ReadByConstant.READBYALL;
            IResponseHandler response = new TeamGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (TeamDTO)response;
                ddlTeam.DataSource = dto.teamList;
                ddlTeam.DataBind();
            }
            else
                showErrorMessage(response);
        }
        protected void tbl_Delete_Click(object sender, CommandEventArgs e)
        {
            Int32 utid = Convert.ToInt32(e.CommandArgument);
            deleteTeam(utid);
            TeamDTO dto = new TeamDTO();
            IResponseHandler response = new TeamGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                getUserTeams();
            else
                showErrorMessage(response);
        }

        private IResponseHandler deleteTeam(Int32 utid)
        {
            UserTeamDTO dto = new UserTeamDTO();
            dto.header = getHeader();
            if (getSubjectID() != null && getSubjectID().Length > 0)
            {
                dto.userteam.userTeamID = utid;
            }
            return new UserTeamDeleteService().executeAsPrimary(dto);
        }

        protected void btnAddTeam_Click(object sender, EventArgs e)
        {
            addTeam();
            TeamDTO dto = new TeamDTO();
            dto.READBY = ReadByConstant.READBYALL;
            IResponseHandler response = new TeamGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
                getUserTeams();
            else
                showErrorMessage(response);
        }

        private IResponseHandler addTeam()
        {
            UserTeamDTO dto = new UserTeamDTO();
            dto.header = getHeader();
            if (getSubjectID() != null && getSubjectID().Length > 0)
                dto.userteam.userID = Convert.ToInt32(getSubjectID());
            dto.userteam.teamID = Convert.ToInt32(ddlTeam.SelectedValue);
            return new UserTeamSaveService().executeAsPrimary(dto);
        }
    }
}
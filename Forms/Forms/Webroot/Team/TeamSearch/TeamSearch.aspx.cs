using ARS.itinsync.src.session;
using Domains.itinsync.icom.interfaces.response;

using Services.itinsync.icom.team;
using Services.itinsync.icom.team.dto;


using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.itinsync.icom.constant.application;
using Utils.itinsync.icom.constant.page;



namespace ARS.Webroot.Desktop.Team.TeamSearch
{
    public partial class TeamSearch : BasePage
    {
        private Int32 PAGEID = 1023;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (hasPermission(PAGEID)) { }
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
          Redirect(PageConstant.PAGE_AddTeam);
        }
        protected void btnClearForm_Click(object sender, EventArgs e)
        {



            txtTeamName.Value = "";

        }

        protected void btnSearchTeam_Click(object sender, EventArgs e)
        {
            TeamDTO dto = new TeamDTO();
            dto.header = getHeader();
            dto.team.teamName = txtTeamName.Value;
            dto.READBY = ReadByConstant.READBYNAME;
            IResponseHandler response = new TeamGetService().executeAsPrimary(dto);
            if (response.getErrorBlock().ErrorCode == ApplicationCodes.ERROR_NO)
            {
                dto = (TeamDTO)response;
                repeaterTeam.DataSource = dto.teamList;
                repeaterTeam.DataBind();
            }
            else
                showErrorMessage(response);
        }
        protected void tblTeam_RowClick(object sender, CommandEventArgs e)
        {
            setSubjectID(Convert.ToString(e.CommandArgument));
            Redirect(PageConstant.PAGE_AddTeam);
        }
    }
}
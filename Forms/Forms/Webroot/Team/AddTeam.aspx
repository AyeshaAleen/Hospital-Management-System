<%@ Page Title="Add Team" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="AddTeam.aspx.cs" Inherits="Forms.Webroot.Team.AddTeam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b><% Response.Write(trasnlation("Add.New.Team")); %></b></h4>

                <div class="col-md-6 col-md-offset-2 col-sm-12">
                <div class="form-group">
                    <label class="col-sm-4 control-label"><% Response.Write(trasnlation("Team.Name")); %> *</label>
                    <div class="col-sm-8">
                        <input type="text" id="txtTeamName" runat="server" required placeholder="Team.Name" class="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-4 control-label"><% Response.Write(trasnlation("Status")); %></label>
                    <div class="col-sm-8">
                        <asp:DropDownList ID="ddlStatus" runat="server" DataValueField="Code" DataTextField="Text" CssClass="chosen-select form-control">
                        </asp:DropDownList>
                    </div>
                </div>


                <div class="form-group col-xs-12">
                    <div class="pull-right text-right">
                        <asp:Button ID="btnClearForm" runat="server" Text="Clear" OnClick="btnClearForm_Click" class="btn btn-info waves-effect waves-light" />
                        <asp:Button ID="btnUpdateTeam" runat="server" OnClick="btnUpdateTeam_Click" Text="Save" class="btn btn-info waves-effect waves-light" />
                    </div>
                </div>
                    </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

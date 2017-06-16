<%@ Page Title="Add Team" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="AddTeam.aspx.cs" Inherits="Forms.Webroot.Team.AddTeam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormMasterBody" runat="server">
  <div class="page-content">

        <div class="page-header">
            <h1><% Response.Write(trasnlation("Add.New.Team")); %></h1>
        </div>
        <!-- /.page-header -->

        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->

                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("Team.Name")); %> *</label>

                            <div class="col-sm-8">
                                <input type="text" id="txtTeamName" runat="server" required placeholder="Team.Name" class="form-control" />
                            </div>
                        </div>

                         <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("Status")); %></label>

                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlStatus" runat="server" DataValueField="Code" DataTextField="Text" CssClass="chosen-select form-control">
                                </asp:DropDownList>
                               
                            </div>
                        </div>


                        <div class="form-group col-xs-12">
                        <div class="pull-right text-right">
                        <asp:Button ID="btnUpdateTeam" runat="server" OnClick="btnUpdateTeam_Click" Text="Save" class="btn btn-sm btn-success"/>
                        <asp:Button ID="btnClearForm" runat="server" Text="Clear" OnClick="btnClearForm_Click" class="btn btn-sm btn-primary"/>
                    </div>
                        </div>
                    </div>

                </div>
                <!-- PAGE CONTENT ENDS -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

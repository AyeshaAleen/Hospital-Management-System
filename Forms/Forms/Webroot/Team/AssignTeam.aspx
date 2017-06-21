<%@ Page Title="Assign Team" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="AssignTeam.aspx.cs" Inherits="Forms.Webroot.Team.AssignTeam" %>
<asp:Content ID="AssignTeamHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="AssignTeamBody" ContentPlaceHolderID="FormMasterBody" runat="server">
   <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b><label class="label label-info text-uppercase" runat="server" id="lblname"></label></b></h4>

                <div class="row">
                    
                    <div class="col-xs-12">
                      
                            <table class="table-bordered table-striped" data-toggle="table" data-search="true" data-page-list="[10, 20, 50, 100]" data-page-size="10" data-pagination="true">
                                <thead>
                                    <tr>
                                        <th data-field="name" data-sortable="true"><% Response.Write(trasnlation("Teams")); %></th>
                                        <th data-field="name" data-align="center"><% Response.Write(trasnlation("Delete")); %></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="tblUserTeams" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                              <td>
                                                <asp:Label runat="server" ID="tbllText" Text='<%# Eval("teamName") %>' /></td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnEdit" runat="server" CssClass="ace-icon fa fa-close bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "userTeamID") ) %>'
                                                        CommandName='edit' OnCommand="tbl_Delete_Click" ToolTip="View">
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>

                <div class="col-xs-12">
                        <h1>Add New Team</h1>
                         <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("Teams")); %></label>

                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlTeam" DataValueField="teamID" DataTextField="teamName"  runat="server" CssClass="chosen-select form-control">
                                    
                                </asp:DropDownList>
                               
                            </div>
                        </div>
                    </div>


                <div class="form-group col-xs-12">
                            <div class="pull-right text-right">
                                <asp:Button ID="btnAddTeam" runat="server" OnClick="btnAddTeam_Click" Text="Add.Team" class="btn btn-info waves-effect waves-light" />
                            </div>
                        </div>

                </div>
            </div>

        </div>

</asp:Content>
<asp:Content ID="AssignTeamFooter" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

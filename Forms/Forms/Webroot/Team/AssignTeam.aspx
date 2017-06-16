<%@ Page Title="Assign Team" Language="C#" MasterPageFile="~/Webroot/Desktop/DesktopMaster.master" AutoEventWireup="true" CodeBehind="AssignTeam.aspx.cs" Inherits="ARS.Webroot.Desktop.Team.AssignTeam" %>
<asp:Content ID="AssignTeamHead" ContentPlaceHolderID="DesktopMasterHeader" runat="server">
</asp:Content>
<asp:Content ID="AssignTeamBody" ContentPlaceHolderID="DesktopMasterBody" runat="server">
    <div class="page-content">

        <div class="page-header">
            <h1 style="text-align:center"><label class="label label-info text-uppercase" runat="server" id="lblname"></label></h1>
        </div>
        <!-- /.page-header -->

        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->

                <div class="row">
                    
                    <div class="col-xs-12">
                        <div class="clearfix">
                            <div class="pull-right tableTools-container"></div>
                        </div>
                        <div class="table-header">
                             <% Response.Write(trasnlation("Current.Teams")); %>
                        </div>

                        <!-- div.table-responsive -->

                        <!-- div.dataTables_borderWrap -->
                        <div>
                            <table class="table table-striped table-bordered table-hover dynamic-table" id="tbluserTeam">
                                <thead>
                                    <tr>
                                        <th style="text-align:center"><% Response.Write(trasnlation("Teams")); %></th>
                                        <th style="text-align:center"><% Response.Write(trasnlation("Delete")); %></th>
                                    </tr>
                                </thead>
                                <tbody runat="server" id="Tbody1">
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
                                <asp:Button ID="btnAddTeam" runat="server" OnClick="btnAddTeam_Click" Text="Add.Team" class="btn btn-sm btn-success" />
                            </div>
                        </div>


                </div>
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
<asp:Content ID="AssignTeamFooter" ContentPlaceHolderID="DesktopMasterFooter" runat="server">
</asp:Content>

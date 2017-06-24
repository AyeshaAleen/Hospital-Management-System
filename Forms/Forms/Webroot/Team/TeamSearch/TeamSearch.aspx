<%@ Page Title="Team Search" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="TeamSearch.aspx.cs" Inherits="Forms.Webroot.Team.TeamSearch.TeamSearch" %>

<asp:Content ID="cntTeamSearchHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntTeamSearchBody" ContentPlaceHolderID="FormMasterBody" runat="server">
  <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b><% Response.Write(trasnlation("Team.Search")); %></b></h4>

           
                        <div class="form-group col-md-6 col-sm-12">
                            
                                <input type="text" id="txtTeamName" runat="server" placeholder="type for team search..." class="form-control" />
                        </div>


                        <div class="form-group col-md-6 col-sm-12">
                            <div class="text-right">
                                <asp:Button ID="btnSearchTeam" runat="server" OnClick="btnSearchTeam_Click" Text="Search" class="btn btn-success waves-effect waves-light" />
                                <asp:Button ID="btnClearForm" runat="server" Text="Clear" OnClick="btnClearForm_Click" class="btn btn-success waves-effect waves-light" />
                                <asp:Button ID="btnAddNew" runat="server" Text="Add.New" OnClick="btnAddNew_Click" class="btn btn-success waves-effect waves-light" />
                            </div>
                        </div>


                <div class="row">
                    <div class="col-xs-12">
                            <table class="table-bordered table-striped" data-toggle="table" data-search="true" data-page-list="[10, 20, 50, 100]" data-page-size="10" data-pagination="true">
                            
                                <thead>
                                    <tr>
                                        <th data-field="id"><% Response.Write(trasnlation("Team.ID")); %></th>
                                        <th data-field="name" data-sortable="true"><% Response.Write(trasnlation("Vendor.Name")); %></th>
                                        <th data-field="action" data-align="center"><% Response.Write(trasnlation("Action")); %></th>
                                    </tr>
                                </thead>

                              <tbody>
                                    <asp:Repeater ID="repeaterTeam" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="tblRefrenceNo" Text='<%# Eval("teamID") %>' />
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="tlblName" Text='<%# Eval("teamName") %>' /></td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnEdit" runat="server" CssClass="ace-icon fa fa-edit bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "teamID") ) %>'
                                                        CommandName='Edit' OnCommand="tblTeam_RowClick" ToolTip="Edit">
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                            
                    </div>
                </div>

            </div>
        </div>
      </div>
</asp:Content>
<asp:Content ID="cntTeamSearchFooter" ContentPlaceHolderID="FormMasterFoot" runat="server">

</asp:Content>

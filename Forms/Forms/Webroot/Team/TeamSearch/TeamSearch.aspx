<%@ Page Title="Team Search" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="TeamSearch.aspx.cs" Inherits="Forms.Webroot.Team.TeamSearch.TeamSearch" %>

<asp:Content ID="cntTeamSearchHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntTeamSearchBody" ContentPlaceHolderID="FormMasterBody" runat="server">

    <div class="page-content">

        <div class="page-header">
            <h1><% Response.Write(trasnlation("Team.Search")); %></h1>
        </div>
        <!-- /.page-header -->

        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->
             <%--   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                          <ContentTemplate>--%>

                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("Team.Name")); %></label>

                            <div class="col-sm-8">
                                <input type="text" id="txtTeamName" runat="server" placeholder="Team.Name" class="form-control" />
                            </div>
                        </div>

                      

                     

                        

                        <div class="form-group col-xs-12">
                            <div class="pull-right text-right">
                                <asp:Button ID="btnSearchTeam" runat="server" OnClick="btnSearchTeam_Click" Text="Search" class="btn btn-sm btn-success" />

                             
                                <asp:Button ID="btnClearForm" runat="server" Text="Clear" OnClick="btnClearForm_Click" class="btn btn-sm btn-primary" />
                                <asp:Button ID="btnAddNew" runat="server" Text="Add.New" OnClick="btnAddNew_Click" class="btn btn-sm btn-info" />
                            </div>
                        </div>
                    </div>

                </div>

                <div class="row">
                    <div class="col-xs-12">
                        <div class="clearfix">
                            <div class="pull-right tableTools-container"></div>
                        </div>
                        <div class="table-header">
                            <% Response.Write(trasnlation("Results.for.Team.Search")); %>
                        </div>

                        <!-- div.table-responsive -->

                        <!-- div.dataTables_borderWrap -->
                        <div>

                            <table class="table table-striped table-bordered table-hover dynamic-table">
                                <thead>
                                    <tr>
                                        <th><% Response.Write(trasnlation("Team.ID")); %></th>
                                       <th><% Response.Write(trasnlation("Vendor.Name")); %></th>
                                        <th><% Response.Write(trasnlation("Action")); %></th>
                                    </tr>
                                </thead>

                              <tbody runat="server" id="tblBody">
                                    <asp:Repeater ID="repeaterTeam" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="hidden-640">
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

                <!-- PAGE CONTENT ENDS -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </div>

</asp:Content>
<asp:Content ID="cntTeamSearchFooter" ContentPlaceHolderID="FormMasterFoot" runat="server">

</asp:Content>

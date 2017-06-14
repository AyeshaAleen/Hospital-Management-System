<%@ Page Title="User Search" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="UserSearch.aspx.cs" Inherits="Forms.Webroot.Users.UserSearch" %>
<asp:Content ID="cntUserSearchHeader" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntUserSearchBody" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="page-content">

        <div class="page-header">
            <h1>User Search</h1>
        </div>
        <!-- /.page-header -->

        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->

                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">User Name</label>

                            <div class="col-sm-8">
                                <input type="text" id="txtUserName" runat="server" placeholder="User Name" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">User ID</label>

                            <div class="col-sm-8">
                                <input type="text" id="txtUserID" runat="server" placeholder="User ID" class="form-control" />
                            </div>
                        </div>

                        

                        <div class="form-group col-xs-12">
                            <div class="pull-right text-right">
                                <asp:Button ID="btnSearchUser" runat="server" OnClick="btnSearchUser_Click" Text="Search" class="btn btn-sm btn-success" />
                                <asp:Button ID="btnClearForm" runat="server" Text="Clear" OnClick="btnClearForm_Click" class="btn btn-sm btn-primary" />
                                <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click" class="btn btn-sm btn-info" />
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
                            Results for "User Search"
                        </div>

                        <!-- div.table-responsive -->

                        <!-- div.dataTables_borderWrap -->
                        <div>

                            <table class="table table-striped table-bordered table-hover dynamic-table">
                                <thead>
                                    <tr>
                                        <th>First Name</th>
                                        <th>Last Name</th>
                                        <th>User Name</th>
                                        <th>User Email</th>
                                        <th>User Phone</th>
                                        <th>Role</th>
                                        <th>Language</th>
                                        <th> Edit </th>
                                        <th> Permission </th>
                                        <th> Team </th>
                                      </tr>
                                </thead>

                              <tbody runat="server" id="tblBody">
                                    <asp:Repeater ID="repeaterUsers" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="hidden-640">
                                                    <asp:Label runat="server" ID="tblFirstName" Text='<%# Eval("firstName") %>' />
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="tblLastName" Text='<%# Eval("lastName") %>' /></td>
                                                <td class="hidden-640">
                                                    <asp:Label runat="server" ID="tblUserName" Text='<%# Eval("UserName") %>' />
                                                </td>
                                                <td class="hidden-640">
                                                    <asp:Label runat="server" ID="tblEmail" Text='<%# Eval("userEmail") %>' />
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="tblContactNo" Text='<%# Eval("userPhone") %>' /></td>
                                                <td>
                                                    <asp:Label runat="server" ID="tblRole" Text='<%# Eval("role_text") %>' /></td>
                                                <td>
                                                    <asp:Label runat="server" ID="tblLanguage" Text='<%# Eval("Lang_text") %>' />
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnEditUser" runat="server" CssClass="ace-icon fa fa-edit bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "userID") ) %>'
                                                        CommandName='Edit' OnCommand="tblEditUser_RowClick" ToolTip="Edit">
                                                    </asp:LinkButton>
                                                </td>
                                                 <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnEditPermission" runat="server" CssClass="ace-icon fa fa-pencil bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "userID") ) %>'
                                                        CommandName='Edit' OnCommand="tblEditPermission_RowClick" ToolTip="Edit">
                                                    </asp:LinkButton>
                                                </td>
                                                 <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnEditTeam" runat="server" CssClass="ace-icon fa fa-pencil bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "userID") ) %>'
                                                        CommandName='Edit' OnCommand="tblEditTeam_RowClick" ToolTip="Edit">
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
<asp:Content ID="cntUserSearchFooter" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

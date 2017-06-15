<%@ Page Title="User Search" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="UserSearch.aspx.cs" Inherits="Forms.Webroot.Users.UserSearch" %>
<asp:Content ID="cntUserSearchHeader" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntUserSearchBody" ContentPlaceHolderID="FormMasterBody" runat="server">
<div class="row">
        <div class="col-sm-12">
            <div class="card-box">
            <h4 class="m-t-0 header-title"><b>User Search</b></h4>

                <div class="row">
                        <div class="form-group col-md-6 col-sm-12">
                            <label class="control-label">User Name</label>
                                <input type="text" id="txtUserName" runat="server" placeholder="User Name" class="form-control" />
                            </div>


                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="control-label">User ID</label>
                                <input type="text" id="txtUserID" runat="server" placeholder="User ID" class="form-control" />
                            </div>

                        

                        <div class="form-group col-xs-12">
                            <div class="pull-right text-right">
                                <asp:Button ID="btnSearchUser" runat="server" OnClick="btnSearchUser_Click" Text="Search" class="btn btn-info waves-effect waves-light" />
                                <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click" class="btn btn-info waves-effect waves-light" />
                            </div>
                        </div>
                    </div>

                <div class="row">
                    <div class="col-xs-12">
                      

                            <table class="table-bordered table-striped table-hover" data-toggle="table" data-search="true"
                    data-page-list="[10, 20, 50, 100]"
                    data-page-size="10" data-pagination="true">
                    <thead>
                        <tr>
                            <th data-field="name" data-sortable="true">Name</th>
                            <th data-field="username">User Name</th>
                            <th data-field="email">Email</th>
                            <th data-field="phone">Phone</th>
                            <th data-field="role" data-align="center">Role</th>
                            <th data-field="language" data-align="center">Language</th>
                            <th data-field="edit" data-align="center">Edit</th>
                            <th data-field="permission" data-align="center">Permission</th>
                            <th data-field="team" data-align="center">Team</th>

                                      </tr>
                                </thead>

                              <tbody>
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
                                                    <asp:LinkButton ID="btnEditUser" runat="server" CssClass="fa fa-edit"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "userID") ) %>'
                                                        CommandName='Edit' OnCommand="tblEditUser_RowClick" ToolTip="Edit">
                                                    </asp:LinkButton>
                                                </td>
                                                 <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnEditPermission" runat="server" CssClass="fa fa-pencil"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "userID") ) %>'
                                                        CommandName='Edit' OnCommand="tblEditPermission_RowClick" ToolTip="Edit">
                                                    </asp:LinkButton>
                                                </td>
                                                 <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnEditTeam" runat="server" CssClass="fa fa-pencil"
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


        <!-- /.row -->
    </div>
  </div>
 </div>
</asp:Content>
<asp:Content ID="cntUserSearchFooter" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

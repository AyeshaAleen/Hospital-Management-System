<%@ Page Title="User Search" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="UserSearch.aspx.cs" Inherits="Forms.Webroot.Users.UserSearch" %>


<asp:Content ID="cntUserSearchHeader" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntUserSearchBody" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b><% Response.Write(trasnlation("User.Search")); %></b></h4>


                <div class="row">
                   
                        <div class="form-group col-md-6 col-sm-12">
                          
                                <input type="text" id="txtUserName" runat="server" placeholder="type username for search..." class="form-control" />
                    
                        </div>

                        <%-- <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("User.ID")); %></label>

                            <div class="col-sm-8">
                                <input type="text" id="txtUserID" runat="server" placeholder="User.ID" class="form-control" />
                            </div>
                        </div>--%>



                        <div class="form-group col-xs-6">
                            <div class="pull-right text-right">
                                <asp:Button ID="btnSearchUser" runat="server" OnClick="btnSearchUser_Click" Text="Search" class="btn btn-info waves-effect waves-light" />
                                <asp:Button ID="btnClearForm" runat="server" Text="Clear" OnClick="btnClearForm_Click" class="btn btn-info waves-effect waves-light" />
                                <asp:Button ID="btnAddNew" runat="server" Text="Add.New" OnClick="btnAddNew_Click" class="btn btn-info waves-effect waves-light" />
                            </div>
                        </div>

                </div>
                <div class="row">
                    <div class="col-xs-12">
                      

                            <table class="table-bordered table-striped" data-toggle="table" data-search="true" data-page-list="[10, 20, 50, 100]" data-page-size="10" data-pagination="true">
                                <thead>
                                    <tr>
                                        <th data-field="name" data-sortable="true"><% Response.Write(trasnlation("Name")); %></th>
                                        <th data-field="uname"><% Response.Write(trasnlation("Username")); %></th>
                                        <th data-field="email"><% Response.Write(trasnlation("Email")); %></th>
                                        <th data-field="number" data-align="center"><% Response.Write(trasnlation("Contact.No")); %></th>
                                        <th data-field="role"><% Response.Write(trasnlation("Role")); %></th>
                                        <th data-field="language"><% Response.Write(trasnlation("Language")); %></th>
                                        <th data-field="changepass" data-align="center"><% Response.Write(trasnlation("Change.Password")); %>  </th>
                                        <th data-field="edit" data-align="center"><% Response.Write(trasnlation("Edit")); %>  </th>
                                        <th data-field="permission" data-align="center"><% Response.Write(trasnlation("Permissions")); %>  </th>
                                        <th data-field="teams" data-align="center"><% Response.Write(trasnlation("Teams")); %>  </th>
                                        <th data-field="stores" data-align="center"><% Response.Write(trasnlation("Stores")); %>  </th>
                                    </tr>
                                </thead>

                                <tbody runat="server" id="tblBody">
                                    <asp:Repeater ID="repeaterUsers" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="tblFirstName" Text='<%# Eval("firstName") %>' /><asp:Label runat="server" ID="tblLastName" Text='<%# Eval("lastName") %>' />
                                                </td>

                                                <td>
                                                    <asp:Label runat="server" ID="tblUserName" Text='<%# Eval("UserName") %>' />
                                                </td>
                                                <td>
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
                                                    <asp:LinkButton ID="btnResetPassword" runat="server" CssClass="ace-icon fa fa-key bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "userID") ) %>'
                                                        CommandName='Reset' OnCommand="btnResetPassword_Command" ToolTip="Edit">
                                                    </asp:LinkButton>
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
                                                    <asp:LinkButton ID="btnEditTeam" runat="server" CssClass="ace-icon fa fa-users bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "userID") ) %>'
                                                        CommandName='Edit' OnCommand="tblEditTeam_RowClick" ToolTip="Edit">
                                                    </asp:LinkButton>
                                                </td>
                                           
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnEditStore" runat="server" CssClass="ace-icon fa fa-users bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "userID") ) %>'
                                                        CommandName='Edit' OnCommand="tblEditStore_RowClick" ToolTip="Edit">
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
        <!-- /.row -->
    </div>
</asp:Content>
<asp:Content ID="cntUserSearchFooter" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

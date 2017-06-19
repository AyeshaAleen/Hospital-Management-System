<%@ Page Title="" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="SearchStore.aspx.cs" Inherits="Forms.Webroot.Store.SearchStore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormMasterBody" runat="server">
     <div class="page-content">

        <div class="page-header">
            <h1><% //Response.Write(trasnlation("User Search")); %></h1>
        </div>
        <!-- /.page-header -->

        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->

                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">
                                <% //Response.Write(trasnlation("Username")); %>

                            </label>

                            <div class="col-sm-8">
                                <input type="text" id="txtStoreName" runat="server" placeholder="Store Name" class="form-control" />
                            </div>
                        </div>

                        <%-- <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("User.ID")); %></label>

                            <div class="col-sm-8">
                                <input type="text" id="txtUserID" runat="server" placeholder="User.ID" class="form-control" />
                            </div>
                        </div>--%>



                        <div class="form-group col-xs-12">
                            <div class="pull-right text-right">
                                <asp:Button ID="btnSearchStore" runat="server" OnClick="btnSearchStore_Click" Text="Search" class="btn btn-sm btn-success" />
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

                            <%--<% Response.Write(trasnlation("Results.for.User.Search")); %>--%>
                        </div>

                        <!-- div.table-responsive -->

                        <!-- div.dataTables_borderWrap -->
                        <div>

                            <table class="table table-striped table-bordered table-hover dynamic-table">
                                <thead>
                                    <tr>
                                        <th>Store Name</th>
                                        <th>Zip Code</th>
                                        <th>Website</th>
                                        <th>Store Link</th>
                                        <th>Comments</th>
                                        <th>Walmart</th>
                                         <th>Fax</th>
                                        <th>Store No</th>
                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                </thead>

                                <tbody runat="server" id="tblBody">
                                    <asp:Repeater ID="repeaterStores" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="tblName" Text='<%# Eval("name") %>' />
                                                </td>

                                                <td>
                                                    <asp:Label runat="server" ID="tblzipcode" Text='<%# Eval("zipcode") %>' />
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="tblwebsite" Text='<%# Eval("website") %>' />
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="tblstorelink" Text='<%# Eval("storelink") %>' /></td>
                                                <td>
                                                    <asp:Label runat="server" ID="tblcomments" Text='<%# Eval("comments") %>' /></td>
                                                <td>
                                                    <asp:Label runat="server" ID="tblwalmart" Text='<%# Eval("walmart") %>' />
                                                </td>
                                                     <td>
                                                    <asp:Label runat="server" ID="tblfax" Text='<%# Eval("fax") %>' />
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="tblstoreno" Text='<%# Eval("storeno") %>' />
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnEditStore" runat="server" CssClass="ace-icon fa fa-edit bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "storeid") ) %>'
                                                        CommandName='Edit' OnCommand="tblEditStore_RowClick" ToolTip="Edit">
                                                    </asp:LinkButton>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnDeleteStore" runat="server" CssClass="ace-icon fa fa-remove bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "storeid") ) %>'
                                                        CommandName='Edit' OnCommand="tblDeleteStore_RowClick" ToolTip="Delete">
                                                    </asp:LinkButton>
                                                </td>
                                               <%-- <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnEditTeam" runat="server" CssClass="ace-icon fa fa-users bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "userID") ) %>'
                                                        CommandName='Edit' OnCommand="tblEditTeam_RowClick" ToolTip="Edit">
                                                    </asp:LinkButton>
                                                </td>--%>
                                           
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
<asp:Content ID="Content3" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

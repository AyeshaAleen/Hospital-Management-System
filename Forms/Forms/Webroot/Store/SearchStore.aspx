<%@ Page Title="Store Search" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="SearchStore.aspx.cs" Inherits="Forms.Webroot.Store.SearchStore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b><% Response.Write(trasnlation("Store.Search")); %></b></h4>

            
                        <div class="form-group col-md-6 col-sm-12">
                                <input type="text" id="txtStoreName" runat="server" placeholder="type store name for search..." class="form-control" />
                            </div>
                  

                        <div class="form-group col-xs-6">
                            <div class="pull-right text-right">
                                <asp:Button ID="btnSearchStore" runat="server" OnClick="btnSearchStore_Click" Text="Search" class="btn btn-success waves-effect waves-light" />
                                <asp:Button ID="btnClearForm" runat="server" Text="Clear" OnClick="btnClearForm_Click" class="btn btn-success waves-effect waves-light" />
                                <asp:Button ID="btnAddNew" runat="server" Text="Add.New" OnClick="btnAddNew_Click" class="btn btn-success waves-effect waves-light" />
                            </div>
                        </div>
      
                <div class="row">
                    <div class="col-xs-12">

                            <table class="table-bordered table-striped" data-toggle="table" data-search="true" data-page-list="[10, 20, 50, 100]" data-page-size="10" data-pagination="true">
                                <thead>
                                    <tr>
                                        <th data-field="name" data-sortable="true">Store Name</th>
                                        <th data-field="code" data-align="center">Zip Code</th>
                                        <th data-field="web" data-align="center">Website</th>
                                        <th data-field="link">Store Link</th>
                                        <th data-field="comment">Comments</th>
                                        <th data-field="mart" data-align="center">Walmart</th>
                                        <th data-field="fax" data-align="center">Fax</th>
                                        <th data-field="no" data-align="center">Store No</th>
                                        <th data-field="edit" data-align="center">Edit</th>
                                        <th data-field="delete" data-align="center">Delete</th>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

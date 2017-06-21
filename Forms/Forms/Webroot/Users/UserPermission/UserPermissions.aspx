<%@ Page Title="User Permission" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="UserPermissions.aspx.cs" Inherits="Forms.Webroot.Users.UserPermission.UserPermissions" %>


<asp:Content ID="Content1" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormMasterBody" runat="server">
     <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b><label class="label label-info text-uppercase" runat="server" id="lblname"></label></b></h4>

                <div class="row">
                    
                    <div class="col-xs-12">
                      
                            <table class="table-bordered table-striped" data-toggle="table" data-search="true" data-page-list="[10, 20, 50, 100]" data-page-size="10" data-pagination="true">
                                <thead>
                                    <tr>
                                        <th data-field="permission"><% Response.Write(trasnlation("Permissions")); %></th>
                                        <th data-field="delete" data-align="center"><% Response.Write(trasnlation("Delete")); %></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="tblUserPermissions" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="tbllText" Text='<%# Eval("text") %>' /></td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnEdit" runat="server" CssClass="ace-icon fa fa-close bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "userPermissionID") ) %>'
                                                        CommandName='edit' OnCommand="tbl_Delete_Click" ToolTip="Delete">
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                 

                    <div class="col-xs-12">
                        <h1>Add New Permission</h1>
                         <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("Pages")); %></label>

                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlPermission" DataValueField="code" DataTextField="text"  runat="server" CssClass="chosen-select form-control">
                                    
                                </asp:DropDownList>
                               
                            </div>
                        </div>
                    </div>

                    <div class="form-group col-xs-12">
                            <div class="pull-right text-right">
                                <asp:Button ID="btnAddPermission" runat="server" OnClick="btnAddPermission_Click" Text="Add.Permission" class="btn btn-info waves-effect waves-light" />
                            </div>
                        </div>


                </div>
            </div>
        </div>
    </div>
         </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>


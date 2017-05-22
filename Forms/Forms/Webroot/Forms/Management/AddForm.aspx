<%@ Page Title="Add New Form" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="AddForm.aspx.cs" Inherits="Forms.Webroot.Forms.Management.AddForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormMasterBody" runat="server">

    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Forms</b></h4>


                <table class="table-bordered table-striped table-hover" data-toggle="table" data-search="true"
                    data-page-list="[10, 20, 50, 100]"
                    data-page-size="10" data-pagination="true">
                    <thead>
                        <tr>
                            <th data-field="name" data-sortable="true">Form Name</th>
                            <th data-field="action" data-align="center">Action</th>
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="tblDocument" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="tblDocName" Text='<%# Eval("name") %>' />
                                    </td>

                                    <td style="text-align: center;">
                                        <asp:LinkButton ID="btnViewDocument" runat="server" CssClass="ace-icon fa fa-eye bigger-120"
                                            CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "xDocumentDefinationID") ) %>'
                                            CommandName='Reset' OnCommand="btnViewDocument_Command" ToolTip="View">
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


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

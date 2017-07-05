﻿<%@ Page Title="Form Management" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="AddForms.aspx.cs" Inherits="Forms.Webroot.Forms.Management.AddForms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormMasterBody" runat="server">

    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                                    
                <h4 class="m-t-0 header-title"><b>Forms</b></h4>
                <%--<a class="btn btn-success waves-effect waves-light pull-right" data-toggle="modal" data-target="#con-close-modal">Add New Forms</a>--%>
                <asp:Button runat="server" ID="btnAdd"  Text="Add New Forms" data-toggle="modal" data-target="#con-close-modal" OnClientClick="Clicked(this);"
                    CssClass="btn btn-success waves-effect waves-light pull-right"
                     />

                
                <div class="clearfix"></div>
                <table class="table-bordered table-striped table-hover" data-toggle="table" data-search="true"
                    data-page-list="[10, 20, 50, 100]"
                    data-page-size="10" data-pagination="true">
                    <thead>
                        <tr>
                            <th data-field="name" data-sortable="true">Form Name</th>
                            <th data-field="view" data-align="center">View</th>
                            <th data-field="edit" data-align="center">Edit</th>
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="tblDocument" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="tblDocName" Text='<%# Eval("name") %>' />

                                      <asp:HiddenField runat="server"  ID="tblDocID" Value='<%# Eval("xDocumentDefinationID") %>' />
                                       
                                    </td>

                                    <td style="text-align: center;">
                                        <asp:LinkButton ID="btnViewDocument" runat="server" CssClass="ace-icon fa fa-eye bigger-120"
                                            CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "xDocumentDefinationID") ) %>'
                                            CommandName='Reset' OnCommand="tbl_sectionDetails" ToolTip="View" >
                                        </asp:LinkButton>
                                        </td>
                                    <td style="text-align: center;">
                                        <asp:LinkButton ID="btnEditDocument" runat="server" CssClass="ace-icon fa fa-edit bigger-120"
                                            CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "xDocumentDefinationID") ) %>'
                                            CommandName='Reset'  ToolTip="Edit"
                                            data-toggle="modal" data-target="#con-close-modal" OnClientClick="Clicked(this)">
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>


                    </tbody>
                </table>
            </div>
        </div>
        <div id="con-close-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">Add new Document</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="field-1" class="control-label">Form Name</label>
                                    <input type="text" class="form-control" required id="TxtDocumentName" runat="server" placeholder="Form Name">

                                   
                                    <input type="hidden" class="form-control" id="TxtEditDocumentId" runat="server">
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default waves-effect" data-dismiss="modal">Close</button>
                        <asp:Button Text="Save" runat="server" ID="btnSaveDocument" OnClick="btnSaveDocument_Click" class="btn btn-success waves-effect waves-light"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.modal -->
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FormMasterFoot" runat="server">
    <script>
        function Clicked(btn) {
            
            document.getElementById('<%=TxtDocumentName.ClientID%>').value = "";
            document.getElementById('<%=TxtEditDocumentId.ClientID%>').value = "";

            if (btn.id.includes("btnEditDocument")) {
                document.getElementById('<%=TxtDocumentName.ClientID%>').value = document.getElementById(btn.id.replace("btnEditDocument", "tblDocName")).innerHTML;
                document.getElementById('<%=TxtEditDocumentId.ClientID%>').value = document.getElementById(btn.id.replace("btnEditDocument", "tblDocID")).value;
            }
        }
    </script>
</asp:Content>

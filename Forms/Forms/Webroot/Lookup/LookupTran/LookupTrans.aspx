<%@ Page Title="Add Lookup" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="LookupTrans.aspx.cs" Inherits="Forms.Webroot.Lookup.LookupTran.LookupTrans" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormMasterBody" runat="server">

    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Add Lookup</b></h4>

           
                        <div class="form-group col-md-6 col-sm-12">
                            
                                <input type="hidden" class="form-control" id="txtLookupID" value="0" runat="server">
                                <input type="text" id="txtLookupName" runat="server" placeholder="LookupTrans Name" class="form-control" />
                                <input type="text" id="txtLookupCode" runat="server" placeholder="LookupTrans Code" class="form-control" />

                        </div>


                        <div class="form-group col-md-6 col-sm-12">
                            <div class="text-right">
                                <asp:Button ID="btnAddLookup" runat="server" OnClick="btnAddLookup_Click" Text="Add New Lookup" class="btn btn-success waves-effect waves-light" />
                            </div>
                        </div>

                 
                <div class="row">
                    <div class="col-xs-12">
                            <table class="table-bordered table-striped" data-toggle="table" data-search="true" data-page-list="[10, 20, 50, 100]" data-page-size="10" data-pagination="true">
                            
                                <thead>
                                    <tr>
                                       
                                        <th data-field="name" data-sortable="true">Lookup Trans Name </th>
                                        <th data-field="name" data-sortable="true">Lookup Trans Code </th>
                                        <th data-field="action" data-align="center">Action</th>
                                    </tr>
                                </thead>

                              <tbody>
                                    <asp:Repeater ID="repeaterLookupTrans" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                
                                                <td>
                                                    <asp:HiddenField runat="server"  ID="tblTransID" Value='<%# Eval("lookupTransID") %>' />
                                                    <asp:Label runat="server" ID="tblTransName" Text='<%# Eval("value") %>' /></td>
                                                <td>
                                                    <asp:Label runat="server" ID="tblTransCode" Text='<%# Eval("code") %>' />

                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnEdit" runat="server" CssClass="ace-icon fa fa-edit bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "lookupTransID") ) %>'
                                                        CommandName='Edit' OnClientClick="Clicked(this)" ToolTip="Edit">
                                                    </asp:LinkButton>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="ace-icon fa fa-remove bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "lookupTransID") ) %>'
                                                        CommandName='Edit' OnCommand="tblLookupDelete_RowClick" ToolTip="Delete">
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
<asp:Content ID="Content3" ContentPlaceHolderID="FormMasterFoot" runat="server">
     <script>
        function Clicked(btn) {
            document.getElementById('<%=txtLookupName.ClientID%>').value = 0;
            document.getElementById('<%=txtLookupName.ClientID%>').value = "";
            document.getElementById('<%=txtLookupCode.ClientID%>').value = "";

            if (btn.id.includes("btnEdit")) {
                document.getElementById('<%=txtLookupID.ClientID%>').value = document.getElementById(btn.id.replace("btnEdit", "tblTransID")).value;
                document.getElementById('<%=txtLookupName.ClientID%>').value = document.getElementById(btn.id.replace("btnEdit", "tblTransName")).innerHTML;
                document.getElementById('<%=txtLookupCode.ClientID%>').value = document.getElementById(btn.id.replace("btnEdit", "tblTransCode")).innerHTML;
            }
        }
    </script>
</asp:Content>

<%@ Page Title="Add Lookup" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="Lookup.aspx.cs" Inherits="Forms.Webroot.Lookup.Lookup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Add Lookup</b></h4>

                       
                        <div class="form-group col-md-6 col-sm-12">
                    <label class="col-sm-4 control-label">Lookup Name *</label>

                    <div class="col-sm-8">
                        <input type="text" id="txtLookupName" runat="server" required placeholder="Lookup Name" class="form-control" />
                    </div>
                </div>

                  <div class="form-group col-md-6 col-sm-12">
                    <label class="col-sm-4 control-label">Lookup Code *</label>

                    <div class="col-sm-8">
                        <input type="text" id="txtLookupCode" runat="server" required placeholder="Lookup Code" class="form-control" />
                    </div>
                </div>

                  <div class="form-group col-md-6 col-sm-12">
                    <label class="col-sm-4 control-label">Lookup Text *</label>

                    <div class="col-sm-8">
                        <input type="text" id="txtLookupText" runat="server" required placeholder="Lookup Text" class="form-control" />
                    </div>
                </div>

                  <div class="form-group col-md-6 col-sm-12">
                    <label class="col-sm-4 control-label">French *</label>

                    <div class="col-sm-8">
                        <input type="text" id="txtFrench" runat="server" required placeholder="French" class="form-control" />
                    </div>
                </div>

                  <div class="form-group col-md-6 col-sm-12">
                    <label class="col-sm-4 control-label">Spanish *</label>

                    <div class="col-sm-8">
                        <input type="text" id="txtSpanish" runat="server" required placeholder="Spanish" class="form-control" />
                    </div>
                </div>

                  <div class="form-group col-md-6 col-sm-12">
                    <label class="col-sm-4 control-label">Urdu *</label>

                    <div class="col-sm-8">
                        <input type="text" id="txtUrdu" runat="server" required placeholder="Urdu" class="form-control" />
                         <input type="hidden" class="form-control" id="txtLookupsID" value="0" runat="server">
                    </div>
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
                                       
                                        <th data-field="name" data-sortable="true">Lookup Name </th>
                                        <th data-field="code" data-sortable="true">Lookup Code </th>
                                        <th data-field="text" data-sortable="true">Lookup Text </th>
                                        <th data-field="french" data-sortable="true">French </th>
                                        <th data-field="spanish" data-sortable="true">Spanish </th>
                                        <th data-field="urdu" data-sortable="true">Urdu </th>
                                        <th data-field="edit" data-align="center">Edit</th>
                                        <th data-field="delete" data-align="center">Delete</th>
                                    </tr>
                                </thead>

                              <tbody>
                                    <asp:Repeater ID="repeaterLookup" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                
                                                <td>
                                                    <asp:HiddenField runat="server"  ID="tbllookupID" Value='<%# Eval("lookUpID") %>' />
                                                    <asp:Label runat="server" ID="tbllookupName" Text='<%# Eval("name") %>' /></td>
                                                <td>
                                                    <asp:Label runat="server" ID="tbllookupCode" Text='<%# Eval("code") %>' /></td>
                                                <td>
                                                    <asp:Label runat="server" ID="tbllookupText" Text='<%# Eval("text") %>' /></td>
                                                <td>
                                                    <asp:Label runat="server" ID="tblfrench" Text='<%# Eval("fr") %>' /></td>
                                                <td>
                                                    <asp:Label runat="server" ID="tblspanish" Text='<%# Eval("sp") %>' /></td>
                                                <td>
                                                    <asp:Label runat="server" ID="tblurdu" Text='<%# Eval("ud") %>' /></td>

                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnEdit" runat="server" CssClass="ace-icon fa fa-edit bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "lookUpID") ) %>'
                                                        CommandName='Edit' OnClientClick="Clicked(this);" ToolTip="Edit">
                                                    </asp:LinkButton>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="ace-icon fa fa-remove bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "lookUpID") ) %>'
                                                        CommandName='Delete' OnCommand="tblLookupDelete_RowClick" ToolTip="Delete">
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
          
            debugger;
            document.getElementById('<%=txtLookupName.ClientID%>').value = "";
            document.getElementById('<%=txtLookupCode.ClientID%>').value = "";
            document.getElementById('<%=txtLookupText.ClientID%>').value = "";
            document.getElementById('<%=txtFrench.ClientID%>').value = "";
            document.getElementById('<%=txtSpanish.ClientID%>').value = "";
            document.getElementById('<%=txtUrdu.ClientID%>').value = "";

            if (btn.id.includes("btnEdit")) {
                document.getElementById('<%=txtLookupsID.ClientID%>').value = document.getElementById(btn.id.replace("btnEdit", "lookUpID")).value;

                document.getElementById('<%=txtLookupName.ClientID%>').value = document.getElementById(btn.id.replace("btnEdit", "tbllookupName")).innerHTML;
                document.getElementById('<%=txtLookupCode.ClientID%>').value = document.getElementById(btn.id.replace("btnEdit", "tbllookupCode")).innerHTML;
                document.getElementById('<%=txtLookupText.ClientID%>').value = document.getElementById(btn.id.replace("btnEdit", "tbllookupText")).innerHTML;
                document.getElementById('<%=txtFrench.ClientID%>').value = document.getElementById(btn.id.replace("btnEdit", "tblfrench")).innerHTML;
                document.getElementById('<%=txtSpanish.ClientID%>').value = document.getElementById(btn.id.replace("btnEdit", "tblspanish")).innerHTML;
                document.getElementById('<%=txtUrdu.ClientID%>').value = document.getElementById(btn.id.replace("btnEdit", "tblurdu")).innerHTML;
            }
        }
    </script>
</asp:Content>

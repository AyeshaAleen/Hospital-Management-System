<%@ Page Title="Add Lookup" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="LookupTrans.aspx.cs" Inherits="Forms.Webroot.Forms.Lookup.LookupTrans" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormMasterBody" runat="server">

    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Add Lookup</b></h4>

           
                        <div class="form-group col-md-6 col-sm-12">
                            
                                <input type="text" id="txtLookupName" runat="server" placeholder="LookupTrans" class="form-control" />
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
                                        <th data-field="action" data-align="center">Action</th>
                                    </tr>
                                </thead>

                              <tbody>
                                    <asp:Repeater ID="repeaterLookupTrans" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                
                                                <td>
                                                    <asp:Label runat="server" ID="tlblName" Text='<%# Eval("value") %>' /></td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnEdit" runat="server" CssClass="ace-icon fa fa-remove bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "lookupTransID") ) %>'
                                                        CommandName='Edit' OnCommand="tblLookup_RowClick" ToolTip="Delete">
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
</asp:Content>

<%@ Page Title="Forms Sections Management" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="ViewDocumentSection.aspx.cs" Inherits="Forms.Webroot.Forms.Management.ViewDocumentSection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormMasterBody" runat="server">

    <div class="row">

        <div class="col-lg-12">
            <div class="portlet">
                <div class="portlet-heading portlet-default">
                    <h3 class="portlet-title">
                        <b><%getParentRef();%></b> <i class="glyphicon glyphicon-arrow-right"></i>Form Sections
                    </h3>
                    <div class="portlet-widgets">
                        <a href="javascript:;" data-toggle="reload"><i class="ion-refresh"></i></a>
                        <span class="divider"></span>
                        <a data-toggle="collapse" data-parent="#accordion1" href="#bg-inverse"><i class="ion-minus-round"></i></a>
                        <span class="divider"></span>
                        <a href="#" data-toggle="remove"><i class="ion-close-round"></i></a>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div id="bg-inverse" class="panel-collapse collapse in">
                    <div class="portlet-body">

                        <div class="card-box">
                            <h4 class="m-t-0 header-title"></h4>




                            <div class="row">
                              
                                    
                                         
                                <div class="form-group col-md-5">
                                    <label for="field-1" class="control-label">Form Name</label>
                                    <input type="text" class="form-control" id="field" runat="server" placeholder="Form Name">
                                </div>
                                <div class="form-group col-md-5">
                                    <label for="field-1" class="control-label">Pages</label>
                                    <asp:DropDownList ID="ddlsectionPagesName" runat="server" CssClass="form-control" DataTextField="pageName" DataValueField="pageID"></asp:DropDownList>
                                </div>
                                <div class="form-group col-md-2">
                                    <asp:Button Text="Save" runat="server" ID="btnSaveSection" OnClick="btnSaveSection_Click" class="btn btn-info waves-effect waves-light btn-sp"></asp:Button>
                                </div>
                            </div>
                                     

                            <div class="clearfix"></div>
                            <table class="table-bordered table-striped table-hover" data-toggle="table" data-search="true"
                                data-page-list="[10, 20, 50, 100]"
                                data-page-size="10" data-pagination="true">
                                <thead>
                                    <tr>
                                        <th data-field="name" data-sortable="true">Section Name</th>
                                        <th data-field="View" data-align="center">View</th>
                                        <th data-field="Edit" data-align="center">Edit</th>
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
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "documentsectionid") ) %>'
                                                        CommandName='Reset' OnCommand="btnViewDocument_Command" ToolTip="View">
                                                    </asp:LinkButton>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnEditDocument" runat="server" CssClass="ace-icon fa fa-edit bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "documentsectionid") ) %>'
                                                        CommandName='Reset' ToolTip="Edit"
                                                        data-toggle="modal" data-target="#con-close-modal" OnClientClick="Clicked(this)">
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>


                                </tbody>
                            </table>
                        </div>



                        <!-- /.modal -->

                    </div>
                </div>
            </div>
        </div>

    </div>


    <div class="row">

        <div class="col-lg-12">
            <div class="portlet">
                <div class="portlet-heading portlet-default">
                    <h3 class="portlet-title">Form Association
                    </h3>
                    <div class="portlet-widgets">
                        <a href="javascript:;" data-toggle="reload"><i class="ion-refresh"></i></a>
                        <span class="divider"></span>
                        <a data-toggle="collapse" data-parent="#accordion1" href="#bg-inverse1"><i class="ion-minus-round"></i></a>
                        <span class="divider"></span>
                        <a href="#" data-toggle="remove"><i class="ion-close-round"></i></a>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div id="bg-inverse1" class="panel-collapse collapse in">
                    <div class="portlet-body">

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">User Role</label>
                                <asp:DropDownList ID="ddlUserRole" runat="server" CssClass="form-control" DataValueField="Code" DataTextField="Text">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <asp:Button ID="btnAddUserRole" Text="Add" OnClick="btnAddUserRole_Click" runat="server" CssClass="btn btn-info waves-effect btn-sp" />
                        </div>

                        <div class="clearfix"></div>
                        <table class="table-bordered table-striped table-hover" data-toggle="table" data-search="true"
                            data-page-list="[10, 20, 50, 100]"
                            data-page-size="10" data-pagination="true">
                            <thead>
                                <tr>
                                    <th data-field="name" data-sortable="true">User Role</th>
                                    <%--<th data-field="Edit" data-align="center">Edit</th>--%>
                                    <th data-field="action" data-align="center">Delete</th>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater ID="tblUserRole" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="tblUserRoleName" Text='<%# Eval("role_Text") %>' />
                                            </td>

                                           <%-- <td style="text-align: center;">
                                                 <asp:LinkButton ID="btnEditUserRole" runat="server" CssClass="ace-icon fa fa-edit bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "xdocumentroleid") ) %>'
                                                        CommandName='Rese' ToolTip="Edit" OnCommand="btnEditUserRole_Command" >
                                                    </asp:LinkButton>
                                            </td>--%>
                                            <td style="text-align: center;">
                                                 <asp:LinkButton ID="btnDeleteUserRole" runat="server" CssClass="ace-icon fa fa-remove bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "xdocumentroleid") ) %>'
                                                        CommandName='Reset' ToolTip="Delete" OnCommand="btnDeleteUserRole_Command"
                                                        >
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


    <div class="row">

        <div class="col-lg-12">
            <div class="portlet">
                <div class="portlet-heading portlet-default">
                    <h3 class="portlet-title">Email Routing
                    </h3>
                    <div class="portlet-widgets">
                        <a href="javascript:;" data-toggle="reload"><i class="ion-refresh"></i></a>
                        <span class="divider"></span>
                        <a data-toggle="collapse" data-parent="#accordion1" href="#bg-inverse2"><i class="ion-minus-round"></i></a>
                        <span class="divider"></span>
                        <a href="#" data-toggle="remove"><i class="ion-close-round"></i></a>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div id="bg-inverse2" class="panel-collapse collapse in">
                    <div class="portlet-body">

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">Route</label>
                                <asp:DropDownList ID="ddlEmailRouting" runat="server" CssClass="form-control" DataValueField="Code" DataTextField="Text">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-control" DataValueField="userID" DataTextField="userName">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <asp:Button ID="btnAddEmailRouting" Text="Add" OnClick="btnAddEmailRouting_Click" runat="server" CssClass="btn btn-info waves-effect btn-sp" />
                        </div>
                        <div class="clearfix"></div>
                        <table class="table-bordered table-striped table-hover" data-toggle="table" data-search="true"
                            data-page-list="[10, 20, 50, 100]"
                            data-page-size="10" data-pagination="true">
                            <thead>
                                <tr>
                                    <th data-field="name" data-sortable="true">Route</th>
                                    <th data-field="edit" data-align="center">Edit</th>
                                    <th data-field="action" data-align="center">Delete</th>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater ID="tblEmailRouting" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="lblEmailRouting" Text='<%# Eval("route_Text") %>' />
                                            </td>
                                            <td style="text-align: center;">
                                                 <asp:LinkButton ID="btnDeleteEmailRouting" runat="server" CssClass="ace-icon fa fa-remove bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "id") ) %>'
                                                        CommandName='Reset' ToolTip="Delete" OnCommand="btnDeleteEmailRouting_Command"
                                                        >
                                                    </asp:LinkButton>
                                            </td>
                                            <td style="text-align: center;"></td>
                                            <td style="text-align: center;"></td>
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
       <%-- function Clicked(btn) {
            document.getElementById('<%=field.ClientID%>').value = "";
            document.getElementById('<%=ClickedId.ClientID%>').value = "";
            document.getElementById('<%=ddlsectionPagesName.ClientID%>').style.display = 'inherit';

            if (btn.id.includes("btnEditDocument")) {
                document.getElementById('<%=field.ClientID%>').value = document.getElementById(btn.id.replace("btnEditDocument", "tblDocName")).innerHTML;
                document.getElementById('<%=ClickedId.ClientID%>').value = btn.id;
                document.getElementById('<%=ddlsectionPagesName.ClientID%>').style.display = 'none';
            }
        }=--%>
</script>
</asp:Content>

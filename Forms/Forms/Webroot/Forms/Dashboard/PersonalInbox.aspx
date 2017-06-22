<%@ Page Title="Personal Inbox" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="PersonalInbox.aspx.cs" Inherits="Forms.Webroot.Forms.Dashboard.PersonalInbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormMasterBody" runat="server">

            <div class="row">

                <div class="col-lg-12">

                    <div class="portlet">
                        <!-- /primary heading -->
                        <div class="portlet-heading">
                            <h3 class="portlet-title text-dark text-uppercase">Activity
                            </h3>
                            <div class="portlet-widgets">
                                <a href="javascript:;" data-toggle="reload"><i class="ion-refresh"></i></a>
                                <span class="divider"></span>
                                <a data-toggle="collapse" data-parent="#accordion1" href="#portlet2"><i class="ion-minus-round"></i></a>
                                <span class="divider"></span>
                                <a href="#" data-toggle="remove"><i class="ion-close-round"></i></a>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div id="portlet2" class="panel-collapse collapse in">
                            <div class="portlet-body">
                                <div class="table-responsive">
                                    <table class="table-bordered table-striped" data-toggle="table" data-search="true" data-page-list="[10, 20, 50, 100]" data-page-size="10" data-pagination="true">
                                        <thead>
                                            <tr>
                                                <th data-field="formname" data-sortable="true">Form Name</th>
                                                <th data-field="submitter" data-sortable="true">Submitter Name</th>
                                                <th data-field="startdate" data-sortable="true">Start Date</th>
                                                <th data-field="status" data-align="center">Status</th>
                                                <th data-field="actions" data-align="center">Action</th>
                                            </tr>
                                        </thead>

                                        <tbody>
                                            <asp:Repeater ID="tblDocument" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="tblFormName" Text='<%# Eval("documentName") %>' />
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="tblUserNama" Text='<%# Eval("users") %>' />
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="tblStartDate" Text='<%# Eval("transDate") %>' />
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="tblStatus" Text='<%# Eval("status") %>' />
                                                </td>

                                                <td style="text-align: center;">
                                                    <asp:LinkButton ID="btnViewDocument" runat="server" CssClass="ace-icon fa fa-eye bigger-120"
                                                        CommandArgument='<%# ( DataBinder.Eval(Container.DataItem, "documentid") ) %>'
                                                        CommandName='Reset' OnCommand="btnViewDocument_Command" ToolTip="View">
                                                    </asp:LinkButton>
                                                </td>
                                                
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                           <%-- <tr>
                                                <td>Sio
                                                </td>

                                                <td>Tomaslau
                                                </td>
                                                <td>01/11/2003
                                                </td>
                                                <td>
                                                    <span class="label label-info">Pending</span>
                                                </td>

                                                <td>
                                                    <a href="#" class="table-action-btn"><i class="md md-replay"></i></a>
                                                    <a href="#" class="table-action-btn"><i class="md md-close"></i></a>
                                                </td>
                                            </tr>--%>

                                        </tbody>
                                    </table>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>


                <!-- end col -->
               
            </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FormMasterFoot" runat="server">

</asp:Content>

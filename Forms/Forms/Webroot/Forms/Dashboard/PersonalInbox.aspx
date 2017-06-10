<%@ Page Title="Personal Inbox" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="PersonalInbox.aspx.cs" Inherits="Forms.Webroot.Forms.Dashboard.PersonalInbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormMasterBody" runat="server">

    <div class="row" id="validate" runat="server">

        <div class="col-sm-12">
            <div class="row">

               


                <div class="col-md-6 col-lg-3">
                    <a href="">
                        <div class="widget-bg-color-icon card-box fadeInDown animated">
                            <div class="bg-icon bg-icon-info pull-left">
                                <i class="md md-home text-info"></i>
                            </div>
                            <div class="text-right">
                                <h3 class="text-dark"><b class="counter">Desktop</b></h3>
                                <%--<p class="text-muted">Total Revenue</p>--%>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </a>
                </div>

                <div class="col-md-6 col-lg-3">
                    <a href="">
                        <div class="widget-bg-color-icon card-box">
                            <div class="bg-icon bg-icon-pink pull-left">
                                <i class="md md-search text-pink"></i>
                            </div>
                            <div class="text-right">
                                <h3 class="text-dark"><b class="counter">Search</b></h3>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </a>
                </div>


                <div class="col-lg-6">

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
                                    <table class="table table-hover mails m-0 table table-actions-bar">
                                        <thead>
                                            <tr>
                                                <th>Form Name</th>
                                                <th>Submitter Name</th>
                                                <th>Start Date</th>
                                                <th>Status</th>
                                                <th style="min-width: 90px;">Action</th>
                                            </tr>
                                        </thead>

                                        <tbody>
                                            <tr>
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
                                            </tr>

                                            <tr>
                                                <td>CEV
                                                </td>

                                                <td>John Doe
                                                </td>
                                                <td>05/11/2015
                                                </td>
                                                <td>
                                                    <span class="label label-primary">Pending</span>

                                                </td>

                                                <td>
                                                    <a href="#" class="table-action-btn"><i class="md md-replay"></i></a>
                                                    <a href="#" class="table-action-btn"><i class="md md-close"></i></a>
                                                </td>
                                            </tr>


                                        </tbody>
                                    </table>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>


                <!-- end col -->
               
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FormMasterFoot" runat="server">

</asp:Content>

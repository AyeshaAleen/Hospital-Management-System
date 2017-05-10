<%@ Page Title="Forms Manager" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="FormsManager.aspx.cs" Inherits="Forms.Webroot.Forms.Management.FormsManager.FormsManager" %>

<asp:Content ID="cntFormsManagerHead" ContentPlaceHolderID="FormMasterHead" runat="server">
    <link href="../../../../itinsync/resources/plugins/dragdrop/style.css" rel="stylesheet" />
    <script src="../../../../itinsync/resources/plugins/dragdrop/redips-drag-min.js"></script>
    <script src="../../../../itinsync/resources/plugins/dragdrop/script.js"></script>
</asp:Content>
<asp:Content ID="cntFormsManagerBody" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="row" id="validate" runat="server">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Forms Manager</b></h4>


                <div class="row">

                    <div id="redips-drag">
                        <!-- left container -->
                        <div class="col-md-4">
                            <h3 class="text-center">Select Controls</h3>
                            <table id="table1" class="table table-bordered">
                                <tr>
                                    <td class="redips-single">
                                        <h5>Label Control</h5>
                                        <div id="a" class="redips-drag redips-clone orange">
                                            <label class="control-label">Label</label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="redips-single">
                                        <h5>Text Box</h5>
                                        <div id="b" class="redips-drag redips-clone orange">
                                            <input type="text" class="form-control">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="redips-single">
                                        <h5>Select Box</h5>
                                        <div id="c" class="redips-drag redips-clone orange">
                                            <select class="form-control select2"></select>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="redips-single">
                                        <h5>Radio Botton</h5>
                                        <div id="d" class="redips-drag redips-clone orange">
                                            <input type="radio" class="radio" value="RadioButton">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="redips-single">
                                        <h5>CheckBox</h5>
                                        <div id="e" class="redips-drag redips-clone orange">
                                            <input type="checkbox" class="checkbox" value="CheckBox">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="redips-single">
                                        <h5>File Upload</h5>
                                        <div id="f" class="redips-drag redips-clone orange">
                                            <input type="file">
                                        </div>
                                    </td>
                                </tr>
                                <!-- <tr>
                                    <td class="redips-trash">Trash</td>
                                </tr>-->
                            </table>
                        </div>

                        <!-- right container -->
                        <div class="col-md-8">
                            <h3 class="text-center">Drop Zone</h3>
                            <table id="table2" class="table table-responsive">
                            </table>

                            <table>
                                <tr>
                                    <td colspan="2">
                                        <button onclick="myFunction()">Try it</button>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div class="col-lg-6">
                                            <h5>No. of Rows</h5>

                                            <input id="tblrows" type="text" class="form-control">
                                        </div>
                                        <div class="col-lg-6">
                                            <h5>No. of Columns</h5>

                                            <input id="tblcolumn" type="text" class="form-control">
                                        </div>
                                        <div class="col-lg-6">
                                            <button onclick="createTable();">Create Table</button>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clearfix"></div>
                        <!-- display block content -->

                        <div class="clearfix"></div>
                    </div>
                    <div class="clearfix"></div>
                </div>


                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Document</label>
                        <select class="form-control select2"></select>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Content</label>
                        <select class="form-control select2"></select>
                    </div>
                </div>
                <div class="clearfix"></div>


                <!-- /.modal -->
                <div class="col-md-12 form-group">
                    <table data-toggle="table">
                        <thead>
                            <tr>
                                <th data-align="center">Table Header</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <h6>Table Content</h6>
                                </td>
                            </tr>
                        </tbody>
                    </table>

                </div>

                <div class="clearfix"></div>
                <div class="col-md-12 form-group">
                    <a class="btn btn-inverse waves-effect waves-light pull-right" data-toggle="modal" data-target="#con-close-modal">Add Row</a>
                </div>
                <div class="clearfix"></div>

                <div id="con-close-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h4 class="modal-title">Add New Row</h4>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">Label</label>
                                            <select class="form-control"></select>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">Label</label>
                                            <select class="form-control"></select>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">Label</label>
                                            <select class="form-control"></select>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">Label</label>
                                            <select class="form-control"></select>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">Label</label>
                                            <select class="form-control"></select>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">Label</label>
                                            <select class="form-control"></select>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default waves-effect" data-dismiss="modal">Close</button>
                                <button type="button" class="btn btn-info waves-effect waves-light">Save</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cntFormsManagerFoot" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

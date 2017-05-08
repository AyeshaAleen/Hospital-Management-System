<%@ Page Title="Forms Manager" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="FormsManager.aspx.cs" Inherits="Forms.Webroot.Forms.Management.FormsManager.FormsManager" %>

<asp:Content ID="cntFormsManagerHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntFormsManagerBody" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="row" id="validate" runat="server">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Forms Manager</b></h4>

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

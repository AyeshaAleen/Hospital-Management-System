<%@ Page Title="Basic Info" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="BasicInfo.aspx.cs" Inherits="Forms.Webroot.Forms.SIO.BasicInfo" %>

<asp:Content ID="cntBasicInfoHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntBasicInfoBody" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="row" id="validate">
        <div class="col-sm-12">
            <div class="card-box">
                <h2 class="text-center m-t-0">Shift Performance Verification Tool</h2>
                <h4 class="m-t-0 header-title text-center">Used for Verification of SIO Principles. Passing Score is 80% in all areas</h4>


                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Restaurant Name</label>
                        <input type="text" id="txtStore" runat="server" class="form-control" irequired="1" imask="" imessage="Reason.This.Field.is.Required" />
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Date</label>
                        <div class="input-group">
                            <input type="text" class="form-control datepicker-autoclose" placeholder="mm/dd/yyyy">
                            <span class="input-group-addon"><i class="icon-calender"></i></span>
                        </div>
                    </div>
                </div>


                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Time</label>
                        <div class="input-group clockpicker " data-placement="top" data-align="top" data-autoclose="true">
                            <input type="text" class="form-control" value="12:00">
                            <span class="input-group-addon"><span class="icon-clock"></span></span>
                        </div>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Shift Manager Name</label>
                        <input type="text" class="form-control">
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Completed By</label>
                        <input type="text" class="form-control">
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">General SIO</label>
                        <input type="text" class="form-control">
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Quality</label>
                        <input type="text" class="form-control">
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Service</label>
                        <input type="text" class="form-control">
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Cleanliness</label>
                        <input type="text" class="form-control">
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Overall</label>
                        <div class="input-group">
                            <span class="input-group-addon half-addon">
                                <asp:Label ID="Label1" runat="server" Text="100%"></asp:Label></span>
                            <input type="text" class="form-control">
                        </div>
                    </div>
                </div>



                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Break Fast Food Safety</label>
                        <input type="text" class="form-control">
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">PreShift Check List</label>
                        <input type="text" class="form-control">
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label"></label>
                        <asp:CheckBox runat="server" CssClass="checkbox" Text="Auto Fail" />
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">DSPT Completed 24 hours in Advance</label><br />
                        <div class="radio radio-inline">
                            <asp:RadioButton GroupName="100" runat="server" Text="Yes" />
                        </div>
                        <div class="radio radio-inline">
                            <asp:RadioButton GroupName="100" runat="server" Text="No" />
                        </div>

                    </div>
                </div>

                <div class="col-md-12">
                    <h4 class="header-title">Send To</h4>
                    <p>
                        <asp:CheckBox runat="server" CssClass="checkbox" Text="Select All" /></p>

                    <p>
                        <asp:CheckBoxList runat="server"
                            RepeatLayout="Flow" RepeatColumns="8" CssClass="checkbox" RepeatDirection="Horizontal"
                            DataValueField="ID" DataTextField="Name">
                        </asp:CheckBoxList>
                    </p>

                </div>

                <div class="col-md-12">

                    <div class="col-sm-6 p-l-r-20">

                        <div class="form-group">
                                <label class="control-label">Signer Name</label>
                                <input type="text" class="form-control">
                            </div>
                        <div id="signature-pad-1" class="m-signature-pad">
                            <div class="m-signature-pad--body">
                                <canvas></canvas>
                            </div>
                            <div class="m-signature-pad--footer">
                                <div class="description">Sign above</div>
                                <div class="left">
                                    <button type="button" class="btn btn-inverse btn-custom waves-effect waves-light" data-action="clear1">Clear</button>
                                </div>
                                <div class="right">
                                    <button type="button" class="btn btn-inverse btn-custom waves-effect waves-light" data-action="save-png1">Save</button>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="col-sm-6 p-l-r-20">
                        <div class="form-group">
                                <label class="control-label">Signer Name</label>
                                <input type="text" class="form-control">
                            </div>
                        <div id="signature-pad-2" class="m-signature-pad">
                            <div class="m-signature-pad--body">
                                <canvas></canvas>
                            </div>
                            <div class="m-signature-pad--footer">
                                <div class="description">Sign above</div>
                                <div class="left">
                                    <button type="button" class="btn btn-inverse btn-custom waves-effect waves-light" data-action="clear2">Clear</button>
                                </div>
                                <div class="right">
                                    <button type="button" class="btn btn-inverse btn-custom waves-effect waves-light" data-action="save-png2">Save</button>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>

                <div class="clearfix"></div>

                <div class="col-md-12 m-t-40">
                    <asp:Button ID="btnPrevious" runat="server" Text="Previous"  OnClick="btnPrevious_Click" CssClass="btn btn-inverse waves-effect waves-light" />
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return validate();" OnClick="btnSubmit_Click" CssClass="btn btn-inverse waves-effect waves-light pull-right" />
                </div>

                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cntBasicInfoFoot" ContentPlaceHolderID="FormMasterFoot" runat="server">
    
</asp:Content>

<%@ Page Title="Basic Info" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="BasicInfo.aspx.cs" Inherits="Forms.Webroot.Forms.SIO.BasicInfo" %>

<asp:Content ID="cntBasicInfoHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntBasicInfoBody" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="row" id="validate">
        <div class="col-sm-12">
            <div class="card-box">
                <h2 class="text-center m-t-0"><% Response.Write(trasnlation("Shift.Performance.Verification.Tool")); %></h2>
                <h4 class="m-t-0 header-title text-center">
                    <% Response.Write(trasnlation("Used.for.Verification.of.SIO.Principles")); %></h4>


                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label"><% Response.Write(trasnlation("Restaurant.Name")); %></label>
                        <input type="text" id="txtStore" runat="server" class="form-control" irequired="1" imask="" />
                    </div>
                </div>
               
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label"><% Response.Write(trasnlation("Date")); %></label>
                        <div class="input-group">
                            <input type="text" class="form-control datepicker-autoclose" id="dateid" placeholder="mm/dd/yyyy">
                            <span class="input-group-addon"><i class="icon-calender"></i></span>
                        </div>
                    </div>
                </div>


                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label"><% Response.Write(trasnlation("Time")); %></label>
                        <div class="input-group clockpicker " data-placement="top" data-align="top" data-autoclose="true">
                            <input type="text" class="form-control" id="txtBI1" runat="server" value="12:00">
                            <span class="input-group-addon"><span class="icon-clock"></span></span>
                        </div>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label"><% Response.Write(trasnlation("Shift.Manager.Name")); %></label>
                        <input type="text" id="txtBI2" runat="server" class="form-control">
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label"><% Response.Write(trasnlation("Completed.By")); %></label>
                        <input type="text" id="txtBI3" runat="server" class="form-control">
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label"><% Response.Write(trasnlation("General.SIO")); %></label>
                        <input type="text" id="txtBI4" runat="server" class="form-control">
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label"><% Response.Write(trasnlation("Quality")); %></label>
                        <input type="text" id="txtBI5" runat="server" class="form-control">
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label"><% Response.Write(trasnlation("Service")); %></label>
                        <input type="text" id="txtBI6" runat="server" class="form-control">
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label"><% Response.Write(trasnlation("Cleanliness")); %></label>
                        <input type="text"  id="txtBI7" runat="server" class="form-control">
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label"><% Response.Write(trasnlation("Overall")); %></label>
                        <div class="input-group">
                            <span class="input-group-addon half-addon">
                                <asp:Label ID="lblBI1" runat="server" Text="100%"></asp:Label></span>
                            <input type="text" id="txtBI12" runat="server" class="form-control">
                        </div>
                    </div>
                </div>



                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label"><% Response.Write(trasnlation("Break.Fast.Food.Safety")); %></label>
                        <input type="text"  id="txtBI8" runat="server" class="form-control">
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label"><% Response.Write(trasnlation("PreShift.Checklist")); %></label>
                        <input type="text"  id="txtBI9" runat="server" class="form-control">
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label"></label>
                        <label class="control-label">
                            <input type="checkbox" runat="server" id="chkBI1" CssClass="checkbox" /> <% Response.Write(trasnlation("Auto.Fail")); %>
                        </label>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label"><% Response.Write(trasnlation("DSPT.Completed.24.hours.in.Advance")); %></label><br />
                        <div class="radio radio-inline">
                            <input type="radio" id="radBI1" name="100" runat="server" Text="Yes" />
                        </div>
                        <div class="radio radio-inline">
                            <input type="radio" id="radBI2" name="100" runat="server" Text="No" />
                        </div>

                    </div>
                </div>

                <div class="col-md-12">
                    <h4 class="header-title">Send To</h4>
                    <p>
                        <input type="checkbox" id="chkBI4" runat="server" CssClass="checkbox" /> <% Response.Write(trasnlation("Select.All")); %></p>

                    <p>
                        <asp:CheckBoxList runat="server"
                            RepeatLayout="Flow" RepeatColumns="8" ID="chkBI5" CssClass="checkbox" RepeatDirection="Horizontal"
                            DataValueField="ID" DataTextField="Name">
                        </asp:CheckBoxList>
                    </p>

                </div>

                <div class="col-md-12">

                    <div class="col-sm-6 p-l-r-20">

                        <div class="form-group">
                                <label class="control-label">Signer Name</label>
                                <input type="text"  id="txtBI10" runat="server" class="form-control">
                            </div>
                        <div id="signature-pad-1" class="m-signature-pad">
                            <div class="m-signature-pad--body">
                                <canvas></canvas>
                            </div>
                            <div class="m-signature-pad--footer">
                                <div class="description"><% Response.Write(trasnlation("Sign.above")); %></div>
                                <div class="left">
                                    <button type="button" class="btn btn-inverse btn-custom waves-effect waves-light" data-action="clear1">Clear</button>
                                </div>
                                
                            </div>
                        </div>
                    </div>


                    <div class="col-sm-6 p-l-r-20">
                        <div class="form-group">
                                <label class="control-label">Signer Name</label>
                                <input type="text"  id="txtBI11" runat="server" class="form-control">
                            </div>
                        <div id="signature-pad-2" class="m-signature-pad">
                            <div class="m-signature-pad--body">
                                <canvas></canvas>
                            </div>
                            <div class="m-signature-pad--footer">
                                <div class="description"><% Response.Write(trasnlation("Sign.above")); %></div>
                                <div class="left">
                                    <button type="button" class="btn btn-inverse btn-custom waves-effect waves-light" data-action="clear2">Clear</button>
                                </div>
                                
                            </div>
                        </div>

                    </div>

                </div>

                <div class="clearfix"></div>

                <div class="col-md-12 m-t-40">
                    <asp:HiddenField ID="signature1" runat="server" />
                    <asp:HiddenField ID="signature2" runat="server" />
                    <%--<input type="text"  id="hfValue" runat="server" class="form-control">--%>
                    <asp:Button ID="btnPrevious" runat="server" Text="Previous"  OnClick="btnPrevious_Click" CssClass="btn btn-inverse waves-effect waves-light" />
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return getSign();" OnClick="btnSubmit_Click" CssClass="btn btn-inverse waves-effect waves-light pull-right" />
                </div>

                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cntBasicInfoFoot" ContentPlaceHolderID="FormMasterFoot" runat="server">
    <script>
        function getSign() {
            
            document.getElementById("CommonMasterBody_FormMasterBody_signature1").value = signaturePad1.toDataURL();

            document.getElementById("CommonMasterBody_FormMasterBody_signature2").value = signaturePad2.toDataURL();
        }
    </script>
</asp:Content>

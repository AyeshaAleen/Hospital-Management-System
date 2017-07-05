<%@ Page Title="Forms Manager" EnableEventValidation="false" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Webroot/Forms/Management/FormsManager/DynamicFormMaster.master" AutoEventWireup="true" CodeBehind="FormManager.aspx.cs" Inherits="Forms.Webroot.Forms.Management.FormsManager.FormsManager" %>

<asp:Content ID="cntFormsManagerHead" ContentPlaceHolderID="DynamicFormMasterHead" runat="server">
    <link href="../../../../itinsync/resources/dynamic/dragdrop/style.css" rel="stylesheet" />
    <script src="../../../../itinsync/resources/dynamic/dragdrop/redips-drag-min.js"></script>
    <script src="../../../../itinsync/resources/dynamic/dragdrop/redips-table-min.js"></script>
    <script src="../../../../itinsync/resources/dynamic/dragdrop/script.js"></script>

</asp:Content>
<asp:Content ID="cntFormsManagerBody" ContentPlaceHolderID="DynamicFormMasterBody" runat="server">

    <div class="row" id="validate" runat="server">

        <div class="col-sm-12">
            <div class="card-box">
                <a href="../ViewDocumentSection.aspx" class="btn btn-success pull-right">Back</a>

                <h4 class="m-t-0 header-title"><b>Forms Manager</b></h4>
                <div class="row">
                    <div id="redips-drag">
                        <!-- left container -->

                        <div id="left" class="col-md-2 col-sm-4 col-xs-5">
                            <div class="instructions">
                                <strong>Building blocks</strong>
                                <br />
                                Drag blocks to the right to build your application.
                            </div>
                            <table id="tblComponents">
                                <tbody>

                                    <tr>
                                        <td class="redips-mark">
                                            <div class="redips-drag redips-clone" id="ca1"><i class="glyphicon glyphicon-text-width"></i>&nbsp;label text</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="redips-mark">
                                            <div class="redips-drag redips-clone" id="ha1"><i class="glyphicon glyphicon-header"></i>&nbsp;Heading</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="redips-mark">
                                            <div class="redips-drag redips-clone" id="dp1"><i class="glyphicon glyphicon-list-alt"></i>&nbsp;DropDown</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="redips-mark">
                                            <div class="redips-drag redips-clone" id="tx1"><i class="md md-textsms"></i>&nbsp;TextBox</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="redips-mark">
                                            <div class="redips-drag redips-clone" id="ch1"><i class="glyphicon glyphicon-check"></i>&nbsp;CheckBox</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="redips-mark">
                                            <div class="redips-drag redips-clone" id="rs1"><i class="glyphicon glyphicon-ok-circle"></i>&nbsp;Radio Button</div>
                                        </td>
                                    </tr>
                                    <%--     <tr>
                                        <td class="redips-mark">
                                            <div class="redips-drag redips-clone" id="rg1"><i class="glyphicon glyphicon-ok-circle"></i><i class="glyphicon glyphicon-ok-circle"></i>RadioGroup</div>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="redips-mark">
                                            <div class="redips-drag redips-clone" id="ta1"><i class="ti-write"></i>&nbsp;TextArea</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="redips-mark">
                                            <div class="redips-drag redips-clone" id="hi1"><i class="glyphicon glyphicon-eye-open"></i>&nbsp;Hidden</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="redips-mark">
                                            <div class="redips-drag redips-clone" id="sg1"><i class="md md-gesture"></i>&nbsp;Signature</div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <!-- left container -->

                        <!-- right container -->
                        <div id="right" class="col-md-10 col-sm-8 col-xs-6">
                            <div class="col-md-12">
                                <!-- toolbox -->
                                <table id="tblToolbox" class="table table-responsive">
                                    <tbody>
                                        <tr>
                                            <td class="redips-mark">
                                                <input type="button" value="Merge" class="btn btn-success" onclick="redips.merge()" title="Merge marked cells horizontally" />
                                                <input type="button" value="Split" class="btn btn-success" onclick="redips.split()" title="Split marked cells horizontally" />
                                            </td>
                                            <td class="redips-mark"></td>

                                            <!--<td class="redips-mark">
								<input type="button" value="Split H" class="button" onclick="redips.split('h')" title="Split marked table cell horizontally"/>
								<input type="button" value="Split V" class="button" onclick="redips.split('v')" title="Split marked table cell vertically"/>
							</td>
							<td class="redips-mark">
								<input type="button" value="Row +" class="button" onclick="redips.row('insert')" title="Add table row"/>
								<input type="button" value="Row -" class="button" onclick="redips.row('delete')" title="Delete table row"/>
							</td>
							<td class="redips-mark">
								<input type="button" value="Col +" class="button" onclick="redips.column('insert')" title="Add table column"/>
								<input type="button" value="Col -" class="button" onclick="redips.column('delete')" title="Delete table column"/>
							</td>
							<td class="trash">Trash</td>-->
                                            <%--<a href="../ViewDocumentSection.aspx">../ViewDocumentSection.aspx</a>
                                        <a href=<%ResolveClientUrl(""); %>>Manage Section</a>--%>
                                        </tr>

                                    </tbody>
                                </table>
                                <div style="overflow-x:scroll">
                                <!-- main table -->
                                <table id="tblEditor" class="table table-responsive">

                                    <tbody>
                                        <tr>
                                            <td></td>

                                            <td id="cellcontrol" class="redips-mark ignore" last="true">
                                                <div>

                                                    <span onclick="redips.cellDelete(this)" class="rowTool">xc/</span>
                                                    <span onclick="redips.rowDelete(this)" class="rowTool">xr/</span>

                                                    <span onclick="redips.rowInsert(this)" class="rowTool">r+/</span>

                                                    <span onclick="redips.colInsert(this)" class="rowTool">c+</span>
                                                </div>
                                            </td>

                                        </tr>
                                    </tbody>
                                </table>

                            </div></div>
                            <!-- save button -->
                            <%--<input type="button" value="Save" class="button sButton" onclick="redips.save()" title="Save form" /><span id="sMessage"></span>--%>

                            <asp:Button ID="savedocument" CssClass="btn btn-success" runat="server" Text="Save" OnClick="savedocument_Click" OnClientClick="getTableContent()" />
                            <input type="hidden" id="ControlCount" runat="server" />
                            <input type="hidden" id="FormName" runat="server" />
                            <input type="hidden" id="SectionName" runat="server" />
                            <input type="hidden" id="sectionID" runat="server" />


                            <!-- demo message (needed to display JSON message) -->
                            <div id="message" />
                        </div>
                        <!-- right container -->
                    </div>



                    <div class="clearfix"></div>
                </div>






                <div class="clearfix"></div>

                <div id="con-close-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                    <div class="modal-dialog" style="width: 400px">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h4 class="modal-title">Add Field Detail</h4>
                                <%--<button value="Delete" class="btn btn-success" onclick="deleteColumn()">Delete</button>--%>
                            </div>
                            <div class="modal-body">

                                <div class="row">
                                    <ul class="nav nav-tabs">
                                        <li class="active">
                                            <a href="#home" data-toggle="tab" aria-expanded="true">
                                                <span class="visible-xs"><i class="fa fa-home"></i></span>
                                                <span class="hidden-xs">Basic</span>
                                            </a>
                                        </li>
                                        <li class="">
                                            <a href="#profile" data-toggle="tab" aria-expanded="false">
                                                <span class="visible-xs"><i class="fa fa-user"></i></span>
                                                <span class="hidden-xs">Operations</span>
                                            </a>
                                        </li>
                                        <li class="">
                                            <a href="#messages" data-toggle="tab" aria-expanded="false">
                                                <span class="visible-xs"><i class="fa fa-envelope-o"></i></span>
                                                <span class="hidden-xs">Condition</span>
                                            </a>
                                        </li>
                                        <li class="">
                                            <a href="#settings" data-toggle="tab" aria-expanded="false">
                                                <span class="visible-xs"><i class="fa fa-cog"></i></span>
                                                <span class="hidden-xs">Reference</span>
                                            </a>
                                        </li>
                                    </ul>
                                    <div class="tab-content">
                                        <div class="tab-pane active" id="home">

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Control Name</label>
                                                    <input type="text" id="ControlName" disabled class="form-control" />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Control ID</label>
                                                    <input type="text" id="ControlID" disabled class="form-control" />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Translation</label>
                                                    <input type="text" id="translation" class="form-control" readonly />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Mask</label>
                                                    <asp:DropDownList ID="ddlMask" runat="server" CssClass="form-control" DataValueField="Code" DataTextField="Text">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Css Class</label>
                                                    <input type="text" id="cssClass" class="form-control" />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">points</label>
                                                    <input type="text" id="points" class="form-control" />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Default Value</label>
                                                    <input type="text" id="defaultValue" class="form-control" onblur="setTranslation()" />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Lookup Name</label>
                                                    <asp:DropDownList ID="ddlLookupName" runat="server" CssClass="form-control" DataValueField="Code" DataTextField="Text">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <input type="checkbox" id="isRequired" />
                                                    isRequired
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <input type="checkbox" id="isReadonly" />
                                                    isReadonly
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>

                                        </div>
                                        <div class="tab-pane" id="profile">

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Operation</label>
                                                    <asp:DropDownList ID="ddlOperation" runat="server" CssClass="form-control" DataValueField="Code" DataTextField="Text">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>


                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Control IDs</label>
                                                    <div class="input-group">
                                                        <select id="ddlControlID" class="form-control"></select>
                                                        <span class="input-group-addon btn btn-success" onclick="AddOperationDetail()">Go</span>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="col-md-12">
                                                <textarea rows="2" id="txtformula" class="form-control"></textarea>
                                            </div>



                                            <%--<div class="col-md-12" style="max-height:250px; overflow-y:scroll">
                                        <table class="table table-hover table-responsive table-bordered" id="tblOperationDetail">
                                            <tr>
                                                <th>Operation</th>
                                                <th>Control ID</th>
                                            </tr>
                                            
                                        </table>
                                    </div>--%>
                                            <div class="clearfix"></div>

                                        </div>
                                        <div class="tab-pane" id="messages">

                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Conditional Operation</label>
                                                    <asp:DropDownList ID="ddlConditionOperation" runat="server" CssClass="form-control" DataValueField="Code" DataTextField="Text">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>


                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="control-label">Control IDs</label>
                                                    <div class="input-group">
                                                        <select id="ddlConditionalControlID" class="form-control"></select>
                                                        <span class="input-group-addon btn btn-success" onclick="AddConditionDetail()">Go</span>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="col-md-12">
                                                <textarea rows="2" id="txtcondition" class="form-control"></textarea>
                                            </div>

                                            <div class="clearfix"></div>

                                        </div>
                                        <div class="tab-pane" id="settings">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="control-label">Ref Label IDs</label>
                                                    <div class="input-group">
                                                        <select id="ddlRefLabelID" class="form-control"></select>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="control-label">Ref Translation</label>
                                                    <input type="text" id="txtBroughtForward" class="form-control" />
                                                </div>
                                            </div>

                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label class="control-label">Forwarded Controls</label>
                                                    <asp:DropDownList ID="ddlForwardedControls" runat="server" CssClass="form-control" DataValueField="controlID" DataTextField="translation">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>


                                            <div class="clearfix"></div>

                                        </div>
                                    </div>
                                </div>


                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default waves-effect" data-dismiss="modal">Close</button>
                                <button type="button" class="btn btn-success waves-effect waves-light" onclick="SetDetail()">Set Detail</button>
                                <input type="text" hidden="hidden" id="tableOuterHtml" runat="server" />
                                <input type="text" hidden="hidden" id="RequiredFieldID" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <input type="hidden" id="PreviousControlID" />


</asp:Content>
<asp:Content ID="cntFormsManagerFoot" ContentPlaceHolderID="DynamicFormMasterFooter" runat="server">
    <script>
        function getTableContent() {
            debugger;
            var outerHTML = document.getElementById("tblEditor").outerHTML;
            outerHTML = decodehtml(outerHTML);
            document.getElementById('CommonMasterBody_DynamicFormMasterBody_tableOuterHtml').value = outerHTML;
        }
        function decodehtml(outerHTML) {
            return outerHTML.replace(/&/g, '&amp;')
                .replace(/</g, '&lt;')
                .replace(/>/g, '&gt;')
                .replace(/"/g, '&quot;')
                .replace(/'/g, '&apos;');

        }


        $(document).ready(function () {
            debugger;


            $('#ddlControlID').on('change', function () {
                $("#ddlControlID > option").each(function () {
                    var elemid = $(this).val();
                    $("#" + elemid).parent().removeClass('redips-drag-highlight').removeClass('redips-drag-field-highlight').addClass('redips-drag');
                });
                var Controlid = document.getElementById("ddlControlID").value;

                $("#" + Controlid).parent().addClass('redips-drag-highlight').removeClass('redips-drag');
            });

            if (document.getElementById("CommonMasterBody_DynamicFormMasterBody_tableOuterHtml").value != "") {
                document.getElementById("tblEditor").innerHTML = document.getElementById("CommonMasterBody_DynamicFormMasterBody_tableOuterHtml").value;
                var theTbl = document.getElementById('tblEditor');
            }

            $('#ddlConditionalControlID').on('change', function () {
                $("#ddlConditionalControlID > option").each(function () {
                    var elemid = $(this).val();
                    $("#" + elemid).parent().removeClass('redips-drag-highlight').removeClass('redips-drag-field-highlight').addClass('redips-drag');
                });
                var Controlid = document.getElementById("ddlConditionalControlID").value;

                $("#" + Controlid).parent().addClass('redips-drag-highlight').removeClass('redips-drag');
            });

            $('#ddlRefLabelID').on('change', function () {
                $("#ddlRefLabelID > option").each(function () {
                    var elemid = $(this).val();
                    $("#" + elemid).parent().removeClass('redips-drag-highlight').removeClass('redips-drag-field-highlight').addClass('redips-drag');
                });
                var Controlid = document.getElementById("ddlRefLabelID").value;

                $("#" + Controlid).parent().addClass('redips-drag-highlight').removeClass('redips-drag');

                document.getElementById("txtBroughtForward").value = document.getElementById(Controlid).getAttribute("translation");
            });



        });
    </script>
</asp:Content>

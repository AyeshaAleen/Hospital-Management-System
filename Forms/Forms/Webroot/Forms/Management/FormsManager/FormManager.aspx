<%@ Page Title="Forms Manager" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Webroot/Forms/Management/FormsManager/DynamicFormMaster.master" AutoEventWireup="true" CodeBehind="FormManager.aspx.cs" Inherits="Forms.Webroot.Forms.Management.FormsManager.FormsManager" %>

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
                                            <div class="redips-drag redips-clone" id="ca1"><i class="glyphicon glyphicon-text-width"></i>label text</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="redips-mark">
                                            <div class="redips-drag redips-clone" id="da1"><i class="glyphicon glyphicon-header"></i>Heading</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="redips-mark">
                                            <div class="redips-drag redips-clone" id="tx1"><i class="md md-textsms"></i>TextBox</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="redips-mark">
                                            <div class="redips-drag redips-clone" id="ch1"><i class="glyphicon glyphicon-check"></i>CheckBox</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="redips-mark">
                                            <div class="redips-drag redips-clone" id="rs1"><i class="glyphicon glyphicon-ok-circle"></i>Radio Single</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="redips-mark">
                                            <div class="redips-drag redips-clone" id="rg1"><i class="glyphicon glyphicon-ok-circle"></i><i class="glyphicon glyphicon-ok-circle"></i>RadioGroup</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="redips-mark">
                                            <div class="redips-drag redips-clone" id="ta1"><i class="ti-write"></i>TextArea</div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <!-- left container -->

                        <!-- right container -->
                        <div id="right" class="table-responsive col-md-10 col-sm-8 col-xs-6" style="overflow-x: scroll">
                            <!-- toolbox -->
                            <table id="tblToolbox">
                                <tbody>
                                    <tr>
                                        <td class="redips-mark">
                                            <input type="button" value="Merge" class="btn btn-primary" onclick="redips.merge()" title="Merge marked cells horizontally" />
                                            <input type="button" value="Split" class="btn btn-primary" onclick="redips.split()" title="Split marked cells horizontally" />
                                        </td>


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

                                    </tr>
                                </tbody>
                            </table>
                            <!-- main table -->
                            <table id="tblEditor">

                                <tbody>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>

                                        <td id="cellcontrol" class="redips-mark ignore" last="true">
                                            <div>
                                                <span onclick="redips.rowDelete(this)" class="rowTool">x</span>
                                                /
									<span onclick="redips.rowInsert(this)" class="rowTool">r+</span>
                                                /
									<span onclick="redips.colInsert(this)" class="rowTool">c+</span>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <!-- save button -->
                            <%--<input type="button" value="Save" class="button sButton" onclick="redips.save()" title="Save form" /><span id="sMessage"></span>--%>

                            <asp:Button ID="savedocument" CssClass="btn btn-primary" runat="server" Text="Button" OnClick="savedocument_Click" OnClientClick="getTableContent()" />
                            <!-- demo message (needed to display JSON message) -->
                            <div id="message" />
                        </div>
                        <!-- right container -->
                    </div>


                    <%--<div id="redips-drag">
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

                                            <button onclick="return createTR();">Create tr</button>
                                            <button onclick="return createTD();">Create td</button>
                                            <button onclick="return getTableHTML();">html</button>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clearfix"></div>
                        <!-- display block content -->

                        <div class="clearfix"></div>
                    </div>--%>
                    <div class="clearfix"></div>
                </div>


               <%-- <div class="col-md-6">
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

                </div>--%>



                <div class="clearfix"></div>

                <div id="con-close-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h4 class="modal-title">Add New Row</h4>
                                <button value="Delete" onclick="deleteColumn()">Delete</button>
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
                                <input type="text" hidden="hidden" id="tableOuterHtml" runat="server" />
                                <input type="text" hidden="hidden" id="RequiredFieldID" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cntFormsManagerFoot" ContentPlaceHolderID="DynamicFormMasterFooter" runat="server">
    <script>
        function getTableContent() {
            var outerHTML = document.getElementById("tblEditor").outerHTML;
            outerHTML = decodehtml(outerHTML);
            document.getElementById('CommonMasterBody_FormMasterBody_tableOuterHtml').value = outerHTML;//document.getElementById("tblEditor").outerHTML;

        }
        $(document).ready(function () {
            var parenttbl = document.getElementById("cellcontrol");
            var outer = parenttbl.outerHTML;
            outer = decodehtml(outer);
            document.getElementById("tblEditor").innerHTML = document.getElementById("CommonMasterBody_FormMasterBody_tableOuterHtml").value;
            var theTbl = document.getElementById('tblEditor');
            $('#tblEditor tr').each(function () {
                var newel = document.createElement('td');
                $(this).append(parenttbl);
            });
        });


        function decodehtml(outerHTML) {
            return outerHTML.replace(/&/g, '&amp;')
                .replace(/</g, '&lt;')
                .replace(/>/g, '&gt;')
                .replace(/"/g, '&quot;')
                .replace(/'/g, '&apos;');

        }


        


    </script>




</asp:Content>

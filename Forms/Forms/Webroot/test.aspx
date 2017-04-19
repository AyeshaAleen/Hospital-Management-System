<%@ Page Title="Test Page" Language="C#" MasterPageFile="~/Webroot/testMaster.master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Forms.Webroot.test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CommonMerFooter" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonMast" runat="server">

    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 m-b-20 header-title"><b>Tags Input</b></h4>

                <div class="row">
                    <div class="col-md-6">
                        <section class="progress-demo">
                        <button class="ladda-button btn btn-success" data-style="contract">Submit
                                                </button>
                            </section>

                        <asp:Button ID="btnd" OnClick="btnd_Click" runat="server" Text="dsfdf" CssClass="ladda-button btn btn-success" OnClientClick="message()"/>


                        <h5><b>Input Tags</b></h5>
                        <p class="text-muted m-b-30 font-13">
                            Just add <code>data-role="tagsinput"</code> to your input field to automatically change it to a tags input field.
                        </p>
                        <div class="tags-default">
                            <input type="text" value="Amsterdam,Washington,Sydney" data-role="tagsinput" placeholder="add tags" />
                        </div>

                    </div>

                    <div class="col-md-6">
                        <h5><b>True multi value</b></h5>
                        <p class="text-muted m-b-30 font-13">
                            Use a <code>&lt;select multiple /&gt;</code> as your input element for a tags input, to gain true multivalue support.
												   Instead of a comma separated string, the values will be set in an array. Existing <code>&lt;option /&gt;</code>
                            elements will automatically be set as tags. This makes it also possible to create tags containing a comma.
                        </p>
                        <div class="m-b-0">
                            <select multiple data-role="tagsinput">
                                <option value="Amsterdam">Amsterdam</option>
                                <option value="Washington">Washington</option>
                                <option value="Sydney">Sydney</option>
                            </select>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Input Types</b></h4>
                <p class="text-muted m-b-30 font-13">
                    Most common form control, text-based input fields. Includes support for all HTML5 types: <code>text</code>, <code>password</code>, <code>datetime</code>, <code>datetime-local</code>, <code>date</code>, <code>month</code>, <code>time</code>, <code>week</code>, <code>number</code>, <code>email</code>, <code>url</code>, <code>search</code>, <code>tel</code>, and <code>color</code>.
                </p>
                <div class="row">
                    <div class="col-md-6">
                      

                            <div class="form-group">
                                <label class="col-md-2 control-label">Readonly</label>
                                <div class="col-md-10">
                                    <input type="text" class="form-control" readonly value="Readonly value">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Disabled</label>
                                <div class="col-md-10">
                                    <input type="text" class="form-control" disabled="" value="Disabled value">
                                </div>
                            </div>


                            <div class="form-group">
                                <label class="col-sm-2 control-label">Static control</label>
                                <div class="col-sm-10">
                                    <p class="form-control-static">email@example.com</p>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">Helping text</label>
                                <div class="col-sm-10">
                                    <input type="text" class="form-control" placeholder="Helping text">
                                    <span class="help-block"><small>A block of help text that breaks onto a new line and may extend beyond one line.</small></span>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Input Select</label>
                                <div class="col-sm-10">
                                    <select class="form-control">
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                        <option>5</option>
                                    </select>
                                    <h6>Multiple select</h6>
                                    <select multiple="" class="form-control">
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                        <option>5</option>
                                    </select>
                                </div>
                            </div>

                    </div>
                    <div class="col-md-6">
                       
                            <div class="form-group">
                                <label class="col-md-2 control-label">Text</label>
                                <div class="col-md-10">
                                    <input type="text" class="form-control" value="Some text value...">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label" for="example-email">Email</label>
                                <div class="col-md-10">
                                    <input type="email" id="example-email" name="example-email" class="form-control" placeholder="Email">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Password</label>
                                <div class="col-md-10">
                                    <input type="password" class="form-control" value="password">
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-2 control-label">Placeholder</label>
                                <div class="col-md-10">
                                    <input type="text" class="form-control" placeholder="placeholder">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Text area</label>
                                <div class="col-md-10">
                                    <textarea class="form-control" rows="5"></textarea>
                                </div>
                            </div>

                    </div>

                    


                </div>
            </div>
        </div>
    </div>



    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Custom Toolbar</b></h4>
                <p class="text-muted font-13">
                    Example of Custom Toolbar (Your text goes here).
                </p>

                <table class="table-bordered" data-toggle="table" data-search="true"
                    data-sort-name="id" data-page-list="[10, 20, 50, 100]"
                    data-page-size="10" data-pagination="true">
                    <thead>
                        <tr>
                            <th data-field="state" data-checkbox="true"></th>
                            <th data-field="id" data-sortable="true">Order ID</th>
                            <th data-field="name" data-sortable="true">Name</th>
                            <th data-field="date" data-sortable="true">Order Date</th>
                            <th data-field="amount" data-align="center" data-sortable="true">Price</th>
                            <th data-field="status" data-align="center" data-sortable="true">Status</th>
                        </tr>
                    </thead>

                    <tbody>
                        <tr>
                            <td></td>
                            <td>UB-1609</td>
                            <td>Boudreaux</td>
                            <td>22 Jun 2015</td>
                            <td>$ 35.00</td>
                            <td>Unpaid</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>UB-1610</td>
                            <td>Woldt</td>
                            <td>24 Jun 2015</td>
                            <td>$ 15.00</td>
                            <td>Paid</td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>UB-1611</td>
                            <td>Leonardo</td>
                            <td>25 Jun 2015</td>
                            <td>$ 35.00</td>
                            <td>Shipped</td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>UB-1612</td>
                            <td>Halladay</td>
                            <td>27 Jun 2015</td>
                            <td>$ 35.00</td>
                            <td>Refunded</td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>UB-1613</td>
                            <td>Badgett</td>
                            <td>28 Jun 2015</td>
                            <td>$ 95.00</td>
                            <td>Unpaid</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>UB-1614</td>
                            <td>Boudreaux</td>
                            <td>29 Jun 2015</td>
                            <td>$ 35.00</td>
                            <td>Paid</td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>UB-1615</td>
                            <td>Boudreaux</td>
                            <td>22 Jun 2015</td>
                            <td>$ 35.00</td>
                            <td>Shipped</td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>UB-1616</td>
                            <td>Boudreaux</td>
                            <td>22 Jun 2015</td>
                            <td>$ 35.00</td>
                            <td>Refunded</td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>UB-1617</td>
                            <td>Boudreaux</td>
                            <td>22 Jun 2015</td>
                            <td>$ 35.00</td>
                            <td>Unpaid</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>UB-1618</td>
                            <td>Boudreaux</td>
                            <td>22 Jun 2015</td>
                            <td>$ 35.00</td>
                            <td>Paid</td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>UB-1619</td>
                            <td>Boudreaux</td>
                            <td>22 Jun 2015</td>
                            <td>$ 35.00</td>
                            <td>Shipped</td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>UB-1620</td>
                            <td>Boudreaux</td>
                            <td>22 Jun 2015</td>
                            <td>$ 35.00</td>
                            <td>Refunded</td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>UB-1621</td>
                            <td>Boudreaux</td>
                            <td>22 Jun 2015</td>
                            <td>$ 35.00</td>
                            <td>Unpaid</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>UB-1622</td>
                            <td>Boudreaux</td>
                            <td>22 Jun 2015</td>
                            <td>$ 35.00</td>
                            <td>Paid</td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>UB-1623</td>
                            <td>Boudreaux</td>
                            <td>22 Jun 2015</td>
                            <td>$ 35.00</td>
                            <td>Shipped</td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>UB-1624</td>
                            <td>Boudreaux</td>
                            <td>22 Jun 2015</td>
                            <td>$ 35.00</td>
                            <td>Refunded</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

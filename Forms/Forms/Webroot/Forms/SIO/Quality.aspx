<%@ Page Title="Quality" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="Quality.aspx.cs" Inherits="Forms.Webroot.Forms.SIO.Quality" %>

<asp:Content ID="cntQualityHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntQualityBody" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Quality</b></h4>

                <table data-toggle="table">
                    <thead>
                        <tr>
                            <th>Quality</th>
                            <th data-align="center">Yes</th>
                            <th data-align="center">No</th>
                            <th data-align="center">N/a</th>
                            <th data-align="center">Pts</th>
                        </tr>
                    </thead>
                    <tbody>

                        <tr>
                            <td>
                                <div class="form-group">
                                    <label class="control-label col-sm-5">Product tested.</label>
                                    <div class="col-sm-7">
                                        <input type="text" id="txtQuality" class="form-control" runat="server" />
                                    </div>
                                </div>
                            </td>
                            <td colspan="4"></td>
                        </tr>



                        <tr>
                            <td>
                                <p>Fries/Hash brown- Hot, fresh, good flavor, salted properly, & golden color</p>
                            </td>
                            <td>
                                <input type="radio" id="radQuality1" name="40" runat="server" /></td>
                            <td>
                                <input type="radio" id="radQuality2" name="40" runat="server" /></td>
                            <td>
                                <input type="radio" id="radQuality3" name="40" runat="server" /></td>
                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Beverages- Properly filled, proper temperature, good flavor, properly made. </p>
                            </td>

                            <td>
                                <input type="radio" id="radQuality4" name="41" runat="server" /></td>
                            <td>
                                <input type="radio" id="radQuality5" name="41" runat="server" /></td>
                            <td>
                                <input type="radio" id="radQuality6" name="41" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Desserts- Properly prepared, good flavor and texture, holding time expectable </p>
                            </td>

                            <td>
                                <input type="radio" id="radQuality7" name="42" runat="server" /></td>
                            <td>
                                <input type="radio" id="radQuality8" name="42" runat="server" /></td>
                            <td>
                                <input type="radio" id="radQuality9" name="42" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Buns/Muffins/Bagels - toasted properly</p>
                            </td>

                            <td>
                                <input type="radio" id="radQuality10" name="43" runat="server" /></td>
                            <td>
                                <input type="radio" id="radQuality11" name="43" runat="server" /></td>
                            <td>
                                <input type="radio" id="radQuality12" name="43" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Production Manager - with 11 or more crew, a dedicated production manager has been shown to help expedite production and service. With fewer than 11 crew, it is helpful to have someone assigned production responsibilities. </p>
                            </td>

                            <td>
                                <input type="radio" id="radQuality13" name="44" runat="server" /></td>
                            <td>
                                <input type="radio" id="radQuality14" name="44" runat="server" /></td>
                            <td>
                                <input type="radio" id="radQuality15" name="44" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Cabinet Charts- in place, up to date, and followed. Holding times adhered to</p>
                            </td>

                            <td>
                                <input type="radio" id="radQuality16" name="45" runat="server" /></td>
                            <td>
                                <input type="radio" id="radQuality17" name="45" runat="server" /></td>
                            <td>
                                <input type="radio" id="radQuality18" name="45" runat="server" /></td>

                            <td>10</td>
                        </tr>

                        <tr>
                            <td colspan="5"><p><strong>Raw product / buns</strong></p></td>
                        </tr>

                        <tr>
                            <td>Within code dates</td>
                            <td><input type="radio" id="radQuality19" name="46" runat="server" /></td>
                            <td><input type="radio" id="radQuality20" name="46" runat="server" /></td>
                            <td><input type="radio" id="radQuality21" name="46" runat="server" /></td>
                            <td>5</td>
                        </tr>

                        <tr>
                            <td>Secondary shelf lives marked</td>
                            <td><input type="radio" id="radQuality22" name="47" runat="server" /></td>
                            <td><input type="radio" id="radQuality23" name="47" runat="server" /></td>
                            <td><input type="radio" id="radQuality24" name="47" runat="server" /></td>
                            <td>5</td>
                        </tr>

                        <tr>
                            <td>Prep table times marked/monitored</td>
                           <td><input type="radio" id="radQuality25" name="48" runat="server" /></td>
                            <td><input type="radio" id="radQuality26" name="48" runat="server" /></td>
                            <td><input type="radio" id="radQuality27" name="48" runat="server" /></td>
                            <td>5</td>
                        </tr>

                        <tr>
                            <td>Tempered product properly marked</td>
                            <td><input type="radio" id="radQuality28" name="49" runat="server" /></td>
                            <td><input type="radio" id="radQuality29" name="49" runat="server" /></td>
                            <td><input type="radio" id="radQuality30" name="49" runat="server" /></td>
                            <td>5</td>
                        </tr>
                        
                       

                    <tr>
                        <td>
                            <p>Oil Quality meets McDonald’s Gold Standard</p>
                        </td>

                        <td>
                            <input type="radio" id="radQuality31" name="103" runat="server" /></td>
                        <td>
                            <input type="radio" id="radQuality32" name="103" runat="server" /></td>
                        <td>
                            <input type="radio" id="radQuality33" name="103" runat="server" /></td>

                        <td>10</td>
                    </tr>


                        <tr>
                            <td>
                                <p><strong>Quality - Total</strong></p>
                            </td>
                            <td colspan="3">
                                <asp:TextBox class="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <span class="form-control">100</span></td>

                        </tr>
                    </tbody>
                </table>

                <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" CssClass="btn btn-inverse waves-effect waves-light" />
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" CssClass="btn btn-inverse waves-effect waves-light pull-right" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cntQualityFoot" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

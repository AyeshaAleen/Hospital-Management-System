<%@ Page Title="Service" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="Service.aspx.cs" Inherits="Forms.Webroot.Forms.SIO.Service" %>

<asp:Content ID="cntServiceHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntServiceBody" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Service</b></h4>
          

                <table data-toggle="table">
                    <thead>
                        <tr>
                            <th>Service </th>
                            <th></th>
                            <th data-align="center">Yes</th>
                            <th data-align="center">No</th>
                            <th data-align="center">N/a</th>
                            <th data-align="center">Pts</th>
                        </tr>
                    </thead>
                    <tbody>
                        
                        <tr>
                            <td colspan="6"><strong>Times within standards:</strong></td>
                        </tr>


                        <tr>
                            <td>Front Counter Line</td>
                            <td><input type="text" id="txtService1" runat="server" CssClass="form-control"/></td>
                            <td><input type="radio" id="radService1" name="13" runat="server" /></td>
                            <td><input type="radio" id="radService2" name="13" runat="server" /></td>
                            <td><input type="radio" id="radService3" name="13" runat="server" /></td>
                            <td>5</td>
                        </tr>

                        <tr>
                            <td>Front Counter Service</td>
                            <td><input type="text" id="txtService2" runat="server" CssClass="form-control"/></td>
                            <td><input type="radio" id="radService4" name="14" runat="server" /></td>
                            <td><input type="radio" id="radService5" name="14" runat="server" /></td>
                            <td><input type="radio" id="radService6" name="14" runat="server" /></td>
                            <td>5</td>
                        </tr>
                        <tr>
                            <td>Drive-Thru Line</td>
                            <td><input type="text" id="txtService3" runat="server" CssClass="form-control"/></td>
                            <td><input type="radio" id="radService7" name="15" runat="server" /></td>
                            <td><input type="radio" id="radService8" name="15" runat="server" /></td>
                            <td><input type="radio" id="radService9" name="15" runat="server" /></td>
                            <td>5</td>
                        </tr>
                        <tr>
                            <td>Drive-Thru Service</td>
                            <td><input type="text" id="txtService4" runat="server" CssClass="form-control"/></td>
                            <td><input type="radio" id="radService10" name="16" runat="server" /></td>
                            <td><input type="radio" id="radService11" name="16" runat="server" /></td>
                            <td><input type="radio" id="radService12" name="16" runat="server" /></td>
                            <td>5</td>
                        </tr>

                        <tr>
                            <td>KVS</td>
                            <td><input type="text" id="txtService5" runat="server" CssClass="form-control"/></td>
                            <td><input type="radio" id="radService13" name="17" runat="server" /></td>
                            <td><input type="radio" id="radService14" name="17" runat="server" /></td>
                            <td><input type="radio" id="radService15" name="17" runat="server" /></td>
                            <td>10</td>
                        </tr>
                        
                        <tr>
                            <td colspan="2">
                                Ask, Ask, Tell and "I see 3" 
                            </td>

                            <td>
                                <input type="radio" id="radService16" name="75" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService17" name="75" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService18" name="75" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                Order accurately filled; condiments, napkins receipt, etc.  
                            </td>

                            <td>
                                <input type="radio" id="radService19" name="30" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService20" name="30" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService21" name="30" runat="server" /></td>

                            <td>10</td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                Nice Hospitality - Hospitality- Smiles, courteous, helpful, friendly, eye contact
                            </td>

                            <td>
                                <input type="radio" id="radService22" name="31" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService23" name="31" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService24" name="31" runat="server" /></td>

                            <td>10</td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                Management Appearance- proper uniform, complete with name tag, clean/well groomed
                            </td>

                            <td>
                                <input type="radio" id="radService25" name="32" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService26" name="32" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService27" name="32" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                Crew Appearance- proper uniform, complete with name tag, clean/well groomed 
                            </td>

                            <td>
                                <input type="radio" id="radService28" name="33" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService29" name="33" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService30" name="33" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                DT & Counter Equipment- operating and positioned properly, enough headsets, etc 
                            </td>

                            <td>
                                <input type="radio" id="radService31" name="34" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService32" name="34" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService33" name="34" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                Order taker suggestive sells when appropriate 
                            </td>

                            <td>
                                <input type="radio" id="radService34" name="35" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService35" name="35" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService36" name="35" runat="server" /></td>

                            <td>5</td>
                        </tr>



                        <tr>
                            <td colspan="2">
                                Travel paths completed.
                            </td>

                            <td>
                                <input type="radio" id="radService37" name="36" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService38" name="36" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService39" name="36" runat="server" /></td>


                            <td>5</td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                Table Service is being executed at 100%
                            </td>

                            <td>
                                <input type="radio" id="radService40" name="101" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService41" name="101" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService42" name="101" runat="server" /></td>
                            <td>10</td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                VOICE survey is communicated to every quest
                            </td>

                            <td>
                                <input type="radio" id="radService43" name="102" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService44" name="102" runat="server" /></td>
                            <td>
                                <input type="radio" id="radService45" name="102" runat="server" /></td>
                            <td>10</td>
                        </tr>



                        <tr>
                            <td colspan="2">
                                <strong>Service - Total</strong>
                            </td>
                            <td colspan="3">
                                <input type="text" id="txtService6" class="form-control" runat="server"/></td>
                            <td>
                                <span class="form-control">100</span></td>

                        </tr>
                    </tbody>
                </table>

                <div class="clearfix"></div>

                <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" CssClass="btn btn-inverse waves-effect waves-light" />
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" CssClass="btn btn-inverse waves-effect waves-light pull-right" />
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cntServiceFoot" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

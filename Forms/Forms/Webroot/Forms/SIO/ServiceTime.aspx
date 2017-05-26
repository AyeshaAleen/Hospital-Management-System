<%@ Page Title="Service Time" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="ServiceTime.aspx.cs" Inherits="Forms.Webroot.Forms.SIO.ServiceTime" %>

<asp:Content ID="cntServiceTimeHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntServiceTimeBody" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="row" runat="server" id="processDynamicDiv"> 
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Service Time</b></h4>

                <asp:Table ID="tableDynamic" runat="server" data-toggle="table">
                   
                </asp:Table>

               <%-- <table data-toggle="table" class="table-bordered"  data-search="true"
                    data-sort-name="id" data-page-list="[4, 8, 12, 100]"
                    data-page-size="4" data-pagination="true" runat="server" id="dynamicContentID">
                    <thead>
                    <tr>
                        <th colspan="2" data-align="center">Drive-Thru Service Times  </th>
                        <th colspan="2" data-align="center">Front Counter Service Times </th>
                        <th data-align="center">KVS Times </th>

                    </tr>

                    <tr>
                        <th data-align="center">Line Time</th>
                        <th data-align="center">Service Time</th>
                        <th data-align="center">Line Time</th>
                        <th data-align="center">Service Time</th>
                        <th data-align="center">Actual</th>
                    </tr>
                  </thead>
                    <tbody>
                    <tr>
                        <td>
                            
                            <input type="text" ID="txtST1"   class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST2" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST3" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST4" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST5" class="form-control" irequired="1" imask="numeric" runat="server" /></td>


                    </tr>
                    <tr>
                        <td>
                            <input type="text" ID="txtST6" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST7" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST8" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST9" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST10" class="form-control" irequired="1" imask="numeric" runat="server" /></td>

                    </tr>
                    <tr>
                        <td>
                            <input type="text" ID="txtST11" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST12" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST13" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST14" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST15" class="form-control" irequired="1" imask="numeric" runat="server" /></td>

                    </tr>
                    <tr>
                        <td>
                            <input type="text" ID="txtST16" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST17" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST18" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST19" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST20" class="form-control" irequired="1" imask="numeric" runat="server" /></td>

                    </tr>
                    <tr>
                        <td>
                            <input type="text" ID="txtST21" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST22" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST23" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST24" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST25" class="form-control" irequired="1" imask="numeric" runat="server" /></td>

                    </tr>

                    <tr>    
                        <td>
                            <input type="text" ID="txtST26" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST27" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST28" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST29" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST30" class="form-control" irequired="1" imask="numeric" runat="server" /></td>

                    </tr>

                    <tr>
                        <td>
                            <input type="text" ID="txtST31" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST32" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST33" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST34" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST35" class="form-control" irequired="1" imask="numeric" runat="server" /></td>

                    </tr>

                    <tr>
                        <td>
                            <input type="text" ID="txtST36" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST37" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST38" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST39" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST40" class="form-control" irequired="1" imask="numeric" runat="server" /></td>

                    </tr>


                    <tr>
                        <td>
                            <input type="text" ID="txtST41" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST42" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST43" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST44" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST45" class="form-control" irequired="1" imask="numeric" runat="server" /></td>

                    </tr>

                    <tr>
                        <td>
                            <input type="text" ID="txtST46" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST47" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST48" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST49" class="form-control" irequired="1" imask="numeric" runat="server" /></td>
                        <td>
                            <input type="text" ID="txtST50" class="form-control" irequired="1" imask="numeric" runat="server" /></td>

                    </tr>
                   
                    <tr>
                        <td>
                            <label>Drive Thru Line Avg</label>
                            <input type="text" ID="txtST51" class="form-control" runat="server">
                        </td>
                        <td>
                            <label>Drive Thru Service Avg</label>
                            <input type="text" ID="txtST52" class="form-control" runat="server" /></td>
                        <td>
                            <label>Front Counter Line Avg</label>
                            <input type="text" ID="txtST53" class="form-control" runat="server" /></td>
                        <td>
                            <label>Front Counter Service Avg</label>
                            <input type="text" ID="txtST54" class="form-control" runat="server" /></td>
                        <td>
                            <label>KVS Actual Avg</label>
                            <input type="text" ID="txtST55" class="form-control" runat="server" /></td>
                    </tr>
                   </tbody>
                </table>--%>

                <div class="clearfix"></div>

                <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" CssClass="btn btn-inverse waves-effect waves-light" />
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" OnClientClick="return validate();" CssClass="btn btn-inverse waves-effect waves-light pull-right" />
                
                <div class="clearfix"></div>
            
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="cntServiceTimeFoot" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

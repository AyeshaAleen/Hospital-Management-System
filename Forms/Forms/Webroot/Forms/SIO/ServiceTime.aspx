<%@ Page Title="Service Time" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="ServiceTime.aspx.cs" Inherits="Forms.Webroot.Forms.SIO.ServiceTime" %>

<asp:Content ID="cntServiceTimeHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntServiceTimeBody" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Service Time</b></h4>

                <div id="iErrorPanel"></div>

                <table data-toggle="table">
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
                            <asp:TextBox ID="txtST1" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST2" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST3" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST4" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST5" class="form-control" irequired="1" imask="numeric" runat="server" ></asp:TextBox></td>


                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtST6" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST7" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST8" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST9" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST10" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>

                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtST11" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST12" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST13" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST14" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST15" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>

                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtST16" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST17" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST18" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST19" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST20" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>

                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtST21" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST22" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST23" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST24" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST25" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>

                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox ID="txtST26" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST27" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST28" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST29" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST30" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>

                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox ID="txtST31" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST32" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST33" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST34" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST35" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>

                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox ID="txtST36" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST37" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST38" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST39" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST40" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>

                    </tr>


                    <tr>
                        <td>
                            <asp:TextBox ID="txtST41" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST42" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST43" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST44" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST45" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>

                    </tr>

                    <tr>
                        <td>
                            <asp:TextBox ID="txtST46" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST47" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST48" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST49" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtST50" class="form-control" irequired="1" imask="numeric" runat="server"></asp:TextBox></td>

                    </tr>
                   
                    <tr>
                        <td>
                            <label>Drive Thru Line Avg</label>
                            <asp:TextBox ID="txtST51" class="form-control" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <label>Drive Thru Service Avg</label>
                            <asp:TextBox ID="txtST52" class="form-control" runat="server"></asp:TextBox></td>
                        <td>
                            <label>Front Counter Line Avg</label>
                            <asp:TextBox ID="txtST53" class="form-control" runat="server"></asp:TextBox></td>
                        <td>
                            <label>Front Counter Service Avg</label>
                            <asp:TextBox ID="txtST54" class="form-control" runat="server"></asp:TextBox></td>
                        <td>
                            <label>KVS Actual Avg</label>
                            <asp:TextBox ID="txtST55" class="form-control" runat="server"></asp:TextBox></td>
                    </tr>
</tbody>
                </table>

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

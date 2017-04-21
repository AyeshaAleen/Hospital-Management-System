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
                            <td><asp:TextBox runat="server" CssClass="form-control"></asp:TextBox></td>
                            <td><asp:RadioButton GroupName="13" runat="server" /></td>
                            <td><asp:RadioButton GroupName="13" runat="server" /></td>
                            <td><asp:RadioButton GroupName="13" runat="server" /></td>
                            <td>5</td>
                        </tr>

                        <tr>
                            <td>Front Counter Service</td>
                            <td><asp:TextBox runat="server" CssClass="form-control"></asp:TextBox></td>
                            <td><asp:RadioButton GroupName="14" runat="server" /></td>
                            <td><asp:RadioButton GroupName="14" runat="server" /></td>
                            <td><asp:RadioButton GroupName="14" runat="server" /></td>
                            <td>5</td>
                        </tr>
                        <tr>
                            <td>Drive-Thru Line</td>
                            <td><asp:TextBox runat="server" CssClass="form-control"></asp:TextBox></td>
                            <td><asp:RadioButton GroupName="15" runat="server" /></td>
                            <td><asp:RadioButton GroupName="15" runat="server" /></td>
                            <td><asp:RadioButton GroupName="15" runat="server" /></td>
                            <td>5</td>
                        </tr>
                        <tr>
                            <td>Drive-Thru Service</td>
                            <td><asp:TextBox runat="server" CssClass="form-control"></asp:TextBox></td>
                            <td><asp:RadioButton GroupName="16" runat="server" /></td>
                            <td><asp:RadioButton GroupName="16" runat="server" /></td>
                            <td><asp:RadioButton GroupName="16" runat="server" /></td>
                            <td>5</td>
                        </tr>

                        <tr>
                            <td>KVS</td>
                            <td><asp:TextBox runat="server" CssClass="form-control"></asp:TextBox></td>
                            <td><asp:RadioButton GroupName="17" runat="server" /></td>
                            <td><asp:RadioButton GroupName="17" runat="server" /></td>
                            <td><asp:RadioButton GroupName="17" runat="server" /></td>
                            <td>10</td>
                        </tr>
                        
                        <tr>
                            <td colspan="2">
                                Ask, Ask, Tell and "I see 3" 
                            </td>

                            <td>
                                <asp:RadioButton GroupName="75" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="75" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="75" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                Order accurately filled; condiments, napkins receipt, etc.  
                            </td>

                            <td>
                                <asp:RadioButton GroupName="30" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="30" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="30" runat="server" /></td>

                            <td>10</td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                Nice Hospitality - Hospitality- Smiles, courteous, helpful, friendly, eye contact
                            </td>

                            <td>
                                <asp:RadioButton GroupName="31" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="31" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="31" runat="server" /></td>

                            <td>10</td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                Management Appearance- proper uniform, complete with name tag, clean/well groomed
                            </td>

                            <td>
                                <asp:RadioButton GroupName="32" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="32" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="32" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                Crew Appearance- proper uniform, complete with name tag, clean/well groomed 
                            </td>

                            <td>
                                <asp:RadioButton GroupName="33" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="33" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="33" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                DT & Counter Equipment- operating and positioned properly, enough headsets, etc 
                            </td>

                            <td>
                                <asp:RadioButton GroupName="34" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="34" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="34" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                Order taker suggestive sells when appropriate 
                            </td>

                            <td>
                                <asp:RadioButton GroupName="35" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="35" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="35" runat="server" /></td>

                            <td>5</td>
                        </tr>



                        <tr>
                            <td colspan="2">
                                Travel paths completed.
                            </td>

                            <td>
                                <asp:RadioButton GroupName="36" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="36" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="36" runat="server" /></td>


                            <td>5</td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                Table Service is being executed at 100%
                            </td>

                            <td>
                                <asp:RadioButton GroupName="101" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="101" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="101" runat="server" /></td>
                            <td>10</td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                VOICE survey is communicated to every quest
                            </td>

                            <td>
                                <asp:RadioButton GroupName="102" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="102" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="102" runat="server" /></td>
                            <td>10</td>
                        </tr>



                        <tr>
                            <td colspan="2">
                                <strong>Service - Total</strong>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtST" class="form-control" runat="server"></asp:TextBox></td>
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

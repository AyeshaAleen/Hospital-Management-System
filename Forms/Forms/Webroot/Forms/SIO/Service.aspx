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
                            <th data-align="center">Yes</th>
                            <th data-align="center">No</th>
                            <th data-align="center">N/a</th>
                            <th data-align="center">Pts</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>

                                <strong>Times within standards:</strong>
                                <br>

                                <div class="spl">
                                    <table class="table table-responsive">
                                        <tr>
                                            <td style="border: 0; width: 50%; padding: 0">Front Counter Line 
                                            </td>
                                            <td style="border: 0; width: 50%; padding: 0">
                                                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: 0; padding: 0">Front Counter Service  
                                            </td>
                                            <td style="border: 0; padding: 0">
                                                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: 0; padding: 0">Drive-Thru Line  
                                            </td>
                                            <td style="border: 0; padding: 0">
                                                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="border: 0; padding: 0">Drive-Thru Service  
                                            </td>
                                            <td style="border: 0; padding: 0">
                                                <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: 0; padding: 0">KVS  
                                            </td>
                                            <td style="border: 0; padding: 0">
                                                <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>

                                </div>

                            </td>


                            <td style="line-height: 1.95">
                                <br />
                                <asp:RadioButton GroupName="13" runat="server" /><br />
                                <asp:RadioButton GroupName="14" runat="server" /><br />
                                <asp:RadioButton GroupName="15" runat="server" /><br />
                                <asp:RadioButton GroupName="16" runat="server" /><br />
                                <asp:RadioButton GroupName="17" runat="server" />

                            </td>
                            <td style="line-height: 1.95">
                                <br />

                                <asp:RadioButton GroupName="13" runat="server" /><br />
                                <asp:RadioButton GroupName="14" runat="server" /><br />
                                <asp:RadioButton GroupName="15" runat="server" /><br />
                                <asp:RadioButton GroupName="16" runat="server" /><br />
                                <asp:RadioButton GroupName="17" runat="server" />
                            </td>

                            <td style="line-height: 1.95">
                                <br />

                                <asp:RadioButton GroupName="13" runat="server" /><br />
                                <asp:RadioButton GroupName="14" runat="server" /><br />
                                <asp:RadioButton GroupName="15" runat="server" /><br />
                                <asp:RadioButton GroupName="16" runat="server" /><br />
                                <asp:RadioButton GroupName="17" runat="server" />
                            </td>

                            <td>
                                <br>
                                <p style="line-height: 1.95">
                                    5<br>
                                    5<br>
                                    5<br>
                                    5<br>
                                    10
                                
                            </td>
                        </tr>

                        <tr>
                            <td>
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
                            <td>
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
                            <td>
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
                            <td>
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
                            <td>
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
                            <td>
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
                            <td>
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
                            <td>
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
                            <td>
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
                            <td>
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
                            <td>
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

<%@ Page Title="General SIO" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="GeneralSIO.aspx.cs" Inherits="Forms.Webroot.Forms.SIO.GeneralSIO" %>

<asp:Content ID="cntGeneralSIOHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>

<asp:Content ID="cntGeneralSIOBody" ContentPlaceHolderID="FormMasterBody" runat="server">

    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>General SIO</b></h4>
              
                <table data-toggle="table">
                    <thead>
                        <tr>
                            <th>General SIO</th>
                            <th data-align="center">Yes</th>
                            <th data-align="center">No</th>
                            <th data-align="center">N/a</th>
                            <th data-align="center">Pts</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                Pre-shift/Maintenance checklist complete
                            </td>
                            <td>
                                <asp:RadioButton GroupName="1" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="1" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="1" runat="server" /></td>
                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                Staffing – hours +/- appropriate for volume
                            </td>
                            <td>
                                <asp:RadioButton GroupName="2" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="2" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="2" runat="server" /></td>
                            <td>10</td>
                        </tr>

                       <tr>
                            <td>
                                Crew positioned to meet customer demands
                            </td>
                            <td>
                                <asp:RadioButton GroupName="3" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="3" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="3" runat="server" /></td>
                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                Second side open / Split function (when needed)
                            </td>
                            <td>
                                <asp:RadioButton GroupName="4" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="4" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="4" runat="server" /></td>
                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                Proactively Manages Danger Zones
                            </td>
                            <td>
                                <asp:RadioButton GroupName="5" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="5" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="5" runat="server" /></td>
                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                Stocking 24/2 (SIP) 
                            </td>
                           
                            <td>
                                <asp:RadioButton GroupName="6" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="6" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="6" runat="server" /></td>
                            
                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                Manager sets targets, everyone knows targets
                            </td>
                            <td>
                                <asp:RadioButton GroupName="7" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="7" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="7" runat="server" /></td>
                             <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                Targets, results, and secondary duties are tracked
                            </td>
                            <td>
                                <asp:RadioButton GroupName="8" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="8" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="8" runat="server" /></td>
                            
                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                Manager managing from the Observation Zone
                            </td>
                            <td>
                                <asp:RadioButton GroupName="9" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="9" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="9" runat="server" /></td>
                            
                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                Cars are pulled forward immediately if the order is not ready
                            </td>
                           
                            <td>
                                <asp:RadioButton GroupName="10" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="10" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="10" runat="server" /></td>
                            
                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                Hand washing is taking place 
                            </td>
                            
                            <td>
                                <asp:RadioButton GroupName="11" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="11" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="11" runat="server" /></td>
                           
                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                Food Safety Daily Checklist Complete
                            </td>
                          
                            <td>
                                <asp:RadioButton GroupName="12" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="12" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="12" runat="server" /></td>
                            
                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                Shift Manager Food Safety Certified
                            </td>
                            
                            <td>
                                <asp:RadioButton GroupName="13" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="13" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="13" runat="server" /></td>
                            
                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <strong>SIO General - Total</strong>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtSIOTotal" class="form-control" runat="server"></asp:TextBox></td>
                           <td><span class="form-control">100</span></td>
                        </tr>
                    </tbody>
                </table>
                   
                  <div class="clearfix"></div>
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click"  CssClass="btn btn-inverse waves-effect waves-light pull-right"/>
           <div class="clearfix"></div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="cntGeneralSIOFoot" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

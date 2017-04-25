<%@ Page Title="General SIO" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="GeneralSIO.aspx.cs" Inherits="Forms.Webroot.Forms.SIO.GeneralSIO" %>

<asp:Content ID="cntGeneralSIOHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>

<asp:Content ID="cntGeneralSIOBody" ContentPlaceHolderID="FormMasterBody" runat="server"> 

    <div class="row" id="validate">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b><% Response.Write(trasnlation("General.SIO")); %></b></h4>
              
                <table data-toggle="table">
                    <thead>
                        <tr>
                            <th><% Response.Write(trasnlation("General.SIO")); %></th>
                            <th data-align="center"><% Response.Write(trasnlation("Yes")); %></th>
                            <th data-align="center"><% Response.Write(trasnlation("No")); %></th>
                            <th data-align="center"><% Response.Write(trasnlation("N/a")); %></th>
                            <th data-align="center"><% Response.Write(trasnlation("Pts")); %></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <% Response.Write(trasnlation("Preshift.Maintenance.checklist.complete")); %>
                            </td>
                            <td>
                                <asp:RadioButton GroupName="1" ID="buttonGroup_Checklist" runat="server" irequired="1" imask="" /></td>
                            <td>
                                <asp:RadioButton GroupName="1" runat="server" irequired="1" imask="" /></td>
                            <td>
                                <asp:RadioButton GroupName="1" runat="server" irequired="1" imask="" /></td>
                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                <% Response.Write(trasnlation("Staffing.hours.appropriate.for.volume")); %>
                            </td>
                            <td>
                                <asp:RadioButton GroupName="2" runat="server" irequired ="1" imask=""  /></td>
                            <td>
                                <asp:RadioButton GroupName="2" runat="server" irequired ="1" imask=""  /></td>
                            <td>
                                <asp:RadioButton GroupName="2" runat="server" irequired ="1" imask=""  /></td>
                            <td>10</td>
                        </tr>

                       <tr>
                            <td>
                                <% Response.Write(trasnlation("Crew.positioned.to.meet.customer.demands")); %>
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
                                <% Response.Write(trasnlation("Second.side.open.Split.function")); %>
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
                                <% Response.Write(trasnlation("Proactively.Manages.Danger.Zones")); %>
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
                                <% Response.Write(trasnlation("Stocking.SIP")); %> 
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
                                <% Response.Write(trasnlation("Manager.sets.targets.everyone.knows.targets")); %>
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
                                <% Response.Write(trasnlation("Targets.results.and.secondary.duties.tracked")); %>
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
                                <% Response.Write(trasnlation("Manager.managing.from.the.Observation.Zone")); %>
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
                                <% Response.Write(trasnlation("Cars.are.pulled.forward.immediately")); %>
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
                                <% Response.Write(trasnlation("Hand.washing.is.taking.place")); %> 
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
                                <% Response.Write(trasnlation("Food.Safety.Daily.Checklist.Complete")); %>
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
                                <% Response.Write(trasnlation("Shift.Manager.Food.Safety.Certified")); %>
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
                                <strong><% Response.Write(trasnlation("SIO.General.Total")); %></strong>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtSIOTotal" class="form-control" runat="server"></asp:TextBox></td>
                           <td><span class="form-control">100</span></td>
                        </tr>
                    </tbody>
                </table>
                   
                  <div class="clearfix"></div>
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click"  OnClientClick="return validate();" CssClass="btn btn-inverse waves-effect waves-light pull-right"/>
           <div class="clearfix"></div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="cntGeneralSIOFoot" ContentPlaceHolderID="FormMasterFoot" runat="server">
    
</asp:Content>

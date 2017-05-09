<%@ Page Title="General SIO" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="GeneralSIO.aspx.cs" Inherits="Forms.Webroot.Forms.SIO.GeneralSIO" %>

<asp:Content ID="cntGeneralSIOHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>

<asp:Content ID="cntGeneralSIOBody" ContentPlaceHolderID="FormMasterBody" runat="server"> 

    <div class="row" id="validate" runat="server">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b><% Response.Write(trasnlation("General.SIO")); %></b></h4>
              
                <asp:Table ID="tableDynamic" runat="server" data-toggle="table">
                   
                </asp:Table>


               <%-- <table data-toggle="table">
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
                               
                                <input id="radGSIO1"  type="radio" name="1" runat="server" irequired="1"  /></td>
                            <td>
                                <input id="radGSIO2" type="radio" name="1" runat="server" irequired="1" imask="" /></td>
                            <td>
                                <input id="radGSIO3" type="radio" name="1" runat="server" irequired="1" imask="" /></td>
                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                <% Response.Write(trasnlation("Staffing.hours.appropriate.for.volume")); %>
                            </td>
                            <td>
                                <input id="radGSIO4" type="radio"  name="2" runat="server" irequired ="1" imask=""  /></td>
                            <td>
                                <input id="radGSIO5" type="radio"  name="2" runat="server" irequired ="1" imask=""  /></td>
                            <td>
                                <input id="radGSIO6" type="radio"  name="2" runat="server" irequired ="1" imask=""  /></td>
                            <td>10</td>
                        </tr>

                       <tr>
                            <td>
                                <% Response.Write(trasnlation("Crew.positioned.to.meet.customer.demands")); %>
                            </td>
                            <td>
                                <input id="radGSIO7" type="radio"  name="3" runat="server" /></td>
                            <td>
                                <input id="radGSIO8" type="radio"  name="3" runat="server" /></td>
                            <td>
                                <input id="radGSIO9" type="radio"  name="3" runat="server" /></td>
                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                <% Response.Write(trasnlation("Second.side.open.Split.function")); %>
                            </td>
                            <td>
                                <input id="radGSIO10" type="radio"  name="4" runat="server" /></td>
                            <td>
                                <input id="radGSIO11" type="radio"  name="4" runat="server" /></td>
                            <td>
                                <input id="radGSIO12" type="radio"  name="4" runat="server" /></td>
                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                <% Response.Write(trasnlation("Proactively.Manages.Danger.Zones")); %>
                            </td>
                            <td>
                                <input id="radGSIO13" type="radio"  name="5" runat="server" /></td>
                            <td>
                                <input id="radGSIO14" type="radio"  name="5" runat="server" /></td>
                            <td>
                                <input id="radGSIO15" type="radio"  name="5" runat="server" /></td>
                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                <% Response.Write(trasnlation("Stocking.SIP")); %> 
                            </td>
                           
                            <td>
                                <input id="radGSIO16" type="radio"  name="6" runat="server" /></td>
                            <td>
                                <input id="radGSIO17" type="radio"  name="6" runat="server" /></td>
                            <td>
                                <input id="radGSIO18" type="radio"  name="6" runat="server" /></td>
                            
                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <% Response.Write(trasnlation("Manager.sets.targets.everyone.knows.targets")); %>
                            </td>
                            <td>
                                <input id="radGSIO19" type="radio"  name="7" runat="server" /></td>
                            <td>
                                <input id="radGSIO20" type="radio"  name="7" runat="server" /></td>
                            <td>
                                <input id="radGSIO21" type="radio"  name="7" runat="server" /></td>
                             <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <% Response.Write(trasnlation("Targets.results.and.secondary.duties.tracked")); %>
                            </td>
                            <td>
                                <input id="radGSIO22" type="radio"  name="8" runat="server" /></td>
                            <td>
                                <input id="radGSIO23" type="radio"  name="8" runat="server" /></td>
                            <td>
                                <input id="radGSIO24" type="radio"  name="8" runat="server" /></td>
                            
                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <% Response.Write(trasnlation("Manager.managing.from.the.Observation.Zone")); %>
                            </td>
                            <td>
                                <input id="radGSIO25" type="radio"  name="9" runat="server" /></td>
                            <td>
                                <input id="radGSIO26" type="radio"  name="9" runat="server" /></td>
                            <td>
                                <input id="radGSIO27" type="radio"  name="9" runat="server" /></td>
                            
                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                <% Response.Write(trasnlation("Cars.are.pulled.forward.immediately")); %>
                            </td>
                           
                            <td>
                                <input id="radGSIO28" type="radio"  name="10" runat="server" /></td>
                            <td>
                                <input id="radGSIO29" type="radio"  name="10" runat="server" /></td>
                            <td>
                                <input id="radGSIO30" type="radio"  name="10" runat="server" /></td>
                            
                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <% Response.Write(trasnlation("Hand.washing.is.taking.place")); %> 
                            </td>
                            
                            <td>
                                <input id="radGSIO31" type="radio"  name="11" runat="server" /></td>
                            <td>
                                <input id="radGSIO32" type="radio"  name="11" runat="server" /></td>
                            <td>
                                <input id="radGSIO33" type="radio"  name="11" runat="server" /></td>
                           
                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <% Response.Write(trasnlation("Food.Safety.Daily.Checklist.Complete")); %>
                            </td>
                          
                            <td>
                                <input id="radGSIO34" type="radio"  name="12" runat="server" /></td>
                            <td>
                                <input id="radGSIO35" type="radio"  name="12" runat="server" /></td>
                            <td>
                                <input id="radGSIO36" type="radio"  name="12" runat="server" /></td>
                            
                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                <% Response.Write(trasnlation("Shift.Manager.Food.Safety.Certified")); %>
                            </td>
                            
                            <td>
                                <input id="radGSIO37" type="radio"  name="13" runat="server" /></td>
                            <td>
                                <input id="radGSIO38" type="radio"  name="13" runat="server" /></td>
                            <td>
                                <input id="radGSIO39" type="radio"  name="13" runat="server" /></td>
                            
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
                </table>--%>
                   
                  <div class="clearfix"></div>
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click"   OnClientClick="return validate();" CssClass="btn btn-inverse waves-effect waves-light pull-right"/>
           <div class="clearfix"></div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="cntGeneralSIOFoot" ContentPlaceHolderID="FormMasterFoot" runat="server">
    
</asp:Content>

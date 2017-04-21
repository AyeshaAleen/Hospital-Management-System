<%@ Page Title="Cleanliness" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="Cleanliness.aspx.cs" Inherits="Forms.Webroot.Forms.SIO.Cleanliness" %>

<asp:Content ID="cntBasicInfoHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntBasicInfoBody" ContentPlaceHolderID="FormMasterBody" runat="server">

    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Cleanliness</b></h4>

                <table data-toggle="table">
                    <thead>
                        <tr>
                            <th>Cleanliness</th>
                            <th data-align="center">Yes</th>
                            <th data-align="center">No</th>
                            <th data-align="center">N/a</th>
                            <th data-align="center">Pts</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <p>Guest Conveniences - self serve area - clean, and supplies stocked, high chairs clean, music on </p>
                            </td>

                            <td>
                                <asp:RadioButton GroupName="14" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="14" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="14" runat="server" /></td>

                            <td>15</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Lobby/Dining Room-floors, chairs, tables, lobby trays properly cleaned. </p>
                            </td>

                            <td>
                                <asp:RadioButton GroupName="15" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="15" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="15" runat="server" /></td>

                            <td>15</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Restrooms- Clean, odor free, supplies available, hand dryer working </p>
                            </td>
                            <td>
                                <asp:RadioButton GroupName="16" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="16" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="16" runat="server" /></td>

                            <td>15</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Windows/Doors- All windows/mullions clean (including DT windows) </p>
                            </td>

                            <td>
                                <asp:RadioButton GroupName="17" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="17" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="17" runat="server" /></td>

                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Outside Lighting - all bulbs working, clean & in good repair </p>
                            </td>

                            <td>
                                <asp:RadioButton GroupName="18" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="18" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="18" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Playplace/ Patio- seating, trashcans, floor, play unit, clean & well maintained</p>
                            </td>

                            <td>
                                <asp:RadioButton GroupName="19" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="19" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="19" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Trash Cans/Sidewalks- Clean and in good repair Emptied as needed </p>
                            </td>

                            <td>
                                <asp:RadioButton GroupName="20" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="20" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="20" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Signage/Flags- In good repair, clean and properly displayed, DT menu board and speaker/COD clean and in good condition </p>

                            </td>
                            <td>
                                <asp:RadioButton GroupName="21" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="21" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="21" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Landscape/Parking Lot- Parking lot free of litter, landscaping well maintained </p>
                            </td>

                            <td>
                                <asp:RadioButton GroupName="22" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="22" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="22" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Kitchen- floors, walls, stainless, equipment clean, not cluttered and in good repair </p>
                            </td>

                            <td>
                                <asp:RadioButton GroupName="23" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="23" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="23" runat="server" /></td>

                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Front Counter/OT- floors, walls, stainless equipment clean, not cluttered and in good repair  </p>
                            </td>

                            <td>
                                <asp:RadioButton GroupName="24" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="24" runat="server" /></td>
                            <td>
                                <asp:RadioButton GroupName="24" runat="server" /></td>

                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                <p><strong>Cleanliness - Total</strong></p>
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
<asp:Content ID="cntBasicInfoFoot" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

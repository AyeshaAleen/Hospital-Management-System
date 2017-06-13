<%@ Page Title="Cleanliness" Language="C#" MasterPageFile="~/Webroot/Forms/DocumentMaster.master" AutoEventWireup="true" CodeBehind="Cleanliness.aspx.cs" Inherits="Forms.Webroot.Forms.SIO.Cleanliness" %>

<asp:Content ID="cntBasicInfoHead" ContentPlaceHolderID="DocumnetMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntBasicInfoBody" ContentPlaceHolderID="DocumnetMasterBody" runat="server">

    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Cleanliness</b></h4>


                 <asp:Table ID="tableDynamic" runat="server">
                       
                 </asp:Table>


                <%--<table data-toggle="table">
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
                                <input type="radio" id="radClean1" name="14" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean2" name="14" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean3" name="14" runat="server" /></td>

                            <td>15</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Lobby/Dining Room-floors, chairs, tables, lobby trays properly cleaned. </p>
                            </td>

                            <td>
                                <input type="radio" id="radClean4" name="15" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean5" name="15" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean6" name="15" runat="server" /></td>

                            <td>15</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Restrooms- Clean, odor free, supplies available, hand dryer working </p>
                            </td>
                            <td>
                                <input type="radio" id="radClean7" name="16" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean8" name="16" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean9" name="16" runat="server" /></td>

                            <td>15</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Windows/Doors- All windows/mullions clean (including DT windows) </p>
                            </td>

                            <td>
                                <input type="radio" id="radClean10" name="17" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean11" name="17" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean12" name="17" runat="server" /></td>

                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Outside Lighting - all bulbs working, clean & in good repair </p>
                            </td>

                            <td>
                                <input type="radio" id="radClean13" name="18" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean14" name="18" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean15" name="18" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Playplace/ Patio- seating, trashcans, floor, play unit, clean & well maintained</p>
                            </td>

                            <td>
                                <input type="radio" id="radClean16" name="19" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean17" name="19" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean18" name="19" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Trash Cans/Sidewalks- Clean and in good repair Emptied as needed </p>
                            </td>

                            <td>
                                <input type="radio" id="radClean19" name="20" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean20" name="20" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean21" name="20" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Signage/Flags- In good repair, clean and properly displayed, DT menu board and speaker/COD clean and in good condition </p>

                            </td>
                            <td>
                                <input type="radio" id="radClean22" name="21" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean23" name="21" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean24" name="21" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Landscape/Parking Lot- Parking lot free of litter, landscaping well maintained </p>
                            </td>

                            <td>
                                <input type="radio" id="radClean25" name="22" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean26" name="22" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean27" name="22" runat="server" /></td>

                            <td>5</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Kitchen- floors, walls, stainless, equipment clean, not cluttered and in good repair </p>
                            </td>

                            <td>
                                <input type="radio" id="radClean28" name="23" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean29" name="23" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean30" name="23" runat="server" /></td>

                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                <p>Front Counter/OT- floors, walls, stainless equipment clean, not cluttered and in good repair  </p>
                            </td>

                            <td>
                                <input type="radio" id="radClean31" name="24" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean32" name="24" runat="server" /></td>
                            <td>
                                <input type="radio" id="radClean33" name="24" runat="server" /></td>

                            <td>10</td>
                        </tr>

                        <tr>
                            <td>
                                <p><strong>Cleanliness - Total</strong></p>
                            </td>
                            <td colspan="3">
                                <input type="text" id="txtCleanlinessTotal" class="form-control" runat="server" /></td>
                            <td>
                                <span class="form-control">100</span></td>

                        </tr>
                    </tbody>
                </table>--%>

                <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" CssClass="btn btn-inverse waves-effect waves-light" />
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" CssClass="btn btn-inverse waves-effect waves-light pull-right" />
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="cntBasicInfoFoot" ContentPlaceHolderID="DocumnetMasterFoot" runat="server">
</asp:Content>

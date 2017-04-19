<%@ Page Title="" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="Quality.aspx.cs" Inherits="Forms.Webroot.Forms.SIO.Quality" %>
<asp:Content ID="cntQualityHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntQualityBody" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>General SIO</b></h4>

               
                <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click"  CssClass="btn btn-inverse waves-effect waves-light"/>
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click"  CssClass="btn btn-inverse waves-effect waves-light pull-right"/>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cntQualityFoot" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

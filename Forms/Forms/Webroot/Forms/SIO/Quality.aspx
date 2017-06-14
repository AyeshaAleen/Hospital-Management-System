<%@ Page Title="Quality" Language="C#" MasterPageFile="~/Webroot/Forms/DocumentMaster.master" AutoEventWireup="true" CodeBehind="Quality.aspx.cs" Inherits="Forms.Webroot.Forms.SIO.Quality" %>

<asp:Content ID="cntQualityHead" ContentPlaceHolderID="DocumnetMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntQualityBody" ContentPlaceHolderID="DocumnetMasterBody" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Quality</b></h4>

                <asp:Table ID="tableDynamic" runat="server" data-toggle="table">
                   
                 </asp:Table>

             

                <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" CssClass="btn btn-inverse waves-effect waves-light" />
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" CssClass="btn btn-inverse waves-effect waves-light pull-right" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cntQualityFoot" ContentPlaceHolderID="DocumnetMasterFoot" runat="server">
</asp:Content>

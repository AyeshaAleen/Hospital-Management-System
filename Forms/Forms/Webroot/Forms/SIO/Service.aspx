<%@ Page Title="Service" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="Service.aspx.cs" Inherits="Forms.Webroot.Forms.SIO.Service" %>

<asp:Content ID="cntServiceHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntServiceBody" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Service</b></h4>
          

          <asp:Table ID="tableDynamic" runat="server" data-toggle="table" CssClass="table table-hover" BorderStyle="Dashed" BorderWidth="50">
                   
                    </asp:Table>

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

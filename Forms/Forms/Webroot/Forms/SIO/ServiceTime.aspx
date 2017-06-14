<%@ Page Title="Service Time" Language="C#" MasterPageFile="~/Webroot/Forms/DocumentMaster.master" AutoEventWireup="true" CodeBehind="ServiceTime.aspx.cs" Inherits="Forms.Webroot.Forms.SIO.ServiceTime" %>

<asp:Content ID="cntServiceTimeHead" ContentPlaceHolderID="DocumnetMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntServiceTimeBody" ContentPlaceHolderID="DocumnetMasterBody" runat="server">
    <div class="row" runat="server" id="processDynamicDiv"> 
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Service Time</b></h4>

                <asp:Table ID="tableDynamic" runat="server" data-toggle="table">
                   
                </asp:Table>

             

                <div class="clearfix"></div>

                <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" CssClass="btn btn-inverse waves-effect waves-light" />
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" OnClientClick="return validate();" CssClass="btn btn-inverse waves-effect waves-light pull-right" />
                
                <div class="clearfix"></div>
            
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="cntServiceTimeFoot" ContentPlaceHolderID="DocumnetMasterFoot" runat="server">
</asp:Content>

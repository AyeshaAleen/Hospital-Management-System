<%@ Page Title="Service" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" validateRequest="false" AutoEventWireup="true" 
    CodeBehind="Service.aspx.cs" Inherits="Forms.Webroot.Forms.SIO.Service" %>

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
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" OnClientClick="return IsValid();" CssClass="btn btn-inverse waves-effect waves-light pull-right" />
                <asp:HiddenField ID="Tages" runat="server" Value="" />
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cntServiceFoot" ContentPlaceHolderID="FormMasterFoot" runat="server">
     <script>
        function IsValid() {
            var tble = document.getElementById("CommonMasterBody_FormMasterBody_tableDynamic");
            var Value = GenerateTags(tble);
            document.getElementById("CommonMasterBody_FormMasterBody_Tages").value = Value;

            if (Value == "")
                return false;
            else
                return true;
        }
    </script>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="GeneralSIOTest.aspx.cs" Inherits="Forms.Webroot.Forms.SIOTest.GeneralSIOTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormMasterBody" runat="server">

    <div class="row" runat="server" id="processDynamicDiv">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>General SIO</b></h4>

                <div id="iErrorPanel"></div>


                <div>


                    <asp:Table ID="tableDynamic" runat="server" data-toggle="table" CssClass="table table-hover" BorderStyle="Dashed" BorderWidth="50">
                   
                    </asp:Table>




                  <%--  <table data-toggle="table" runat="server">
                    
                </table>--%>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

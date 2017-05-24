<%@ Page Title="" Language="C#" MasterPageFile="~/Webroot/admin/AdminMaster.master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="Forms.Webroot.admin.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminMasterBody" runat="server">

    <div class="row" id="validate" runat="server">
          
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Forms Manager</b></h4>


                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Document</label>
                        <select class="form-control select2"></select>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Section</label>
                        <select class="form-control select2"></select>
                    </div>
                </div>
                <div class="clearfix"></div>


            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AdminMasterFoot" runat="server">
</asp:Content>

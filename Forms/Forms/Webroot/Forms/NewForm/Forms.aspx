<%@ Page Title="Forms Management" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="Forms.aspx.cs" Inherits="Forms.Webroot.Forms.NewForm.Forms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Forms Management</b></h4>

                <div class="form-group col-md-5">
                    <label class="control-label">Forms</label>
                    <select id="ddlForms" class="selectpicker" data-live-search="true" data-style="btn-white" runat="server"></select>
                </div>
                <div class="form-group col-md-5">
                    <label class="control-label">Store</label>
                    <select id="ddlStore" class="selectpicker" data-live-search="true" data-style="btn-white" runat="server"></select>
                </div>
                <div class="form-group col-md-2">
                    <br />
                    <button id="btnGo" runat="server" class="btn btn-primary waves-effect" onclick=""><span style="font-size:20px">Go</span> &nbsp;<i class="fa fa-arrow-right"></i></button>

                </div>
                <div class="clearfix"></div>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

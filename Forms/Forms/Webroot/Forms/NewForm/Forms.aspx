<%@ Page Title="Forms Management" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="Forms.aspx.cs" Inherits="Forms.Webroot.Forms.NewForm.Forms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormMasterBody" runat="server">

    <div class="row min-height-sp">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b>Forms Management</b></h4>

                <div class="form-group col-md-5">
                    <label class="control-label">Forms</label>
                    <asp:DropDownList ID="ddlForms" class="selectpicker" data-style="btn-white" runat="server" DataTextField="name" DataValueField="xDocumentDefinationID" data-live-search="true"></asp:DropDownList>
                </div>
                <div class="form-group col-md-5">
                    <label class="control-label">Store</label>
                    <asp:DropDownList ID="ddlStore" class="selectpicker" data-style="btn-white" runat="server" DataTextField="name" DataValueField="storeid" data-live-search="true"></asp:DropDownList>
                    <%--<select id="ddlForms" class="selectpicker" data-live-search="true" data-style="btn-white" runat="server" DataTextField="name" DataValueField="xDocumentDefinationID" ></select>--%>
                </div>
                <div class="form-group col-md-2">
                    <br />
                    <button runat="server" id="btnGo" onserverclick="getDocumentDetail" class="btn btn-primary waves-effect">
                        GO <i class='fa fa-arrow-right'></i>
                    </button>

                </div>
                <div class="clearfix"></div>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FormMasterFoot" runat="server">

    
</asp:Content>

﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="AddStore.aspx.cs" Inherits="Forms.Webroot.Store.AddStore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormMasterBody" runat="server">
       <div class="page-content">

        <div class="page-header">
            <h1>
                <%--<% Response.Write(trasnlation("Add.New.Store")); %>--%>
                Add New Store
            </h1>
        </div>
        <!-- /.page-header -->

        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->

                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">Store Name *</label>

                            <div class="col-sm-8">
                                <input type="text" id="txtStoreName" runat="server" required placeholder="Store Name" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">Zip Code *</label>

                            <div class="col-sm-8">
                                <input type="text" id="txtZipCode" runat="server"  placeholder="Zip Code" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">Website *</label>

                            <div class="col-sm-8">
                                <input type="text" id="txtWebSite" runat="server" placeholder="Website" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">Store Link *</label>

                            <div class="col-sm-8">
                                <input type="text" id="txtStoreLink" runat="server" placeholder="Store Link" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label" id="lblComments" runat="server">Comments *</label>

                            <div class="col-sm-8">
                                <input type="text" id="txtComments" runat="server"  placeholder="Comments" class="form-control"  />
                            </div>
                          
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                           <label class="col-sm-4 control-label" id="lblWalmart" runat="server">Walmart *</label>
                            <div class="col-sm-8">
                                <input type="text" id="txtWalmart"  runat="server" placeholder="Walmart" class="form-control"  />
                               
                            </div>

                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label" id="lblFax" runat="server">Fax *</label>
                            <div class="col-sm-8">
                                <input type="text" id="txtFax"  runat="server" placeholder="Fax" class="form-control"  />
                                <%--<asp:DropDownList ID="ddlCountryCode" DataValueField="Code" DataTextField="Text" runat="server" CssClass="chosen-select form-control">
                                </asp:DropDownList>--%>
                            </div>
                        </div>

                         <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label" id="lblStoreNo" runat="server">Store No *</label>
                            <div class="col-sm-8">
                                <input type="text" id="txtStoreNo"  runat="server" placeholder="Store No" class="form-control"  />
                            </div>
                        </div>

                        <div class="form-group col-xs-12">
                            <div class="pull-right text-right">
                                <asp:Button ID="btnAddStore" runat="server" Text="Save" class="btn btn-sm btn-primary" OnClick="btnAddStore_Click" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <!-- PAGE CONTENT ENDS -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>
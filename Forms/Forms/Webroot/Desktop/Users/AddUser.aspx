<%@ Page Title="Add User" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Forms.Webroot.Desktop.Users.AddUser" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="cntAddUserHeader" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntAddUserBody" ContentPlaceHolderID="FormMasterBody" runat="server">

    
  <div class="page-content">

        <div class="page-header">
            <h1>Add New User</h1>
        </div>
        <!-- /.page-header -->

        <div class="row">
            <div class="col-xs-12">
                <!-- PAGE CONTENT BEGINS -->
                <div class="col-md-8 col-md-offset-2">
                <div class="center">
                    <div class="alert alert-success fade in text-center blinking" onchange="hideWaitBox();" visible="false" id="alertSuccess" runat="server">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                        User Created successfully.<strong>Thank You..!</strong>
                    </div>

                    <div class="alert alert-danger fade in text-center blinking" onchange="hideWaitBox();" visible="false" id="alertFailure" runat="server">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    </div>
                </div>
            </div>

                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">First Name*</label>

                            <div class="col-sm-8">
                                <input type="text" id="txtFirstName" runat="server" required placeholder="First Name" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">Last Name*</label>

                            <div class="col-sm-8">
                                <input type="text" id="txtLastName" runat="server" required placeholder="Last Name" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">Username*</label>

                            <div class="col-sm-8">
                                <input type="text" id="txtUserName" runat="server" required placeholder="Username" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">Email*</label>

                            <div class="col-sm-8">
                                <input type="email" id="txtUserEmail" runat="server" required placeholder="example@abc.com" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">Password*</label>

                            <div class="col-sm-8">
                                <input type="password" id="txtPassword" runat="server" required placeholder="at least 6 digits" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">Confirm Password*</label>

                            <div class="col-sm-8">
                                <input type="password" id="txtConfirmPassword" required runat="server" placeholder="******" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">Country Code*</label>

                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlCountryCode" DataValueField="Code" DataTextField="Text" runat="server" CssClass="chosen-select form-control">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">Contact No.*</label>

                            <div class="col-sm-8">
                                <input type="text" id="txtContact" required runat="server" placeholder="(123) 456-7890" class="input-mask-phone form-control" />
                            </div>
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">Role*</label>

                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlUserRole" DataValueField="Code" DataTextField="Text" runat="server" CssClass="chosen-select form-control">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">Language*</label>

                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlLang" DataValueField="Code" DataTextField="Text" runat="server" CssClass="chosen-select form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label">Vendors*</label>

                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlvendor" DataValueField="vendorID" DataTextField="name" runat="server" CssClass="chosen-select form-control">
                                </asp:DropDownList>
                            </div>
                        </div>

                       
                        <div class="form-group col-xs-12">
                            <div class="pull-right text-right">
                                <asp:Button ID="btnAddUser" runat="server" Text="Save" class="btn btn-sm btn-primary" OnClick="btnAddUser_Click" />
                            </div>
                        </div>
                        </div>
                    </div>

                </div>
                <!-- PAGE CONTENT ENDS -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
<asp:Content ID="cntAddUserFooter" ContentPlaceHolderID="FormMasterFoot" runat="server">
</asp:Content>

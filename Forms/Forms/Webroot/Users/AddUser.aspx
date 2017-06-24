<%@ Page Title="Add User" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Forms.Webroot.Users.AddUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="cntAddUserHeader" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntAddUserBody" ContentPlaceHolderID="FormMasterBody" runat="server">

 <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b><% Response.Write(trasnlation("Add.New.User")); %></b></h4>

                <div class="row">
                    <div class="col-xs-12">
                        <div class="form-group col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("First.Name")); %> *</label>

                            <div class="col-sm-8">
                                <input type="text" id="txtFirstName" runat="server" required placeholder="First.Name" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("Last.Name")); %> *</label>

                            <div class="col-sm-8">
                                <input type="text" id="txtLastName" runat="server" required placeholder="Last.Name" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("Username")); %> *</label>

                            <div class="col-sm-8">
                                <input type="text" id="txtUserName" runat="server" required placeholder="Username" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("Email")); %> *</label>

                            <div class="col-sm-8">
                                <input type="email" id="txtUserEmail" runat="server" required placeholder="example@abc.com" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label" id="lblPassword" runat="server"><% Response.Write(trasnlation("Password")); %> *</label>

                            <div class="col-sm-8">
                                <input type="password" id="txtPassword" name="txtPassword" runat="server" required placeholder="at least 6 digits" class="form-control" value="" />
                            </div>
                          
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label" id="lblConfirmPassword" runat="server"><% Response.Write(trasnlation("Confirm.Password")); %> *</label>

                            <div class="col-sm-8">
                                <input type="password" id="txtConfirmPassword" name="txtConfirmPassword" required runat="server" placeholder="******" class="form-control" onblur="checkPassword()" />
                                <span class="col-sm-8" id="PasswordErrormsg" style="color: red; visibility: hidden">! Password Not Match
                                </span>
                            </div>

                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("Country.Code")); %> *</label>

                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlCountryCode" DataValueField="Code" DataTextField="Text" runat="server" CssClass="chosen-select form-control">
                                </asp:DropDownList>
                            </div>
                        </div>

                         <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("Mobile.Carrier")); %> *</label>

                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlCarrier" DataValueField="Code" DataTextField="Text" runat="server" CssClass="chosen-select form-control">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("Contact.No")); %> *</label>

                            <div class="col-sm-8">
                                <input type="text" id="txtContact" required runat="server" placeholder="(1234) 456-7891" class="input-mask-phone form-control" />
                            </div>
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("Role")); %> *</label>

                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlUserRole" DataValueField="Code" DataTextField="Text" runat="server" CssClass="chosen-select form-control">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("Language")); %> *</label>

                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlLang" DataValueField="Code" DataTextField="Text" runat="server" CssClass="chosen-select form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("Vendor")); %> *</label>

                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlvendor" DataValueField="vendorID" DataTextField="name" runat="server" CssClass="chosen-select form-control">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group  col-md-6 col-sm-12">
                            <label class="col-sm-4 control-label"><% Response.Write(trasnlation("Time.Zone")); %> *</label>

                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlTimeZone" DataValueField="Id" DataTextField="StandardName" runat="server" CssClass="chosen-select form-control">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group col-xs-12">
                            <div class="pull-right text-right">
                                <asp:Button ID="btnAddUser" runat="server" Text="Save" class="btn btn-success waves-effect waves-light" OnClick="btnAddUser_Click" />
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
<asp:Content ID="cntAddUserFooter" ContentPlaceHolderID="FormMasterFoot" runat="server">
    <script type="text/javascript">

        function checkPassword() {
            var txtPassword = document.getElementById('CommonMasterBody_DesktopMasterBody_txtPassword').value;
            var txtConfirmPassword = document.getElementById('CommonMasterBody_DesktopMasterBody_txtConfirmPassword').value;

            if ($.trim(txtConfirmPassword) != "") {
                if (txtPassword != txtConfirmPassword) {

                    document.getElementById('CommonMasterBody_DesktopMasterBody_txtConfirmPassword').value = "";
                    document.getElementById("PasswordErrormsg").style.visibility = '';

                    return false;
                }
                else {

                    document.getElementById("PasswordErrormsg").style.visibility = 'hidden';
                }
            }

        }

    </script>

</asp:Content>


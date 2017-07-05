<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Forms.Webroot.Users.ChangePassword" %>


<asp:Content ID="cntChangePasswordHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntChangePasswordBody" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="m-t-0 header-title"><b><% Response.Write(trasnlation("Change.Password")); %></b></h4>


                <div class="col-md-6 col-md-offset-2 col-sm-12">
                    <div id="currentUser" runat="server" visible="true">

                    
                <div class="form-group">
                    <label class="col-sm-5 control-label"><% Response.Write(trasnlation("Current.Password")); %> *</label>

                    <div class="col-sm-7">
                        <input type="password" id="txtcurrentpassword" name="txtPassword" runat="server" required placeholder="at least 6 digits" class="form-control" value="" />
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-5 control-label"><% Response.Write(trasnlation("New.Password")); %> *</label>

                    <div class="col-sm-7">
                        <input type="password" id="txtPassword" runat="server" required placeholder="at least 6 digits" class="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-5 control-label"><% Response.Write(trasnlation("Confirm.New.Password")); %> *</label>

                    <div class="col-sm-7">
                        <input type="password" id="txtConfirmPassword" name="txtConfirmPassword" required runat="server" placeholder="******" class="form-control" onblur="checkPassword()" />
                        <span class="col-sm-8" id="PasswordErrormsg" style="color: red; visibility: hidden"><% Response.Write(trasnlation("Password.Not.Matched")); %> 
                        </span>
                    </div>

                </div>


                <div class="col-md-12">
                    <div class="pull-right text-right">
                        <asp:Button ID="btnChangePassword" runat="server" Text="Change.Password" class="btn btn-success waves-effect waves-light" OnClick="btnChangePassword_Click" />
                    </div>
                </div>

                    </div>


                    <div id="adminUser" runat="server" visible="false">

                        <div class="form-group">
                        <h3><asp:Label ID="password" style="text-decoration:double;" runat="server"></asp:Label></h3>
                </div>

                        <div class="col-md-12">
                        <asp:Button ID="btnGeneratePassword" runat="server" Text="Generate.Password" class="btn btn-info waves-effect waves-light" OnClick="btnGeneratePassword_Click" />
                </div>

                    </div>

</div>
        <div class="clearfix"></div>



            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cntChangePasswordFoot" ContentPlaceHolderID="FormMasterFoot" runat="server">
    <script type="text/javascript">

        function checkPassword() {
            debugger;
            var txtPassword = document.getElementById('CommonMasterBody_FormMasterBody_txtPassword').value;
            var txtConfirmPassword = document.getElementById('CommonMasterBody_FormMasterBody_txtConfirmPassword').value;

            if ($.trim(txtConfirmPassword) != "") {
                if (txtPassword != txtConfirmPassword) {

                    document.getElementById('CommonMasterBody_FormMasterBody_txtConfirmPassword').value = "";
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

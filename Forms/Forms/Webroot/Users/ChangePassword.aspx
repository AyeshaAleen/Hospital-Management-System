<%@ Page Title="" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Forms.Webroot.Users.ChangePassword" %>


<asp:Content ID="cntChangePasswordHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>
<asp:Content ID="cntChangePasswordBody" ContentPlaceHolderID="FormMasterBody" runat="server">
    <div class="page-content">

        <div class="page-header">
            <h1><% Response.Write(trasnlation("Change.Password")); %></h1>
        </div>
        <!-- /.page-header -->

        <%-- <div class="row">
            <div class="col-xs-12">--%>
        <!-- PAGE CONTENT BEGINS -->

        <div class="row">
            <div class="col-xs-12">
                <div class="form-group  col-md-6 col-sm-12">
                    <label class="col-sm-5 control-label"><% Response.Write(trasnlation("Current.Password")); %> *</label>

                    <div class="col-sm-7">
                        <input type="password" id="txtcurrentpassword" name="txtPassword" runat="server" required placeholder="at least 6 digits" class="form-control" value="" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="form-group  col-md-6 col-sm-12">
                    <label class="col-sm-5 control-label"><% Response.Write(trasnlation("New.Password")); %> *</label>

                    <div class="col-sm-7">
                        <input type="password" id="txtPassword" runat="server" required placeholder="at least 6 digits" class="form-control" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="form-group  col-md-6 col-sm-12">
                    <label class="col-sm-5 control-label"><% Response.Write(trasnlation("Confirm.New.Password")); %> *</label>

                    <div class="col-sm-7">
                        <input type="password" id="txtConfirmPassword" name="txtConfirmPassword" required runat="server" placeholder="******" class="form-control" onblur="checkPassword()" />
                        <span class="col-sm-8" id="PasswordErrormsg" style="color: red; visibility: hidden">! Password Not Match
                        </span>
                    </div>

                </div>
                 </div>
        </div>
          <div class="row">
            <div class="col-xs-12">
                 <div class="form-group  col-md-6 col-sm-12">
                    <%--<label class="col-sm-5 control-label"><% Response.Write(trasnlation("Confirm.New.Password")); %> *</label>--%>

                    <div class="col-sm-12">
                         <div class="pull-right text-right">
                         <asp:Button ID="btnChangePassword" runat="server" Text="Change.Password" class="btn btn-sm btn-primary" OnClick="btnChangePassword_Click" />
                    </div>
  </div>
                </div>

               <%-- <div class="form-group col-xs-12">
                    <div class="pull-right text-right">
                        <asp:Button ID="btnChangePassword" runat="server" Text="Change.Password" class="btn btn-sm btn-primary" OnClick="btnChangePassword_Click" />
                    </div>
                </div>--%>
            </div>
         </div>
        <!-- PAGE CONTENT ENDS -->
        <%--  </div>
        <!-- /.row -->
    </div>--%>
</asp:Content>
<asp:Content ID="cntChangePasswordFoot" ContentPlaceHolderID="FormMasterFoot" runat="server">
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
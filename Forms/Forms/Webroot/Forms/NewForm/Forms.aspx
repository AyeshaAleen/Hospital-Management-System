<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forms.aspx.cs" Inherits="Forms.Webroot.Forms.NewForm.Forms" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title></title>
    <!-- Plugins css-->
    <link href="<%= ResolveClientUrl("~/itinsync/resources/plugins/bootstrap-tagsinput/css/bootstrap-tagsinput.css" ) %>" rel="stylesheet" />
    <link href="<%= ResolveClientUrl("~/itinsync/resources/plugins/switchery/css/switchery.min.css" ) %>" rel="stylesheet" />
    <link href="<%= ResolveClientUrl("~/itinsync/resources/plugins/multiselect/css/multi-select.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveClientUrl("~/itinsync/resources/plugins/select2/css/select2.min.css" ) %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveClientUrl("~/itinsync/resources/plugins/bootstrap-select/css/bootstrap-select.min.css" ) %>" rel="stylesheet" />
    <link href="<%= ResolveClientUrl("~/itinsync/resources/plugins/bootstrap-touchspin/css/jquery.bootstrap-touchspin.min.css" ) %>" rel="stylesheet" />

    <link href="<%= ResolveClientUrl("~/itinsync/resources/plugins/bootstrap-table/css/bootstrap-table.min.css" ) %>" rel="stylesheet" />
    <link href="<%= ResolveClientUrl("~/itinsync/resources/plugins/ladda-buttons/css/ladda-themeless.min.css" ) %>" rel="stylesheet" />

    <link href="<%= ResolveClientUrl("~/itinsync/resources/plugins/timepicker/bootstrap-timepicker.min.css" ) %>" rel="stylesheet" />
    <link href="<%= ResolveClientUrl("~/itinsync/resources/plugins/bootstrap-datepicker/css/bootstrap-datepicker.min.css" ) %>" rel="stylesheet" />
    <link href="<%= ResolveClientUrl("~/itinsync/resources/plugins/clockpicker/css/bootstrap-clockpicker.min.css" ) %>" rel="stylesheet" />

    <link href="<%= ResolveClientUrl("~/itinsync/resources/plugins/bootstrap-sweetalert/sweet-alert.css" ) %>" rel="stylesheet" />

    <link href="<%= ResolveClientUrl("~/itinsync/resources/css/bootstrap.min.css" ) %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveClientUrl("~/itinsync/resources/css/core.css" ) %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveClientUrl("~/itinsync/resources/css/components.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveClientUrl("~/itinsync/resources/css/icons.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveClientUrl("~/itinsync/resources/css/pages.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveClientUrl("~/itinsync/resources/css/responsive.css"  ) %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveClientUrl("~/itinsync/resources/css/signature-pad.css"  ) %>" rel="stylesheet" type="text/css" />

    <link href="<%= ResolveClientUrl("~/itinsync/resources/plugins/custombox/css/custombox.css"  ) %>" rel="stylesheet" type="text/css" />

     
    <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js") %>"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js") %>"></script>
        <![endif]-->

    <script src="<%= ResolveClientUrl("~/itinsync/resources/js/modernizr.min.js") %>"></script>

</head>
<body style="background:#fff;">
    <form runat="server" id="form">
    
               <div class="form-group col-md-6">
                        <label class="control-label"><% Response.Write(trasnlation("Forms")); %></label>
                        <asp:DropDownList ID="ddlForms" class="selectpicker" data-style="btn-white" runat="server" DataTextField="name" DataValueField="xDocumentDefinationID" data-live-search="true"></asp:DropDownList>
                    </div>
                    <div class="form-group col-md-6">
                        <label class="control-label"><% Response.Write(trasnlation("Store")); %></label>
                        <asp:DropDownList ID="ddlStore" class="selectpicker" data-style="btn-white" runat="server" DataTextField="name" DataValueField="storeid" data-live-search="true"></asp:DropDownList>
                    </div>
                    <div class="form-group col-md-6">
                        <label class="control-label"><% Response.Write(trasnlation("Date")); %></label>
                        <%--<input type="text" id="txtFormDate" runat="server" />--%>
                        <input type="text" id="txtFormDate" class="form-control datepicker-autoclose" placeholder="mm/dd/yyyy"  runat="server" >
                    </div>
                    <div class="form-group col-md-6">
                    
                        <button runat="server" id="btnGo" onserverclick="getDocumentDetail" class="btn btn-primary waves-effect">
                            GO <i class='fa fa-arrow-right'></i>
                        </button>

                            </div>
                <div class="clearfix"></div>


        </form>
   <script>
        var resizefunc = [];
    </script>

    <script src="<%= ResolveClientUrl("~/itinsync/resources/js/jquery.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/js/bootstrap.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/js/detect.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/js/fastclick.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/js/jquery.slimscroll.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/js/jquery.blockUI.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/js/waves.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/js/wow.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/js/jquery.nicescroll.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/js/jquery.scrollTo.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/js/signature_pad.js") %>"></script>
    <%--<script src="<%= ResolveClientUrl("~/itinsync/resources/js/app.js") %>"></script>--%>

    <!-- Bootstrap Pickers  -->
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/moment/moment.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/bootstrap-colorpicker/js/bootstrap-colorpicker.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/timepicker/bootstrap-timepicker.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/clockpicker/js/bootstrap-clockpicker.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js") %>"></script>

    <!-- Forms  -->
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/bootstrap-tagsinput/js/bootstrap-tagsinput.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/switchery/js/switchery.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/multiselect/js/jquery.multi-select.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/jquery-quicksearch/jquery.quicksearch.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/select2/js/select2.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/bootstrap-select/js/bootstrap-select.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/bootstrap-filestyle/js/bootstrap-filestyle.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/bootstrap-touchspin/js/jquery.bootstrap-touchspin.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/bootstrap-maxlength/bootstrap-maxlength.min.js") %>"></script>

    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/autocomplete/jquery.mockjax.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/autocomplete/jquery.autocomplete.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/autocomplete/countries.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/pages/autocomplete.js") %>"></script>

    <!-- Advance Forms  -->
    <script src="<%= ResolveClientUrl("~/itinsync/resources/pages/jquery.form-advanced.init.js") %>"></script>

    <!-- Bootstrap DataTable  -->
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/bootstrap-table/js/bootstrap-table.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/pages/jquery.bs-table.js") %>"></script>


    <!-- Bootstrap Notification  -->
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/notifyjs/js/notify.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/notifications/notify-metro.js") %>"></script>

    <script src="<%= ResolveClientUrl("~/itinsync/resources/js/jquery.core.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/js/jquery.app.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/js/app.js") %>"></script>

    <script src="<%= ResolveClientUrl("~/itinsync/resources/pages/jquery.form-pickers.init.js") %>"></script>
    <!-- Button Loaders  -->
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/ladda-buttons/js/spin.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/ladda-buttons/js/ladda.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/ladda-buttons/js/ladda.jquery.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/js/custom.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/validate/IValidation.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/calculation/IFormDynamicCalculator.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/dynamic/conditions/IFormDynamicCondition.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/controls/IFormControls.js") %>"></script>
 
    <script src="<%= ResolveClientUrl("~/itinsync/resources/dynamic/table/DynamicTable.js") %>"></script>

    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/bootstrap-sweetalert/sweet-alert.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/pages/jquery.sweet-alert.init.js") %>"></script>


    <!-- Modal-Effect -->
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/custombox/js/custombox.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/itinsync/resources/plugins/custombox/js/legacy.min.js") %>"></script>

</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Section.aspx.cs" Inherits="Forms.Webroot.Forms.section.Section" MasterPageFile="~/Webroot/Forms/DocumentMaster.master" %>

<asp:Content ID="SectionHead" ContentPlaceHolderID="DocumnetMasterHead" runat="server">
</asp:Content>


<asp:Content ID="SectionBody" ContentPlaceHolderID="DocumnetMasterBody" runat="server"> 

    <div class="row" id="validate" runat="server">
        <div class="col-sm-12">
            <div class="card-box">
           
              <h4 class="m-t-0 header-title" id="sectionHeading" runat="server"><b></b></h4>
            
        
                <asp:Table ID="tableDynamic" runat="server" data-toggle="table" CssClass="table table-bordered table-hover">
                   
                </asp:Table>
             
           <div class="clearfix"></div>
                
          </div>
        </div>

         <div id="hiddenFieldDiv" style="display:none" runat="server"></div>
    </div>
     <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" CssClass="btn btn-inverse waves-effect waves-light" />
     <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click"   OnClientClick="return validate();" CssClass="btn btn-inverse waves-effect waves-light pull-right"/>
     
    <div id="hiddenDiv" style="display:none"></div>

    <script>

            
            var id = "forms";
           var isForm = true;

            this.isThisForm = isForm;
            this.formFieldsObjects = new Array();
            this.toplevelId = id;
            this.initted = false;

           

            var theDiv;
            var idDiv = this.toplevelId;
            if (this.isThisForm)
                theDiv = document.forms[idDiv];
            else
                theDiv = document.getElementById(idDiv);

            // Get all the components
            var inputfrwdFields = theDiv.getElementsByTagName('INPUT');

            for (var i = 0; i < inputfrwdFields.length; i++) {
                var inputfrwdObj = inputfrwdFields[i];
               

                var inputrefControl = inputfrwdObj.getAttribute('refcontrol');
                if (!inputrefControl)
                    continue;
                
                inputfrwdObj.value = document.getElementById("CommonMasterBody_DocumnetMasterBody_hidden" + inputrefControl).value;
                
            }

       
    </script>
</asp:Content>


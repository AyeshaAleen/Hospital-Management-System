<%@ Page Title="General SIO" Language="C#" MasterPageFile="~/Webroot/Forms/FormMaster.master" AutoEventWireup="true" CodeBehind="GeneralSIO.aspx.cs" Inherits="Forms.Webroot.Forms.SIO.GeneralSIO" %>

<asp:Content ID="cntGeneralSIOHead" ContentPlaceHolderID="FormMasterHead" runat="server">
</asp:Content>

<asp:Content ID="cntGeneralSIOBody" ContentPlaceHolderID="FormMasterBody" runat="server"> 

    <div class="row" id="validate" runat="server">
        <div class="col-sm-12">
            <div class="card-box">
           
              <h4 class="m-t-0 header-title"><b>General SIO</b></h4>
            
                  <asp:Panel ID="PagePanel" runat="server">
                <asp:Table ID="tableDynamic" runat="server" data-toggle="table">
                   
                </asp:Table>
             
                   </asp:Panel>


              
             
                   
                  <div class="clearfix"></div>
               
                <button onclick="javascript:demoFromHTML();">PDF</button>

           <div class="clearfix"></div>
            </div>
        </div>
    </div>
     <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click"   OnClientClick="return validate();" CssClass="btn btn-inverse waves-effect waves-light pull-right"/>

</asp:Content>

<asp:Content ID="cntGeneralSIOFoot" ContentPlaceHolderID="FormMasterFoot" runat="server">
    <script>
function demoFromHTML() {

    var pdf = new jsPDF('p', 'pt', 'letter');

        alert("hello");
    // source can be HTML-formatted string, or a reference
    // to an actual DOM element from which the text will be scraped.
    source = $('#validate')[0];

    // we support special element handlers. Register them with jQuery-style 
    // ID selector for either ID or node name. ("#iAmID", "div", "span" etc.)
    // There is no support for any other type of selectors 
    // (class, of compound) at this time.
    specialElementHandlers = {
        // element with id of "bypass" - jQuery style selector
        '#bypassme': function (element, renderer) {
            // true = "handled elsewhere, bypass text extraction"
            return true
        }
    };
    margins = {
        top: 80,
        bottom: 60,
        left: 10,
        width: 700
    };
    // all coords and widths are in jsPDF instance's declared units
    // 'inches' in this case
    pdf.fromHTML(
    source, // HTML string or DOM elem ref.
    margins.left, // x coord
    margins.top, { // y coord
        'width': margins.width, // max width of content on PDF
        'elementHandlers': specialElementHandlers
    },

    function (dispose) {
        // dispose: object with X, Y of the last line add to the PDF 
        //          this allow the insertion of new lines after html
        pdf.save('Test.pdf');
    }, margins);
}


    </script>
</asp:Content>

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
               
                

           <div class="clearfix"></div>
            </div>
        </div>
    </div>
     <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click"   OnClientClick="return validate();" CssClass="btn btn-inverse waves-effect waves-light pull-right"/>

    <div id="hiddenDiv" style="display:none"></div>
</asp:Content>
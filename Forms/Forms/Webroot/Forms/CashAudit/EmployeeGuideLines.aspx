﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeGuideLines.aspx.cs" Inherits="Forms.Webroot.Forms.CashAudit.EmployeeGuideLines" MasterPageFile="~/Webroot/Forms/DocumentMaster.master"  %>

<asp:Content ID="cntGeneralSIOHead" ContentPlaceHolderID="DocumnetMasterHead" runat="server">
</asp:Content>

<asp:Content ID="cntGeneralSIOBody" ContentPlaceHolderID="DocumnetMasterBody" runat="server"> 

    <div class="row" id="validate" runat="server">
        <div class="col-sm-12">
            <div class="card-box">
           
              <h4 class="m-t-0 header-title"><b>Employee Guide Lines</b></h4>
            
        
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
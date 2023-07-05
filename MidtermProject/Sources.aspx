<%@ Page 
    Title="Sources" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Sources.aspx.cs" 
    Inherits="MidtermProject.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- div for formatting -->
    <div class="row" style="padding-top: 30px; text-align: center">
        <!-- page title -->
        <p style="font-size: 28pt; margin-bottom: 0px;"><%: Title %></p>
        <hr />

        <!-- link to source for piecewise function used in calculations -->
        <p style="font-size: 18pt;"><b><u>Verifiable Website for Water Usage Rates:</u></b> <a class="site-text-size-md" href="https://tomlinsonpsd.com/rates/rates-new-18/" target="_blank">https://tomlinsonpsd.com/rates/rates-new-18/</a></p>
    </div>
    
</asp:Content>

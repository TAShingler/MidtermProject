<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MidtermProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Input column -->
    <div class="col-md-6" style="height: 100%; padding-right: 50px;">

        <!-- container -->
        <div class="calc-box">

            <!-- container header -->
            <div class="calc-box-header" style="background-color: mediumseagreen;">
                <p class="header-text site-text-size-lg">Water Usage</p>
            </div>

            <!-- container body -->
            <div class="calc-box-body site-text-size-md">

                <!-- First Name row -->
                <div class="row calc-box-body-row">
                    <asp:Label ID="lblFName" runat="server" Text="First Name:"></asp:Label>
                    <asp:TextBox ID="txtBoxFName" runat="server"></asp:TextBox>
                </div>

                <!-- Last Name row -->
                <div class="row calc-box-body-row">
                    <asp:Label ID="lblLName" runat="server" Text="Last Name:"></asp:Label>
                    <asp:TextBox ID="txtBoxLName" runat="server"></asp:TextBox>
                </div>

                <!-- Initial Reading row -->
                <div class="row calc-box-body-row">
                    <asp:Label ID="lblInitRdgBefore" runat="server" Text="Initial Reading:"></asp:Label>
                    <asp:TextBox ID="txtBoxInitRdg" runat="server" Width="150px"></asp:TextBox>
                    <asp:Label ID="lblInitRdgAfter" runat="server" Text="gallons"></asp:Label>
                </div>

                <!-- fFinal Reading row -->
                <div class="row calc-box-body-row">
                    <asp:Label ID="lblFinRdgBefore" runat="server" Text="Final Reading:"></asp:Label>
                    <asp:TextBox ID="txtBoxFinRdg" runat="server" Width="150px"></asp:TextBox>
                    <asp:Label ID="lblFinRdgAfter" runat="server" Text="gallons"></asp:Label>
                </div>

                <!-- Tax Rate row -->
                <div class="row calc-box-body-row">
                    <asp:Label ID="lblTaxBefore" runat="server" Text="Tax rate is"></asp:Label>
                    <asp:TextBox ID="txtBoxTax" runat="server" Width="75px"></asp:TextBox>
                    <asp:Label ID="lblTaxAfter" runat="server" Text="%"></asp:Label>
                </div>

                <!-- line break for formatting -->
                <br />

                <!-- Buttons row -->
                <div class="row calc-box-body-row" style="text-align: center;">
                    <asp:Button ID="btnCalculate" runat="server" Text="Bill Statement" OnClick="btnCalculate_Click" />
                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" Width="175px" />
                </div>
            </div>
        </div>
    </div>

    <!-- Output column -->
    <div class="col-md-6" style="height: 100%; padding-left: 50px;">

        <!-- container -->
        <div class="calc-box">

            <!-- container header -->
            <div class="calc-box-header" style="background-color: royalblue;">
                <p class="header-text site-text-size-lg">Monthly Bill Statement</p>
            </div>

            <!-- container body containing Labels for output to user -->
            <div class="calc-box-body site-text-size-md">
                <p style="margin-bottom: 20px;">
                    <asp:Label ID="lblOutputGreeting" runat="server"></asp:Label>
                </p>
                <p style="margin-bottom: 20px;">
                    <asp:Label ID="lblOutputCalcs" runat="server"></asp:Label>
                </p>
                <asp:Label ID="lblOutputThanks" runat="server"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>

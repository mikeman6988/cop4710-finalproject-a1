<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporting.aspx.cs" Inherits="RescueReceiving.Reporting" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblStartDate" Text="Start Date  " runat="server"></asp:Label>
    <asp:TextBox ID="tbStartdate" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblStopDate" Text="Stop Date  " runat="server"></asp:Label>
    <asp:TextBox ID="tbStopdate" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Button ID="btnReport" runat="server" Text="Run Report" 
                    onclick="btnReport_Click" />
</asp:Content>

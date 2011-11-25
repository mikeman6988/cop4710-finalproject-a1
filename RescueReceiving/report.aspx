<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" 
    CodeBehind="report.aspx.cs" Inherits="RescueReceiving.report" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Table ID="tblReport" runat="server" BorderStyle="Solid" Width="100%" 
        GridLines="Both">
    </asp:Table>
</asp:Content>
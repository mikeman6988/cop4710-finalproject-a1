<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" 
    CodeBehind="report.aspx.cs" Inherits="RescueReceiving.report" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Button ID="btnDelete1" runat="server" Text="Delete" Visible="False" 
        onclick="btnDelete_Click" />
    <asp:Table ID="tblReport" runat="server" BorderStyle="Solid" Width="100%" 
        GridLines="Both">
    </asp:Table>
   <asp:Button ID="btnDelete2" runat="server" Text="Delete" Visible="False" 
        onclick="btnDelete_Click" />
 </asp:Content>
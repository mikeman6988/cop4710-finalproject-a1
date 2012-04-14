<%@ Page Title="Administration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Admin.aspx.cs" Inherits="RescueReceiving.Admin" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    Welcome to the admin page.
    <br />
    <br />
    <table width="25%">
    <tr>
        <th>Users</th>
        <th>Imports</th>
    </tr>
    <tr>
        <td  align="center">
        <asp:Button ID="btnUsers" runat="server" Text="Manage Users" onclick="btnUsers_Click"/>
        </td>    
        <td  align="center">
        <asp:Button ID="btnImport" runat="server" Text="Import" onclick="btnImport_Click" />
        </td>
    </tr>
    </table>    
</asp:Content>

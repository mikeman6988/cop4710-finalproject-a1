<%@ Page Title="Administration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Admin.aspx.cs" Inherits="RescueReceiving.Admin" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    Welcome to the admin page.
    <br />
    <br />
    <table width="100%">
    <tr>
        <th align="center">Users</th>
        <th align="center">Reports</th>
        <th align="center">Imports</th>
    </tr>
    <tr>
        <td align="center">
        <asp:Button ID="btnUsers" runat="server" Text="Manage Users" onclick="btnUsers_Click"/>
        </td>    
        <td align="center">
        <asp:Label ID="lblStartDate" Text="Start Date  " runat="server"></asp:Label>
        <asp:TextBox ID="tbStartdate" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblStopDate" Text="Stop Date  " runat="server"></asp:Label>
        <asp:TextBox ID="tbStopdate" runat="server"></asp:TextBox>
        </td>    
        <td align="center">
        <asp:Button ID="btnImport" runat="server" Text="Import" onclick="btnImport_Click" />
        </td>
    </tr>
    <tr>
        <td></td>
        <td align="center"><asp:Button ID="btnReport" runat="server" Text="Run Report" 
                onclick="btnReport_Click" /></td>
    </tr>
   </table>    
</asp:Content>

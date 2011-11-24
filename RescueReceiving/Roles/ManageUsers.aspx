<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="ManageUsers.aspx.cs" Inherits="RescueReceiving.Administration.ManageUsers" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="tblUsers" runat="server" GridLines="Vertical" 
        HorizontalAlign="Center" Width="100%">
        <asp:TableRow runat="server" BackColor="Black" ForeColor="White" 
            HorizontalAlign="Center">
            <asp:TableCell runat="server">Name</asp:TableCell>
            <asp:TableCell runat="server">Created</asp:TableCell>
            <asp:TableCell runat="server">Last On</asp:TableCell>
            <asp:TableCell runat="server">Administrator</asp:TableCell>
            <asp:TableCell runat="server">Commands</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <asp:Label ID="Label1" runat="server" Text="User Name:"></asp:Label>
    <br />
    <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="E-mail:"></asp:Label>
    <br />
    <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
    <br />
    <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Confirm Password:"></asp:Label>
    <br />
    <asp:TextBox ID="tbConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:CheckBox ID="cbIsAdmin" Text="Is administrator?" runat="server" />
    <br />
    <br />
    <asp:Button ID="btnCreateNewUser" runat="server" Text="Create New User" 
        onclick="btnCreateNewUser_Click" />
</asp:Content>

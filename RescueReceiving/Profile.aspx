<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Profile.aspx.cs" Inherits="RescueReceiving.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" 
        onclick="btnChangePassword_Click" />
</asp:Content>

<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="RescueReceiving._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to Rescue Receiving!
    </h2>
    <p>
    COP 4710/5716 - Data Modeling <br />
    Dr. Behrooz Seyed-Abbassi
    </p>
    <p>Team A1 Sauce</p>
    <asp:BulletedList ID="BulletedList1" runat="server">
        <asp:ListItem>Jorge Lopez</asp:ListItem>
        <asp:ListItem>Robert Polk</asp:ListItem>
        <asp:ListItem>Thomas Furman</asp:ListItem>
        <asp:ListItem>Willie Batista</asp:ListItem>
    </asp:BulletedList>
</asp:Content>

<%@ Page Title="Import Excel Report" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="import.aspx.cs" Inherits="RescueReceiving.import" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
        <asp:FileUpload ID="FileUpload1" runat="server" />
    </p>
    <p>
    <asp:Button ID="btnImport" runat="server" Text="Import" onclick="btnImport_Click" />
    </p>
</asp:Content>
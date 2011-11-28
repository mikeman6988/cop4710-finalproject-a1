<%@ Page Title="Import Excel Report" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="import.aspx.cs" Inherits="RescueReceiving.import" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
        <asp:FileUpload ID="FileUpload1" runat="server" />
    </p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Date" DataFormatString="{0:MM/dd/yy}" 
                HeaderText="Date" />
            <asp:BoundField DataField="Time" HeaderText="Time" />
            <asp:BoundField DataField="Unit" HeaderText="Unit" />
            <asp:BoundField DataField="Age" HeaderText="Age" />
            <asp:BoundField DataField="Sex" HeaderText="Sex" />
            <asp:BoundField DataField="Category" HeaderText="Category" />
            <asp:BoundField DataField="CC/Description" HeaderText="CC/Description" />
            <asp:BoundField DataField="BP" HeaderText="BP" SortExpression="BP" />
            <asp:BoundField DataField="R" HeaderText="P" SortExpression="R" />
            <asp:BoundField DataField="R" HeaderText="R" SortExpression="R" />
            <asp:BoundField DataField="O2 Sat" HeaderText="O2 Sat" 
                SortExpression="02 Sat" />
            <asp:BoundField DataField="BGL#1/#2" HeaderText="BGL#1/#2" 
                SortExpression="BGL#1/#2" />            
            <asp:BoundField DataField="LOC" HeaderText="LOC" SortExpression="LOC" />
            <asp:BoundField DataField="GCS" HeaderText="GCS" SortExpression="GCS" />
            <asp:BoundField DataField="T/A" HeaderText="T/A" SortExpression="T/A" />
            <asp:BoundField DataField="S/A" HeaderText="S/A" SortExpression="S/A" />
            <asp:BoundField DataField="Stemi" HeaderText="Stemi" SortExpression="Stemi" />
            <asp:BoundField DataField="TC/ER/Peds" HeaderText="TC/ER/Peds" 
                SortExpression="TC/ER/Peds" />
            <asp:BoundField DataField="Level 1,2,3,T, Resus" 
                HeaderText="Level 1,2,3,T, Resus" />
            <asp:BoundField DataField="ACS" HeaderText="ACS" SortExpression="ACS" />
            <asp:BoundField DataField="ETA" HeaderText="ETA" SortExpression="ETA" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <p>
    <asp:Button ID="btnView" runat="server" Text="View" onclick="btnView_Click" />
    <asp:Button ID="btnImport" runat="server" Text="Import" onclick="btnImport_Click" 
            Visible="False" />
            <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" 
            Text="Reset" />
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
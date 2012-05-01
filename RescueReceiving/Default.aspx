<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="RescueReceiving._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to Rescue Receiving!
    </h2>
    <table width="100%">
        <tr align="center" valign="top">
            <td>
                <asp:Image ID="Image1" runat="server" 
                    ImageUrl="~/Images/UNF_LOGO_VERT_PMS_BlueSilv.jpg" Height="250px" />
                <p>
                Dr. Behrooz Seyed-Abbassi
                </p>
                <p>
                Jorge Lopez<br />
                Lyn On<br />
                Robert Polk<br />
                Thomas Furman<br />
                Willie Batista
                </p>
            </td>
            <td>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/SHANDS_LOGO.jpg" 
                    Height="250px" />
                <p>
                    Dr. Joseph Sabato, M.D.<br />
                    UF College of Medicine Jacksonville<br />
                    Department of Emergency Medicine<br />
                    Director of Field Operations and Disaster Management<br />
                </p>
                <p>
                    Mr. Ernest K. Parker<br />
                    Shands Hospital<br />
                    Communications Supervisor<br />
                    Trauma One Flight Program
                </p>
            </td>
        </tr>
    </table>
</asp:Content>

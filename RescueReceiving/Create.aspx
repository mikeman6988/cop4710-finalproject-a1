<%@ Page Title="Emergency Call" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" 
    CodeBehind="Create.aspx.cs" Inherits="RescueReceiving.Create" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 395px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div>
        <asp:Label ID="lblEcId" runat="server" Text="" Visible="False"></asp:Label>
        <table width="100%">
            <tr valign="top">
                <td>
                    <asp:Label ID="Label12" runat="server" Text="Date:"></asp:Label>
                    <asp:TextBox ID="tbDate" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label14" runat="server" Text="Time:"></asp:Label>
                    <asp:TextBox ID="tbTime" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label19" runat="server" Text="County:"></asp:Label>
                    <asp:DropDownList ID="ddlCounty" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="OnSelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label43" runat="server" Text="Unit:"></asp:Label>
                    <asp:DropDownList ID="ddlUnit" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label46" runat="server" Text="Created By:"></asp:Label>
&nbsp;
                    <asp:Label ID="lblDispatcher" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        
        <table width="100%">
            <tr valign="top">
                <td width="40%">
                    <table width="100%">
                        <tr valign="top">
                            <td colspan="2">
                                <asp:Label ID="Label1" runat="server" Text="Age:"></asp:Label>
                                <asp:TextBox ID="tbAge" Columns="5" runat="server"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="rbYears" GroupName="age" runat="server" Checked="true" Text="Years" />
                                <asp:RadioButton ID="rbMonths" GroupName="age" runat="server" Text="Months" />
                                <asp:RadioButton ID="rbWeeks" GroupName="age" runat="server" Text="Weeks" />
                            </td>
                        </tr>
                        <tr valign="top">
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Sex:"></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="rbMale" GroupName="sex" runat="server" Text="Male" />
                                <asp:RadioButton ID="rbFemale" GroupName="sex" runat="server" Text="Female" />
                            </td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="A&O X"></asp:Label>
                                <asp:DropDownList ID="ddlAlertOriented" runat="server">
                                    <asp:ListItem Value="-1">N/A</asp:ListItem>
                                    <asp:ListItem Value="4">4</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="0">0</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="cbMultiplePatient" runat="server" Text="MCI" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="60%">
                    <table width="100%">
                        <tr valign="top">
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="B/P:"></asp:Label>
                                <asp:TextBox ID="tbBPS1" Columns="5" runat="server"></asp:TextBox> / 
                                <asp:TextBox ID="tbBPD1" Columns="5" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="Pulse:"></asp:Label>
                                <asp:TextBox ID="tbPulse1" Columns="5" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="Resp:"></asp:Label>
                                <asp:TextBox ID="tbResp1" Columns="5" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label18" runat="server" Text="O2 Sat:"></asp:Label>
                                <asp:TextBox ID="tbO2SAT1" Columns="5" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td>
                                <asp:Label ID="Label39" runat="server" Text="B/P:"></asp:Label>
                                <asp:TextBox ID="tbBPS2" Columns="5" runat="server"></asp:TextBox> / 
                                <asp:TextBox ID="tbBPD2" Columns="5" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label40" runat="server" Text="Pulse:"></asp:Label>
                                <asp:TextBox ID="tbPulse2" Columns="5" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label41" runat="server" Text="Resp:"></asp:Label>
                                <asp:TextBox ID="tbResp2" Columns="5" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label42" runat="server" Text="O2 Sat:"></asp:Label>
                                <asp:TextBox ID="tbO2SAT2" Columns="5" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td>
                                <asp:Label ID="Label24" runat="server" Text="LOC:"></asp:Label>
                                <asp:DropDownList ID="ddlLOC" runat="server">
                                    <asp:ListItem Value="U">Unknown</asp:ListItem>
                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    <asp:ListItem Value="N">No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label15" runat="server" Text="GCS:"></asp:Label>
                                <asp:DropDownList ID="ddlGCS" runat="server">
                                    <asp:ListItem Value="-1">N/A</asp:ListItem>
                                    <asp:ListItem Value="15">15</asp:ListItem>
                                    <asp:ListItem Value="14">14</asp:ListItem>
                                    <asp:ListItem Value="13">13</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                    <asp:ListItem Value="11">11</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="9">9</asp:ListItem>
                                    <asp:ListItem Value="8">8</asp:ListItem>
                                    <asp:ListItem Value="7">7</asp:ListItem>
                                    <asp:ListItem Value="6">6</asp:ListItem>
                                    <asp:ListItem Value="5">5</asp:ListItem>
                                    <asp:ListItem Value="4">4</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label16" runat="server" Text="BGL#1:"></asp:Label>
                                <asp:TextBox ID="tbBGL1" Columns="5" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label17" runat="server" Text="BGL#2:"></asp:Label>
                                <asp:TextBox ID="tbBGL2" Columns="5" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr valign="top">
                <td class="style1">
                    <asp:Label ID="Label44" runat="server" Text="Category:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlCategory" Width="100%" runat="server">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Chief Complaint:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlChiefComplaint" Width="100%" runat="server">
                    </asp:DropDownList>
                    <br />
                </td>
                <td>
                    <asp:Label ID="Label45" runat="server" Text="Additional Complaints:"></asp:Label>
                    <asp:TextBox TextMode="MultiLine" Rows="2" Width="100%" ID="tbChiefComplaint" 
                        runat="server" Height="50px" style="margin-top: 3px"></asp:TextBox>
                </td>
            </tr>
        </table>
        
        <table width="100%">
            <tr valign="top">
                <th colspan="4">
                    <asp:Label ID="Label10" runat="server" Text="Accident Detail"></asp:Label>
                </th>
            </tr>
            <tr valign="top">
                <td>
                    <asp:Label ID="Label23" runat="server" Text="Speed:"></asp:Label>
                    <asp:TextBox ID="tbSpeed" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label21" runat="server" Text="Driver:"></asp:Label>
                    <asp:DropDownList ID="ddlDriver" runat="server">
                        <asp:ListItem Value="-1">N/A</asp:ListItem>
                        <asp:ListItem Value="0">Unrestrained</asp:ListItem>
                        <asp:ListItem Value="1">Restrained</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label22" runat="server" Text="Passenger:"></asp:Label>
                    <asp:DropDownList ID="ddlPassenger" runat="server">
                        <asp:ListItem Value="-1">N/A</asp:ListItem>
                        <asp:ListItem Value="0">Front Unrestrained</asp:ListItem>
                        <asp:ListItem Value="1">Front Restrained</asp:ListItem>
                        <asp:ListItem Value="2">Rear Unrestrained</asp:ListItem>
                        <asp:ListItem Value="3">Rear Restrained</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <asp:CheckBox ID="cbEjected" runat="server" Text="Ejected" />
                </td>
                <td>
                    <asp:CheckBox ID="cbEntrapped" runat="server" Text="Entrapped" />
                </td>
                <td>
                    <asp:CheckBox ID="cbRollover" runat="server" Text="Rollover" />
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <asp:CheckBox ID="cbAirbag" runat="server" Text="Airbag" />
                </td>
                <td>
                    <asp:CheckBox ID="cbPackaged" runat="server" Text="Packaged" />
                </td>
                <td>
                    <asp:CheckBox ID="cbHelmet" runat="server" Text="Helmet" />
                </td>
            </tr>
        </table>

        <table width="100%">
            <tr valign="top">
                <th colspan="3">
                    <asp:Label ID="Label32" runat="server" Text="Medical Detail"></asp:Label>
                </th>
            </tr>
            <tr valign="top">
                <td colspan="3">
                    <asp:TextBox TextMode="MultiLine" Rows="3" Width="100%" ID="tbMedicalDetail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <asp:Label ID="Label33" runat="server" Text="Level:"></asp:Label>
                    <asp:DropDownList ID="ddlLevel" runat="server">
                        <asp:ListItem Value="0">N/A</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="T">T</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label34" runat="server" Text="Destination:"></asp:Label>
                    <asp:DropDownList ID="ddlDestination" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:CheckBox ID="cbCardiacRed" runat="server" Text="Cardiac Red" />
                </td>
            </tr>
        </table>

        <table width="100%">
            <tr valign="top">
                <th colspan="3">
                    <asp:Label ID="Label4" runat="server" Text="Alerts"></asp:Label>
                </th>
            </tr>
            <tr valign="top">
                <td>
                    <asp:CheckBox ID="cbStrokeAlert" runat="server" Text="Stroke Alert" />
                </td>
                <td>
                    <asp:CheckBox ID="cbStemi" runat="server" Text="STEMI" />
                </td>
                <td>
                    <asp:CheckBox ID="cbTraumaAlert" runat="server" Text="Trauma Alert" />
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <asp:CheckBox ID="cbResusitation" runat="server" Text="Resusitation" />
                </td>
                <td>
                    <asp:Label ID="Label26" runat="server" Text="Time Issued by Rescue:"></asp:Label>
                    <asp:TextBox ID="tbTimeIssued" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label25" runat="server" Text="Onset:"></asp:Label>
                    <asp:TextBox ID="tbOnset" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr valign="top">
                <td>
                    &nbsp;</td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <asp:Label ID="Label27" runat="server" Text="History:"></asp:Label>
                    <br />
                    <asp:CheckBoxList ID="cblHistory" runat="server" RepeatColumns="4">
                    </asp:CheckBoxList>
                </td>
                <td>
                    <asp:Label ID="Label28" runat="server" Text="Treatment:"></asp:Label>
                    <br />
                    <asp:CheckBoxList ID="cblTreatment" runat="server" RepeatColumns="3">
                    </asp:CheckBoxList>
                </td>
                <td>
                    <asp:Label ID="Label29" runat="server" Text="Dispatcher:"></asp:Label>
                    <asp:TextBox ID="tbDispatcher" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbNotified" runat="server" Text="Notified" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label31" runat="server" Text="ETA:"></asp:Label>
                    <asp:DropDownList ID="ddlETA" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
      
        </div>
        <br />
        <div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                onclick="btnSubmit_Click" />
    </div>

</asp:Content>
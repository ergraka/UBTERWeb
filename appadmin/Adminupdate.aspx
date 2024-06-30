<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="Adminupdate.aspx.cs" Inherits="Adminupdate" Title="Admin Home" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <div style="width: 95%;">
            <p style="color: #FFFF00; font-size: 18px; background-image: url(../Images/bg.png);">
                UPDATE DETAILS</p>
            <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </ajax:ToolkitScriptManager>
            <table cellspacing="0" style="width: 100%; font-family: Cambria; background: url(../Images/Watermark.jpg);
                color: #000000; background-repeat-x: no-repeat; background-repeat-y: no-repeat;
                background-position: center;">
                <tr>
                    <td align="left" style="width: 100%;">
                        <ajax:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="Tab">
                            <ajax:TabPanel ID="TabPanel1" runat="server" Height="300px" HeaderText="USER PASSWORD">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <table width="100%" style="font-family: Cambria; font-size: 13px">
                                                    <tr>
                                                        <td align="center" colspan="3" style="color: #FFFF00; font-size: 18px; background-image: url(../Images/bg.png);">
                                                            - USER PASSWORD -
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">
                                                            SELECT USER ID:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:DropDownList ID="Drpuserid" ValidationGroup="Reg" Width="450px" AutoPostBack="true"
                                                                runat="server" Font-Names="Cambria" OnSelectedIndexChanged="Drpuserid_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">
                                                            BRANCH PASSWORD:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:TextBox ID="Txtpassword" ValidationGroup="Reg" Width="450px" Font-Names="Cambria"
                                                                placeholder="BRANCH PASSWORD" runat="server" TextMode="SingleLine" MaxLength="12"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2" align="left" valign="middle" style="height: 50px">
                                                            <asp:Button ID="Btnchange" CausesValidation="true" runat="server" CssClass="butn"
                                                                ValidationGroup="Reg" Text="CHANGE" OnClick="Btnchange_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left" valign="middle">
                                                            <asp:Label ID="ltrlMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3">
                                                            <asp:RegularExpressionValidator Display="None" ValidationGroup="Reg" ControlToValidate="txtpassword"
                                                                ID="RE" ValidationExpression="^[\s\S]{8,12}$" runat="server" ErrorMessage="Password must be 8 to 12 characters."></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                                    ID="Requireduserpassword" runat="server" ControlToValidate="txtpassword" Display="None"
                                                                    ErrorMessage="Please Enter Password." SetFocusOnError="True" ValidationGroup="Reg"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Reg"
                                                                DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel2" runat="server" Height="300px" HeaderText="CHANGE STUDENT BRANCH">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel3" runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <table width="100%" style="font-family: Cambria; font-size: 13px">
                                                    <tr>
                                                        <td align="center" colspan="3" style="color: #FFFF00; font-size: 18px; background-image: url(../Images/bg.png);">
                                                            - CHANGE STUDENT BRANCH -
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">
                                                            REGISTRATION/ROLL NUMBER:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:TextBox ID="Txtregno" ValidationGroup="Change" Width="450px" Font-Names="Cambria"
                                                                Font-Size="16px" placeholder="REGISTRATION NUMBER" runat="server" TextMode="SingleLine"
                                                                MaxLength="11"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">
                                                            CURRENT BRANCH:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:DropDownList ID="Drpcrrbranch" ValidationGroup="Change" Width="450px" runat="server"
                                                                Font-Names="Cambria">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">
                                                            NEW BRANCH:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:DropDownList ID="Drpnewbranch" ValidationGroup="Change" Width="450px" runat="server"
                                                                Font-Names="Cambria">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2" align="left" valign="middle" style="height: 50px">
                                                            <asp:Button ID="Btnbrchange" CausesValidation="true" runat="server" CssClass="butn"
                                                                ValidationGroup="Change" OnClick="Btnbrchange_Click" Text="SUBMIT" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left" valign="middle">
                                                            <asp:Label ID="Lblbrchange" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txtregno"
                                                                Display="None" ErrorMessage="Please Enter Registration Number." SetFocusOnError="True"
                                                                ValidationGroup="Change"></asp:RequiredFieldValidator><asp:CompareValidator ID="Cvcrrbranch"
                                                                    runat="server" Display="None" ValidationGroup="Change" ErrorMessage="Please Select Current Branch."
                                                                    ControlToValidate="Drpcrrbranch" ValueToCompare="0" Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator><asp:CompareValidator
                                                                        ID="Cvnewbranch" runat="server" Display="None" ValidationGroup="Change" ErrorMessage="Please Select New Branch."
                                                                        ControlToValidate="Drpnewbranch" ValueToCompare="0" Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator><asp:CompareValidator
                                                                            ID="CompareValidator1" runat="server" Display="None" ValidationGroup="Change"
                                                                            ControlToValidate="Drpcrrbranch" ControlToCompare="Drpnewbranch" Operator="NotEqual"
                                                                            ErrorMessage="Current AND New Branch Should not be same."></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Change"
                                                                DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel3" runat="server" Height="300px" HeaderText="CHANGE STUDENT INSTITUTE">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel4" runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <table width="100%" style="font-family: Cambria; font-size: 13px">
                                                    <tr>
                                                        <td align="center" colspan="3" style="color: #FFFF00; font-size: 18px; background-image: url(../Images/bg.png);">
                                                            - CHANGE STUDENT INSTITUTE -
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">
                                                            REGISTRATION/ROLL NUMBER:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:TextBox ID="Txtregnoins" ValidationGroup="InsChange" Width="450px" Font-Names="Cambria"
                                                                Font-Size="16px" placeholder="REGISTRATION NUMBER" runat="server" TextMode="SingleLine"
                                                                MaxLength="11"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">
                                                            Old Institute Name:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:DropDownList ID="Drpoldins" ValidationGroup="InsChange" Width="450px" runat="server"
                                                                Font-Names="Cambria">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">
                                                            New Institute Name:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:DropDownList ID="Drpnewins" ValidationGroup="InsChange" Width="450px" runat="server"
                                                                Font-Names="Cambria">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2" align="left" valign="middle" style="height: 50px">
                                                            <asp:Button ID="Btninschange" CausesValidation="true" runat="server" CssClass="butn"
                                                                ValidationGroup="InsChange" OnClick="Btninschange_Click" Text="SUBMIT" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left" valign="middle">
                                                            <asp:Label ID="Lblins" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txtregnoins"
                                                                Display="None" ErrorMessage="Please Enter Registration Number." SetFocusOnError="True"
                                                                ValidationGroup="InsChange"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CompareValidator3" runat="server" Display="None" ValidationGroup="InsChange"
                                                                ErrorMessage="Please Select New Institute." ControlToValidate="Drpnewins" ValueToCompare="0"
                                                                Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
                                                            <asp:CompareValidator ID="CompareValidator5" runat="server" Display="None" ValidationGroup="InsChange"
                                                                ControlToValidate="Drpoldins" ControlToCompare="Drpnewins" Operator="NotEqual"
                                                                ErrorMessage="Current AND New Institute Should not be same."></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="InsChange"
                                                                DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                            <ajax:TabPanel ID="TabPanel4" runat="server" Height="300px" HeaderText="CHANGE SEMESTER">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <table width="100%" style="font-family: Cambria; font-size: 13px">
                                                    <tr>
                                                        <td align="center" colspan="3" style="color: #FFFF00; font-size: 18px; background-image: url(../Images/bg.png);">
                                                            - CHANGE STUDENT SEMESTER -
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">
                                                            REGISTRATION/ROLL NUMBER:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:TextBox ID="Txtregsem" ValidationGroup="Semchange" Width="450px" Font-Names="Cambria"
                                                                Font-Size="16px" placeholder="REGISTRATION NUMBER" runat="server" TextMode="SingleLine"
                                                                MaxLength="11"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">
                                                            Old Semester:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:DropDownList ID="Drpoldsem" ValidationGroup="Semchange" Width="450px" runat="server"
                                                                Font-Names="Cambria">
                                                                <asp:ListItem Value="0" Text="-Semester-"></asp:ListItem>
                                                                <asp:ListItem Value="01" Text="1st Semester"></asp:ListItem>
                                                                <asp:ListItem Value="02" Text="2nd Semester"></asp:ListItem>
                                                                <asp:ListItem Value="03" Text="3rd Semester"></asp:ListItem>
                                                                <asp:ListItem Value="04" Text="4th Semester"></asp:ListItem>
                                                                <asp:ListItem Value="05" Text="5th Semester"></asp:ListItem>
                                                                <asp:ListItem Value="06" Text="6th Semester"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="middle" style="font-size: 15px;">
                                                            New Semester:<span style="color: #FF0000">*</span>
                                                        </td>
                                                        <td align="left" valign="middle" colspan="3" style="font-size: 15px;">
                                                            <asp:DropDownList ID="Drpnewsem" ValidationGroup="Semchange" Width="450px" runat="server"
                                                                Font-Names="Cambria">
                                                                <asp:ListItem Value="0" Text="-Semester-"></asp:ListItem>
                                                                <asp:ListItem Value="01" Text="1st Semester"></asp:ListItem>
                                                                <asp:ListItem Value="02" Text="2nd Semester"></asp:ListItem>
                                                                <asp:ListItem Value="03" Text="3rd Semester"></asp:ListItem>
                                                                <asp:ListItem Value="04" Text="4th Semester"></asp:ListItem>
                                                                <asp:ListItem Value="05" Text="5th Semester"></asp:ListItem>
                                                                <asp:ListItem Value="06" Text="6th Semester"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2" align="left" valign="middle" style="height: 50px">
                                                            <asp:Button ID="Btnsem" CausesValidation="true" runat="server" CssClass="butn" ValidationGroup="Semchange"
                                                                OnClick="Btnsemchange_Click" Text="SUBMIT" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left" valign="middle">
                                                            <asp:Label ID="Lblsem" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Txtregsem"
                                                                Display="None" ErrorMessage="Please Enter Registration Number." SetFocusOnError="True"
                                                                ValidationGroup="Semchange"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CompareValidator2" runat="server" Display="None" ValidationGroup="Semchange"
                                                                ErrorMessage="Please Select New Semester." ControlToValidate="Drpnewsem" ValueToCompare="0"
                                                                Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
                                                            <asp:CompareValidator ID="CompareValidator4" runat="server" Display="None" ValidationGroup="Semchange"
                                                                ControlToValidate="Drpoldsem" ControlToCompare="Drpnewsem" Operator="NotEqual"
                                                                ErrorMessage="Current AND New Semester Should not be same."></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:ValidationSummary ID="ValidationSummary4" runat="server" ValidationGroup="Semchange"
                                                                DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                </ContentTemplate>
                            </ajax:TabPanel>
                        </ajax:TabContainer>
                    </td>
                </tr>
            </table>
        </div>
    </center>
</asp:Content>

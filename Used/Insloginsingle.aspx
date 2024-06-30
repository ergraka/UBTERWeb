<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Insloginsingle.aspx.cs" Inherits="Insloginsingle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::ROORKEE ANNUAL/SEMESTER EXAMINATION </title>
    <link href="../Images/favicon.ico" rel="Icon File" />
    <link href="../CSS/HeaderFooter.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Home.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/All.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript">
        window.history.forward();
        function noBack() {
            if (!navigator.onLine) {
                document.body.innerHTML = 'Loading.....';
                window.location = '../Error.aspx';
            }
            window.history.forward();
        }
    </script>
</head>
<body onload="noBack();" oncontextmenu="return false" style="background-color: #F5F5F5;
    color: #000000; font-family: Cambria; font-size: 16px;">
    <form id="form1" runat="server">
    <center>
        <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
        </asp:ScriptManager>
        <table cellpadding="0" cellspacing="0" style="width: 100%;">
            <tr>
                <td align="right" class="linehead" style="background-color: #008000; color: #FFFFFF;
                    width: 400px;">
                    <img alt="Uttarakhand" src="../Images/Logo.jpg" height="100px" />
                </td>
                <td align="center" class="linehead" style="background-color: #008000; color: #FFFFFF;
                    font-family: Agency FB; height: 60px; font-size: 25px;">
                    UTTARAKHAND BOARD OF TECHNICAL EDUCATION , ROORKEE [ HARIDWAR ]
                    <br />
                    <font style="color: #FFFFFF; font-family: Courier New; font-size: 16px;">ANNUAL / SEMESTER
                        EXAMINATION<br />
                        <font style="color: #D2B48C; font-family: Courier New;">( SUMMER / WINTER )</font>
                    </font>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div style="width: 1024px;">
                    <br />
                    <table align="center" cellpadding="2" cellspacing="3" style="width: 600px; border: 1px solid #4169E1;
                        border-radius: 20px;">
                        <tr>
                            <td colspan="3" align="center" class="lineheader" style="background-color: #008000;
                                border-top-left-radius: 20px; width: 1024px; height: 30px; border-top-right-radius: 20px;
                                font-size: 25px; color: #FFFFFF; font-weight: bold;">
                                -- INSTITUTE/BRANCH LOGIN --
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 25px; width: 150px;">
                                Institute Name:
                            </td>
                            <td align="left" valign="top">
                                <asp:DropDownList ID="Drpins" ValidationGroup="Reg" Width="450px" Font-Names="Cambria"
                                    Font-Size="15px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 25px;">
                                User Type:
                            </td>
                            <td align="left" valign="top">
                                <asp:DropDownList ID="Drpusertype" ValidationGroup="Reg" Width="180px" Font-Names="Cambria"
                                    Font-Size="16px" runat="server">
                                    <asp:ListItem Value="0" Text="User Type"></asp:ListItem>
                                    <asp:ListItem Value="I" Text="Institute Login"></asp:ListItem>
                                    <asp:ListItem Value="B" Text="Branch Login"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 25px;">
                                Branch Name:
                            </td>
                            <td align="left" valign="top">
                                <asp:DropDownList ID="Drpbranch" Font-Names="Cambria" Font-Size="15px" ValidationGroup="Reg"
                                    Width="450px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="height: 25px;">
                                Password:
                            </td>
                            <td align="left" valign="bottom">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" AutoComplete="off"
                                    Font-Names="Cambria" Font-Size="15px" Font-Bold="true" ValidationGroup="Reg"
                                    MaxLength="12" Style="border: #7f9db9 1px solid;" ToolTip="Login Password" placeholder="Login Password"></asp:TextBox>
                                <img src="../Images/lock.jpg" alt="Lock" height="10px" width="8px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left" valign="top" style="height: 25px">
                                <span style="color: #FF0000; font-size: 12px">[ Password must be 8 to 12 characters
                                    ]</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left" valign="top" style="height: 25px">
                                <asp:CheckBox ID="CheckBox1" ForeColor="#4169E1" runat="server" Font-Size="13px"
                                    ValidationGroup="Reg" Font-Italic="true" Text="Remember Me on this Computer." />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                                <asp:Button ID="btnLogin" BackColor="#663399" ForeColor="#FFFFFF" runat="server"
                                    ValidationGroup="Reg" CssClass="btn" Text="Login" Font-Bold="True" Font-Size="15px"
                                    Width="90px" OnClick="btnLogin_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left" style="font-style: italic;">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div class="Waiting">
                                            <div class="center">
                                                <img src="../Images/loading.gif" alt="Loading..." />
                                            </div>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
                                <asp:Label ID="LblMessage" Font-Size="12px" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                <asp:CompareValidator ID="CVPDrpins" runat="server" Display="None" ValidationGroup="Reg"
                                    ErrorMessage="Please Select Institute Name !" ControlToValidate="Drpins" ValueToCompare="0"
                                    Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
                                <asp:CompareValidator ID="CVUtype" runat="server" Display="None" ValidationGroup="Reg"
                                    ErrorMessage="Please Select User Type !" ControlToValidate="Drpusertype" ValueToCompare="0"
                                    Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
                                <asp:CompareValidator ID="Cvbranch" runat="server" Display="None" ValidationGroup="Reg"
                                    ErrorMessage="Please Select Branch !" ControlToValidate="Drpbranch" ValueToCompare="0"
                                    Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
                                <asp:RegularExpressionValidator Display="None" ValidationGroup="Reg" ControlToValidate="txtPassword"
                                    ID="RE" ValidationExpression="^[\s\S]{8,12}$" runat="server" ErrorMessage="Password must be 8 to 12 characters."></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="Requireduserpassword" runat="server" ControlToValidate="txtPassword"
                                    Display="None" ErrorMessage="Please Enter Login Password." SetFocusOnError="True"
                                    ValidationGroup="Reg"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Reg"
                                    DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <p>
                        <marquee onmouseover="this.stop();" direction="right" onmouseout="this.start();"><span style="color: #FF0000; font-size:12px;">*Do Not Share Your Login ID and Password to Anyone*</span></marquee>
                    </p>
                    <hr />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="SAN" style="width: 1024px">
            <div class="container">
                <div align="center">
                    Uttarakhand Board of Technical Education | &#169; All Rights Reserved | 2019
                </div>
            </div>
        </div>
    </center>
    </form>
</body>
</html>

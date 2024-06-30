<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Emplogin.aspx.cs" Inherits="Emplogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../CSS/Style.css" type="text/css" rel="Stylesheet" />
    <link href="../Images/favicon.ico" rel="Icon File" />
    <link href="../CSS/HeaderFooter.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Home.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/All.css" type="text/css" rel="Stylesheet" />
    <script src="../Scripts/Common.js" type="text/javascript" language="javascript"></script>
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
<body onload="noBack();" oncontextmenu="return false">
    <form id="form1" runat="server" style="color: #000000;">
    <center>
        <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <div class="Waiting">
                    <div class="center">
                        <img src="../Images/loading.gif" alt="Loading..." />
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div style="width: 95%">
                    <table width="100%" cellpadding="4">
                        <tr class="linehead">
                            <td colspan="2" align="center">
                                <div class="row">
                                    <div class="col-lg-3">
                                        <img alt="Ppr" src="../Images/Logo.jpg" height="100px" />
                                    </div>
                                    <div class="col-lg-8" style="font-family: Agency FB; font-size: 20px;">
                                        <b style="font-family: Agency FB; font-size: 24px; color: #FF0000;">UTTARAKHAND BOARD
                                            OF TECHNICAL EDUCATION , ROORKEE [ HARIDWAR ]
                                            <br />
                                            <font style="color: #FF0000; font-family: Courier New; font-size: 16px;">ANNUAL & SEMESTER
                                                EXAMINATION<br />
                                                <font style="color: #000000; font-family: Courier New;">( SUMMER & WINTER )</font>
                                            </font></b>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <p class="panel-heading" style="background-image: url(../Images/bg.jpg); font-family: Agency FB;
                                    font-size: 25px; color: #FFFFFF;">
                                    <asp:Label ID="Lblcp" runat="server" Text=" -- Examiner Login --"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Registration Number OR Roll Number<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox ID="txtUserName" onkeypress="return numbersonly(event)" runat="server"
                                            CssClass="Fontfill" ValidationGroup="Login" AutoComplete="off" MaxLength="15"
                                            ToolTip="Employee Code" placeholder="Employee Code"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Password<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" AutoComplete="off"
                                            CssClass="Fontfill" ValidationGroup="Login" MaxLength="12" ToolTip="Login Password"
                                            placeholder="Password"></asp:TextBox>
                                        <span style="color: #FF0000; font-size: 12px">[ Password must be 8 to 12 characters
                                            ]</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:CheckBox ID="CheckBox1" ForeColor="#4169E1" runat="server" Font-Size="13px"
                                            Font-Italic="true" Text="Remember Me on this Computer." />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Button ID="btnLogin" runat="server" ValidationGroup="Login" CssClass="btn" Text="Login"
                                            OnClick="btnLogin_Click" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                    </div>
                                    <div class="col-lg-6">
                                        For home&nbsp; <a href="../Default.aspx" class="link" style="color: #0000FF"><strong>
                                            CLICK HERE.</strong></a>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Label ID="LblMessage" Font-Size="12px" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Login"
                                            DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" />
                                        <asp:RequiredFieldValidator ID="Requiredusername" runat="server" ControlToValidate="txtUserName"
                                            Display="None" ErrorMessage="Please Enter Registration Number Or Roll Number."
                                            SetFocusOnError="True" ValidationGroup="Login"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator Display="None" ValidationGroup="Login" ControlToValidate="txtPassword"
                                            ID="RE" ValidationExpression="^[\s\S]{8,12}$" runat="server" ErrorMessage="Password must be 8 to 12 characters."></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="Requireduserpassword" runat="server" ControlToValidate="txtPassword"
                                            Display="None" ErrorMessage="Please Enter Password." SetFocusOnError="True" ValidationGroup="Login"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <p>
                        <marquee onmouseover="this.stop();" direction="right" onmouseout="this.start();"><span style="color: #FF0000; font-size:13px;">* Please Do Not Share Your Registration Number and Password to Anyone *</span></marquee>
                        <marquee onmouseover="this.stop();" direction="left" onmouseout="this.start();"><span style="color: #FF0000; font-size:13px;">* Check Mail in Inbox and also in Spam box *</span></marquee>
                    </p>
                    <div id="SAN">
                        <div class="container">
                            <div align="center">
                                Uttarakhand Board of Technical Education | &#169; All Rights Reserved | <%=DateTime.Now.Year.ToString() %>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    </form>
</body>
</html>

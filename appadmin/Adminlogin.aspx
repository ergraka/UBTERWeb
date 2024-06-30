<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adminlogin.aspx.cs" Inherits="Adminlogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <link href="../CSS/Style.css" type="text/css" rel="Stylesheet" />
    <link href="../Images/favicon.ico" rel="Icon File" />
    <link href="../CSS/HeaderFooter.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Home.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Homeother.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/All.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript">
        window.history.forward();
        function noBack() {
            if (!navigator.onLine) {
                document.body.innerHTML = 'Loading.....';
                window.location = 'Error.aspx';
            }
            window.history.forward();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <div>
           <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" runat="server" EnableHistory="false" ></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                        <ProgressTemplate>
                            <div class="Waiting">
                                <div class="center">
                                    <img src="../Images/loading.gif" alt="Loading..." />
                                </div>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div style="width: 95%">
                        <table width="100%" cellpadding="4">
                            <tr class="linehead">
                                <td colspan="2" align="center">
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <img alt="Ubter" src="../Images/Logo.jpg" height="100px" />
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
                                        <asp:Label ID="Lblcp" runat="server" Text=" -- ADMIN LOGIN --"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            User Name<span style="color: #FF0000">*</span>
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:TextBox ID="txtUserName" ValidationGroup="Login" runat="server" CssClass="Fontfill" AutoComplete="Off"
                                                ToolTip="User Name" placeholder="User Name"></asp:TextBox>
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
                                            <asp:TextBox ID="txtPassword" ValidationGroup="Login" runat="server" CssClass="Fontfillcaptcha" AutoComplete="Off"
                                                TextMode="Password" MaxLength="12" ToolTip="Password" placeholder="Password"></asp:TextBox>
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
                                                Display="None" ErrorMessage="PLEASE ENTER USER NAME." SetFocusOnError="True"
                                                ValidationGroup="Login"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="Requireduserpassword" runat="server" ControlToValidate="txtPassword"
                                                Display="None" ErrorMessage="PLEASE ENTER USER PASSWORD." SetFocusOnError="True"
                                                ValidationGroup="Login"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <div id="SAN">
                            <div align="center">
                                Uttarakhand Board of Technical Education | &#169; All Rights Reserved |
                                <%=DateTime.Now.Year.ToString() %>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </center>
    </form>
</body>
</html>

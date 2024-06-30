<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inslogin.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ROORKEE ANNUAL/SEMESTER EXAMINATION </title>
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
    <form id="form1" runat="server">
        <center>
            <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" runat="server" EnableHistory="false"></asp:ScriptManager>
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
                                    <p class="panel-heading" style="background-image: url(../Images/bg.jpg); font-family: Agency FB; font-size: 25px; color: #FFFFFF;">
                                        <asp:Label ID="Lblcp" runat="server" Text=" -- Institute & Branch Login --"></asp:Label>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Institute Name<span style="color: #FF0000">*</span>
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:DropDownList ID="Drpins" ValidationGroup="Reg" CssClass="Fontfill" AutoPostBack="true"
                                                runat="server" OnSelectedIndexChanged="Drpins_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            User Type<span style="color: #FF0000">*</span>
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:DropDownList ID="Drpusertype" ValidationGroup="Reg" CssClass="Fontfill" AutoPostBack="true"
                                                runat="server" OnSelectedIndexChanged="Drpusertype_SelectedIndexChanged">
                                                <asp:ListItem Value="0" Text="User Type"></asp:ListItem>
                                                <asp:ListItem Value="I" Text="Institute Login"></asp:ListItem>
                                                <asp:ListItem Value="B" Text="Branch Login"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr runat="server" id="TRBRANCH" visible="false">
                                <td>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Branch Name<span style="color: #FF0000">*</span>
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:DropDownList ID="Drpbranch" ValidationGroup="Reg" CssClass="Fontfill" runat="server">
                                            </asp:DropDownList>
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
                                            <asp:TextBox ID="txtPassword" runat="server" onkeypress="return Password(event)" CssClass="Fontfillcaptcha" TextMode="Password"
                                                AutoComplete="off" ValidationGroup="Reg" MaxLength="12" ToolTip="Login Password"
                                                placeholder="Login Password"></asp:TextBox>
                                            <span style="color: #FF0000; font-size: 12px">[ Not Allowed In Password <b style="color: black">&#x27A4;</b> Space,",',~,`,Comma,=
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
                                            For home&nbsp; <a href="../Default.aspx" class="link" style="color: #0000FF"><strong>CLICK HERE.</strong></a>
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
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Reg"
                                                DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" />
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
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <p>
                            <marquee onmouseover="this.stop();" direction="right" onmouseout="this.start();"><span style="color: #FF0000; font-size: 12px;">*Do Not Share Your Login ID and Password to Anyone*</span></marquee>
                        </p>
                        <hr />
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

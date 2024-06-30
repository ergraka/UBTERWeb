<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Insforgetpassword.aspx.cs"
    Inherits="Insforgetpassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forget Password </title>
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
        <div style="width: 95%">
            <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
            </asp:ScriptManager>
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
            </table>
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
                    <div>
                        <br />
                        <table align="center" width="100%">
                            <tr>
                                <td align="center" colspan="2">
                                    <p class="panel-heading" style="background-image: url(../Images/bg.jpg); font-family: Agency FB;
                                        font-size: 25px; color: #FFFFFF;">
                                        <asp:Label ID="Lblcp" runat="server" Text=" -- Institute Get Password --"></asp:Label>
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
                                            <asp:DropDownList ID="Drpins" ValidationGroup="Reg" CssClass="Fontfill" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            Mobile Number<span style="color: #FF0000">*</span>
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:TextBox ID="Txtmono" runat="server" AutoComplete="off" CssClass="Fontfill" onkeypress="return numbersonly(event)"
                                                ValidationGroup="Reg" MaxLength="10" ToolTip="MOBILE NUMBER" placeholder="MOBILE NUMBER"></asp:TextBox>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <br />
                                    <asp:Button ID="btngetpass" BackColor="#663399" ForeColor="#FFFFFF" runat="server"
                                        Font-Names="Cambria" ValidationGroup="Reg" CssClass="butn" Text="GET PASSWORD"
                                        Font-Bold="True" Font-Size="15px" OnClick="btngetpass_Click" />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" valign="middle" style="height: 50px; background-color:Gray;
                                    border-top-left-radius: 20px; border-top-right-radius: 20px;">
                                    <asp:ImageButton ID="ImageButton1" runat="server" Width="30px" Height="30px" Font-Size="16px"
                                        CausesValidation="false" ValidationGroup="Forget" OnClick="Button1_Click" ImageUrl="~/Images/Refresh.png" />
                                    &nbsp;&nbsp;
                                    <asp:Label ID="Label4" ForeColor="#FFFFFF" Style="text-align: center" Font-Size="30px"
                                        runat="server" Height="27px" Width="100px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" style="height: 50px; background-color: #BDB76B; color: #DC143C;
                                    border-bottom-left-radius: 20px; border-bottom-right-radius: 20px;">
                                    Type the above 6th digit characters in the below Text field.
                                    <br />
                                    <br />
                                    <asp:TextBox ID="TextBox13" CssClass="txtbox" MaxLength="6" Font-Size="16px" runat="server"
                                        placeholder="Enter Text" ValidationGroup="Forget" AutoComplete="off" Style="border: #7f9db9 1px solid;
                                        font-family: Cambria; width: 100px"></asp:TextBox>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="font-style: italic;">
                                    For Home &nbsp;
                                    <asp:LinkButton ID="lnkhome" CssClass="link" runat="server" Font-Italic="true" Text="click here"
                                        CausesValidation="false" ValidationGroup="Reg" Font-Size="13px" OnClick="lnkhome_Click"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Label ID="LblMessage" Font-Size="12px" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                    <asp:CompareValidator ID="CVPDrpins" runat="server" Display="None" ValidationGroup="Reg"
                                        ErrorMessage="Please Select Institute Name !" ControlToValidate="Drpins" ValueToCompare="0"
                                        Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
                                    <asp:RegularExpressionValidator Display="None" ValidationGroup="Reg" ControlToValidate="Txtmono"
                                        ID="Remono" ValidationExpression="^[\s\S]{10,10}$" runat="server" ErrorMessage="Invalid mobile number."></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="Requiredmono" runat="server" ControlToValidate="Txtmono"
                                        Display="None" ErrorMessage="Please Enter Mobile Number." SetFocusOnError="True"
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
                        <p>
                            <marquee onmouseover="this.stop();" direction="right" onmouseout="this.start();"><span style="color: #FF0000; font-size:14px;">*Do Not Share Your Login ID and Password to Anyone*</span></marquee>
                        </p>
                        <hr />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="SAN">
                <div class="container">
                    <div align="center">
                        Uttarakhand Board of Technical Education | &#169; All Rights Reserved |
                        <%=System.DateTime.Now.Year %>
                    </div>
                </div>
            </div>
        </div>
    </center>
    </form>
</body>
</html>

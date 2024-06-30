<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Forgot Password</title>
    <link href="../Content/Admin/css/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Admin/css/font-awesome.css" rel="stylesheet" />
    <link href="../Content/Admin/css/style.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <link href="../Images/favicon.ico" rel="Icon File" />
    <link href="../CSS/HeaderFooter.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Home.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/All.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Tab.css" type="text/css" rel="Stylesheet" />
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
<body onload="noBack();" oncontextmenu="return false" style="font-family: Cambria;">
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
    <center>
        <div style="width: 95%">
            <table cellpadding="0" cellspacing="0" style="width: 100%;">
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
            </table>
            <hr />
            <p style="font-family: Agency FB; font-size: 24px; color: #000000; width: 1024px"
                align="left">
                GET YOUR PASSWORD<br />
                <i style="font-size: 16px; font-family: Tahoma;"><b>Note:-</b>Candidate also get his/her
                    password by branch H.O.D.</i>
            </p>
            <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                    <table style="font-family: verdana; font-size: 12px; width: 556px;" border="0">
                        <tr>
                            <td style="font-family: Arial; font-size: 14px; color: #000000; height: 50px" align="center"
                                valign="middle">
                                Enter your Registration or Roll Number to have your Email & Password mailed to you.
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top"> 
                                <asp:TextBox ID="Txtroll" onkeypress="return numbersonly(event)" CssClass="Fontfill" required
                                    runat="server" Font-Size="15px" ValidationGroup="Forget" AutoComplete="off" MaxLength="11"
                                    ToolTip="Registration or Roll Number" Style="border: #7f9db9 1px solid;" placeholder="Registration or Roll Number"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle" style="height: 50px; background-color: #BDB76B;
                                border-top-left-radius: 20px; border-top-right-radius: 20px;">
                                <asp:ImageButton ID="ImageButton1" runat="server" Width="30px" Height="30px" Font-Size="16px"
                                    CausesValidation="false" ValidationGroup="Forget" OnClick="Button1_Click" ImageUrl="~/Images/Refresh.png" />
                                &nbsp;&nbsp;
                                <asp:Label ID="Label4" ForeColor="#FFFFFF" Style="text-align: center" Font-Size="30px"
                                    runat="server" Height="27px" Width="100px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="height: 50px; background-color: #BDB76B; color: #DC143C;
                                border-bottom-left-radius: 20px; border-bottom-right-radius: 20px;">
                                Type the above 6th digit characters in the below Text field.
                                <br />
                                <br />
                                <asp:TextBox ID="TextBox13" CssClass="Fontfillcaptcha" MaxLength="6" runat="server"
                                    placeholder="Enter Text" ValidationGroup="Forget" Font-Size="20px" AutoComplete="off"
                                    Style="border: #7f9db9 1px solid;"></asp:TextBox>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <br />
                                <asp:Label ID="ltrlMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                <asp:Button ID="btnSubmit" Font-Names="Cambria" Font-Bold="true" runat="server" BackColor="#003366"
                                    CssClass="btn" ValidationGroup="Forget" ForeColor="White" OnClick="btnSubmit_Click"
                                    Text="Get Password" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                For Home
                                <asp:LinkButton ID="lnkforgotpassword" CssClass="link" runat="server" Text="Click here"
                                    Style="font-size: 15px; font-family: Lucida Bright;" Font-Size="13px" OnClick="lnkforgotpassword_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                    ValidationGroup="Forget" ShowSummary="False" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <div id="SAN" style="width: 100%">
                <div class="container">
                    <div align="center">
                        Uttarakhand Board of Technical Education | &#169; All Rights Reserved | 2019
                    </div>
                </div>
            </div>
        </div>
    </center>
    </form>
</body>
</html>

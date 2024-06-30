<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Uttarakhand Board of Technical Education</title>
    <link href="Images/favicon.ico" rel="Icon File" />
    <link href="CSS/Style.css" type="text/css" rel="Stylesheet" />
    <link href="CSS/HeaderFooter.css" type="text/css" rel="Stylesheet" />
    <link href="CSS/Home.css" type="text/css" rel="Stylesheet" />
    <link href="CSS/All.css" type="text/css" rel="Stylesheet" />
    <link href="CSS/Tab.css" type="text/css" rel="Stylesheet" />
    <script src='https://kit.fontawesome.com/a076d05399.js' type="text/javascript"></script>
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
<body onload="noBack();" oncontextmenu="return false">
    <form id="form1" runat="server">
        <center>
            <div style="width: 95%">
               <%-- <table width="100%" cellpadding="4" style="background: url(Images/Watermark.jpg); border-collapse: collapse; background-repeat:no-repeat background-repeat-x: no-repeat; background-repeat-y: no-repeat; background-position: center;">--%>
                 <table width="100%" cellpadding="4" style="background: url(Images/Watermark.jpg); border-collapse: collapse; background-repeat:no-repeat; background-position: center;">    
                <tr class="linehead">
                        <td colspan="2" align="center">
                            <div class="row">
                                <div class="col-lg-3">
                                    <img alt="Ppr" src="Images/Logo.jpg" height="100px" />
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
                            <table class="table table-striped table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <th align="center" colspan="2" style="background-image: url(Images/bg.jpg); font-family: Agency FB; font-size: 19px; color: #FFFFFF;">IMPORTANT DATES OF ONLINE APPLICATION
                                        </th>
                                    </tr>
                                </thead>
                                <tr>
                                    <th>Important Work
                                    </th>
                                    <th>Date
                                    </th>
                                </tr>
                                <%=srwork%>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-lg-6">
                                    <p style="font-size: 20px; background-image: url(Images/bg.jpg); border-top-left-radius: 10px; border-top-right-radius: 10px; color: #FFFFFF; font-family: Agency FB;">
                                        &nbsp;&nbsp;PORTAL
                                    </p>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <i class='fas fa-graduation-cap' style='color: #FF0000'></i>
                                            <asp:LinkButton ID="Lnkgov" runat="server" ToolTip="Government Institute Login."
                                                OnClick="Lnkgov_Click">Government Institute Login</asp:LinkButton>
                                        </div>
                                        <div class="col-lg-6">
                                            <i class='fas fa-graduation-cap' style='color: #FF0000'></i>
                                            <asp:LinkButton ID="Lnkpvt" runat="server" ToolTip="Self-Aided Institute Login."
                                                OnClick="Lnkpvt_Click">Self-Aided Institute Login</asp:LinkButton>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <i class='fas fa-user' style='color: #FF0000'></i><a href="Student/Login.aspx" title="Student Login.">Student Login</a>
                                        </div>
                                        <div class="col-lg-6">
                                            <i class='fas fa-lock' style='color: #FF0000'></i><a href="Student/ForgotPassword.aspx"
                                                title="Forget Password ?">&nbsp;Student Forget Password ?</a>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <i class='fas fa-book-open' style='color: #FF0000'></i><a href="Institute/Ins.aspx"
                                                target="_blank" title="Instruction How to apply ?">Instruction How to apply ?</a>
                                        </div>
                                        <div class="col-lg-6">
                                            <i class='fas fa-lock' style='color: #FF0000'></i><a href="Institute/Insforgetpassword.aspx"
                                                target="_blank" title="Institute Forget Password ?">&nbsp;Institute Forget Password
                                            ?</a>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <i class='fas fa-user' style='color: #FF0000'></i><a href="Employee/Emplogin.aspx" title="Examiner Login.">Examiner Login</a>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <p style="font-size: 20px; background-image: url(Images/bg.jpg); border-top-left-radius: 10px; border-top-right-radius: 10px; color: #FFFFFF; font-family: Agency FB;">
                                        &nbsp;&nbsp;ANNOUNCEMENTS
                                    </p>
                                    <div style="height: 200px;">
                                        <marquee direction="up" behavior="alternate" scrollamount="2" onmouseover="this.stop();"
                                            onmouseout="this.start();" style="height: 200px; color: #0000FF">
                                            &#187;&nbsp;<font style="color: #FF0000;">* Kindly visit regularly for latest updates *</font>
                                            <br />
                                            &#187;&nbsp;<font style="color: #FF0000;">* Check Mail in Inbox and in Spam box *</font>
                                            <br />
                                            &#187;&nbsp;<font style="color: #FF0000;">In case of Only technical
                                queries Email us at : <a style="color: #0000FF">helpubterpolytech@gmail.com</a></font>
                                        </marquee>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <div class="row">
                                <div class="col-lg-12">
                                    <hr />
                                    <p align="center" style="font-size: 25px; color: #FF0000; font-family: Agency FB">
                                        Uttarakhand Board of Technical Education<br />
                                        Roorkee [ HARIDWAR ]
                                    </p>
                                    <div align="center" style="font-family: Agency FB; font-weight: bold; font-size: 22px;">
                                        ONLINE USER'S<br />
                                        <b style="color: #000000; font-family: Agency FB; font-size: 28px">
                                            <%=sr %></b>
                                    </div>
                                    <p style="text-align: center; color: #0000FF;">
                                        <br />
                                        |<img src="Images/Chrome.png" height="15px" width="15px" alt="Chrome" />
                                        <a target="_blank" style="color: #0000FF" href="https://support.google.com/chrome/answer/95346?hl=en">Use GOOGLE CHROME for best performance</a>|
                                    <br />
                                    </p>
                                    <div id="SAN">
                                        <div class="container">
                                            <div align="center">
                                                Uttarakhand Board of Technical Education | &#169; All Rights Reserved |
                                            <%=DateTime.Now.Year.ToString() %>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </center>
    </form>
</body>
</html>

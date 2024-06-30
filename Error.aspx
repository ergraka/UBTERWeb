<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error Page</title>
    <link href="Images/favicon.ico" rel="Icon File" />
    <link href="CSS/Style.css" type="text/css" rel="Stylesheet" />
    <script src="Scripts/Common.js" type="text/javascript" language="javascript"></script>
    <link href="CSS/Home.css" type="text/css" rel="Stylesheet" />
    <link href="CSS/All.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <div style="width: 95%">
            <table cellpadding="0" cellspacing="0" style="width: 100%; font-family: Agency FB;">
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
            </table>
            <hr />
            <table border="0" cellspacing="0" cellpadding="0" align="center" width="100%">
                <tr>
                    <td style="color: #800000; font-size: 20px">
                        Page Cannot be Displayed !
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="height: 14px; color: #FF0000">
                        <span style="color: #FF0000">&#x27A4;</span> Maintenance Activity is Scheduled in
                        this period.
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="height: 14px; color: #FF0000">
                        <span style="color: #FF0000">&#x27A4;</span> Check Entered link.
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="height: 14px; color: #FF0000">
                        <span style="color: #FF0000">&#x27A4;</span> You are not authorized to view this
                        page.
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="height: 14px; color: #FF0000">
                        <span style="color: #FF0000">&#x27A4;</span> You do not have valid access to view
                        this page.
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="height: 14px; color: #FF0000">
                        <span style="color: #FF0000">&#x27A4;</span> Server Busy.
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="height: 14px; color: #FF0000">
                        <span style="color: #FF0000">&#x27A4;</span> Update Activity.
                    </td>
                </tr>
                <tr>
                    <td valign="top" style="height: 14px; color: #FF0000">
                        <span style="color: #FF0000">&#x27A4;</span> Operation Time Out.
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <div id="SAN">
                <div class="container">
                    <div align="center">
                        Uttarakhand Board of Technical Education | &#169; All Rights Reserved |
                        <%=DateTime.Now.Year.ToString() %>
                    </div>
                </div>
            </div>
        </div>
    </center>
    </form>
</body>
</html>

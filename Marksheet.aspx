<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Marksheet.aspx.cs" Inherits="Marksheet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Marks Sheet</title>
    <link href="../CSS/Style.css" type="text/css" rel="Stylesheet" />
    <script src="../Scripts/Common.js" type="text/javascript" language="javascript"></script>
    <link rel="Icon" href="../Images/favicon.ico" />
    <link href="../CSS/HeaderFooter.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Home.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Homeother.css" type="text/css" rel="Stylesheet" />
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
    <style type="text/css">
        @media Print
        {
            .noprint
            {
                display: none;
                width: 100%;
            }
            .print
            {
                width: 100%;
            }
        }
    </style>
</head>
<body onload="noBack();" oncontextmenu="return false" style="font-size: 14px; color: #000000;
    background-color: #FFFFFF; margin: 0px">
    <form id="form1" runat="server">
    <center>
        <div style="width: 95%; height: auto; background: url(../Images/Watermark.jpg); font-family: Cambria;
            background-repeat-x: no-repeat; background-repeat-y: no-repeat; background-position: center;">
            <table width="100%" cellpadding="4">
                <tr class="linehead">
                    <td colspan="2" align="center">
                        <div class="row">
                            <div class="col-lg-3">
                                <img alt="Ppr" src="../Images/Logo.jpg" height="100px" />
                            </div>
                            <div class="col-lg-8" style="font-family: Agency FB;  font-size: 20px;">
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
            <table cellpadding="4" cellspacing="0" style="width: 100%;">
                <tr>
                    <th align="left" valign="middle">
                        INSTITUTE NAME&nbsp;:
                    </th>
                    <td colspan="3" align="left" valign="middle">
                        <%=INSTITUTE %>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle">
                        BRANCH NAME&nbsp;:
                    </th>
                    <td colspan="3" align="left" valign="middle">
                        <%=BRANCH %>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle">
                        STUDENT NAME&nbsp;:
                    </th>
                    <td align="left" valign="middle">
                        <%=CNAME %>
                    </td>
                    <th align="left" valign="middle">
                        FATHER NAME&nbsp;:
                    </th>
                    <td align="left" valign="middle">
                        <%=FNAME %>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle">
                        REGISTRATION NUMBER&nbsp;:
                    </th>
                    <td align="left" valign="middle">
                        <%=CANDIDATEID %>
                    </td>
                    <th align="left" valign="middle">
                        ROLL NUMBER&nbsp;:
                    </th>
                    <td align="left" valign="middle">
                        <%=ROLL %>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle">
                        DATE&nbsp;:
                    </th>
                    <td align="left" valign="middle">
                        <%=DATE %>
                    </td>
                    <th align="left" valign="middle">
                        CATEGORY&nbsp;:
                    </th>
                    <td align="left" valign="middle">
                        <%=TYPE %>
                    </td>
                </tr>
            </table>
            <hr />
            <%=STR %><br />
            <%=STRSGPAH %>
            <br />
            <br />
            <table width="100%">
                <tr>
                    <td align="left" valign="middle" style="font-family: Cambria;">
                        <br />
                        <br />
                        <br />
                        <b>( PREPARED BY )</b>
                        <br />
                    </td>
                    <td align="center" valign="bottom" style="height: 50px; font-family: Cambria;">
                        <br />
                        <br />
                        <br />
                        <b>CHECKED BY<br />
                            ( H.O.D )</b>
                        <br />
                    </td>
                    <td align="right" valign="bottom" style="height: 50px; font-family: Cambria;">
                        <br />
                        <br />
                        <br />
                        <b>( PRINCIPAL SIGNATURE )<br />
                            SEAL&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>
                        <br />
                    </td>
                </tr>
            </table>

            <div align="center" style="width: 100%">
                <hr />
            Note:- this is for information purposes only.
                <asp:Label ID="LblMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
            </div>
            <div class="noprint">
                <br />
                <img src="../Images/Print.jpeg" alt="Click here to print Admit Card." id="btnprint"
                    style="height: 30px; width: 25px;" onclick="javascript:alert('Please Print in Portrait format');javascript:window.print();" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            </div>
            <br />
            <br />
            <br />
            <br />
        </div>
    </center>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Listd_Theory.aspx.cs" Inherits="Listd_Theory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MARKS LIST-D(Theory)</title>
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
<body onload="noBack();" oncontextmenu="return false" style="color: #000000">
    <form id="form1" runat="server">
    <center>
        <div style="width: 1024px; font-family: Cambria;">
            <div class="noprint" style="background-color: #20B2AA">
                <br />
                <i style="font-size: 18px; color: #000000;">&raquo;&nbsp;SELECT SUBJECT</i>&nbsp;:<span
                    style="color: #FF0000">*</span>
                <asp:DropDownList ID="Drpsub" ValidationGroup="Reg" Width="400px" Height="30px" Font-Size="16px"
                    Font-Names="Cambria" runat="server">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="Btnview" CssClass="butn" runat="server" Text="View Report" Height="30px"
                    OnClick="Btnview_Click" />
                <br />
                <br />
                <img src="../Images/Print.png" alt="Click here to print Admit Card." id="btnprint"
                    style="height: 30px; width: 25px;" onclick="javascript:alert('Please Print This Report in PORTRAIT FORMAT Only.');javascript:window.print();" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:ImageButton ID="Imghome" ImageUrl="~/Images/Home.png" Height="30px" Width="20px"
                    runat="server" OnClick="Imghome_Click" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:ImageButton ID="Imglogout" ImageUrl="~/Images/Logout.png" Height="30px" Width="20px"
                    runat="server" OnClick="Imglogout_Click" />
                <br />
                <asp:Label ID="LblMessage" Font-Size="15px" ForeColor="#FF0000" runat="server" Text=""></asp:Label></div>
            <br />
            <table cellpadding="1" cellspacing="2" style="width: 1024px;">
                <tr>
                    <td valign="top" align="center" style="width: 50%">
                        <table cellpadding="3" cellspacing="0" style="width: 100%">
                            <tr>
                                <th colspan="5" align="center" style="font-family: Cambria; border-bottom: 1px solid #000000;
                                    border-top: 1px solid #000000; font-size: 17px">
                                    U.B.T.E.R MARKS LIST-D ( THEORY )
                                    <br />
                                     <%=HEADSESS %>
                                </th>
                            </tr>
                            <tr>
                                <th align="left" valign="middle" style="font-size: 18px;">
                                    COUNTER FOIL
                                </th>
                                <th align="left" colspan="4" valign="middle" style="font-size: 18px;">
                                    <asp:Label ID="Lblfoil1" Font-Names="Cambria" runat="server" Text="FOIL NUMBER"></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <th align="left" valign="middle" style="font-size: 15px;">
                                    INSTITUTE NAME&nbsp;:
                                </th>
                                <td align="left" colspan="4" valign="middle" style="font-size: 15px;">
                                    <asp:Label ID="Lblins" Font-Names="Cambria" runat="server" Text="Institute Name"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th align="left" valign="middle" style="font-size: 15px;">
                                    BRANCH NAME&nbsp;:
                                </th>
                                <td align="left" colspan="4" valign="middle" style="font-size: 15px;">
                                    <asp:Label ID="Lblbranch" Font-Names="Cambria" runat="server" Text="Branch Name"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th align="left" valign="middle" style="font-size: 15px;">
                                    SEMESTER&nbsp;/&nbsp;SHIFT:
                                </th>
                                <td align="left" colspan="4" valign="middle" style="font-size: 15px;">
                                    <asp:Label ID="Lblsem" Font-Names="Cambria" runat="server" Text="Semester"></asp:Label>&nbsp;/&nbsp;
                                    <asp:Label ID="Lblshift" Font-Names="Cambria" runat="server" Text="Shift"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th align="left" valign="middle" style="font-size: 15px;">
                                    SUBJECT&nbsp;:
                                </th>
                                <td align="left" colspan="4" valign="middle" style="font-size: 15px;">
                                    <asp:Label ID="Lblsub" Font-Names="Cambria" runat="server" Text="Subject"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th align="left" valign="middle" style="font-size: 15px;">
                                    MARKS&nbsp;:
                                    <br />
                                    <br />
                                </th>
                                <td align="left" colspan="4" valign="middle" style="font-size: 15px;">
                                    (&nbsp;&nbsp;&nbsp;Maximum:&nbsp;<asp:Label ID="Lblmax" Font-Names="Cambria" runat="server"
                                        Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;Minimum:&nbsp;<asp:Label ID="Lblmin"
                                            Font-Names="Cambria" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;)
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <th rowspan="2" align="center" valign="middle" style="border-bottom: 1px solid #000000;
                                    border-top: 1px solid #000000; border-left: 1px solid #000000; border-right: 1px solid #000000;
                                    font-size: 16px; width: 130px;">
                                    ROLL
                                </th>
                                <th rowspan="2" align="center" valign="middle" style="border-bottom: 1px solid #000000;
                                    border-top: 1px solid #000000; border-right: 1px solid #000000; font-size: 16px;">
                                    SUB
                                </th>
                                <th rowspan="2" align="center" valign="middle" style="border-bottom: 1px solid #000000;
                                    border-top: 1px solid #000000; border-right: 1px solid #000000; font-size: 16px;">
                                    BRC
                                </th>
                                <th colspan="2" align="center" valign="middle" style="border-bottom: 1px solid #000000;
                                    border-top: 1px solid #000000; border-right: 1px solid #000000; font-size: 15px;">
                                    TOTAL MARKS
                                </th>
                            </tr>
                            <tr>
                                <th align="center" valign="middle" style="border-bottom: 1px solid #000000; border-right: 1px solid #000000;
                                    font-size: 15px; width: 60px;">
                                    FIG.
                                </th>
                                <th align="left" valign="middle" style="border-bottom: 1px solid #000000; border-right: 1px solid #000000;
                                    font-size: 15px;">
                                    WORDS
                                </th>
                            </tr>
                            <tr>
                                <%=DATA %>
                            </tr>
                            <tr>
                                <td colspan="3" align="left" valign="bottom" style="height: 50px; font-size: 15px;
                                    border-bottom: 1px solid #000000; border-left: 1px solid #000000; font-family: Cambria;">
                                    <br />
                                    <br />
                                    <br />
                                    &nbsp;EXAMINER SIGN:<br />
                                    &nbsp;EXAMINER NAME:
                                    <br />
                                </td>
                                <td style="border-bottom: 1px solid #000000;">
                                </td>
                                <td align="center" valign="bottom" style="height: 50px; font-size: 15px; border-bottom: 1px solid #000000;
                                    border-right: 1px solid #000000; font-family: Cambria;">
                                    <br />
                                    <br />
                                    <br />
                                    ( EVALUATION CENTRE )<br />
                                    SEAL & SIGN
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="center" valign="top" rowspan="10">
                        <img src="../Images/cessor_down.jpg" alt="UBTER" width="20px" /><br />
                        P<br />
                        L<br />
                        E<br />
                        A<br />
                        S<br />
                        E<br />
                        <br />
                        T<br />
                        O<br />
                        R<br />
                        E<br />
                        <br />
                        F<br />
                        R<br />
                        O<br />
                        M<br />
                        <br />
                        U<br />
                        P<br />
                        <br />
                        OR<br />
                        <br />
                        D<br />
                        O<br />
                        W<br />
                        N<br />
                        <img src="../Images/cessor_up.jpg" alt="UBTER" width="20px" />
                    </td>
                    <td valign="top" align="center" style="width: 50%">
                        <table cellpadding="3" cellspacing="0" style="width: 100%">
                            <tr>
                                <th colspan="5" align="center" style="font-family: Cambria; border-bottom: 1px solid #000000;
                                    border-top: 1px solid #000000; font-size: 17px">
                                    U.B.T.E.R MARKS LIST-D ( THEORY )<br />
                                    <%=HEADSESS %>
                                    <br />
                                </th>
                            </tr>
                            <tr>
                                <th align="left" valign="middle" style="font-size: 18px;">
                                    FIRST FOIL&nbsp;:
                                </th>
                                <th align="left" colspan="4" valign="middle" style="font-size: 18px;">
                                    <asp:Label ID="Lblfoil2" Font-Names="Cambria" runat="server" Text="FOIL NUMBER"></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <th align="left" valign="middle" style="font-size: 15px;">
                                    INSTITUTE NAME&nbsp;:
                                </th>
                                <td colspan="4" align="left" valign="middle" style="font-size: 15px;">
                                    <asp:Label ID="Lblins1" Font-Names="Cambria" runat="server" Text="Institute Name"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th align="left" valign="middle" style="font-size: 15px;">
                                    BRANCH NAME&nbsp;:
                                </th>
                                <td colspan="4" align="left" valign="middle" style="font-size: 15px;">
                                    <asp:Label ID="Lblbranch1" Font-Names="Cambria" runat="server" Text="Branch Name"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th align="left" valign="middle" style="font-size: 15px;">
                                    SEMESTER&nbsp;/&nbsp;SHIFT:
                                </th>
                                <td colspan="4" align="left" valign="middle" style="font-size: 15px;">
                                    <asp:Label ID="Lblsem1" Font-Names="Cambria" runat="server" Text="Semester"></asp:Label>&nbsp;/&nbsp;
                                    <asp:Label ID="Lblshift1" Font-Names="Cambria" runat="server" Text="Shift"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th align="left" valign="middle" style="font-size: 15px;">
                                    SUBJECT&nbsp;:
                                </th>
                                <td colspan="4" align="left" valign="middle" style="font-size: 15px;">
                                    <asp:Label ID="Lblsub1" Font-Names="Cambria" runat="server" Text="Subject"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th align="left" valign="middle" style="font-size: 15px;">
                                    MARKS&nbsp;:
                                    <br />
                                    <br />
                                </th>
                                <td colspan="4" align="left" valign="middle" style="font-size: 15px;">
                                    (&nbsp;&nbsp;&nbsp;Maximum:&nbsp;<asp:Label ID="Lblmax1" Font-Names="Cambria" runat="server"
                                        Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;Minimum:&nbsp;<asp:Label ID="Lblmin1"
                                            Font-Names="Cambria" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;)
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <th rowspan="2" align="center" valign="middle" style="border-bottom: 1px solid #000000;
                                    border-top: 1px solid #000000; border-left: 1px solid #000000; border-right: 1px solid #000000;
                                    font-size: 17px; width: 130px;">
                                    ROLL
                                </th>
                                <th rowspan="2" align="center" valign="middle" style="border-bottom: 1px solid #000000;
                                    border-top: 1px solid #000000; border-right: 1px solid #000000; font-size: 16px;">
                                    SUB
                                </th>
                                <th rowspan="2" align="center" valign="middle" style="border-bottom: 1px solid #000000;
                                    border-top: 1px solid #000000; border-right: 1px solid #000000; font-size: 16px;">
                                    BRC
                                </th>
                                <th colspan="2" align="center" valign="middle" style="border-bottom: 1px solid #000000;
                                    border-top: 1px solid #000000; border-right: 1px solid #000000; font-size: 17px;">
                                    TOTAL MARKS
                                </th>
                            </tr>
                            <tr>
                                <th align="center" valign="middle" style="border-bottom: 1px solid #000000; border-right: 1px solid #000000;
                                    font-size: 15px; width: 60px;">
                                    FIG.
                                </th>
                                <th align="left" valign="middle" style="border-bottom: 1px solid #000000; border-right: 1px solid #000000;
                                    font-size: 15px;">
                                    WORDS
                                </th>
                            </tr>
                            <tr>
                                <%=DATA %>
                            </tr>
                            <tr>
                                <td colspan="3" align="left" valign="bottom" style="height: 50px; font-size: 15px;
                                    border-bottom: 1px solid #000000; border-left: 1px solid #000000; font-family: Cambria;">
                                    <br />
                                    <br />
                                    <br />
                                    &nbsp;EXAMINER SIGN:<br />
                                    &nbsp;EXAMINER NAME:
                                    <br />
                                </td>
                                <td style="border-bottom: 1px solid #000000;">
                                </td>
                                <td align="center" valign="bottom" style="height: 50px; font-size: 15px; border-bottom: 1px solid #000000;
                                    border-right: 1px solid #000000; font-family: Cambria;">
                                    <br />
                                    <br />
                                    <br />
                                    ( EVALUATION CENTRE )<br />
                                    SEAL & SIGN
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
            <hr />
            <div style="width: 1024px; text-align: left">
                Note:-Please Print This Report in PORTRAIT FORMAT Only.
            </div>
            <br />
            <hr />
            <br />
        </div>
    </center>
    </form>
</body>
</html>

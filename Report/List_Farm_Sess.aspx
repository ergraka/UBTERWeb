<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List_Farm_Sess.aspx.cs" Inherits="List_Farm_Sess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Images/favicon.ico" rel="Icon File" />
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
<body onload="noBack();" oncontextmenu="return false" style="color: #000000; font-family: Cambria;
    font-size: 14px;">
    <form id="form1" runat="server">
    <center>
        <div class="noprint" style="background-color: #20B2AA; width: 1024px">
            <br />
            <br />
            <img src="../Images/Print.png" alt="Click here to print Admit Card." id="btnprint"
                style="height: 30px; width: 25px;" onclick="javascript:alert('Please Print This Report in LANDSCAPE FORMAT Only.');javascript:window.print();" />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:ImageButton ID="Imghome" ImageUrl="~/Images/Home.png" Height="30px" Width="20px"
                runat="server" OnClick="Imghome_Click" />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:ImageButton ID="Imglogout" ImageUrl="~/Images/Logout.png" Height="30px" Width="20px"
                runat="server" OnClick="Imglogout_Click" />
            <br />
            <asp:Label ID="LblMessage" Font-Size="15px" ForeColor="#FF0000" runat="server" Text=""></asp:Label></div>
        <div style="width: 1024px; border: 1px solid #000000;">
            <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <th valign="middle" colspan="16" align="center" style="font-family: Cambria; border-bottom: 1px solid #000000;
                        font-size: 18px;">
                        <p>
                            U.B.T.E.R SESSIONAL LIST<br />
                             <%=HEADSESS %></p>
                    </th>
                </tr>
                <tr>
                    <th align="left" valign="middle" style="font-size: 15px;">
                        INSTITUTE NAME&nbsp;:
                    </th>
                    <td align="left" colspan="15" valign="middle" style="font-size: 15px;">
                        <asp:Label ID="Lblins" Font-Names="Cambria" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle" style="font-size: 15px;">
                        BRANCH NAME&nbsp;:
                    </th>
                    <td align="left" colspan="15" valign="middle" style="font-size: 15px;">
                        <asp:Label ID="Lblbranch" Font-Names="Cambria" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle" style="font-size: 15px; border-bottom: 1px solid #000000;">
                        SEMESTER&nbsp;/&nbsp;SHIFT:
                    </th>
                    <td align="left" colspan="15" valign="middle" style="font-size: 15px; border-bottom: 1px solid #000000;">
                        <asp:Label ID="Lblsem" Font-Names="Cambria" runat="server" Text=""></asp:Label>&nbsp;/&nbsp;
                        <asp:Label ID="Lblshift" Font-Names="Cambria" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <%=DATA1 %>
                <%=DATA %>
                <tr>
                    <td colspan="3" align="center" valign="bottom" style="height: 50px; font-size: 15px;
                        font-family: Cambria;">
                        <br />
                        <br />
                        <br />
                        <b>( PREPARED BY ) </b>
                        <br />
                    </td>
                    <td colspan="4" align="center" valign="bottom" style="height: 50px; font-size: 15px;
                        font-family: Cambria;">
                        <br />
                        <br />
                        <br />
                        <b>( CHECKED BY ) </b>
                        <br />
                    </td>
                    <td colspan="5" align="center" valign="bottom" style="height: 50px; font-size: 15px;
                        font-family: Cambria;">
                        <br />
                        <br />
                        <br />
                        <b>( PRINCIPAL ) </b>
                        <br />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div style="width: 1024px; text-align: left">
            <hr />
            Note:-Please Print This Report in LANDSCAPE FORMAT Only.
            <hr />
        </div>
        <br />
        <br />
    </center>
    </form>
</body>
</html>

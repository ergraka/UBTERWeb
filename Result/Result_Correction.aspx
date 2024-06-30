<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Result_Correction.aspx.cs"
    Inherits="Result_Result_Correction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UBTER : RESULT CORRECTION</title>
    <script src="../Scripts/Common.js" type="text/javascript" language="javascript"></script>
    <link rel="Icon" href="../Images/favicon.ico" />
    <link href="../CSS/HeaderFooter.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Home.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Homeother.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript">

        function Name() {
            document.getElementById('Txtroll').value = "";
        }
        function Roll() {
            document.getElementById('Txtcname').value = "";
            document.getElementById('Drpday').value = 0;
            document.getElementById('Drpmonth').value = 0;
            document.getElementById('Drpyear').value = 0;
        }


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
<body onload="noBack();" oncontextmenu="return false" style="font-family: Cambria;
    font-size: 15px; background-color: #F8F8F0; color: #000000; margin: 0px">
    <form id="form1" runat="server">
    <center>
        <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table cellpadding="0" cellspacing="0" style="width: 100%;">
                        <tr>
                            <td align="right" class="linehead" style="background-color: #008000; color: #FFFFFF;
                                width: 400px;">
                                <img alt="Uttarakhand" src="../Images/Logo.jpg" height="100px" />
                            </td>
                            <td align="center" class="linehead" style="background-color: #008000; color: #FFFFFF;
                                font-family: Agency FB; height: 60px; font-size: 25px;">
                                UTTARAKHAND BOARD OF TECHNICAL EDUCATION , ROORKEE [ HARIDWAR ]
                                <br />
                                <font style="color: #FFFFFF; font-family: Courier New; font-size: 16px;">ANNUAL / SEMESTER
                                    EXAMINATION<br />
                                    <font style="color: #D2B48C; font-family: Courier New;">( SUMMER / WINTER )</font>
                                </font>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" style="border-bottom: 1px solid #000000; font-weight: bold;
                                font-size: 18px; background-color: #008080; color: #FFFFFF;">
                                RESULT CORRECTION
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="1024px" cellpadding="0" cellspacing="4">
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <br />
        <br />
        <br />
        <div id="SAN" style="width: 1024px">
            <div class="container">
                <div align="right">
                    Uttarakhand Board of Technical Education | &#169; All Rights Reserved | 2019
                </div>
            </div>
        </div>
    </center>
    </form>
</body>
</html>

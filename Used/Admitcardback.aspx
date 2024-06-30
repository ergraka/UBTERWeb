<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admitcardback.aspx.cs" Inherits="Admitcardback" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Images/favicon.ico" rel="Icon File" />
    <title>Backpaper Admit Card</title>
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
<body style="margin: 0px; font-family: Cambria; font-size: 14px;" onload="noBack();"
    oncontextmenu="return false">
    <form id="form1" runat="server">
    <center>
        <div class="noprint">
            <br />
            <img src="../Images/Print.jpeg" alt="Click here to print Admit Card." id="btnprint"
                style="height: 30px; width: 25px;" onclick="javascript:alert('Please Print in Portrait format');javascript:window.print();" />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:ImageButton ID="Imglogout" ImageUrl="~/Images/Logout.png" Height="30px" Width="20px"
                runat="server" OnClick="Imglogout_Click" />
        </div>
        <div style="width: 1024px; border: 1px solid #000000">
            <table cellpadding="0" cellspacing="0" width="1024px">
                <tr>
                    <td align="center" style="border-bottom: 1px solid #000000; height: 100px;">
                        <img src="../Images/LOGO.jpg" width="100px" height="90px" alt="UBTER" />
                    </td>
                    <td colspan="5" valign="middle" align="center" style="color: #000000; font-size: 25px;
                        font-family: Agency FB; border-bottom: 1px solid #000000">
                        <b>UTTARAKHAND BOARD OF TECHNICAL EDUCATION , ROORKEE [ HARIDWAR ]</b><br />
                        <i style="font-size: 18px; font-family: Courier New;">ADMIT CARD</i>
                        <br />
                        Verification, Special Back Paper Examination, SUMMER - 2022
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="middle">
                        ROLL NO:
                    </td>
                    <th align="left" valign="middle">
                        <%=ROLL %>
                    </th>
                    <td align="left" valign="middle">
                        REGISTRATION NO:
                    </td>
                    <th align="left" valign="middle">
                        <%=REG %>
                    </th>
                    <td valign="middle" align="center" rowspan="5" style="height: 200px; border-left: 1px solid #000000;">
                        <asp:Image ID="Imgphver" runat="server" Height="160px" Width="150px" BorderColor="Black"
                            BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                    <td valign="middle" align="center" rowspan="5" style="height: 200px;">
                        <div style="border: 1px solid #000000; text-align: center; vertical-align: middle;
                            color: #A9A9A9; width: 150px; height: 160px;">
                            <br />
                            <br />
                            <br />
                            Student Please Paste
                            <br />
                            Recent Photo
                            <br />
                            Here
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="middle">
                        NAME:
                    </td>
                    <th align="left" valign="middle">
                        <%=NAME %>
                    </th>
                    <td align="left" valign="middle">
                        SEMESTER / YEAR:
                    </td>
                    <th align="left" valign="middle">
                        <%=SEM %>
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle">
                        FATHER NAME:
                    </td>
                    <th align="left" valign="middle">
                        <%=FNAME %>
                    </th>
                    <td align="left" valign="middle">
                        STATUS:
                    </td>
                    <th align="left" valign="middle">
                        <%=STAT %>
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle">
                        BRANCH:
                    </td>
                    <th align="left" valign="middle">
                        <%=BRANCH %>
                    </th>
                    <td align="left" valign="middle">
                        DATE OF BIRTH:
                    </td>
                    <th align="left" valign="middle">
                        <%=DOB %>
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle">
                        EXAM CENTRE:
                    </td>
                    <th colspan="3" align="left" valign="middle">
                        <%=CENTRE %>
                    </th>
                </tr>
                <tr>
                    <th colspan="6" align="center" style="border-top: 1px solid #000000">
                        <br />
                        <%=SUBJECTS %>
                        <br />
                        <br />
                        <br />
                        <br />
                    </th>
                </tr>
                <tr>
                    <td align="left" colspan="4" valign="middle" style="height: 30px; border-bottom: 1px solid #000000;">
                        <br />
                        Note : * Back Papers.
                        <br />
                        <br />
                    </td>
                    <th colspan="2" align="center" valign="middle" style="border-bottom: 1px solid #000000;">
                        <br />
                        ( Sign & Seal of C.S./Principal )
                        <br />
                        <br />
                    </th>
                </tr>
                <tr>
                    <td colspan="6" style="height: 20px">
                        <br />
                        <br />
                        <img src="../Images/Line.jpg" height="15px" alt="Cut the page here." width="1024px" />
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center" style="border-bottom: 1px solid #000000; border-top: 1px solid #000000;
                        height: 100px;">
                        <img src="../Images/LOGO.jpg" width="100px" height="90px" alt="UBTER" />
                    </td>
                    <td colspan="5" valign="middle" align="center" style="color: #000000; font-size: 25px;
                        font-family: Agency FB; border-bottom: 1px solid #000000; border-top: 1px solid #000000;">
                        <b>UTTARAKHAND BOARD OF TECHNICAL EDUCATION , ROORKEE [ HARIDWAR ]</b><br />
                        <i style="font-size: 18px; font-family: Courier New;">ANNUAL/SEMESTER EXAMINATION</i>
                        <br />
                        Admit Card, Special Back Paper Examination, SUMMER - 2022
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="middle">
                        ROLL NO:
                    </td>
                    <th align="left" valign="middle">
                        <%=ROLL %>
                    </th>
                    <td align="left" valign="middle">
                        REGISTRATION NO:
                    </td>
                    <th align="left" valign="middle">
                        <%=REG %>
                    </th>
                    <td align="center" valign="middle" rowspan="5" style="height: 200px; border-bottom: 1px solid #000000;
                        border-left: 1px solid #000000;">
                        <asp:Image ID="Imgphadm" runat="server" Height="160px" Width="150px" BorderColor="Black"
                            BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                    <td align="center" valign="middle" rowspan="5" style="height: 200px; border-bottom: 1px solid #000000;">
                        <div style="border: 1px solid #000000; text-align: center; vertical-align: middle;
                            color: #A9A9A9; width: 150px; height: 160px;">
                            <br />
                            <br />
                            <br />
                            Student Please Paste
                            <br />
                            Recent Photo
                            <br />
                            Here
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="middle">
                        NAME:
                    </td>
                    <th align="left" valign="middle">
                        <%=NAME %>
                    </th>
                    <td align="left" valign="middle">
                        SEMESTER / YEAR:
                    </td>
                    <th align="left" valign="middle">
                        <%=SEM %>
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle">
                        FATHER NAME:
                    </td>
                    <th align="left" valign="middle">
                        <%=FNAME %>
                    </th>
                    <td align="left" valign="middle">
                        STATUS:
                    </td>
                    <th align="left" valign="middle">
                        <%=STAT %>
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle">
                        BRANCH:
                    </td>
                    <th align="left" valign="middle">
                        <%=BRANCH %>
                    </th>
                    <td align="left" valign="middle">
                        DATE OF BIRTH:
                    </td>
                    <th align="left" valign="middle">
                        <%=DOB %>
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px; border-bottom: 1px solid #000000;">
                        EXAM CENTRE:
                    </td>
                    <th colspan="3" align="left" valign="middle" style="border-bottom: 1px solid #000000;">
                        <%=CENTRE %>
                    </th>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <th align="right" valign="middle" style="height: 30px;">
                        Date of Issue:
                    </th>
                    <td colspan="2" style="border-left: 1px solid #000000; border-bottom: 1px solid #000000">
                    </td>
                </tr>
                <tr>
                    <td align="justify" colspan="6">
                        <hr />
                        <b><u>NOTE:-</u>परीक्षा केन्द्र में निम्न्वत स्टेशनरी / उपकरण / सामग्री प्रतिबन्धित
                            होगी :-</b>हस्तलिखित / प्रिंटेड सामग्री, कागज के टुकड़े, किताब, पेन्सिल बाक्स,
                        प्लास्टिक पाउच, प्रोग्रामेबल कैलकुलेटर, हैण्डबैग, लाग टेबल, इलेक्ट्रॉनिक पेन, स्कैनर,
                        मोबाईल, टैब, ब्लूटूथ, माईक्रोफोन, पेजर, हैल्थ बैण्ड, पर्स, सनग्लास, टोपी, बैल्ट,
                        स्कार्फ, घडी / हाथ की घडी (Digital Watch) / कैमरा आदि।
                    </td>
                </tr>
                <tr>
                    <th align="center" colspan="6">
                        <u>परीक्षार्थी अपने साथ अपना कोई एक फोटो पहचान पत्र (आधार कार्ड, वोटर आई. डी. या संस्था
                        का I-कार्ड आदि) अवश्य लेकर आयें |</u>
                    </th>
                </tr>
                <tr>
                    <th align="center" valign="middle" style="height: 30px;">
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        SECRETARY
                    </th>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <th colspan="2" align="center" valign="bottom" style="height: 30px;">
                        Sign of C.S./Principal<br />
                        ( With Seal )
                    </th>
                </tr>
            </table>
            <br />
        </div>
        <br />
        <br />
    </center>
    </form>
</body>
</html>

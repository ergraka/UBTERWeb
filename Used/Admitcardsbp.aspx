<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admitcardsbp.aspx.cs" Inherits="Admitcardsbp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Images/favicon.ico" rel="Icon File" />
    <title>SBP Admit Card</title>
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
                        Special Back Paper Examination - 2019
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
                    </th>
                </tr>
                <tr>
                    <td align="justify" colspan="6">
                        <b><u>NOTE:-</u></b>परीक्षा केंद्र में निम्नवत स्टेशनरी/उपकरण/सामग्री प्रतिबंधित
                        होगीः- हस्तलिखित/प्रिंटेड सामग्री, कागज के टुकड़े, किताब, पेंसिल बॉक्स, प्लास्टिक
                        पाउच, प्रोग्रामेबल कैलकुलेटर, हैंडबैग, लोग टेबल, इलेक्ट्रिक पेन, स्कैनर, मोबाइल,
                        टैब, ब्लूटूथ, माइक्रोफोन, पेजर, हेल्थ बैंड, पर्स, सनग्लास, टोपी, बैल्ट, स्कार्फ,
                        घडी/हाथ की घडी/कैमरा आदि । छात्रों को अपने साथ दो फोटो लाना अनिवार्य है।
                        <br />
                        पेपर कोड 1002, 2002, 4012 आरै 6013 में छात्रों की संख्या अधिक हाने के कारण उनके
                        पेपर देने की व्यवस्था निम्न तालिका के अनुसार होगी।
                    </td>
                </tr>
                <tr runat="server" id="TRSBP">
                    <td align="center" colspan="6">
                        <hr />
                        <img src="../Document/Sbp.jpg" width="90%" alt="UBTER" />
                        <hr />
                    </td>
                </tr>
                <tr>
                    <th align="center" valign="middle" style="height: 30px;">
                        <br />
                        <br />
                        <br />
                        <br />
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

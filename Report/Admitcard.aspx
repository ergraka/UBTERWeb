<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admitcard.aspx.cs" Inherits="Admitcard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Images/favicon.ico" rel="Icon File" />
    <title>Admit Card</title>
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
            <img src="../Images/Print.jpeg" alt="Click here to print Admit Card." id="btnprint"
                style="height: 30px; width: 25px;" onclick="javascript:alert('Please Print in Portrait format');javascript:window.print();" />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:ImageButton ID="Imglogout" ImageUrl="~/Images/Logout.png" Height="30px" Width="20px"
                runat="server" OnClick="Imglogout_Click" />
        </div>
        <div style="width: 1024px; border: 1px solid #000000">
            <table cellpadding="8" cellspacing="0" style="width: 1024px;">
                <tr>
                    <td align="center" style="border-bottom: 1px solid #000000; height: 100px;">
                        <img src="../Images/LOGO.jpg" width="100px" height="90px" alt="UBTER" />
                    </td>
                    <td colspan="5" valign="middle" align="center" style="color: #000000; font-size: 25px;
                        font-family: Agency FB; border-bottom: 1px solid #000000">
                        <b>UTTARAKHAND BOARD OF TECHNICAL EDUCATION , ROORKEE [ HARIDWAR ]</b><br />
                        
                       <i style="font-size: 18px; font-family: Courier New;">ANNUAL/SEMESTER EXAMINATION</i>
                        <br />
                        <%=HEAD %><br />
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px; width: 130px;">
                        ROLL NO:
                    </td>
                    <th align="left" valign="middle" style="width: 0px;">
                        <%=ROLL %>
                    </th>
                    <td align="left" valign="middle" style="width: 150px;">
                        REGISTRATION NO:
                    </td>
                    <th align="left" valign="middle" style="width: 150px;">
                        <%=REG %>
                    </th>
                    <td align="center" valign="middle" rowspan="5" style="height: 170px; border-bottom: 1px solid #000000;">
                        <asp:Image ID="Imgphadm" runat="server" Height="160px" Width="140px" BorderColor="Black"
                            BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                     <td rowspan="5" align="center" style="border-style: solid; border-color:black; border-width: 1px; padding: 1px 4px; height: 230px; width: 120px; margin-left:20px; text-align: center">
                        <b>&nbsp; Paste your recent&nbsp; passport size Photograph here</b> 
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
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
                    <td align="left" valign="middle" style="height: 30px;">
                        FATHER NAME:
                    </td>
                    <th align="left" valign="middle">
                        <%=FNAME %>
                    </th>
                    <td align="left" valign="middle">
                        STATUS:
                    </td>
                    <th align="left" valign="middle">
                        <%=REGPVT %>
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
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
                    <th colspan="3" align="right" valign="middle" style="height: 30px; border-bottom: 1px solid #000000">
                        Date of Issue:
                    </th>
                    <td colspan="3" style="border-left: 1px solid #000000; border-bottom: 1px solid #000000">
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="6">
                        <div style="font-weight: bold; font-size: 20px; background-color: #DCDCDC; border-radius: 20px;
                            border-bottom: 1px solid #000000;">
                            --महत्वपूर्ण निर्देश--</div>
                        <br />
                        <br />
                        <div style="width: 90%; text-align: left; margin-left:0px;"><b>Note:-Students can check their result by student login at ubertex.in, where Username is student's Roll_Number and password is student's Registration_Number.</b> 
                            </div>
                   
<%--<br />
                        <div style="width: 90%; text-align: justify; border-bottom: 1px solid #000000;">
                            <b style="text-decoration: underline;">कोविड-19 महामारी से बचाव के लिये अभ्यर्थी निम्नवत
                                बातों का ध्यान रखेंः-</b><br />
                            <br />
                            A. अभ्यर्थी अनिवार्य रूप से मास्क का प्रयोग करें।
                            <br />
                            <br />
                            B. अभ्यर्थी अपने साथ अपना हैण्ड सैनिटाईजर लायें।<br />
                            <br />
                            C. अभ्यर्थी पानी पीने के लिये पारदर्शी बोतल रखें।<br />
                            <br />
                            D. अभ्यर्थी परीक्षा केन्द्र पर समय से 1 घंटा पूर्व पहुँचे जिससे सेनीटाईजेशन के उपरान्त
                            आपके पाास परीक्षा कक्ष में पहुँचने के लिये पर्याप्त समय उपलब्ध हो।
                            <br />
                            <br />
                            E. अभ्यर्थी परीक्षा केन्द्र में अनिवार्य रूप से सोशल डिस्टेन्सिंग का अनुपालन करें।<br />
                            <br />
                            F. अभ्यर्थी द्वारा परीक्षा केन्द्र में प्रवेश द्वार, परीक्षा कक्ष में किसी प्रकार की भीड़-भाड़
                            ना की जाये।
                            <br />
                            <br />
                            G. अभ्यर्थी परीक्षा केन्द्र के प्रवेश द्वार पर हैण्ड सैनिटाइजेशन एवं थर्मल स्कैनिंग
                            करवाने के उपरान्त ही परीक्षा कक्ष में प्रवेश करें।
                            <br />
                            <br />
                            H. अभ्यर्थी परीक्षा कक्ष में किसी प्रकार की स्टेशनरी का आदान प्रदान ना करें।<br />
                            <br />
                            I. अभ्यर्थी परीक्षा केन्द्र में तैनात स्टाफ द्वारा दिए गए निर्देशों का अनिवार्य
                            रूप से पालन सुनिश्चित करें।
                            <br />
                            <br />
                            <br />--%>
		<br />
		<br />	
		<br />	
                            <b><u>NOTE:-परीक्षा केन्द्र में निम्न्वत स्टेशनरी / उपकरण / सामग्री प्रतिबन्धित होगी</u>
                                :-</b>
                            <br />
                            <br />
                            हस्तलिखित / प्रिंटेड सामग्री, कागज के टुकड़े, किताब, पेन्सिल बाक्स, प्लास्टिक पाउच,
                            प्रोग्रामेबल कैलकुलेटर, हैण्डबैग, लाग टेबल, इलेक्ट्रॉनिक पेन, स्कैनर, मोबाईल, टैब,
                            ब्लूटूथ, माईक्रोफोन, पेजर, हैल्थ बैण्ड, पर्स, सनग्लास, टोपी, बैल्ट, स्कार्फ, घडी
                            / हाथ की घडी (Digital Watch) / कैमरा आदि।
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="center" valign="middle" style="height: 30px;">
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                         <asp:Image ID="Image2" runat="server" Height="80px" Width="250px" 
                             ImageUrl="~/Images/AdmitCardSign.png" />
                        <%--SECRETARY--%>
                    </th>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <th align="center" valign="bottom" style="height: 30px;">
                        Sign of C.S./Principal<br />
                        ( With Seal )
                    </th>
                </tr>
            </table>
            <br />
        </div>
        --Please print in portrait format only--
        <br />
        <br />
    </center>
    </form>
</body>
</html>

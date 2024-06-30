<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Allotment_Letter.aspx.cs" Inherits="Allotment_Letter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Allotment Letter</title>
    <link href="../CSS/Style.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/HeaderFooter.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Homeother.css" type="text/css" rel="Stylesheet" />
    <script src="../Scripts/Common.js" type="text/javascript" language="javascript"></script>
    <link rel="Icon" href="../Images/favicon.ico" />
    <style type="text/css">
        @media Print {
            .noprint {
                display: none;
                width: 100%;
            }

            .print {
                width: 100%;
            }
        }
    </style>
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
<body onload="noBack();">
    <form id="form1" runat="server" autocomplete="off">
        <center>
            <div class="noprint">
                <br />
                <img src="../Images/Print.jpeg" alt="Click here to print Admit Card." id="Img1" style="height: 30px; width: 25px;"
                    onclick="javascript:alert('Please Print in Portrait format');javascript:window.print();" />
            </div>
            <div style="width: 90%;">
                <table style="width: 100%; border-collapse: collapse;">
                    <tr>
                        <td align="center">
                            <div class="row">
                                <div class="col-lg-12">
                                    <b style="font-family: Agency FB; font-size: 24px; color: #FF0000;">UTTARAKHAND BOARD
                                    OF TECHNICAL EDUCATION , ROORKEE [ HARIDWAR ]
                                    <br />
                                        <font style="color: #FF0000; font-family: Courier New; font-size: 16px;">PRACTICAL EXAMINATION 2022 ( SUMMER )<br />
                                            <font style="color: #000000; font-family: Courier New;">ALLOTTMENT-LETTER</font>
                                        </font></b>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <hr />
                <table style="width: 100%">
                    <tr>
                        <td valign="top">Letter No. : 409-591/UBTE/PRACT/ 2022/SUMMER Dated - 21/MAY / 2022
                        </td>
                        <td>Secretary UBTER<br />
                            Sunhara Road Near KLP Hostel<br />
                            Kashipuri Roorkee<br />
                            Contact : 9411503295, 9411338834,<br />
                            8630515707, 7983499930<br />
                            EMAIL-js.ubte15@gmail.com
                           
                        </td>

                    </tr>
                    <tr>
                        <td valign="top">02102 KOHIMA YADAV<br />
                            LEC<br />
                            G P C BHEEMTAL (NAINITAL) BHIMTAL
                        </td>
                        <td>MOB: 9760857634
                        </td>
                    </tr>
                    <tr>
                        <td align="justify" colspan="4" valign="middle">
                            <br />
                            Sir/Madam,<br />
                            You are being appointed as a practical examiner in the following institution(s) as per the details given below. Please contact
the Principal of the concerened Instituttion(s) through letter or telephone . Practical examinations are to be conducted from 21-05-2022.
Practical examinations must be conducted before theory examination. In case of any incoveniece, practical examination may be completed
after exam.
                        </td>
                    </tr>
                    <tr>
                        <td align="justify" colspan="4" valign="middle">
                            <br />
                            Note- 1. If you are unable to conduct the practical examination on time, you are requested to inform the institute as well as the undersigned
immediately. So that the alternative arrangement can be made accordingly.The refusal of the examinership is expected only on the basis of
some valid reason and such request is to be submmited along with supporting document i.e. Medical certificate, Study leave etc.<br />
                            4.PLEASE SUBMIT E-LIST (MARKS) IN A SEALED BUNDEL TO THE PRINCIPAL OF RESPECTIVE INSTITUTION.<br />
                            5.The practical examiner will conduct all alloted practical exams of students irrespective of the shift.<br />
                            7. Practical must be performed as per the Syllabus.<br />

                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle" style="border-bottom: 1px solid #000000;">
                            <br />
                            <br />
                            <br />
                            <br />
                            <b>THIS REPORT IS SYSTEM GENERATED NEED NOT TO BE SIGNED</b>
                        </td>
                        <td align="right" valign="middle" style="border-bottom: 1px solid #000000;">
                            <br />
                            <br />
                            <br />
                            <br />
                            <b>SECRETARY</b>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
            </div>
        </center>
    </form>
</body>
</html>

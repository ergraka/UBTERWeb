<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Application Form</title>
    <link href="../CSS/Style.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/HeaderFooter.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Homeother.css" type="text/css" rel="Stylesheet" />
    <script src="../Scripts/Common.js" type="text/javascript" language="javascript"></script>
    <link rel="Icon" href="../Images/favicon.ico" />
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
<body style="background-color: #FFFFFF; font-family: Cambria; font-size: 15px; margin: 0px;"
    onload="noBack();">
    <form id="form1" runat="server" autocomplete="off">
    <center>
        <div class="noprint">
            <br />
            <img src="../Images/Print.jpeg" alt="Click here to print Admit Card." id="Img1" style="height: 30px;
                width: 25px;" onclick="javascript:alert('Please Print in Portrait format');javascript:window.print();" />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:ImageButton ID="Imghome" ImageUrl="~/Images/Home.png" Height="30px" Width="20px"
                runat="server" OnClick="Imghome_Click" />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:ImageButton ID="Imglogout" ImageUrl="~/Images/Logout.png" Height="30px" Width="20px"
                runat="server" OnClick="Imglogout_Click" />
        </div>
        <div style="width: 95%; height: auto; background: url(../Images/Watermark.jpg); font-family: Cambria;
            background-repeat-x: no-repeat; background-repeat-y: no-repeat; background-position: center;">
            <div>
                <table border='1' cellpadding="3" cellspacing="1" style="width: 100%; border-collapse: collapse;">
                    <tr class="linehead">
                        <td colspan="4" align="center">
                            <div class="row">
                                <div class="col-lg-3">
                                    <img alt="Ppr" src="../Images/Logo.jpg" height="100px" />
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
                        <td colspan="3" align="center" valign="middle" style="color: #000080; font-size: 18px;">
                            APPLICATION FORM ANNUAL / SEMESTER EXAMINATION
                            <br />
                            <%=CP %>
                        </td>
                        <td align="center">
                            <asp:Image ID="ImgPH" Height="150px" Width="147px" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            Registration Number
                        </td>
                        <td colspan="3" valign="middle" align="center" style="font-weight: bold;">
                            <%=_CANDIDATEID%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            Roll Number
                        </td>
                        <td valign="middle" align="left" style="font-weight: bold;">
                            <%=_ROLL%>
                        </td>
                        <td align="left" valign="middle" style="width: 200px">
                            Group / Shift
                        </td>
                        <td valign="middle" align="left">
                            <%=_GRP%>
                            /
                            <%=_SHIFT%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            NAME
                        </td>
                        <td valign="middle" align="left">
                            <%=_CANDIDATE_NAME%>
                        </td>
                        <td align="left" valign="middle">
                            Father's Name
                        </td>
                        <td align="left" valign="middle">
                            <%=_FATHER_NAME%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            YEAR/SEMESTER
                        </td>
                        <td colspan="3" valign="middle" align="left">
                            <%=_SEM%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            Institute Name
                        </td>
                        <td colspan="3" align="left" valign="middle">
                            <%=_INSTITUTE%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            Branch Name
                        </td>
                        <td colspan="3" align="left" valign="middle">
                            <%=_BRANCH%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            EMail Address
                        </td>
                        <td align="left" valign="middle">
                            <%=_EMAIL%>
                        </td>
                        <td align="left" valign="middle">
                            Nationality
                        </td>
                        <td valign="middle" align="left">
                            <%=_NATIONALITY%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            Date of Birth
                        </td>
                        <td valign="middle" align="left">
                            <%=_DOB%>
                        </td>
                        <td align="left" valign="middle">
                            Gender
                        </td>
                        <td valign="middle" align="left">
                            <%=_GENDER%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            Category
                        </td>
                        <td align="left" valign="middle">
                            <%=_CATEGORY%>
                        </td>
                        <td align="left" valign="middle">
                            Sub Category
                        </td>
                        <td align="left" valign="middle">
                            <%=_SUBCAT%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            Mobile Number
                        </td>
                        <td align="left" valign="middle">
                            <%=_MONO%>
                        </td>
                        <td align="left" valign="middle">
                            Landline Number
                        </td>
                        <td align="left" valign="middle">
                            <%=_LLN%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            Fee Submitted
                        </td>
                        <td align="left" valign="middle">
                            <%=_FEE%>
                        </td>
                        <td align="left" valign="middle">
                            Regular/Private
                        </td>
                        <td align="left" valign="middle">
                            <%=_REGPVT%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            High School Pass ?
                        </td>
                        <td align="left" valign="middle">
                            <%=_HPASS%>
                        </td>
                        <td align="left" valign="middle">
                            Intermediate Pass ?
                        </td>
                        <td align="left" valign="middle">
                            <%=_IPASS%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            High School Area Type
                        </td>
                        <td align="left" valign="middle">
                            <%=_HAREA%>
                        </td>
                        <td align="left" valign="middle">
                            I.T.I Pass Or Not ?
                        </td>
                        <td align="left" valign="middle">
                            <%=_ITIPASS%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            Minority ?
                        </td>
                        <td align="left" valign="middle">
                            <%=_MINORITY%>
                        </td>
                        <td align="left" valign="middle">
                            Aadhar Number
                        </td>
                        <td align="left" valign="middle">
                            <%=_AADHAR%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="left" valign="middle">
                            <%=_COMP%>
                        </td>
                        <td colspan="3" align="left" valign="middle">
                            Yes
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="left" style="background-color: #3CB371; color: #FFFFFF;">
                            CORRESPONDENCE ADDRESS DETAILS
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            Address
                        </td>
                        <td align="left" valign="middle">
                            <%=_CADDRESS%>
                        </td>
                        <td align="left" valign="middle">
                            State
                        </td>
                        <td align="left" valign="middle">
                            <%=_CSTATE%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            District
                        </td>
                        <td align="left" valign="middle">
                            <%=_CDISTRICT%>
                        </td>
                        <td align="left" valign="middle">
                            Pin Code
                        </td>
                        <td align="left" valign="middle">
                            <%=_CPIN%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            Tehsil
                        </td>
                        <td align="left" valign="middle">
                            <%=_CTEHSIL%>
                        </td>
                        <td align="left" valign="middle">
                            Block
                        </td>
                        <td align="left" valign="middle">
                            <%=_CBLOCK%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" valign="middle" align="left" style="background-color: #3CB371; color: #FFFFFF;">
                            PERMANENT ADDRESS DETAILS
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            Address
                        </td>
                        <td align="left" valign="middle">
                            <%=_PADDRESS%>
                        </td>
                        <td align="left" valign="middle">
                            State
                        </td>
                        <td align="left" valign="middle">
                            <%=_PSTATE%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            District
                        </td>
                        <td align="left" valign="middle">
                            <%=_PDISTRICT%>
                        </td>
                        <td align="left" valign="middle">
                            Pin Code
                        </td>
                        <td align="left" valign="middle">
                            <%=_PPIN%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle">
                            Tehsil
                        </td>
                        <td align="left" valign="middle">
                            <%=_PTEHSIL%>
                        </td>
                        <td align="left" valign="middle">
                            Block
                        </td>
                        <td align="left" valign="middle">
                            <%=_PBLOCK%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="left" style="background-color: #3CB371; color: #FFFFFF;">
                            QUALIFICATIONS DETAILS
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table align="center" border="1" width="100%" style="border-collapse: collapse">
                                <tr style="color: #FFFFFF; font-size: 16px;">
                                    <td style="background-color: #3CB371;" align="center">
                                        EXAMINATION
                                    </td>
                                    <td style="background-color: #3CB371;" align="center">
                                        COURSE NAME
                                    </td>
                                    <td style="background-color: #3CB371;" align="center">
                                        BOARD / UNIVERSITY
                                    </td>
                                    <td style="background-color: #3CB371;" align="center">
                                        PASSING YEAR
                                    </td>
                                    <td style="background-color: #3CB371;" align="center">
                                        MARKS OBTAINED
                                    </td>
                                    <td style="background-color: #3CB371;" align="center">
                                        MAX MARKS
                                    </td>
                                    <td style="background-color: #3CB371;" align="center">
                                        PER(%)/GRADE/POINTS
                                    </td>
                                </tr>
                                <tr>
                                    <td class="caption" align="left" colspan="2">
                                        HIGH SCHOOL OR EQUIVALENT
                                    </td>
                                    <td align="center">
                                        <%=_TENUNI %>
                                    </td>
                                    <td align="center">
                                        <%=_TENYEAR %>
                                    </td>
                                    <td align="center">
                                        <%=_TENMO %>
                                    </td>
                                    <td align="center">
                                        <%=_TENMM %>
                                    </td>
                                    <td align="center">
                                        <%=_TENPER %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="caption" align="left" colspan="2">
                                        INTERMEDIATE OR EQUIVALENT
                                    </td>
                                    <td align="center">
                                        <%=_INTERUNI %>
                                    </td>
                                    <td align="center">
                                        <%=_INTERYEAR%>
                                    </td>
                                    <td align="center">
                                        <%=_INTERMO%>
                                    </td>
                                    <td align="center">
                                        <%=_INTERMM%>
                                    </td>
                                    <td align="center">
                                        <%=_INTERPER%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        UNDER GRADUATE
                                    </td>
                                    <td align="center">
                                        <%=_UG %>
                                    </td>
                                    <td align="center">
                                        <%=_UGUNI %>
                                    </td>
                                    <td align="center">
                                        <%=_UGYEAR%>
                                    </td>
                                    <td align="center">
                                        <%=_UGMO%>
                                    </td>
                                    <td align="center">
                                        <%=_UGMM%>
                                    </td>
                                    <td align="center">
                                        <%=_UGPER%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="caption" align="left">
                                        POST GRADUATE
                                    </td>
                                    <td align="center">
                                        <%=_PG %>
                                    </td>
                                    <td align="center">
                                        <%=_PGUNI %>
                                    </td>
                                    <td align="center">
                                        <%=_PGYEAR%>
                                    </td>
                                    <td align="center">
                                        <%=_PGMO%>
                                    </td>
                                    <td align="center">
                                        <%=_PGMM%>
                                    </td>
                                    <td align="center">
                                        <%=_PGPER%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="caption" align="left">
                                        OTHER'S
                                    </td>
                                    <td align="center">
                                        <%=_OTH %>
                                    </td>
                                    <td align="center">
                                        <%=_OUNI %>
                                    </td>
                                    <td align="center">
                                        <%=_OYEAR%>
                                    </td>
                                    <td align="center">
                                        <%=_OMO%>
                                    </td>
                                    <td align="center">
                                        <%=_OMM%>
                                    </td>
                                    <td align="center">
                                        <%=_OPER%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="justify" colspan="3" valign="middle" style="border-bottom: 1px solid #000000;">
                            I hereby declare that the particulars filled are true, correct and complete to the
                            best of my knowledge and belief and nothing has been concealed, In case any of the
                            information is found to be false, incorrect or misleading at any stage I shall have
                            no claim against cancellation of my candidature and/or taking other legal action
                            as deemed fit by U.B.T.E.R.
                        </td>
                        <td align="right" style="border-bottom: 1px solid #000000;">
                            <asp:Image ID="ImgSign" Height="60px" Width="220px" runat="server" /><br />
                            <b>( Signature of&nbsp; the Applicant )</b>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3" valign="middle" style="border-bottom: 1px solid #000000;">
                            <br />
                            <br />
                            <br />
                            <b>( H.O.D. Signature )</b>
                        </td>
                        <td align="right" valign="bottom" style="border-bottom: 1px solid #000000; height: 50px;">
                            <br />
                            <br />
                            <br />
                            <b>( Principal Signature )</b>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="left">
                            <b>Note:- </b>Please keep safe this application form in your college/Institute records.
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <br />
            <br />
        </div>
    </center>
    </form>
</body>
</html>

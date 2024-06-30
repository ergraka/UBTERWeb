<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Receiptbackpaper.aspx.cs"
    Inherits="Receiptbackpaper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Back Paper Form</title>
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
            <asp:ImageButton ID="Imglogout" ImageUrl="~/Images/Logout.png" Height="30px" Width="20px"
                runat="server" OnClick="Imglogout_Click" />
        </div>
        <div style="width: 95%; height: auto; background: url(../Images/Watermark.jpg); font-family: Cambria;
            background-repeat-x: no-repeat; background-repeat-y: no-repeat; background-position: center;">
            <table cellpadding="3" cellspacing="1" border="1" style="width: 100%;">
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
                    <th colspan="3" align="center" valign="middle" style="color: #000080; border-bottom: 1px solid #000000;
                        font-size: 18px;">
                        BACK PAPER APPLICATION FORM <%=CP %>
                    </th>
                    <td align="center" style="border-bottom: 1px solid #000000; border-left: 1px solid #000000;
                        border-bottom: 1px solid #000000;">
                        <asp:Image ID="ImgPH" Height="150px" Width="147px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle">
                        Registration Number
                    </th>
                    <td valign="middle" align="left" style="font-weight: bold;">
                        <%=_CANDIDATEID%>
                    </td>
                    <th align="left" valign="middle">
                        Roll Number
                    </th>
                    <th valign="middle" align="left">
                        <%=_ROLL%>
                    </th>
                </tr>
                <tr>
                    <th align="left" valign="middle">
                        NAME
                    </th>
                    <td valign="middle" align="left">
                        <%=_CANDIDATE_NAME%>
                    </td>
                    <th align="left" valign="middle">
                        Father's Name
                    </th>
                    <td align="left" valign="middle">
                        <%=_FATHER_NAME%>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle">
                        YEAR/SEMESTER
                    </th>
                    <td valign="middle" align="left">
                        <%=_SEM%>
                    </td>
                    <th align="left" valign="middle">
                        Shift
                    </th>
                    <th valign="middle" align="left">
                        <%=_SHIFT%>
                    </th>
                </tr>
                <tr>
                    <th align="left" valign="middle">
                        Institute Name
                    </th>
                    <td colspan="3" align="left" valign="middle">
                        <%=_INSTITUTE%>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle">
                        Branch Name
                    </th>
                    <td colspan="3" align="left" valign="middle">
                        <%=_BRANCH%>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle">
                        Date of Birth
                    </th>
                    <td valign="middle" align="left">
                        <%=_DOB%>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle">
                        Back Paper Fee
                    </th>
                    <td align="left" valign="middle">
                        <%=_BFEE%>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle">
                        Regular/Private
                    </th>
                    <td align="left" valign="middle">
                        <%=_REGPVT%>
                    </td>
                </tr>
                <tr>
                    <th colspan="4" align="left" style="background-color: #0000FF; color: #FFFFFF;">
                        APPLIED BACK PAPER DETAILS
                    </th>
                </tr>
                <tr>
                    <th colspan="4" align="left" valign="middle">
                        <b>
                            <%=_SUB %></b>
                    </th>
                </tr>
               <%-- <tr>
                    <th colspan="4" align="left" style="background-color: #FF0000; color: #FFFFFF;">
                        NOT-APPLIED BACK PAPER DETAILS
                    </th>
                </tr>
                <tr>
                    <th colspan="4" align="left" valign="middle">
                        <b>
                            <%=_SUBN %></b>
                    </th>
                </tr>--%>
                <tr>
                    <td align="justify" colspan="3" valign="middle" style="border-bottom: 1px solid #000000;">
                        I hereby declare that the particulars filled are true, correct and complete to the
                        best of my knowledge and belief and nothing has been concealed, In case any of the
                        information is found to be false, incorrect or misleading at any stage I shall have
                        no claim against cancellation of my candidature and/or taking other legal action
                        as deemed fit by U.B.T.E.R.
                    </td>
                    <td align="right" style="border-bottom: 1px solid #000000;">
                        <asp:Image ID="ImgSign" Height="60px" Width="200px" runat="server" /><br />
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
                    <td colspan="3" align="left">
                        <b>Note:- </b>Please keep safe this application form in your college/Institute records.
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </div>
    </center>
    </form>
</body>
</html>

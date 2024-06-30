<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Receiptscrutiny.aspx.cs"
    Inherits="Receiptscrutiny" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Scrutiny Receipt</title>
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
<body onload="noBack();">
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
        <div style="width: 90%;">
            <table border="1" style="width: 100%; border-collapse: collapse;">
                <tr class="linehead">
                    <td align="center">
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
            </table>
            <table class="table">
                <tr>
                    <td colspan="4" align="center" valign="middle" style="color: White; background-image: url(../Images/bg.jpg);
                        border-bottom: 1px solid #000000; font-size: 18px; font-weight: bold;">
                        SCRUTINY RECEIPT <%=CP %>
                    </td>
                </tr>
                <tr runat="server" id="TRSTAT">
                    <td colspan="4" align="center" style="color: #FF0000; height: auto; border-bottom: 1px solid #000000;">
                        Your Application form is still pending. Please approve your application form by
                        Branch H.O.D.
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle" style="height: 25px;">
                        Registration Number
                    </th>
                    <td valign="middle" align="left" style="font-weight: bold; height: 25px;">
                        <%=_CANDIDATEID%>
                    </td>
                    <th align="left" valign="middle" style="height: 25px;">
                        Roll Number
                    </th>
                    <th valign="middle" align="left" style="height: 25px;">
                        <%=_ROLL%>
                    </th>
                </tr>
                <tr>
                    <th align="left" valign="middle" style="height: 25px;">
                        Name
                    </th>
                    <td valign="middle" align="left" style="height: 25px;">
                        <%=_CANDIDATE_NAME%>
                    </td>
                    <th align="left" valign="middle" style="width: 256px; font-size: 15px; height: 25px;">
                        Father's Name
                    </th>
                    <td align="left" valign="middle" style="width: 256px; height: 25px;">
                        <%=_FATHER_NAME%>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle" style="height: 25px;">
                        Institute Name
                    </th>
                    <td colspan="3" align="left" valign="middle" style="height: 25px;">
                        <%=_INSTITUTE%>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle" style="height: 25px;">
                        Branch Name
                    </th>
                    <td colspan="3" align="left" valign="middle" style="height: 25px;">
                        <%=_BRANCH%>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle" style="width: 200px; height: 25px;">
                        Date of Birth
                    </th>
                    <td valign="middle" align="left" style="width: 300px; height: 25px;">
                        <%=_DOB%>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle" style="height: 25px;">
                        Fee
                    </th>
                    <td align="left" valign="middle" style="height: 25px;">
                        INR
                        <%=_FEE%>/-
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle" style="height: 25px;">
                        Scrutiny Subject
                    </th>
                    <td align="left" valign="middle" style="height: 25px;">
                        <%=_SUB%>
                    </td>
                </tr>
                <tr>
                    <th align="left" valign="middle" style="height: 25px;">
                        Printing Time
                    </th>
                    <td align="left" valign="middle" style="height: 25px;">
                        <%=indianTime%>
                    </td>
                </tr>
                <tr>
                    <td align="justify" colspan="4" valign="middle" style="font-size: 15px; border-bottom: 1px solid #000000;">
                        <br />
                        I hereby declare that the particulars filled are true, correct and complete to the
                        best of my knowledge and belief and nothing has been concealed, In case any of the
                        information is found to be false, incorrect or misleading at any stage I shall have
                        no claim against cancellation of my candidature and/or taking other legal action
                        as deemed fit by U.B.T.E.
                        <hr />
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

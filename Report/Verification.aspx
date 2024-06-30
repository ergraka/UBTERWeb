<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Verification.aspx.cs" Inherits="Verification" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Images/favicon.ico" rel="Icon File" />
    <title>Verification</title>
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
            <table cellpadding="0" cellspacing="0" style="width: 1024px;">
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
                    <th align="left" valign="middle" style="width: 130px;">
                        <%=ROLL %>
                    </th>
                    <td align="left" valign="middle" style="width: 130px;">
                        REGISTRATION NO:
                    </td>
                    <th align="left" valign="middle" style="width: 130px;">
                        <%=REG %>
                    </th>
                    <td rowspan="5" align="center" style="height: 230px; width: 150px;">
                        <asp:Image ID="Imgphver" runat="server" Height="160px" Width="140px" BorderColor="Black"
                            BorderStyle="Solid" BorderWidth="1px" />
                        <br />
                        <asp:Image ID="Imgsignver" runat="server" Height="40" Width="140px" BorderColor="Black"
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
                        <%=REGPVT%>
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
                    <td align="left" valign="middle" style="height: 30px;">
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
                    </th>
                </tr>
                <tr>
                    <td align="left" colspan="5" valign="middle" style="height: 30px; border-bottom: 1px solid #000000;">
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <asp:Image ID="Image2" runat="server" Height="80px" Width="250px" 
                             ImageUrl="~/Images/AdmitCardSign.png" />
                        
                        <br />
                        <br />
                        Note : * Back Papers.
                    </td>
                    <th colspan="1" align="center" valign="middle" style="border-bottom: 1px solid #000000;">
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        ( Sign & Seal of C.S./Principal )
                        <br />
                        <br />
                    </th>
                </tr>
            </table>
            --Please print in portrait format only--
        </div>
        <br />
        <br />
    </center>
    </form>
</body>
</html>

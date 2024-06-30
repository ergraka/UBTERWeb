<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Feestructure.aspx.cs" Inherits="Feestructure" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Fee Structure</title>
    <link href="../Content/Admin/css/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Admin/css/font-awesome.css" rel="stylesheet" />
    <link href="../Content/Admin/css/style.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <link href="../Images/favicon.ico" rel="Icon File" />
    <link href="../CSS/HeaderFooter.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Home.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/All.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Tab.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript">
        window.history.forward();
        function noBack() {
            if (!navigator.onLine) {
                document.body.innerHTML = 'Loading.....';
                window.location = 'Error.aspx';
            }
            window.history.forward();
        }
    </script>
</head>
<body onload="noBack();" oncontextmenu="return false" style="font-family: Cambria;
    font-size: 14px; color: #000000; margin: 0px">
    <form id="form1" runat="server">
    <center>
        <div style="width: 90%">
            <table width="100%" border="1" style="border-collapse: collapse">
                <tr class="linehead">
                    <td colspan="2" align="center">
                        <div class="row">
                            <div class="col-lg-3">
                                <img alt="Ubter" src="../Images/Logo.jpg" height="100px" />
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
            <table class="table" width="100%" align="center">
                <tr>
                    <td align="center" colspan="3" style="height: 20px; color: #FFFFFF; background-color: #008000;
                        font-weight: bold; font-size: 22px;" class="lineheader">
                        - FEE STRUCTURE -
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
                        Application From Fee
                    </td>
                    <th align="left" valign="middle">
                        500/-
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
                        Examination From Fee Private
                    </td>
                    <th align="left" valign="middle">
                        1000/-
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
                        Examination Fee for Government
                    </td>
                    <th align="left" valign="middle">
                        500/-
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
                        Marks Sheet Fee
                    </td>
                    <th align="left" valign="middle">
                        20/30 INR
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
                        Late Fee ( Per Application Form )
                    </td>
                    <th align="left" valign="middle">
                        100/-
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
                        Back Paper Fee (Per Subject)
                    </td>
                    <th align="left" valign="middle">
                        200/-
                    </th>
                </tr>
                <tr>
                    <td colspan="2" align="left" valign="middle" style="height: 30px;">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
                        Total Fee Government
                    </td>
                    <th align="left" valign="middle">
                        1020/1030 INR /-
                    </th>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="height: 30px;">
                        Total Fee Private
                    </td>
                    <th align="left" valign="middle">
                        1520/1530 INR /-
                    </th>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Label ID="LblMessage" Font-Size="15px" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                        <br />
                    </td>
                </tr>
            </table>
            <div id="SAN" style="width: 100%">
                <div class="container">
                    <div align="center">
                        Uttarakhand Board of Technical Education | &#169; All Rights Reserved | <%=System.DateTime.Now.Year %>
                    </div>
                </div>
            </div>
        </div>
    </center>
    </form>
</body>
</html>

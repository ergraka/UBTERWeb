<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Nominalbackpaper.aspx.cs"
    Inherits="Nominalbackpaper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Back Paper Nominal Roll</title>
    <link href="../Images/favicon.ico" rel="Icon File" />
    <link href="../CSS/HeaderFooter.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Home.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Homeother.css" type="text/css" rel="Stylesheet" />
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
<body onload="noBack();" oncontextmenu="return false" style="color: #000000">
    <form id="form1" runat="server">
    <center>
        <div class="noprint">
            <img src="../Images/Print.jpeg" alt="Click here to print Admit Card." id="btnprint"
                style="height: 30px; width: 25px;" onclick="javascript:alert('Please Print in Landscape format');javascript:window.print();" />
        </div>
        <div style="width: 95%;">
            <table style="width: 100%;">
                <tr>
                    <th colspan="2" align="center" style="font-family: Cambria; border-bottom: 1px solid #000000;
                        font-size: 16px">
                        <br />
                        UTTARAKHAND BOARD OF TECHNICAL EDUCATION , ROORKEE [ HARIDWAR ]<br />
                        ANNUAL / SEMESTER EXAMINATION<br />
                        (SUMMER - 2023)<br />
                        BACK PAPER NOMINAL ROLL
                        <br />
                        <br />
                    </th>
                </tr>
                <tr>
                    <th align="left" style="font-family: Cambria; font-size: 16px">
                        INSTITUTE NAME :
                    </th>
                    <td align="left" style="font-family: Cambria; font-size: 16px">
                        <%=INSNAME %>
                    </td>
                </tr>
                <tr>
                    <th align="left" style="font-family: Cambria; font-size: 16px">
                        BRANCH NAME :
                    </th>
                    <td align="left" style="font-family: Cambria; font-size: 16px">
                        <%=BRNAME %>
                    </td>
                </tr>
                <tr>
                    <th align="left" style="font-family: Cambria; font-size: 16px">
                        SEMESTER :
                    </th>
                    <td align="left" style="font-family: Cambria; font-size: 16px">
                        <%=TYPSEM %>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="border-top: 1px solid #000000;">
                        <br />
                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                    HeaderText="SRNO">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Width="2%" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                    HeaderText="REG NO" DataField="CANDIDATEID" />
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                    HeaderText="ROLL" DataField="ROLL" />
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                    HeaderText="CNAME" DataField="CNAME" />
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                    HeaderText="BRANCH" DataField="BRCODE" />
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                    HeaderText="APPLIED SUBJECT" DataField="SUBA" />
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                    HeaderText="NOT APPLIED SUBJECT" DataField="SUBN" />
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                    HeaderText="FEE" DataField="FEE" />
                            </Columns>
                        </asp:GridView>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="border-top: 1px solid #000000; font-family: Cambria;
                        height: 25px; font-size: 16px">
                        TOTAL FEE: &nbsp;&nbsp;&nbsp;<b><%=FEE %>&nbsp;/-</b>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="border-bottom: 1px solid #000000; font-family: Cambria;
                        height: 25px; font-size: 15px">
                        Printing Date: &nbsp;&nbsp;&nbsp;<b><%=DateTime.Now.ToString("dd/MM/yyyy") %></b>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="font-size: 15px; font-family: Cambria;">
                        <br />
                        <br />
                        <br />
                        <b>( H.O.D. Signature )</b>
                        <br />
                    </td>
                    <td align="right" valign="bottom" style="height: 50px; font-size: 15px; font-family: Cambria;">
                        <br />
                        <br />
                        <br />
                        <b>( Principal Signature )</b>
                        <br />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
    </center>
    </form>
</body>
</html>

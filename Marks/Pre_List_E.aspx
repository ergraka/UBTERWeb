<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pre_List_E.aspx.cs" Inherits="Marks_Pre_List_E" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::ROORKEE ANNUAL/SEMESTER EXAMINATION </title>
    <script src="../Scripts/Common.js" type="text/javascript" language="javascript"></script>
    <link rel="Icon" href="../Images/favicon.ico" />
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
</head>
<body onload="noBack();" oncontextmenu="return false" style="font-family: Cambria;
    color: #000000; margin: 0px">
    <form id="form1" runat="server">
    <center>
        <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table cellpadding="0" cellspacing="0" style="width: 1024px; background-color: #F5F5DC;">
                        <tr>
                            <td colspan="2" align="right" class="linehead" style="background-color: #008000;
                                color: #FFFFFF; width: 400px;">
                                <img alt="Uttarakhand" src="../Images/Logo.jpg" height="100px" />
                            </td>
                            <td align="center" class="linehead" style="background-color: #008000; color: #FFFFFF;
                                font-family: Agency FB; height: 60px; font-size: 25px;">
                                UTTARAKHAND BOARD OF TECHNICAL EDUCATION , ROORKEE [ HARIDWAR ]
                                <br />
                                <font style="color: #FFFFFF; font-family: Courier New; font-size: 16px;">ANNUAL / SEMESTER
                                    EXAMINATION<br />
                                    <font style="color: #D2B48C; font-family: Courier New;">( SUMMER / WINTER )</font>
                                </font>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" style="font-size: 18px; height: 25px; color: #000000;
                                background-color: #FFFFFF; font-family: Cambria; font-weight: bold;" valign="middle">
                                <hr />
                                <hr />
                                MARKS LIST-E [ PRACTICAL ]<br />
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2" align="left" valign="middle" style="font-size: 15px;">
                                &raquo;&nbsp;SELECT SUBJECT&nbsp;:<span style="color: #FF0000">*</span>
                            </th>
                            <td colspan="2" align="left" valign="middle" style="font-size: 15px;">
                                <asp:DropDownList ID="Drpsub" ValidationGroup="Reg" Width="320px" Font-Names="Cambria"
                                    runat="server">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Btnview" CssClass="butn" runat="server" Text="START" Height="30px"
                                    OnClick="Btnview_Click" />
                                &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                <asp:Label ID="Lblcount" ForeColor="#FF0000" Font-Names="Cambria" runat="server"
                                    Text="00"></asp:Label>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2" align="left" valign="middle" style="font-size: 15px;">
                                &raquo;&nbsp;INSTITUTE NAME&nbsp;:
                            </th>
                            <td colspan="2" align="left" valign="middle" style="font-size: 15px;">
                                <asp:Label ID="Lblins" Font-Names="Cambria" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2" align="left" valign="middle" style="font-size: 15px;">
                                &raquo;&nbsp;BRANCH NAME&nbsp;:
                            </th>
                            <td colspan="2" align="left" valign="middle" style="font-size: 15px;">
                                <asp:Label ID="Lblbranch" Font-Names="Cambria" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2" align="left" valign="middle" style="font-size: 15px;">
                                &raquo;&nbsp;SEMESTER&nbsp;/&nbsp;SHIFT:
                            </th>
                            <td colspan="2" align="left" valign="middle" style="font-size: 15px;">
                                <asp:Label ID="Lblsem" Font-Names="Cambria" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                                <asp:Label ID="Lblshift" Font-Names="Cambria" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2" align="left" valign="middle" style="font-size: 15px;">
                                &raquo;&nbsp;SUBJECT&nbsp;:
                            </th>
                            <td colspan="2" align="left" valign="middle" style="font-size: 15px;">
                                <asp:Label ID="Lblsub" Font-Names="Cambria" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2" align="left" valign="middle" style="font-size: 15px;">
                                &raquo;&nbsp;SUBJECT CODE&nbsp;:
                            </th>
                            <td colspan="2" align="left" valign="middle" style="font-size: 15px;">
                                <asp:Label ID="Lblsubcode" Font-Names="Cambria" runat="server" Text=""></asp:Label>
                                &nbsp;(&nbsp;Maximum:&nbsp;<asp:Label ID="Lblmax" Font-Names="Cambria" runat="server"
                                    Text=""></asp:Label>&nbsp;&nbsp;Minimum:&nbsp;<asp:Label ID="Lblmin" Font-Names="Cambria"
                                        runat="server" Text=""></asp:Label>&nbsp;)
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle" colspan="4">
                                <asp:GridView ID="Grddata" CssClass="grd" AllowPaging="True" Width="100%" runat="server"
                                    AutoGenerateColumns="False" OnPageIndexChanging="Grddata_PageIndexChanging" CellPadding="1"
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                    <Columns>
                                        <asp:BoundField HeaderText="REG. NO." DataField="CANDIDATEID" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        <asp:BoundField HeaderText="NAME" DataField="CNAME" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                        <asp:BoundField HeaderText="FATHER NAME" DataField="FNAME" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                        <asp:BoundField HeaderText="DOB" DataField="DOB" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                        <asp:BoundField HeaderText="SEX" DataField="GENDER" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        <asp:TemplateField HeaderText="MARKS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="Txtmarks" MaxLength="2" Font-Names="Cambria" Width="50px" onkeypress="return numbersonly(event)"
                                                    runat="server"></asp:TextBox>
                                                <%-- <asp:CheckBox ID="CbSelect" Text='<%# Eval("CANDIDATEID") %>' CssClass="gridCB" runat="server">
                                                </asp:CheckBox>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left"></PagerStyle>
                                    <RowStyle ForeColor="#000066"></RowStyle>
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                                    <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>
                                    <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>
                                    <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>
                                    <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle" colspan="4">
                                <br />
                                <hr />
                                <asp:Button ID="Btnsave" CssClass="butn" runat="server" Text="Save" Height="28px"
                                    Width="100px" OnClick="Btnsave_Click" />
                                <br />
                                <hr />
                                <br />
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Label ID="LblMessage" Font-Size="15px" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                <p style="color: #0000FF">
                                    - Please Do Not Refresh This Page -</p>
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    </form>
</body>
</html>

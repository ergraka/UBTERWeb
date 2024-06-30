<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Result_Search.aspx.cs" Inherits="Result_Result_Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UBTER : RESULT SEARCH </title>
    <script src="../Scripts/Common.js" type="text/javascript" language="javascript"></script>
    <link rel="Icon" href="../Images/favicon.ico" />
    <link href="../CSS/HeaderFooter.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Home.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Homeother.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript">
        function Name() {
            document.getElementById('Txtroll').value = "";
        }
        function Roll() {
            document.getElementById('Txtcname').value = "";
            document.getElementById('Drpday').value = 0;
            document.getElementById('Drpmonth').value = 0;
            document.getElementById('Drpyear').value = 0;
        }
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
    font-size: 15px; background-color: #F8F8F0; color: #000000; margin: 0px">
    <form id="form1" runat="server" autocomplete="off">
    <center>
        <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table cellpadding="0" cellspacing="0" style="width: 100%;">
                        <tr>
                            <td align="right" class="linehead" style="background-color: #008000; color: #FFFFFF;
                                width: 400px;">
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
                            <td colspan="2" align="center" style="border-bottom: 1px solid #000000; font-weight: bold;
                                font-size: 20px; background-color: #008080; color: #FFFFFF;">
                                RESULT CORRECTION SEARCH
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="1024px" cellpadding="0" cellspacing="4">
                        <tr>
                            <td align="left" valign="middle" style="height: 50px">
                                <img alt="Right Arrow" src="../Images/right.png" height="15px" width="20px" />
                                <asp:RadioButton ID="Rdoroll" Font-Size="17px" Text="SEARCH ON ROLL NUMBER" Checked="true"
                                    GroupName="Type" ForeColor="#0000FF" runat="server" />
                            </td>
                            <td align="left" valign="middle">
                                ENTER ROLL NUMBER:
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="Txtroll" Width="190px" MaxLength="11" onkeypress="return numbersonly(event)"
                                    onfocus="Roll()" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2" align="left" valign="middle">
                                <img alt="Right Arrow" src="../Images/right.png" height="15px" width="20px" />
                                <asp:RadioButton ID="Rdoname" Font-Size="17px" Text="SEARCH ON NAME & DOB" GroupName="Type"
                                    ForeColor="#0000FF" runat="server" />
                            </td>
                            <td align="left" valign="top">
                                ENTER CANDIDATE NAME:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtcname" onkeypress="return charsonly(event)" Width="190px" MaxLength="35"
                                    onfocus="Name()" CssClass="txtupper" runat="server"></asp:TextBox><span style="color: #FF0000;
                                        font-size: 12px;">&nbsp;&nbsp;[ Enter Atleast 3 Character of Name ]</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="middle">
                                DATE OF BIRTH:
                            </td>
                            <td align="left" valign="middle">
                                <asp:DropDownList ID="Drpday" ValidationGroup="Reg" Width="55px" runat="server">
                                    <asp:ListItem Value="0">Day</asp:ListItem>
                                    <asp:ListItem Value="01">01</asp:ListItem>
                                    <asp:ListItem Value="02">02</asp:ListItem>
                                    <asp:ListItem Value="03">03</asp:ListItem>
                                    <asp:ListItem Value="04">04</asp:ListItem>
                                    <asp:ListItem Value="05">05</asp:ListItem>
                                    <asp:ListItem Value="06">06</asp:ListItem>
                                    <asp:ListItem Value="07">07</asp:ListItem>
                                    <asp:ListItem Value="08">08</asp:ListItem>
                                    <asp:ListItem Value="09">09</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="11">11</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                    <asp:ListItem Value="13">13</asp:ListItem>
                                    <asp:ListItem Value="14">14</asp:ListItem>
                                    <asp:ListItem Value="15">15</asp:ListItem>
                                    <asp:ListItem Value="16">16</asp:ListItem>
                                    <asp:ListItem Value="17">17</asp:ListItem>
                                    <asp:ListItem Value="18">18</asp:ListItem>
                                    <asp:ListItem Value="19">19</asp:ListItem>
                                    <asp:ListItem Value="20">20</asp:ListItem>
                                    <asp:ListItem Value="21">21</asp:ListItem>
                                    <asp:ListItem Value="22">22</asp:ListItem>
                                    <asp:ListItem Value="23">23</asp:ListItem>
                                    <asp:ListItem Value="24">24</asp:ListItem>
                                    <asp:ListItem Value="25">25</asp:ListItem>
                                    <asp:ListItem Value="26">26</asp:ListItem>
                                    <asp:ListItem Value="27">27</asp:ListItem>
                                    <asp:ListItem Value="28">28</asp:ListItem>
                                    <asp:ListItem Value="29">29</asp:ListItem>
                                    <asp:ListItem Value="30">30</asp:ListItem>
                                    <asp:ListItem Value="31">31</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="Drpmonth" ValidationGroup="Reg" Width="70px" runat="server">
                                    <asp:ListItem Value="0">Month</asp:ListItem>
                                    <asp:ListItem Value="01">Jan</asp:ListItem>
                                    <asp:ListItem Value="02">Feb</asp:ListItem>
                                    <asp:ListItem Value="03">Mar</asp:ListItem>
                                    <asp:ListItem Value="04">Apr</asp:ListItem>
                                    <asp:ListItem Value="05">May</asp:ListItem>
                                    <asp:ListItem Value="06">Jun</asp:ListItem>
                                    <asp:ListItem Value="07">Jul</asp:ListItem>
                                    <asp:ListItem Value="08">Aug</asp:ListItem>
                                    <asp:ListItem Value="09">Sep</asp:ListItem>
                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="Drpyear" ValidationGroup="Reg" Width="65px" runat="server">
                                    <asp:ListItem Value="0">Year</asp:ListItem>
                                    <asp:ListItem Value="2015">2015</asp:ListItem>
                                    <asp:ListItem Value="2014">2014</asp:ListItem>
                                    <asp:ListItem Value="2013">2013</asp:ListItem>
                                    <asp:ListItem Value="2012">2012</asp:ListItem>
                                    <asp:ListItem Value="2011">2011</asp:ListItem>
                                    <asp:ListItem Value="2010">2010</asp:ListItem>
                                    <asp:ListItem Value="2009">2009</asp:ListItem>
                                    <asp:ListItem Value="2008">2008</asp:ListItem>
                                    <asp:ListItem Value="2007">2007</asp:ListItem>
                                    <asp:ListItem Value="2006">2006</asp:ListItem>
                                    <asp:ListItem Value="2005">2005</asp:ListItem>
                                    <asp:ListItem Value="2004">2004</asp:ListItem>
                                    <asp:ListItem Value="2003">2003</asp:ListItem>
                                    <asp:ListItem Value="2002">2002</asp:ListItem>
                                    <asp:ListItem Value="2001">2001</asp:ListItem>
                                    <asp:ListItem Value="2000">2000</asp:ListItem>
                                    <asp:ListItem Value="1999">1999</asp:ListItem>
                                    <asp:ListItem Value="1998">1998</asp:ListItem>
                                    <asp:ListItem Value="1997">1997</asp:ListItem>
                                    <asp:ListItem Value="1996">1996</asp:ListItem>
                                    <asp:ListItem Value="1995">1995</asp:ListItem>
                                    <asp:ListItem Value="1994">1994</asp:ListItem>
                                    <asp:ListItem Value="1993">1993</asp:ListItem>
                                    <asp:ListItem Value="1992">1992</asp:ListItem>
                                    <asp:ListItem Value="1991">1991</asp:ListItem>
                                    <asp:ListItem Value="1990">1990</asp:ListItem>
                                    <asp:ListItem Value="1989">1989</asp:ListItem>
                                    <asp:ListItem Value="1988">1988</asp:ListItem>
                                    <asp:ListItem Value="1987">1987</asp:ListItem>
                                    <asp:ListItem Value="1986">1986</asp:ListItem>
                                    <asp:ListItem Value="1985">1985</asp:ListItem>
                                    <asp:ListItem Value="1984">1984</asp:ListItem>
                                    <asp:ListItem Value="1983">1983</asp:ListItem>
                                    <asp:ListItem Value="1982">1982</asp:ListItem>
                                    <asp:ListItem Value="1981">1981</asp:ListItem>
                                    <asp:ListItem Value="1980">1980</asp:ListItem>
                                    <asp:ListItem Value="1979">1979</asp:ListItem>
                                    <asp:ListItem Value="1978">1978</asp:ListItem>
                                    <asp:ListItem Value="1977">1977</asp:ListItem>
                                    <asp:ListItem Value="1976">1976</asp:ListItem>
                                    <asp:ListItem Value="1975">1975</asp:ListItem>
                                    <asp:ListItem Value="1974">1974</asp:ListItem>
                                    <asp:ListItem Value="1973">1973</asp:ListItem>
                                    <asp:ListItem Value="1972">1972</asp:ListItem>
                                    <asp:ListItem Value="1971">1971</asp:ListItem>
                                    <asp:ListItem Value="1970">1970</asp:ListItem>
                                    <asp:ListItem Value="1969">1969</asp:ListItem>
                                    <asp:ListItem Value="1968">1968</asp:ListItem>
                                    <asp:ListItem Value="1967">1967</asp:ListItem>
                                    <asp:ListItem Value="1966">1966</asp:ListItem>
                                    <asp:ListItem Value="1965">1965</asp:ListItem>
                                    <asp:ListItem Value="1964">1964</asp:ListItem>
                                    <asp:ListItem Value="1963">1963</asp:ListItem>
                                    <asp:ListItem Value="1962">1962</asp:ListItem>
                                    <asp:ListItem Value="1961">1961</asp:ListItem>
                                    <asp:ListItem Value="1960">1960</asp:ListItem>
                                    <asp:ListItem Value="1959">1959</asp:ListItem>
                                    <asp:ListItem Value="1958">1958</asp:ListItem>
                                    <asp:ListItem Value="1957">1957</asp:ListItem>
                                    <asp:ListItem Value="1956">1956</asp:ListItem>
                                    <asp:ListItem Value="1955">1955</asp:ListItem>
                                    <asp:ListItem Value="1954">1954</asp:ListItem>
                                    <asp:ListItem Value="1953">1953</asp:ListItem>
                                    <asp:ListItem Value="1952">1952</asp:ListItem>
                                    <asp:ListItem Value="1951">1951</asp:ListItem>
                                    <asp:ListItem Value="1950">1950</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td align="left" valign="middle">
                                <br />
                                <asp:Button ID="Btnsubmit" CssClass="butn" runat="server" Text="Submit" Height="30px"
                                    OnClick="Btnsubmit_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <br />
                                <asp:Label ID="LblMessage" Font-Size="12px" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
                                <asp:GridView ID="Grddata" CssClass="grd" Width="900px" runat="server" AllowPaging="True"
                                    PagerSettings-Mode="Numeric" Font-Size="15px" AllowSorting="True" AutoGenerateColumns="False"
                                    CellPadding="4" OnPageIndexChanging="Grddata_PageIndexChanging" BackColor="White"
                                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
                                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                    <RowStyle ForeColor="#330099" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="ROLL" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:HyperLink Target="_blank" CssClass="Link" ID="HyperLink1" runat="server" Text='<%# Eval("CANDIDATEID") %>'
                                                    NavigateUrl='<%# "Result_Correction.aspx?RESULT="+Eval("CANDIDATEID") %>'></asp:HyperLink>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="CANDIDATE NAME" DataField="CNAME" HeaderStyle-HorizontalAlign="Left">
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="FATHER NAME" DataField="FNAME" HeaderStyle-HorizontalAlign="Left">
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="DOB" DataField="DOB" HeaderStyle-HorizontalAlign="Left">
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="GENDER" DataField="GENDER" HeaderStyle-HorizontalAlign="Left">
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="true" ForeColor="#663399" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="true" ForeColor="#FFFFCC" CssClass="txt" />
                                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <br />
        <br />
        <br />
        <div id="SAN" style="width: 1024px">
            <div class="container">
                <div align="right">
                    Uttarakhand Board of Technical Education | &#169; All Rights Reserved | 2019
                </div>
            </div>
        </div>
    </center>
    </form>
</body>
</html>

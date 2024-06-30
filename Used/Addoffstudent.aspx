<%@ Page Title="Offline Student" Language="C#" MasterPageFile="~/Institute/Default.master"
    AutoEventWireup="true" CodeFile="Addoffstudent.aspx.cs" Inherits="Addoffstudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" runat="server" EnableHistory="false" ></asp:ScriptManager>
    <i style="color: #FF0000; text-align: left;">NOTE:-<br />
        1.PLEASE COMPLETE ALL STEPS OF STUDENTS I.E(REGISTRATION, ADDRESS,QUALIFICATION,
        PHOTO SIGN)<br />
                1.All SBP Category Student will be Shown in "PASSED STUDENT" Tab.<br />
    </i>
    <center>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div>
                    <table align="center" cellpadding="3" cellspacing="5" style="width: 1024px; font-family: Cambria;
                        font-size: 15px;">
                        <tr>
                            <td colspan="4" align="center" class="lineheader" style="background-color: #008000;
                                height: 15px; font-size: 20px; color: #FFFFFF; font-weight: bold;">
                                -- ADD OFFLINE PRIVATE STUDENT TO ONLINE REGULAR --
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="middle">
                                <asp:Label ID="Lblsearch" runat="server" Text="Offline Roll Number:"></asp:Label>
                                <span style="color: #FF0000">*</span>
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="Txtjeeproll" CssClass="txt" Placeholder="Roll Number" MaxLength="11"
                                    Font-Names="Cambria" onkeypress="return numbersonly(event)" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                NAME:<span style="color: #FF0000">*</span>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtcname" ValidationGroup="Reg" Width="200px" Font-Names="Tahoma"
                                    CssClass="txtupper" placeholder="Name" onkeypress="return charsonly(event)" runat="server"
                                    MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Father NAME:<span style="color: #FF0000">*</span>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtfname" ValidationGroup="Reg" Width="200px" Font-Names="Tahoma"
                                    placeholder="Father Name" onkeypress="return charsonly(event)" runat="server"
                                    MaxLength="50" CssClass="txtupper"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Date of Birth:<span style="color: #FF0000">*</span>
                            </td>
                            <td align="left" valign="middle">
                                <asp:DropDownList ID="Drpday" Font-Names="Tahoma" ValidationGroup="Reg" Width="55px"
                                    runat="server">
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
                                <asp:DropDownList ID="Drpmonth" ValidationGroup="Reg" Width="65px" runat="server"
                                    Font-Names="Tahoma">
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
                                <asp:DropDownList ID="Drpyear" ValidationGroup="Reg" Width="65px" runat="server"
                                    Font-Names="Tahoma">
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
                            <td align="left">
                                Group:<span style="color: #FF0000">*</span>/Shift:<span style="color: #FF0000">*</span>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="Drpgrp" ValidationGroup="Reg" Width="60px" Font-Names="Cambria"
                                    runat="server">
                                    <asp:ListItem Value="0">Group</asp:ListItem>
                                    <asp:ListItem Value="E">E</asp:ListItem>
                                    <asp:ListItem Value="P">P</asp:ListItem>
                                    <asp:ListItem Value="H">H</asp:ListItem>
                                    <asp:ListItem Value="M">M</asp:ListItem>
                                    <asp:ListItem Value="G">G</asp:ListItem>
                                    <asp:ListItem Value="T">T</asp:ListItem>
                                    <asp:ListItem Value="A">A</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;
                                <asp:DropDownList ID="Drpshift" ValidationGroup="Reg" Width="80px" Font-Names="Cambria"
                                    runat="server">
                                    <asp:ListItem Value="0">-Shift-</asp:ListItem>
                                    <asp:ListItem Value="I">Shift-I</asp:ListItem>
                                    <asp:ListItem Value="II">Shift-II</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Semester/Year:<span style="color: #FF0000">*</span>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="Drpsem" ValidationGroup="Reg" Width="60px" Font-Names="Cambria"
                                    runat="server">
                                    <asp:ListItem Value="0">Sem</asp:ListItem>
                                    <asp:ListItem Value="01">01</asp:ListItem>
                                    <asp:ListItem Value="02">02</asp:ListItem>
                                    <asp:ListItem Value="03">03</asp:ListItem>
                                    <asp:ListItem Value="04">04</asp:ListItem>
                                    <asp:ListItem Value="05">05</asp:ListItem>
                                    <asp:ListItem Value="06">06</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Private/Regular/SBP:<span style="color: #FF0000">*</span>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="Drpprireg" ValidationGroup="Reg" Width="100px" Font-Names="Cambria"
                                    runat="server">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="P">Private</asp:ListItem>
                                    <asp:ListItem Value="R">Regular</asp:ListItem>
                                    <asp:ListItem Value="Q">SBP</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Registration Fee Submitted:<span style="color: #FF0000">*</span>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtfee" ValidationGroup="Reg" Width="100px" Font-Names="Tahoma"
                                    CssClass="txtupper" placeholder="Fee" onkeypress="return numbersonly(event)"
                                    runat="server" MaxLength="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Fee Submitted Date:<span style="color: #FF0000">*</span>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtfeedate" ValidationGroup="Reg" Width="200px" Font-Names="Tahoma"
                                    placeholder="DD/MM/YYYY" runat="server" MaxLength="10" CssClass="txtupper"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left" colspan="3">
                                <asp:Button ID="Btnadd" CssClass="butn" runat="server" Text="Click to Add" OnClick="Btnadd_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Label ID="ltrlMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr runat="server" id="TRUID">
                            <td colspan="4" align="center" valign="middle">
                                Registration No.:<asp:Label ID="Lblusename" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr runat="server" id="TRPASS">
                            <td colspan="4" align="center" valign="middle">
                                Login Password:<asp:Label ID="Lblpassword" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" style="background-color: #228B22; color: #FFFFFF;
                                font-size: 20px;">
                                Current Fee Structure
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="left" valign="middle">
                                Private Institute: 1520/-<br />
                                Government Institute: 1020/-
                                Late Fee : 100/- (if Required)
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left" colspan="3" style="color: #4B0082">
                                Note :-<br />
                                1.Please approve only those candidates who have submitted fee.<br />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>

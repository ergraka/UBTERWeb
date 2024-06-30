﻿<%@ Page Title="Add New Students" Language="C#" MasterPageFile="~/Admin/Admin.master"
    AutoEventWireup="true" CodeFile="Studentaddnew.aspx.cs" Inherits="Studentaddnew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <div class="Waiting">
                    <div class="center">
                        <img src="../Images/loading.gif" alt="Loading..." />
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div style="width: 95%">
                    <table width="100%" cellpadding="4">
                        <tr>
                            <td align="center" colspan="2">
                                <p class="panel-heading" style="background-image: url(../Images/bg.jpg); font-family: Agency FB;
                                    font-size: 25px; color: #FFFFFF;">
                                    <asp:Label ID="Lblcp" runat="server" Text=" -- Add New Student --"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Institute Name<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="Drpins" ValidationGroup="Reg" CssClass="Fontfill" AutoPostBack="true"
                                            runat="server" OnSelectedIndexChanged="Drpins_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Branch Name<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="Drpbranch" ValidationGroup="Reg" CssClass="Fontfill" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr runat="server" id="TRPVT" visible="false">
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Registration Category:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="Drpaddcat" ValidationGroup="Reg" CssClass="Fontfill" runat="server"
                                            AutoPostBack="True" OnSelectedIndexChanged="Drpaddcat_SelectedIndexChanged">
                                            <asp:ListItem Value="0">Qualification Category</asp:ListItem>
                                            <asp:ListItem Value="R">JEEP RANKER</asp:ListItem>
                                            <asp:ListItem Value="M">MINIMUM QUALIFICATION</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr runat="server" id="TRJEEPROLL" visible="false">
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        JEEP Roll Number:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox ID="Txtjeeproll" CssClass="Fontfill" Placeholder="JEEP ROLLNO" MaxLength="10"
                                            onkeypress="return numbersonly(event)" runat="server"></asp:TextBox>
                                        <asp:Button ID="Btnsearch" CssClass="btn" runat="server" Text="Search" OnClick="Btnsearch_Click" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <hr />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr id="TRCJEEP" runat="server">
                            <td>
                                <div class="row">
                                    <div class="col-lg-2">
                                        Current JEEP Roll No
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:Label ID="Lblcjeep" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        RANK
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox ID="Txtrank" ValidationGroup="Reg" placeholder="Rank" onkeypress="return charsonly(event)"
                                            runat="server" MaxLength="50" ReadOnly="true" CssClass="Fontfill"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-2">
                                        NAME:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox ID="Txtcname" ValidationGroup="Reg" CssClass="Fontfill" placeholder="Name"
                                            onkeypress="return charsonly(event)" runat="server" MaxLength="50"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        Father Name:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox ID="Txtfname" ValidationGroup="Reg" placeholder="Father Name" onkeypress="return charsonly(event)"
                                            runat="server" MaxLength="50" CssClass="Fontfill"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-2">
                                        Date of Birth:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:DropDownList ID="Drpday" CssClass="Fontfill" ValidationGroup="Reg" Width="80px"
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
                                        <asp:DropDownList ID="Drpmonth" ValidationGroup="Reg" Width="120px" runat="server"
                                            CssClass="Fontfill">
                                            <asp:ListItem Value="0">Month</asp:ListItem>
                                            <asp:ListItem Value="01">01-Jan</asp:ListItem>
                                            <asp:ListItem Value="02">02-Feb</asp:ListItem>
                                            <asp:ListItem Value="03">03-Mar</asp:ListItem>
                                            <asp:ListItem Value="04">04-Apr</asp:ListItem>
                                            <asp:ListItem Value="05">05-May</asp:ListItem>
                                            <asp:ListItem Value="06">06-Jun</asp:ListItem>
                                            <asp:ListItem Value="07">07-Jul</asp:ListItem>
                                            <asp:ListItem Value="08">08-Aug</asp:ListItem>
                                            <asp:ListItem Value="09">09-Sep</asp:ListItem>
                                            <asp:ListItem Value="10">10-Oct</asp:ListItem>
                                            <asp:ListItem Value="11">11-Nov</asp:ListItem>
                                            <asp:ListItem Value="12">12-Dec</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="Drpyear" ValidationGroup="Reg" Width="100px" runat="server"
                                            CssClass="Fontfill">
                                            <asp:ListItem Value="0">Year</asp:ListItem>
                                            <asp:ListItem Value="2022">2022</asp:ListItem>
                                            <asp:ListItem Value="2021">2021</asp:ListItem>
                                            <asp:ListItem Value="2020">2020</asp:ListItem>
                                            <asp:ListItem Value="2019">2019</asp:ListItem>
                                            <asp:ListItem Value="2018">2018</asp:ListItem>
                                            <asp:ListItem Value="2017">2017</asp:ListItem>
                                            <asp:ListItem Value="2016">2016</asp:ListItem>
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
                                    </div>
                                    <div class="col-lg-2">
                                        Group:<span style="color: #FF0000">*</span>/Shift:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:DropDownList ID="Drpgrp" ValidationGroup="Reg" Width="100px" CssClass="Fontfill"
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
                                        &nbsp;
                                        <asp:DropDownList ID="Drpshift" ValidationGroup="Reg" Width="200px" CssClass="Fontfill"
                                            runat="server">
                                            <asp:ListItem Value="0">-Shift-</asp:ListItem>
                                            <asp:ListItem Value="I">Shift-I</asp:ListItem>
                                            <asp:ListItem Value="II">Shift-II</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;
                                        <asp:Label ID="Lblregcat" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-2">
                                        FEE Submitted:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox ID="Txtfee" ValidationGroup="Reg" CssClass="Fontfill" placeholder="Fee"
                                            onkeypress="return numbersonly(event)" runat="server" MaxLength="4"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        Fee Submitted Date:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox ID="Txtfeedate" ValidationGroup="Reg" placeholder="DD/MM/YYYY" runat="server"
                                            MaxLength="10" CssClass="Fontfill"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-2">
                                        Session:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox ID="Txtsession" ValidationGroup="Reg" CssClass="Fontfill" placeholder="MM-YYYY"
                                             runat="server" MaxLength="7"></asp:TextBox>
                                    </div>
                                     <div class="col-lg-2">
                                        Roll:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:TextBox ID="Txtroll" ValidationGroup="Reg" CssClass="Fontfill" placeholder="Roll Number"
                                             runat="server" MaxLength="11"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <hr />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Button ID="Btnadd" CssClass="btn" runat="server" Text="Click to Add" OnClick="Btnadd_Click" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:Label ID="ltrlMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                    </div>
                                    <div class="col-lg-6">
                                        Registration No.:<asp:Label ID="Lblusename" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                    </div>
                                    <div class="col-lg-6">
                                        Login Password:<asp:Label ID="Lblpassword" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>
<%@ Page Language="C#" MasterPageFile="~/Student/Main.master" AutoEventWireup="true"
    CodeFile="Registration.aspx.cs" Inherits="Registration" Title="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" EnableHistory="false" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table width="100%" align="center" style="border: 1px solid #000000; font-family: Cambria;
                font-size: 15px;">
                <tr>
                    <td colspan="3" class="linktd" style="font-size: 16px; height: 25px; color: #FFFFFF;
                        background-color: #008000;" align="center" valign="middle">
                        <b>----- REGISTRATION FORM -----</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <hr />
                    </td>
                </tr>
                <tr runat="server" id="TR8">
                    <td align="right" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" valign="middle" style="font-size: 15px;">
                        Institute ID/Name/Type:
                    </td>
                    <td align="left" valign="middle">
                        <asp:Label ID="Lblinscode" ForeColor="#FF0000" runat="server" Text=""></asp:Label>&nbsp;/&nbsp;
                        <asp:Label ID="Lblinsname" ForeColor="#FF0000" runat="server" Text=""></asp:Label>&nbsp;/&nbsp;
                        <asp:Label ID="Lblregcat" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" valign="middle" style="font-size: 15px;">
                        Branch ID/Name/Shift:
                    </td>
                    <td align="left" valign="middle">
                        <asp:Label ID="Lblbrcode" ForeColor="#FF0000" runat="server" Text=""></asp:Label>&nbsp;/&nbsp;
                        <asp:Label ID="Lblbrname" ForeColor="#FF0000" runat="server" Text=""></asp:Label>&nbsp;/&nbsp;
                        <asp:Label ID="Lblshift" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" valign="middle" style="font-size: 15px;">
                        Registration Number / Group:
                    </td>
                    <td align="left" valign="middle">
                        <asp:Label ID="Lblregid" ForeColor="#FF0000" runat="server" Text=""></asp:Label>&nbsp;/&nbsp;
                        <asp:Label ID="Lblgroup" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" valign="middle" style="font-size: 15px;">
                        Student Name:<span style="color: #FF0000">*</span>
                    </td>
                    <td align="left" valign="middle">
                        <asp:TextBox ID="Txtcname" ValidationGroup="Reg" Width="200px" placeholder="NAME"
                            onkeypress="return charsonly(event)" runat="server" MaxLength="35" CssClass="txtupper"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" valign="middle" style="font-size: 15px;">
                        Father's Name:<span style="color: #FF0000">*</span>
                    </td>
                    <td align="left" valign="middle">
                        <asp:TextBox ID="Txtfathername" CssClass="txtupper" ValidationGroup="Reg" Width="200px"
                            placeholder="Father Name" onkeypress="return charsonly(event)" runat="server"
                            MaxLength="35"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" valign="middle" style="font-size: 15px;">
                        Date of Birth:<span style="color: #FF0000">*</span>
                    </td>
                    <td align="left" valign="middle">
                        <asp:DropDownList ID="Drpday" CssClass="txtupper" ValidationGroup="Reg" Width="55px" runat="server" OnSelectedIndexChanged="Drpday_SelectedIndexChanged"
                            AutoPostBack="True">
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
                        <asp:DropDownList ID="Drpmonth" CssClass="txtupper" ValidationGroup="Reg" Width="70px" runat="server"
                            OnSelectedIndexChanged="Drpmonth_SelectedIndexChanged" AutoPostBack="True">
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
                        <asp:DropDownList ID="Drpyear" CssClass="txtupper" ValidationGroup="Reg" Width="70px" runat="server">
                            <asp:ListItem Value="0">Year</asp:ListItem>
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
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" valign="middle" style="font-size: 15px;">
                        Gender:<span style="color: #FF0000">*</span>
                    </td>
                    <td align="left" valign="middle">
                        <asp:DropDownList ID="Drpgender" CssClass="txtupper" ValidationGroup="Reg" Width="230px" runat="server">
                            <asp:ListItem Value="0">Gender</asp:ListItem>
                            <asp:ListItem Value="M">MALE</asp:ListItem>
                            <asp:ListItem Value="F">FEMALE</asp:ListItem>
                            <asp:ListItem Value="T">TRANSGENDER</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr runat="server" id="TR3">
                    <td align="right" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" valign="middle" style="font-size: 15px;">
                        Category:<span style="color: #FF0000">*</span>
                    </td>
                    <td align="left" valign="middle">
                        <asp:DropDownList ID="Drpcat" CssClass="txtupper" ValidationGroup="Reg" Width="230px" runat="server">
                            <asp:ListItem Value="0">Category</asp:ListItem>
                            <asp:ListItem Value="GEN">General(GEN)</asp:ListItem>
                            <asp:ListItem Value="OBC">Other Backward Caste(OBC)</asp:ListItem>
                            <asp:ListItem Value="SC">Scheduled Caste(SC)</asp:ListItem>
                            <asp:ListItem Value="ST">Scheduled Tribes(ST)</asp:ListItem>
                            <asp:ListItem Value="EWS">Economically Weaker Section(EWS)</asp:ListItem>
                            <asp:ListItem Value="TFW">Tuition Fee Waiver(TFW)</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" valign="middle" style="font-size: 15px;">
                        Sub Category:<span style="color: #FF0000">*</span>
                    </td>
                    <td align="left" valign="middle">
                        <asp:DropDownList ID="Drpsubcat" CssClass="txtupper" ValidationGroup="Reg" Width="230px" runat="server">
                            <asp:ListItem Value="0">Sub Category</asp:ListItem>
                            <asp:ListItem Value="DFF">Dependent Freedom Fighter(D.F.F)</asp:ListItem>
                            <asp:ListItem Value="MP">Military Person(M.P)</asp:ListItem>
                            <asp:ListItem Value="PH">Physical Handicap(P.H)</asp:ListItem>
                            <asp:ListItem Value="WO">Women(WO)</asp:ListItem>
                            <asp:ListItem Value="N">None</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" valign="middle" style="font-size: 15px;">
                        Minority:<span style="color: #FF0000">*</span>
                    </td>
                    <td align="left" valign="middle">
                        <asp:DropDownList ID="Drpminority" CssClass="txtupper" ValidationGroup="Reg" Width="230px" runat="server">
                            <asp:ListItem Value="0">Select One</asp:ListItem>
                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                            <asp:ListItem Value="N">No</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" valign="middle" style="font-size: 15px;">
                        Nationality:<span style="color: #FF0000">*</span>
                    </td>
                    <td align="left" valign="middle">
                        <asp:DropDownList ID="DrpNationality" CssClass="txtupper" ValidationGroup="Reg" Width="230px" AutoPostBack="true"
                            runat="server" OnSelectedIndexChanged="DrpNationality_SelectedIndexChanged">
                            <asp:ListItem Value="0">Nationality</asp:ListItem>
                            <asp:ListItem Value="IND">Indian</asp:ListItem>
                            <asp:ListItem Value="OTH">Other</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LblNationalityOth" Font-Size="15px" runat="server" Visible="false"
                            Text="Others:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:TextBox ID="TxtNationalityOth" ValidationGroup="Reg" Width="200px" Visible="false" CssClass="txtupper"
                            placeholder="Nationality" onkeypress="return charsonly(event)" runat="server"
                            MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" valign="middle" style="font-size: 15px;">
                        Mobile Number :<span style="color: #FF0000">*</span>
                    </td>
                    <td align="left" valign="middle">
                        <asp:TextBox ID="TxtMono" ValidationGroup="Reg" Width="130px" CssClass="txtupper"
                            placeholder="Mobile number" onkeypress="return numbersonly(event)" runat="server"
                            MaxLength="10"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-size: 15px">Landline
                            Number :</span>
                        <asp:TextBox ID="Txtstdcode" ValidationGroup="Reg" Width="80px" CssClass="txtupper"
                            placeholder="Std Code" onkeypress="return numbersonly(event)" runat="server"
                            MaxLength="5"></asp:TextBox>
                        -
                        <asp:TextBox ID="TxtLLN" ValidationGroup="Reg" Width="130px" CssClass="txtupper"
                            placeholder="Landline Number" onkeypress="return numbersonly(event)" runat="server"
                            MaxLength="8"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td align="left" valign="middle" style="color: #FF0000; font-size: 12px;">
                        [ 10 Digit Mobile Number ] &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ Std Code - Landline
                        Number ]
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" valign="middle" style="font-size: 15px;">
                        EMail Address:<span style="color: #FF0000">*</span>&nbsp;/&nbsp;Confirm Email Address:<span
                            style="color: #FF0000">*</span>
                    </td>
                    <td align="left" valign="middle">
                        <asp:TextBox ID="Txtemail" ValidationGroup="Reg" Width="200px" placeholder="Enter Valid E-mail ID"
                            runat="server" MaxLength="50"></asp:TextBox>
                        &nbsp;
                        <asp:TextBox ID="Txtcemail" ValidationGroup="Reg" Width="200px" onCut="return false"
                            placeholder="Re-Enter E-mail ID" onCopy="return false" onPaste="return false"
                            runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" valign="middle" style="font-size: 15px;">
                        Aadhar Number:<span style="color: #FF0000">*</span>
                    </td>
                    <td align="left" valign="middle">
                        <asp:TextBox ID="Txtaadhar" ValidationGroup="Reg" CssClass="txtupper" Width="200px" placeholder="Aadhar Number"
                            runat="server" MaxLength="12"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                    </td>
                    <td align="left" valign="middle" style="font-size: 15px;">
                        Enter Below Text:<span style="color: #FF0000">*</span>
                    </td>
                    <td align="left" valign="middle">
                        <asp:TextBox ID="TxtCaptcha" MaxLength="6" Font-Size="16px" runat="server" placeholder="Below Text"
                            ValidationGroup="Reg" AutoComplete="off" Style="border: #7f9db9 1px solid; font-family: Arial;
                            width: 100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="middle" style="font-size: 15px;">
                    </td>
                    <td align="right" valign="middle">
                        <asp:ImageButton ID="Imgbtncapcha" ImageUrl="../Images/Refresh.png" Height="35px"
                            Width="30px" ValidationGroup="Reg" runat="server" CausesValidation="false" OnClick="Imgbtncapcha_Click" />
                    </td>
                    <td align="left" valign="middle">
                        <span style="color: #000000; font-size: 30px; font-style: oblique; background-image: url(../Images/Captcha.jpg);">
                            <asp:Label ID="Lblcaptch" runat="server" Text="Label"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" valign="middle" class="caption" align="left">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" ValidationGroup="Reg"
                            Text="Proceed >>" Font-Size="15px" OnClick="Button1_Click" />
                    </td>
                    <td align="left" valign="middle">
                        <asp:Label ID="ltrlMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" ValidationGroup="Reg"
        ShowMessageBox="true" runat="server" />
    <asp:RequiredFieldValidator ID="RFVName" Display="None" ValidationGroup="Reg" ControlToValidate="Txtcname"
        runat="server" ErrorMessage="Please Enter Name !"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RFVFatherName" Display="None" ValidationGroup="Reg"
        ControlToValidate="Txtfathername" runat="server" ErrorMessage="Please Enter Father Name !"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CVday" runat="server" Display="None" ValidationGroup="Reg"
        ErrorMessage="Please select Birth Date !" ControlToValidate="Drpday" ValueToCompare="0"
        Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
    <asp:CompareValidator ID="CVmonth" runat="server" Display="None" ValidationGroup="Reg"
        ErrorMessage="Please select Birth Month !" ControlToValidate="Drpmonth" ValueToCompare="0"
        Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
    <asp:CompareValidator ID="CVyear" runat="server" Display="None" ValidationGroup="Reg"
        ErrorMessage="Please select Birth Year!" ControlToValidate="Drpyear" ValueToCompare="0"
        Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
    <asp:CompareValidator ID="CVDrpgender" runat="server" Display="None" ValidationGroup="Reg"
        ErrorMessage="Please Select Gender." ControlToValidate="Drpgender" ValueToCompare="0"
        Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
    <asp:CompareValidator ID="CVDrpcat" runat="server" Display="None" ValidationGroup="Reg"
        ErrorMessage="Please select Category!" ControlToValidate="Drpcat" ValueToCompare="0"
        Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
    <asp:CompareValidator ID="CVDrpsubcat" runat="server" Display="None" ValidationGroup="Reg"
        ErrorMessage="Please select Sub Category!" ControlToValidate="Drpsubcat" ValueToCompare="0"
        Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
    <asp:CompareValidator ID="CvDrpminority" runat="server" Display="None" ValidationGroup="Reg"
        ErrorMessage="Please select Minority." ControlToValidate="Drpminority" ValueToCompare="0"
        Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
    <asp:CompareValidator ID="CVNATIONALITY" runat="server" Display="None" ValidationGroup="Reg"
        ErrorMessage="Please Select Nationality !" ControlToValidate="DrpNationality"
        ValueToCompare="0" Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
    <asp:RequiredFieldValidator ID="RFVMO" Display="None" ValidationGroup="Reg" ControlToValidate="TxtMono"
        runat="server" ErrorMessage="Please Enter Mobile Number !"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="Rfvemail" Display="None" ValidationGroup="Reg" ControlToValidate="Txtemail"
        runat="server" ErrorMessage="Please Enter Email Address !"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="Rfvcemail" Display="None" ValidationGroup="Reg" ControlToValidate="Txtcemail"
        runat="server" ErrorMessage="Please Enter Confirm Email Address !"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="REMail" Display="None" ValidationGroup="Reg"
        ControlToValidate="Txtemail" runat="server" ErrorMessage="Invalid E-Mail id !"
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="RECMail" Display="None" ValidationGroup="Reg"
        ControlToValidate="Txtcemail" runat="server" ErrorMessage="Invalid Confirm E-Mail id !"
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    <asp:CompareValidator ID="CVBemail" runat="server" Display="None" ValidationGroup="Reg"
        ErrorMessage="Confirm E-Mail id does not match !" ControlToCompare="Txtemail"
        ControlToValidate="Txtcemail"></asp:CompareValidator>
    <asp:RequiredFieldValidator ID="RFVTxtCaptcha" Display="None" ValidationGroup="Reg"
        ControlToValidate="TxtCaptcha" runat="server" ErrorMessage="Please Enter Captcha Value !"></asp:RequiredFieldValidator>
</asp:Content>

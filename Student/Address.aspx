<%@ Page Language="C#" MasterPageFile="~/Student/Main.master" AutoEventWireup="true"
    CodeFile="Address.aspx.cs" Inherits="Default2" Title="Candidate Address" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" runat="server" EnableHistory="false" ></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table width="98%" border="1" align="center" style="color: #000000; border-collapse: collapse;
                font-family: Cambria; font-size: 13px">
                <tr>
                    <td>
                        <table width="100%" align="center">
                            <tr>
                                <td align="center" colspan="3" style="height: 20px; color: #FFFFFF; background-color: #008000;
                                    font-weight: bold; font-size: 18px;" class="lineheader">
                                    CORRESPONDENCE ADDRESS DETAILS
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                                <td align="left" valign="middle" style="color: #FF0000; font-size: 13px; font-weight: bold;
                                    font-style: italic;">
                                    [Don't Enter Your Name In The Address Field's]
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                                </td>
                                <td align="left" valign="top" style="font-size: 18px; width: 300px;">
                                    Address :<span style="color: #FF0000">*</span>
                                </td>
                                <td align="left" style="width: 800px;">
                                    <asp:TextBox ID="Txtcaddress" TextMode="MultiLine" placeholder="Enter Correspondence Address"
                                        ValidationGroup="Reg" Width="95%" runat="server" MaxLength="100" Height="53px"
                                        CssClass="uppercase"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td align="right" valign="middle">
                                    <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                                </td>
                                <td align="left" valign="middle" style="font-size: 18px; width: 300px;">
                                    State:<span style="color: #FF0000">*</span>
                                </td>
                                <td align="left" valign="middle" style="font-size: 15px; text-transform: uppercase;
                                    width: 500px;">
                                    <asp:DropDownList ID="Drpcstate" AutoPostBack="true" ValidationGroup="Reg" Width="200px"
                                        CssClass="uppercase" runat="server" Font-Names="Cambria" OnSelectedIndexChanged="Drpcstate_SelectedIndexChanged">
                                        <asp:ListItem Value="0">SELECT STATE</asp:ListItem>
                                        <asp:ListItem Value="ANDAMAN AND NICOBAR ISLANDS">ANDAMAN AND NICOBAR ISLANDS</asp:ListItem>
                                        <asp:ListItem Value="ANDHRA PRADESH">ANDHRA PRADESH</asp:ListItem>
                                        <asp:ListItem Value="ARUNACHAL PRADESH">ARUNACHAL PRADESH</asp:ListItem>
                                        <asp:ListItem Value="ASSAM">ASSAM</asp:ListItem>
                                        <asp:ListItem Value="BIHAR">BIHAR</asp:ListItem>
                                        <asp:ListItem Value="CHANDIGARH">CHANDIGARH</asp:ListItem>
                                        <asp:ListItem Value="CHATTISGARH">CHATTISGARH</asp:ListItem>
                                        <asp:ListItem Value="DADRA AND NAGAR HAVELI">DADRA AND NAGAR HAVELI</asp:ListItem>
                                        <asp:ListItem Value="DAMAN AND DIU">DAMAN AND DIU</asp:ListItem>
                                        <asp:ListItem Value="DELHI">DELHI</asp:ListItem>
                                        <asp:ListItem Value="GOA">GOA</asp:ListItem>
                                        <asp:ListItem Value="GUJARAT">GUJARAT</asp:ListItem>
                                        <asp:ListItem Value="HARYANA">HARYANA</asp:ListItem>
                                        <asp:ListItem Value="HIMACHAL PRADESH">HIMACHAL PRADESH</asp:ListItem>
                                        <asp:ListItem Value="JAMMU AND KASHMIR">JAMMU AND KASHMIR</asp:ListItem>
                                        <asp:ListItem Value="jharkhand">jharkhand</asp:ListItem>
                                        <asp:ListItem Value="karnataka">karnataka</asp:ListItem>
                                        <asp:ListItem Value="kerala">kerala</asp:ListItem>
                                        <asp:ListItem Value="lakshadweep">lakshadweep</asp:ListItem>
                                        <asp:ListItem Value="madhya pradesh">madhya pradesh</asp:ListItem>
                                        <asp:ListItem Value="maharashtra">maharashtra</asp:ListItem>
                                        <asp:ListItem Value="manipur">manipur</asp:ListItem>
                                        <asp:ListItem Value="meghalaya">meghalaya</asp:ListItem>
                                        <asp:ListItem Value="mizoram">mizoram</asp:ListItem>
                                        <asp:ListItem Value="nagaland">nagaland</asp:ListItem>
                                        <asp:ListItem Value="orissa">orissa</asp:ListItem>
                                        <asp:ListItem Value="pondicherry">pondicherry</asp:ListItem>
                                        <asp:ListItem Value="punjab">punjab</asp:ListItem>
                                        <asp:ListItem Value="rajasthan">rajasthan</asp:ListItem>
                                        <asp:ListItem Value="sikkim">sikkim</asp:ListItem>
                                        <asp:ListItem Value="tamil nadu">tamil nadu</asp:ListItem>
                                        <asp:ListItem Value="tripura">tripura</asp:ListItem>
                                        <asp:ListItem Value="uttarakhand">uttarakhand</asp:ListItem>
                                        <asp:ListItem Value="uttar Pradesh">uttar Pradesh</asp:ListItem>
                                        <asp:ListItem Value="west bengal">west bengal</asp:ListItem>
                                        <asp:ListItem Value="other">other</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="Txtcother" Width="200px" Font-Names="Tahoma" placeholder="other"
                                        Visible="false" onkeypress="return charsonly(event)" runat="server" MaxLength="100"
                                        CssClass="uppercase"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td align="right" valign="middle">
                                    <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                                </td>
                                <td align="left" valign="middle" style="font-size: 18px; width: 300px;">
                                    District :<span style="color: #FF0000">*</span>
                                </td>
                                <td align="left" valign="middle" style="font-size: 15px; margin-left: 40px;">
                                    <asp:DropDownList ID="Drpcdistname" ValidationGroup="Reg" Width="200px" Font-Names="Tahoma"
                                        runat="server">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="Txtcdistname" Visible="false" placeholder="Enter District name"
                                        Width="200px" runat="server" ValidationGroup="Reg" onkeypress="return charsonly(event)"
                                        MaxLength="50" CssClass="uppercase"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td align="right" valign="middle">
                                    <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                                </td>
                                <td align="left" valign="middle" style="font-size: 18px; width: 300px;">
                                    Tehsil :<span style="color: #FF0000">*</span>
                                </td>
                                <td align="left" valign="middle" style="font-size: 15px;">
                                    <asp:DropDownList ID="Drpctehsil" ValidationGroup="Reg" Width="200px" Font-Names="Tahoma"
                                        runat="server">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="Txtctehsil" Visible="false" placeholder="Enter Tehsil name" Width="200px"
                                        runat="server" ValidationGroup="Reg" onkeypress="return charsonly(event)" MaxLength="35"
                                        CssClass="uppercase"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td align="right" valign="middle">
                                    <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                                </td>
                                <td align="left" valign="middle" style="font-size: 18px; width: 300px;">
                                    Block :<span style="color: #FF0000">*</span>
                                </td>
                                <td align="left" valign="middle" style="font-size: 15px;">
                                    <asp:DropDownList ID="Drpcblock" ValidationGroup="Reg" Width="200px" Font-Names="Tahoma"
                                        runat="server">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="Txtcblock" Visible="false" placeholder="Enter Block name" Width="200px"
                                        runat="server" ValidationGroup="Reg" onkeypress="return charsonly(event)" MaxLength="35"
                                        CssClass="uppercase"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td align="right" valign="middle">
                                    <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                                </td>
                                <td align="left" valign="middle" style="font-size: 18px; width: 300px;">
                                    Pin Code:<span style="color: #FF0000">*</span>
                                </td>
                                <td align="left" valign="middle" style="font-size: 18px; width: 300px;">
                                    <asp:TextBox ID="Txtcpin" onkeypress="return numbersonly(event)" placeholder="Enter Pin Code"
                                        ValidationGroup="Reg" Width="200px" MaxLength="6" runat="server" CssClass="uppercase"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table width="100%" align="center">
                            <tr>
                                <td align="center" colspan="3" style="height: 20px; color: #FFFFFF; background-color: #008000;"
                                    class="lineheader">
                                    <asp:CheckBox ID="CheckBox1" CssClass="lineheader" Width="100%" BackColor="#FFFFFF"
                                        Font-Size="15px" Font-Names="Cambria" Text="Permanent Address same as Correspondence Address ?"
                                        ValidationGroup="Reg" runat="server" ForeColor="#FFFFFF" AutoPostBack="True"
                                        OnCheckedChanged="CheckBox1_CheckedChanged" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                                <td align="left" valign="middle" style="color: #FF0000; font-size: 13px; font-weight: bold;
                                    font-style: italic;">
                                    [Don't Enter Your Name In The Address Field's]
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                                </td>
                                <td align="left" valign="top" style="font-size: 18px; width: 300px;">
                                    Address :<span style="color: #FF0000">*</span>
                                </td>
                                <td align="left" style="width: 500px;">
                                    <asp:TextBox ID="Txtpaddress" TextMode="MultiLine" placeholder="Enter Permanent Address"
                                        ValidationGroup="Reg" Width="95%" runat="server" MaxLength="100" Height="53px"
                                        CssClass="uppercase"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td align="right" valign="middle">
                                    <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                                </td>
                                <td align="left" valign="middle" style="font-size: 18px; width: 300px;">
                                    State:<span style="color: #FF0000">*</span>
                                </td>
                                <td align="left" valign="middle" style="font-size: 15px; text-transform: uppercase;
                                    width: 300px;">
                                    <asp:DropDownList ID="Drppstate" AutoPostBack="true" ValidationGroup="Reg" Width="200px"
                                        Font-Names="Cambria" CssClass="uppercase" runat="server" OnSelectedIndexChanged="Drppstate_SelectedIndexChanged">
                                        <asp:ListItem Value="0">select state</asp:ListItem>
                                        <asp:ListItem Value="andaman and nicobar islands">andaman and nicobar islands</asp:ListItem>
                                        <asp:ListItem Value="andhra pradesh">andhra pradesh</asp:ListItem>
                                        <asp:ListItem Value="arunachal pradesh">arunachal pradesh</asp:ListItem>
                                        <asp:ListItem Value="assam">assam</asp:ListItem>
                                        <asp:ListItem Value="bihar">bihar</asp:ListItem>
                                        <asp:ListItem Value="chandigarh">chandigarh</asp:ListItem>
                                        <asp:ListItem Value="chattisgarh">chattisgarh</asp:ListItem>
                                        <asp:ListItem Value="dadra and nagar haveli">dadra and nagar haveli</asp:ListItem>
                                        <asp:ListItem Value="daman and diu">daman and diu</asp:ListItem>
                                        <asp:ListItem Value="delhi">delhi</asp:ListItem>
                                        <asp:ListItem Value="goa">goa</asp:ListItem>
                                        <asp:ListItem Value="gujarat">gujarat</asp:ListItem>
                                        <asp:ListItem Value="haryana">haryana</asp:ListItem>
                                        <asp:ListItem Value="himachal pradesh">himachal pradesh</asp:ListItem>
                                        <asp:ListItem Value="jammu and kashmir">jammu and kashmir</asp:ListItem>
                                        <asp:ListItem Value="jharkhand">jharkhand</asp:ListItem>
                                        <asp:ListItem Value="karnataka">karnataka</asp:ListItem>
                                        <asp:ListItem Value="kerala">kerala</asp:ListItem>
                                        <asp:ListItem Value="lakshadweep">lakshadweep</asp:ListItem>
                                        <asp:ListItem Value="madhya pradesh">madhya pradesh</asp:ListItem>
                                        <asp:ListItem Value="maharashtra">maharashtra</asp:ListItem>
                                        <asp:ListItem Value="manipur">manipur</asp:ListItem>
                                        <asp:ListItem Value="meghalaya">meghalaya</asp:ListItem>
                                        <asp:ListItem Value="mizoram">mizoram</asp:ListItem>
                                        <asp:ListItem Value="nagaland">nagaland</asp:ListItem>
                                        <asp:ListItem Value="orissa">orissa</asp:ListItem>
                                        <asp:ListItem Value="pondicherry">pondicherry</asp:ListItem>
                                        <asp:ListItem Value="punjab">punjab</asp:ListItem>
                                        <asp:ListItem Value="rajasthan">rajasthan</asp:ListItem>
                                        <asp:ListItem Value="sikkim">sikkim</asp:ListItem>
                                        <asp:ListItem Value="tamil nadu">tamil nadu</asp:ListItem>
                                        <asp:ListItem Value="tripura">tripura</asp:ListItem>
                                        <asp:ListItem Value="uttarakhand">uttarakhand</asp:ListItem>
                                        <asp:ListItem Value="uttar Pradesh">uttar Pradesh</asp:ListItem>
                                        <asp:ListItem Value="west bengal">west bengal</asp:ListItem>
                                        <asp:ListItem Value="other">other</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="Txtpother" Width="200px" Font-Names="Tahoma" placeholder="other"
                                        Visible="false" onkeypress="return charsonly(event)" runat="server" MaxLength="100"
                                        CssClass="uppercase"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td align="right" valign="middle">
                                    <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                                </td>
                                <td align="left" valign="middle" style="font-size: 18px; width: 300px;">
                                    District :<span style="color: #FF0000">*</span>
                                </td>
                                <td align="left" valign="middle" style="font-size: 15px;">
                                    <asp:DropDownList ID="Drppdistname" ValidationGroup="Reg" Width="200px" Font-Names="Tahoma"
                                        runat="server">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="Txtpdistname" Visible="false" placeholder="Enter District name"
                                        Width="200px" runat="server" ValidationGroup="Reg" onkeypress="return charsonly(event)"
                                        MaxLength="50" CssClass="uppercase"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td align="right" valign="middle">
                                    <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                                </td>
                                <td align="left" valign="middle" style="font-size: 18px; width: 300px;">
                                    Tehsil :<span style="color: #FF0000">*</span>
                                </td>
                                <td align="left" valign="middle" style="font-size: 15px;">
                                    <asp:DropDownList ID="Drpptehsil" ValidationGroup="Reg" Width="200px" Font-Names="Tahoma"
                                        runat="server">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="Txtptehsil" Visible="false" placeholder="Enter Tehsil name" Width="200px"
                                        runat="server" ValidationGroup="Reg" onkeypress="return charsonly(event)" MaxLength="35"
                                        CssClass="uppercase"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td align="right" valign="middle">
                                    <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                                </td>
                                <td align="left" valign="middle" style="font-size: 18px; width: 300px;">
                                    Block :<span style="color: #FF0000">*</span>
                                </td>
                                <td align="left" valign="middle" style="font-size: 15px;">
                                    <asp:DropDownList ID="Drppblock" ValidationGroup="Reg" Width="200px" Font-Names="Tahoma"
                                        runat="server">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="Txtpblock" Visible="false" placeholder="Enter Block name" Width="200px"
                                        runat="server" ValidationGroup="Reg" onkeypress="return charsonly(event)" MaxLength="35"
                                        CssClass="uppercase"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 30px;">
                                <td align="right" valign="middle">
                                    <img alt="Right Arrow" src="../Images/right.png" height="35px" width="30px" />
                                </td>
                                <td align="left" valign="middle" style="font-size: 18px; width: 300px;">
                                    Pin Code:<span style="color: #FF0000">*</span>
                                </td>
                                <td align="left" valign="middle" style="font-size: 15px; width: 300px;">
                                    <asp:TextBox ID="Txtppin" onkeypress="return numbersonly(event)" placeholder="Enter Pin Code"
                                        ValidationGroup="Reg" Width="200px" MaxLength="6" runat="server" CssClass="uppercase"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="caption" valign="middle" align="left" style="height: 50px">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Continue" ValidationGroup="Reg"
                            Font-Bold="True" Font-Size="15px" Width="100px" OnClick="Button1_Click" />
                    </td>
                    <td align="left">
                        <asp:Label ID="ltrlMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ValidationSummary ID="ValidationSummary1" ShowSummary="false" ValidationGroup="Reg"
        ShowMessageBox="true" runat="server" />
    <asp:RequiredFieldValidator ID="RFVCaddress" Display="None" ValidationGroup="Reg"
        ControlToValidate="Txtcaddress" runat="server" ErrorMessage="Please Enter Correspondence Address !"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CVDrpcstate" runat="server" Display="None" ValidationGroup="Reg"
        ErrorMessage="Please Select Correspondence State !" ControlToValidate="Drpcstate"
        ValueToCompare="0" Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
    <asp:RequiredFieldValidator ID="RFVCDIST" Display="None" ValidationGroup="Reg" ControlToValidate="Txtcdistname"
        runat="server" ErrorMessage="Please Enter Correspondence District !"></asp:RequiredFieldValidator>
   
    <asp:RequiredFieldValidator ID="RFVTehsil" Display="None" ValidationGroup="Reg" ControlToValidate="Txtptehsil"
        runat="server" ErrorMessage="Please Enter Correspondence Tehsil !"></asp:RequiredFieldValidator>
   <asp:RequiredFieldValidator ID="RFVBlock" Display="None" ValidationGroup="Reg" ControlToValidate="Txtpblock"
        runat="server" ErrorMessage="Please Enter Correspondence Block !"></asp:RequiredFieldValidator>
   
    
     <asp:RequiredFieldValidator ID="RFVCPIN" Display="None" ValidationGroup="Reg" ControlToValidate="Txtcpin"
        runat="server" ErrorMessage="Please Enter Correspondence Pin !"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RFVPADD" Display="None" ValidationGroup="Reg" ControlToValidate="Txtpaddress"
        runat="server" ErrorMessage="Please Enter Permanent Address !"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CVPSTATE" runat="server" Display="None" ValidationGroup="Reg"
        ErrorMessage="Please Select Permanent State !" ControlToValidate="Drppstate"
        ValueToCompare="0" Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
   <%-- <asp:RequiredFieldValidator ID="RFVPDIST" Display="None" ValidationGroup="Reg" ControlToValidate="Txtpdistname"
        runat="server" ErrorMessage="Please Enter Permanent District !"></asp:RequiredFieldValidator>--%>
  <%--  <asp:RequiredFieldValidator ID="RFVPPIN" Display="None" ValidationGroup="Reg" ControlToValidate="Txtppin"
        runat="server" ErrorMessage="Please Enter Permanent Pin !"></asp:RequiredFieldValidator>--%>
    <asp:RegularExpressionValidator Display="None" ValidationGroup="Reg" ControlToValidate="Txtcpin"
        ID="REcorpin" ValidationExpression="^[\s\S]{6,6}$" runat="server" ErrorMessage="Correspondence pin must be 6 characters."></asp:RegularExpressionValidator>
   <%-- <asp:RegularExpressionValidator Display="None" ValidationGroup="Reg" ControlToValidate="Txtppin"
        ID="Reppin" ValidationExpression="^[\s\S]{6,6}$" runat="server" ErrorMessage="Permanent pin must be 6 characters."></asp:RegularExpressionValidator>--%>
</asp:Content>

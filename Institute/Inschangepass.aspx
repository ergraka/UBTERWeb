<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inschangepass.aspx.cs" Inherits="Inschangepass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>::ROORKEE ANNUAL/SEMESTER EXAMINATION </title>
    <link href="../Images/favicon.ico" rel="Icon File" />
    <link href="../CSS/HeaderFooter.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/Home.css" type="text/css" rel="Stylesheet" />
    <link href="../CSS/All.css" type="text/css" rel="Stylesheet" />
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
<body onload="noBack();" oncontextmenu="return false" style="font-family: Tahoma;
    margin: 0px">
    <form id="form1" runat="server" enctype="multipart/form-data" autocomplete="off">
    <center>
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
        </table>
        <div style="width: 1024px; border-left: 1px solid #000000; border-right: 1px solid #000000;">
            <p class="linehead" style="font-family: Arial; color: #000000; border: 1px solid #0000FF;"
                align="center">
                <i>
                    <asp:Label ID="Lblins" ForeColor="#FFFFFF" runat="server" Font-Size="20px" Text="INSTITUTE NAME"></asp:Label>-<asp:LinkButton
                        ID="Lnklogin" ForeColor="#FF0000 " runat="server" OnClick="Lnklogin_Click">Logout !</asp:LinkButton>
                </i>
            </p>
            <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                        <ProgressTemplate>
                            <div class="Waiting">
                                <div class="center">
                                    <img src="../Images/loading.gif" alt="Loading..." />
                                </div>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <table style="font-family: verdana; font-size: 12px; width: 900px;" border="0">
                        <tr>
                            <td align="left" style="font-size: 15px; width: 300px;">
                                Old Password<span style="color: #FF0000">*</span>
                            </td>
                            <td align="right" valign="middle">
                                <img alt="Right Arrow" src="../Images/right.jpg" height="35px" width="30px" />
                            </td>
                            <td align="left" style="width: 500px">
                                <asp:TextBox ID="Txtpassword" ValidationGroup="Reg" Width="200px" Font-Names="Tahoma"
                                    placeholder="Old Password" runat="server" TextMode="Password" MaxLength="12"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="font-size: 15px;">
                                New Password<span style="color: #FF0000">*</span>
                            </td>
                            <td align="right" valign="middle">
                                <img alt="Right Arrow" src="../Images/right.jpg" height="35px" width="30px" />
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtnpassword" ValidationGroup="Reg" Width="200px" Font-Names="Tahoma"
                                    placeholder="New Password" runat="server" TextMode="Password" MaxLength="12"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="font-size: 15px;">
                                Confirm Password<span style="color: #FF0000">*</span>
                            </td>
                            <td align="right" valign="middle">
                                <img alt="Right Arrow" src="../Images/right.jpg" height="35px" width="30px" />
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtcpassword" ValidationGroup="Reg" Width="200px" Font-Names="Tahoma"
                                    placeholder="Confirm Password" runat="server" TextMode="Password" MaxLength="12"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="middle" style="font-family: Tahoma; font-size: 15px;">
                                Mobile Number :<span style="color: #FF0000">*</span>
                            </td>
                            <td align="right" valign="middle">
                                <img alt="Right Arrow" src="../Images/right.jpg" height="35px" width="30px" />
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="TxtMono" ValidationGroup="Reg" Width="100px" Font-Names="Tahoma"
                                    placeholder="Mobile number" onkeypress="return numbersonly(event)" runat="server"
                                    MaxLength="10"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-family: Tahoma;
                                    font-size: 15px">Landline Number :</span><span style="color: #FF0000">*</span>
                                <asp:TextBox ID="Txtstdcode" ValidationGroup="Reg" Width="50px" Font-Names="Tahoma"
                                    placeholder="Std Code" onkeypress="return numbersonly(event)" runat="server"
                                    MaxLength="5"></asp:TextBox>
                                -
                                <asp:TextBox ID="TxtLLN" ValidationGroup="Reg" Width="100px" Font-Names="Tahoma"
                                    placeholder="Landline Number" onkeypress="return numbersonly(event)" runat="server"
                                    MaxLength="8"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                            <td align="left" valign="middle" style="font-family: Tahoma; color: #FF0000; font-size: 12px;">
                                [ 10 Digit Mobile Number ] &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ Std Code
                                - Landline Number ]
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="middle" style="font-family: Tahoma; font-size: 15px;">
                                Email Address:<span style="color: #FF0000">*</span>&nbsp;/&nbsp;Confirm Email Address:<span
                                    style="color: #FF0000">*</span>
                            </td>
                            <td align="right" valign="middle">
                                <img alt="Right Arrow" src="../Images/right.jpg" height="35px" width="30px" />
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="Txtemail" ValidationGroup="Reg" Width="200px" Font-Names="Tahoma"
                                    placeholder="Enter Valid E-mail ID" runat="server" MaxLength="50"></asp:TextBox>
                                &nbsp;
                                <asp:TextBox ID="Txtcemail" ValidationGroup="Reg" Width="200px" Font-Names="Tahoma"
                                    onCut="return false" placeholder="Re-Enter E-mail ID" onCopy="return false" onPaste="return false"
                                    runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center" valign="middle" style="height: 50px; background-color: #BDB76B;
                                border-top-left-radius: 20px; border-top-right-radius: 20px;">
                                <asp:ImageButton ID="ImageButton1" runat="server" Width="30px" Height="30px" Font-Size="16px"
                                    CausesValidation="false" ValidationGroup="Reg" OnClick="Button1_Click" ImageUrl="~/Images/A29-CurvedArrow-Green.png" />
                                &nbsp;&nbsp;
                                <asp:Label ID="Lblcaptcha" ForeColor="#FFFFFF" Style="text-align: center" Font-Size="30px"
                                    runat="server" Height="27px" Width="100px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center" style="height: 50px; background-color: #BDB76B; color: #DC143C;
                                border-bottom-left-radius: 20px; border-bottom-right-radius: 20px;">
                                Type the above 6th digit characters in the below Text field.
                                <br />
                                <br />
                                <asp:TextBox ID="Txtcaptcha" CssClass="txtbox" MaxLength="6" Font-Size="16px" runat="server"
                                    placeholder="Enter Text" ValidationGroup="Reg" AutoComplete="off" Style="border: #7f9db9 1px solid;
                                    font-family: Arial; width: 100px"></asp:TextBox>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Label ID="ltrlMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                            </td>
                            <td colspan="2" align="left">
                                <asp:Button ID="btnSubmit" CssClass="butn" runat="server" ValidationGroup="Reg" OnClick="btnSubmit_Click"
                                    Text="Submit" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RequiredFieldValidator ID="RFVpassword" Display="None" ValidationGroup="Reg"
                                    ControlToValidate="Txtpassword" runat="server" ErrorMessage="Please Enter old Password !"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RFVTxtnpassword" Display="None" ValidationGroup="Reg"
                                    ControlToValidate="Txtnpassword" runat="server" ErrorMessage="Please Enter New Password !"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RFVcpassword" Display="None" ValidationGroup="Reg"
                                    ControlToValidate="Txtcpassword" runat="server" ErrorMessage="Please Enter Confirm Password !"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CVbPassword" runat="server" Display="None" ValidationGroup="Reg"
                                    ErrorMessage="Confirm Password does not match !" ControlToCompare="Txtnpassword"
                                    ControlToValidate="Txtcpassword"></asp:CompareValidator>
                                <asp:RegularExpressionValidator Display="None" ValidationGroup="Reg" ControlToValidate="txtPassword"
                                    ID="RE" ValidationExpression="^[\s\S]{8,12}$" runat="server" ErrorMessage="Password must be 8 to 12 characters."></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator Display="None" ValidationGroup="Reg" ControlToValidate="Txtpassword"
                                    ID="REoldpassword" ValidationExpression="^[\s\S]{8,12}$" runat="server" ErrorMessage="Old Password must be 8 to 12 characters."></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator Display="None" ValidationGroup="Reg" ControlToValidate="Txtnpassword"
                                    ID="REpass" ValidationExpression="^[\s\S]{8,12}$" runat="server" ErrorMessage="New Password must be 8 to 12 characters."></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator Display="None" ValidationGroup="Reg" ControlToValidate="Txtcpassword"
                                    ID="Recpassword" ValidationExpression="^[\s\S]{8,12}$" runat="server" ErrorMessage="Confirm Password must be 8 to 12 characters."></asp:RegularExpressionValidator>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                    ValidationGroup="Reg" ShowSummary="False" />
                                <asp:RegularExpressionValidator Display="None" ValidationGroup="Reg" ControlToValidate="TxtMono"
                                    ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{10,10}$" runat="server"
                                    ErrorMessage="Enter Valid Mobile Number."></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="REMail" Display="None" ValidationGroup="Reg"
                                    ControlToValidate="Txtemail" runat="server" ErrorMessage="Invalid E-Mail id !"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="RECMail" Display="None" ValidationGroup="Reg"
                                    ControlToValidate="Txtcemail" runat="server" ErrorMessage="Invalid Confirm E-Mail id !"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="CVBemail" runat="server" Display="None" ValidationGroup="Reg"
                                    ErrorMessage="Confirm E-Mail id does not match !" ControlToCompare="Txtemail"
                                    ControlToValidate="Txtcemail"></asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="RFVMO" Display="None" ValidationGroup="Reg" ControlToValidate="TxtMono"
                                    runat="server" ErrorMessage="Please Enter Mobile Number !"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="Reemail" Display="None" ValidationGroup="Reg" ControlToValidate="Txtemail"
                                    runat="server" ErrorMessage="Please Enter Email Address !"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="Recemail" Display="None" ValidationGroup="Reg" ControlToValidate="Txtcemail"
                                    runat="server" ErrorMessage="Please Enter Confirm Email Address !"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="Rvstdcode" Display="None" ValidationGroup="Reg" ControlToValidate="Txtstdcode"
                                    runat="server" ErrorMessage="Please Enter Std Code !"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="Rvllno" Display="None" ValidationGroup="Reg" ControlToValidate="TxtLLN"
                                    runat="server" ErrorMessage="Please Enter Landline number !"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="SAN">
                <div class="container">
                    <div align="right">
                        Uttarakhand Board of Technical Education | &#169; All Rights Reserved | 2019
                    </div>
                </div>
            </div>
        </div>
    </center>
    </form>
</body>
</html>

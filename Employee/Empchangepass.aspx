<%@ Page Language="C#" MasterPageFile="~/Employee/Employee.master" AutoEventWireup="true"
    CodeFile="Empchangepass.aspx.cs" Inherits="Empchangepass" Title="Change Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="border: 1px solid #000000; width: 100%; color: #000000; font-family:Cambria;">
        <center>
            <br />
            <p style="font-size: 28px; text-align: left;">
                <i>CHANGE PASSWORD</i></p>
            <br />
            <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="font-family:Cambria; font-size: 12px; width: 556px;" border="0">
                        <tr>
                            <td align="right" style="font-size: 15px;">
                                Old Password<span style="color: #FF0000">*</span>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtpassword" ValidationGroup="Change" Width="200px" Font-Names="Tahoma"
                                    placeholder="Old Password" runat="server" TextMode="Password" MaxLength="12"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="font-size: 15px;">
                                New Password<span style="color: #FF0000">*</span>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtnpassword" ValidationGroup="Change" Width="200px" Font-Names="Tahoma"
                                    placeholder="New Password" runat="server" TextMode="Password" MaxLength="12"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="font-size: 15px;">
                                Confirm Password<span style="color: #FF0000">*</span>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Txtcpassword" ValidationGroup="Change" Width="200px" Font-Names="Tahoma"
                                    placeholder="Confirm Password" runat="server" TextMode="Password" MaxLength="12"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" valign="middle" style="height: 50px; background-color: #BDB76B;
                                border-top-left-radius: 20px; border-top-right-radius: 20px;">
                                <asp:ImageButton ID="ImageButton1" runat="server" Width="30px" Height="30px" Font-Size="16px"
                                    CausesValidation="false" ValidationGroup="Change" OnClick="Button1_Click" ImageUrl="~/Images/Refresh.png" />
                                &nbsp;&nbsp;
                                <asp:Label ID="Label4" ForeColor="#FFFFFF" Style="text-align: center" Font-Size="30px"
                                    runat="server" Height="27px" Width="100px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" style="height: 50px; background-color: #BDB76B; color: #DC143C;
                                border-bottom-left-radius: 20px; border-bottom-right-radius: 20px;">
                                Type the above 6th digit characters in the below Text field.
                                <br />
                                <br />
                                <asp:TextBox ID="TextBox13" CssClass="txtbox" MaxLength="6" Font-Size="16px" runat="server"
                                    placeholder="Enter Text" ValidationGroup="Change" AutoComplete="off" Style="border: #7f9db9 1px solid;"></asp:TextBox>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="ltrlMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Button ID="btnSubmit" CssClass="butn" Font-Bold="true" runat="server" BackColor="#003366"
                                    ValidationGroup="Change" ForeColor="White" Height="35px" OnClick="btnSubmit_Click"
                                    Text="Change" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RequiredFieldValidator ID="RFVpassword" Display="None" ValidationGroup="Change"
                                    ControlToValidate="Txtpassword" runat="server" ErrorMessage="Please Enter Password !"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RFVTxtnpassword" Display="None" ValidationGroup="Change"
                                    ControlToValidate="Txtnpassword" runat="server" ErrorMessage="Please New Enter Password !"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RFVcpassword" Display="None" ValidationGroup="Change"
                                    ControlToValidate="Txtcpassword" runat="server" ErrorMessage="Please Enter Confirm Password !"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CVbPassword" runat="server" Display="None" ValidationGroup="Change"
                                    ErrorMessage="Confirm Password does not match !" ControlToCompare="Txtnpassword"
                                    ControlToValidate="Txtcpassword"></asp:CompareValidator>
                                <asp:RegularExpressionValidator Display="None" ValidationGroup="Change" ControlToValidate="Txtpassword"
                                    ID="REoldpassword" ValidationExpression="^[\s\S]{8,12}$" runat="server" ErrorMessage="Old Password must be 8 to 12 characters."></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator Display="None" ValidationGroup="Change" ControlToValidate="Txtnpassword"
                                    ID="REpass" ValidationExpression="^[\s\S]{8,12}$" runat="server" ErrorMessage="New Password must be 8 to 12 characters."></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator Display="None" ValidationGroup="Change" ControlToValidate="Txtcpassword"
                                    ID="Recpassword" ValidationExpression="^[\s\S]{8,12}$" runat="server" ErrorMessage="Confirm Password must be 8 to 12 characters."></asp:RegularExpressionValidator>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                    ValidationGroup="Change" ShowSummary="False" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>
</asp:Content>

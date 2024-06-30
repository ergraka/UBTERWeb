<%@ Page Language="C#" MasterPageFile="~/Student/Home.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" Title="Change Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <hr />
        <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="95%" cellpadding="4" align="center" style="color: #000000; font-size: 15px;">
                    <tr>
                        <td align="center" colspan="2">
                            <p class="panel-heading" style="background-image: url(../Images/images.jpg); font-family: Agency FB; font-size: 25px; color: #FFFFFF;">
                                <asp:Label ID="Lblcaption" runat="server" Text=" -- CHANGE PASSWORD --"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-lg-6">
                                    Old Password<span style="color: #FF0000">*</span>
                                </div>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="Txtpassword" ValidationGroup="Change" onkeypress="return Password(event)"
                                        onCopy="return false" onCut="return false" onPaste="return false" CssClass="Fontfill"
                                        placeholder="Old Password" runat="server" TextMode="Password" MaxLength="12"></asp:TextBox>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-lg-6">
                                    New Password<span style="color: #FF0000">*</span>
                                </div>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="Txtnpassword" ValidationGroup="Change" CssClass="Fontfill" onkeypress="return Password(event)"
                                        onCopy="return false" onCut="return false" onPaste="return false" placeholder="New Password"
                                        runat="server" TextMode="Password" MaxLength="12"></asp:TextBox>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-lg-6">
                                    Confirm New Password<span style="color: #FF0000">*</span>
                                </div>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="Txtcpassword" ValidationGroup="Change" CssClass="Fontfill" onkeypress="return Password(event)"
                                        onCopy="return false" onCut="return false" onPaste="return false" placeholder="Confirm Password"
                                        runat="server" TextMode="Password" MaxLength="12"></asp:TextBox>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-lg-6">
                                </div>
                                <div class="col-lg-6">
                                    <span style="color: #FF0000">Not Allowed In Password <b style="color: black">&#x27A4;</b> Space,",',~,`,Comma,=</span>
                                    <hr />
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-lg-6">
                                </div>
                                <div class="col-lg-6">
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn-danger" OnClick="btnSubmit_Click"
                                        Text="Update Password" ValidationGroup="Change" />
                                </div>
                                <br />
                                <br />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-lg-6">
                                </div>
                                <div class="col-lg-6">
                                    <asp:Label ID="ltrlMessage" runat="server" ForeColor="#FF0000" Text=""></asp:Label>
                                </div>
                            </div>
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
</asp:Content>

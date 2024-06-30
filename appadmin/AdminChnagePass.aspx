<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="AdminChnagePass.aspx.cs" Inherits="AdminChnagePass" Title="Change Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <div style="width: 90%; color: #000000;">
           <asp:ScriptManager EnableCdn="true" ID="ScriptManager1" runat="server" EnableHistory="false" ></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%" cellpadding="4" align="center">
                        <tr>
                            <td class="linktd" style="color: #FFFF00; font-family: Agency FB; font-size: 22px;
                                background-image: url(../Images/bg.jpg);" align="center" valign="middle">
                                <asp:Label ID="Lblhead" runat="server" Text="- CHANGE PASSWORD -"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Password<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox ID="Txtpassword" ValidationGroup="Login" runat="server" CssClass="Fontfillcaptcha"
                                            AutoComplete="Off" TextMode="Password" MaxLength="12" ToolTip="Old Password" placeholder="Old Password"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        New Password<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox ID="Txtnpassword" ValidationGroup="Login" runat="server" CssClass="Fontfillcaptcha"
                                            AutoComplete="Off" TextMode="Password" MaxLength="12" ToolTip="New Password" placeholder="New Password"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Confirm Password<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox ID="Txtcpassword" ValidationGroup="Login" runat="server" CssClass="Fontfillcaptcha"
                                            AutoComplete="Off" TextMode="Password" MaxLength="12" ToolTip="Confirm Password" placeholder="Confirm Password"></asp:TextBox>
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
                                        <asp:Button ID="btnSubmit" CssClass="btn" Font-Bold="true" runat="server" BackColor="#003366"
                                            ValidationGroup="Change" ForeColor="White" OnClick="btnSubmit_Click" Text="Change" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="ltrlMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label><br />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                    ValidationGroup="Change" ShowSummary="False" />
                                <asp:RequiredFieldValidator ID="RFVpassword" Display="None" ValidationGroup="Change"
                                    ControlToValidate="Txtpassword" runat="server" SetFocusOnError="true" ErrorMessage="Please Enter Password !"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RFVTxtnpassword" Display="None" ValidationGroup="Change"
                                    ControlToValidate="Txtnpassword" runat="server" SetFocusOnError="true" ErrorMessage="Please New Enter Password !"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RFVcpassword" Display="None" ValidationGroup="Change"
                                    ControlToValidate="Txtcpassword" runat="server" SetFocusOnError="true" ErrorMessage="Please Enter Confirm Password !"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CVbPassword" runat="server" Display="None" ValidationGroup="Change"
                                    ErrorMessage="Confirm Password does not match !" ControlToCompare="Txtnpassword"
                                    ControlToValidate="Txtcpassword"></asp:CompareValidator>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </center>
</asp:Content>

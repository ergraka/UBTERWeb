<%@ Page Title="Examiner Registration Form" Language="C#" MasterPageFile="~/Institute/Default.master"
    AutoEventWireup="true" CodeFile="Insaddexaminer.aspx.cs" Inherits="Insaddexaminer" %>

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
                                <p class="panel-heading" style="background-image: url(../Images/bg.jpg); font-family: Agency FB; font-size: 25px; color: #FFFFFF;">
                                    <asp:Label ID="Lblcp" runat="server" Text=" -- ADD EXAMINER --"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Employee Code:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="Txtexcode" ValidationGroup="Reg" CssClass="Fontfill" placeholder="Employee Code"
                                            runat="server" MaxLength="15"></asp:TextBox>
                                        <span style="color: #FF0000; font-size: 12px;">[ Please Enter 4 time Zero (0000), if Don't Know Code ]
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Examiner Name:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="Txtexname" onkeypress="return charsonly(event)" ValidationGroup="Reg" runat="server" placeholder="Examiner Name"
                                            MaxLength="50" CssClass="Fontfill"></asp:TextBox>
                                        <span style="color: #FF0000; font-size: 12px;">[ Please do not use any prefix such as
                                        Mr. or Ms. etc ]
                                        </span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Examiner Designation:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:DropDownList ID="Drpdesig" ValidationGroup="Reg" CssClass="Fontfill" runat="server">
                                            <asp:ListItem Value="0">-Select One-</asp:ListItem>
                                            <asp:ListItem Value="PRI">PRINCIPAL</asp:ListItem>
                                            <asp:ListItem Value="LEC">LECTURER</asp:ListItem>
                                            <asp:ListItem Value="WOR">WORKSHOP INSTRUCTOR</asp:ListItem>
                                            <asp:ListItem Value="HOD">H.O.D</asp:ListItem>
                                            <asp:ListItem Value="PRO">PROGRAMMER</asp:ListItem>
                                            <asp:ListItem Value="ASS">ASST. LECTURER</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>

                                <div class="row">
                                    <div class="col-lg-4">
                                        Select Branch:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:DropDownList ID="Drpbrcode" ValidationGroup="Reg" CssClass="Fontfill" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Institute Name:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:DropDownList ID="Drpins" ValidationGroup="Reg" CssClass="Fontfill" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Employee City:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="Txtcity" onkeypress="return charsonly(event)" ValidationGroup="Reg" runat="server" placeholder="Examiner City"
                                            MaxLength="50" CssClass="Fontfill"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Employee District:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:DropDownList ID="Drpdistrict" ValidationGroup="Reg" CssClass="Fontfill" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Mobile Number :<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="Txtmono" runat="server" MaxLength="10" onkeypress="return numbersonly(event)"
                                            placeholder="Mobile number" ValidationGroup="Reg" CssClass="Fontfill"></asp:TextBox>
                                        <span style="color: #FF0000; font-size: 12px">[ What's App 10 Digit Mobile Number ]</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        E-Mail Address:
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="Txtemail" runat="server" MaxLength="50" placeholder="Enter Valid E-mail ID"
                                            ValidationGroup="Reg" CssClass="Fontfill"></asp:TextBox>
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
                                    <div class="col-lg-8">
                                        <asp:Button ID="Btnadd" ValidationGroup="Reg" CssClass="btn" runat="server" Text="Click to Add"
                                            OnClick="Btnadd_Click" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
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
                                    <div class="col-lg-6">
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Reg"
                                            DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" />
                                        <asp:RequiredFieldValidator ID="Rfvtctxtexcode" runat="server" ControlToValidate="Txtexcode"
                                            Display="None" ErrorMessage="Please Enter Examiner Code." SetFocusOnError="True"
                                            ValidationGroup="Reg"></asp:RequiredFieldValidator>


                                        <asp:RequiredFieldValidator ID="RfvTxtexname" runat="server" ControlToValidate="Txtexname"
                                            Display="None" ErrorMessage="Please Enter Examiner Name." SetFocusOnError="True"
                                            ValidationGroup="Reg"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CvDrpdesig" runat="server" Display="None" ValidationGroup="Reg"
                                            ErrorMessage="Please Select Examiner Designation." ControlToValidate="Drpdesig" ValueToCompare="0"
                                            Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
                                        <asp:RequiredFieldValidator ID="rfvTxtcity" runat="server" ControlToValidate="Txtcity"
                                            Display="None" ErrorMessage="Please Enter Examiner City." SetFocusOnError="True"
                                            ValidationGroup="Reg"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CvDrpdistrict" runat="server" Display="None" ValidationGroup="Reg"
                                            ErrorMessage="Please Select Examiner District." ControlToValidate="Drpdistrict" ValueToCompare="0"
                                            Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
                                        <asp:RequiredFieldValidator ID="RFVMO" Display="None" ValidationGroup="Reg" ControlToValidate="TxtMono"
                                            runat="server" ErrorMessage="Please Enter Mobile Number !"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator Display="None" ValidationGroup="Reg" ControlToValidate="TxtMono"
                                            ID="REMobile" ValidationExpression="^[\s\S]{10,10}$" runat="server" ErrorMessage="Enter Valid Mobile Number."></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RfvTxtemail" runat="server" ControlToValidate="Txtemail"
                                            Display="None" ErrorMessage="Please Enter Email Address." SetFocusOnError="True"
                                            ValidationGroup="Reg"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="REMail" Display="None" ValidationGroup="Reg"
                                            ControlToValidate="Txtemail" runat="server" ErrorMessage="Invalid E-Mail id !"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
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

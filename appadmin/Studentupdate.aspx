<%@ Page Title="Change Student Institute & Branch" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="Studentupdate.aspx.cs" Inherits="Studentupdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <center>
                <div style="width: 95%">
                    <table width="100%" cellpadding="4">
                        <tr>
                            <td align="center" colspan="2">
                                <p class="panel-heading" style="background-image: url(../Images/bg.jpg); font-family: Agency FB;
                                    font-size: 25px; color: #FFFFFF;">
                                    <asp:Label ID="Lblcp" runat="server" Text=" -- Change Student Institute & Branch --"></asp:Label>
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
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Registration Number OR Roll Number:<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox ID="Txtroll" ValidationGroup="Reg" CssClass="Fontfill" Placeholder="Registration Number OR Roll Number"
                                            MaxLength="11" onkeypress="return numbersonly(event)" runat="server"></asp:TextBox>
                                        <asp:Button ID="Btnsearch" CssClass="btn" runat="server" ValidationGroup="Reg" Text="Search"
                                            OnClick="Btnsearch_Click" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" class="panel-heading" style="font-family: Agency FB;
                                background-color: #CD5C5C; font-size: 25px; color: #FFFFFF;">
                                -- Update Details --
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        New Institute Name<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="Drpnins" ValidationGroup="Reg" CssClass="Fontfill" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        New Branch Name<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="Drpnbranch" ValidationGroup="Reg" CssClass="Fontfill" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Semester OR Year<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="Drpsem" ValidationGroup="Reg" CssClass="Fontfill" runat="server">
                                            <asp:ListItem Value="01">01</asp:ListItem>
                                            <asp:ListItem Value="02">02</asp:ListItem>
                                            <asp:ListItem Value="03">03</asp:ListItem>
                                            <asp:ListItem Value="04">04</asp:ListItem>
                                            <asp:ListItem Value="05">05</asp:ListItem>
                                            <asp:ListItem Value="06">06</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        Student Type<span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="Drpregpvt" ValidationGroup="Reg" CssClass="Fontfill" runat="server">
                                            <asp:ListItem Value="R">Regular</asp:ListItem>
                                            <asp:ListItem Value="P">Private</asp:ListItem>
                                            <asp:ListItem Value="Q">Qualified</asp:ListItem>
                                        </asp:DropDownList>
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
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Reg"
                                            DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" />
                                        <asp:CompareValidator ID="CVPDrpins" runat="server" Display="None" ValidationGroup="Reg"
                                            ErrorMessage="Please Select Institute Name." ControlToValidate="Drpins" ValueToCompare="0"
                                            Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
                                        <asp:CompareValidator ID="Cvbranch" runat="server" Display="None" ValidationGroup="Reg"
                                            ErrorMessage="Please Select Branch." ControlToValidate="Drpbranch" ValueToCompare="0"
                                            Operator="NotEqual" SetFocusOnError="True"></asp:CompareValidator>
                                        <asp:RequiredFieldValidator ID="Rfvroll" runat="server" ControlToValidate="Txtroll"
                                            Display="None" ErrorMessage="Please Enter Registration Number Or Roll Number."
                                            SetFocusOnError="True" ValidationGroup="Reg"></asp:RequiredFieldValidator>
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
                                        <asp:CheckBox ID="Chklatefee" Text="Late Fee" runat="server" />
                                        <asp:Button ID="Btnsubmit" CssClass="btn" runat="server" Text="Update" OnClick="Btnsubmit_Click" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:Label ID="LblMessage" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<%@ Page Title="Update Student" Language="C#" MasterPageFile="~/Admin/Admin.master"
    AutoEventWireup="true" CodeFile="Updatestudent.aspx.cs" Inherits="Updatestudent" %>

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
                                    <asp:Label ID="Lblcp" runat="server" Text=" -- Update Student --"></asp:Label>
                                </p>
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
                        <tr runat="server" id="Trchange" visible="false">
                            <td>
                                <div class="row">
                                    <div class="col-lg-4">
                                        <asp:DropDownList ID="Drpclm" ValidationGroup="Reg" AutoPostBack="true" CssClass="Fontfill"
                                            runat="server" OnSelectedIndexChanged="Drpclm_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <span style="color: #FF0000">*</span>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox ID="Txtchange" ValidationGroup="Reg" CssClass="Fontfill" Placeholder="Changes Value"
                                            MaxLength="100" runat="server"></asp:TextBox>
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
